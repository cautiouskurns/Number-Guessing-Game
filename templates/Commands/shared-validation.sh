#!/bin/bash

# Shared Parameter Validation Utilities
# Source this file in workflow commands for consistent validation

# Enhanced Parameter Validation Function
validate_project_parameters() {
    local PARAMS_FILE="$1"
    local COMMAND_TYPE="$2"  # "gdd", "tds", "roadmap", "epics", "features", "tasks"
    
    echo "🔍 Validating project parameters for $COMMAND_TYPE generation..."
    
    # Check if parameters file exists
    if [ ! -f "$PARAMS_FILE" ]; then
        echo "❌ ERROR: project-parameters.yaml not found at $PARAMS_FILE"
        echo "💡 Run 'setup-project-structure' first to create project structure"
        return 1
    fi
    
    # Load key parameters
    PROJECT_NAME=$(grep "PROJECT_NAME:" "$PARAMS_FILE" | cut -d'"' -f2)
    COMPLEXITY_LEVEL=$(grep "COMPLEXITY_LEVEL:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')
    PHASE_COUNT=$(grep -A10 "^$COMPLEXITY_LEVEL:" "$PARAMS_FILE" | grep "phases:" | awk '{print $2}')
    PHASES_CONFIG=$(grep "PHASES:" "$PARAMS_FILE" | sed 's/.*PHASES: \[\(.*\)\].*/\1/' | tr -d '"')
    
    # Validate basic parameter presence
    if [ -z "$PROJECT_NAME" ]; then
        echo "❌ ERROR: PROJECT_NAME not found in parameters file"
        return 1
    fi
    
    if [ -z "$COMPLEXITY_LEVEL" ]; then
        echo "❌ ERROR: COMPLEXITY_LEVEL not found in parameters file"
        return 1
    fi
    
    # Validate parameter consistency
    echo "📋 Project: $PROJECT_NAME"
    echo "🎯 Complexity: $COMPLEXITY_LEVEL"
    echo "📊 Phases: $PHASE_COUNT"
    echo "📝 Phase List: [$PHASES_CONFIG]"
    
    # Complexity validation
    case "$COMPLEXITY_LEVEL" in
        "simple")
            if [ "$PHASE_COUNT" != "1" ]; then
                complexity_mismatch_help "$COMPLEXITY_LEVEL" "1" "$PHASE_COUNT"
                return 1
            fi
            if [[ ! "$PHASES_CONFIG" =~ "Technical MVP" ]] || [[ "$PHASES_CONFIG" =~ "," ]]; then
                echo "❌ ERROR: Simple complexity must have PHASES: [\"Technical MVP\"] only"
                echo "   Found: [$PHASES_CONFIG]"
                return 1
            fi
            ;;
        "intermediate")
            if [ "$PHASE_COUNT" != "3" ]; then
                complexity_mismatch_help "$COMPLEXITY_LEVEL" "3" "$PHASE_COUNT"
                return 1
            fi
            ;;
        "detailed")
            if [ "$PHASE_COUNT" != "4" ]; then
                complexity_mismatch_help "$COMPLEXITY_LEVEL" "4" "$PHASE_COUNT"
                return 1
            fi
            ;;
        *)
            echo "❌ ERROR: Invalid complexity level: $COMPLEXITY_LEVEL"
            echo "   Valid options: simple, intermediate, detailed"
            return 1
            ;;
    esac
    
    # Command-specific validation
    case "$COMMAND_TYPE" in
        "roadmap")
            echo "📑 Roadmap will generate $PHASE_COUNT phases for $COMPLEXITY_LEVEL complexity"
            if [ "$COMPLEXITY_LEVEL" = "simple" ]; then
                echo "✅ Simple roadmap: Technical MVP phase only"
            fi
            ;;
        "tds")
            local EXPECTED_SECTIONS
            case "$COMPLEXITY_LEVEL" in
                "simple") EXPECTED_SECTIONS="4 (Sections 0-3)" ;;
                "intermediate") EXPECTED_SECTIONS="6 (Sections 0-5)" ;;
                "detailed") EXPECTED_SECTIONS="8 (Sections 0-7)" ;;
            esac
            echo "📑 TDS will generate $EXPECTED_SECTIONS"
            ;;
        "gdd")
            echo "📑 GDD will use $COMPLEXITY_LEVEL complexity filtering"
            ;;
        "epics")
            local EPIC_COUNT=$(grep "EPIC_COUNT:" "$PARAMS_FILE" | awk '{print $2}')
            case "$COMPLEXITY_LEVEL" in
                "simple")
                    if [ "$EPIC_COUNT" -lt 2 ] || [ "$EPIC_COUNT" -gt 3 ]; then
                        echo "❌ ERROR: Simple complexity should have 2-3 epics, found $EPIC_COUNT"
                        return 1
                    fi
                    ;;
                "intermediate")
                    if [ "$EPIC_COUNT" -lt 3 ] || [ "$EPIC_COUNT" -gt 5 ]; then
                        echo "❌ ERROR: Intermediate complexity should have 3-5 epics, found $EPIC_COUNT"
                        return 1
                    fi
                    ;;
                "detailed")
                    if [ "$EPIC_COUNT" -lt 5 ] || [ "$EPIC_COUNT" -gt 8 ]; then
                        echo "❌ ERROR: Detailed complexity should have 5-8 epics, found $EPIC_COUNT"
                        return 1
                    fi
                    ;;
            esac
            echo "📑 Epic generation configured for $EPIC_COUNT epics"
            ;;
    esac
    
    echo "✅ Parameter validation passed"
    return 0
}

# Complexity mismatch help function
complexity_mismatch_help() {
    local DETECTED_COMPLEXITY="$1"
    local EXPECTED_PHASES="$2"
    local ACTUAL_PHASES="$3"
    
    echo "
❌ COMPLEXITY MISMATCH DETECTED

🎯 Detected Complexity: $DETECTED_COMPLEXITY
📊 Expected Phases: $EXPECTED_PHASES  
📊 Configured Phases: $ACTUAL_PHASES

🔧 FIX OPTIONS:

Option 1 - Update Complexity Level:
   Edit project-parameters.yaml:
   COMPLEXITY_LEVEL: \"intermediate\"  # for 3 phases
   COMPLEXITY_LEVEL: \"detailed\"      # for 4 phases

Option 2 - Update Phase Configuration:
   Edit project-parameters.yaml:
   PHASES: [\"Technical MVP\"]                                    # for simple
   PHASES: [\"Technical MVP\", \"Vertical Slice\", \"Beta\"]      # for intermediate
   PHASES: [\"Technical MVP\", \"Vertical Slice\", \"Beta\", \"Release\"] # for detailed

Option 3 - Use Complexity Override:
   {COMMAND_NAME} --complexity simple --force
   
💡 Recommendation: Keep it simple for learning projects!
"
}

# Show generation preview and get confirmation
show_generation_preview() {
    local COMMAND_TYPE="$1"
    local PROJECT_NAME="$2"
    local COMPLEXITY_LEVEL="$3"
    local PROJECT_TYPE="$4"
    local ADDITIONAL_INFO="$5"
    
    echo "
================================================================================
🔍 GENERATION PREVIEW - $COMMAND_TYPE
================================================================================

📋 Configuration Detected:
   - Project: $PROJECT_NAME  
   - Complexity: $COMPLEXITY_LEVEL
   - Project Type: $PROJECT_TYPE

📄 Will Generate:
$ADDITIONAL_INFO

❓ Does this match your expectations? (y/N)
"

    if [[ ! "$*" =~ "--auto-confirm" ]]; then
        read -r CONFIRM
        if [ "$CONFIRM" != "y" ] && [ "$CONFIRM" != "Y" ]; then
            echo "❌ Generation cancelled. Please check project-parameters.yaml configuration."
            return 1
        fi
    fi
    
    echo "✅ Starting $COMMAND_TYPE generation..."
    return 0
}

# Load project parameters safely
load_project_parameters() {
    local PARAMS_FILE="$1"
    
    # Export commonly used parameters
    export PROJECT_NAME=$(grep "PROJECT_NAME:" "$PARAMS_FILE" | cut -d'"' -f2)
    export PROJECT_TYPE=$(grep "PROJECT_TYPE:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')
    export COMPLEXITY_LEVEL=$(grep "COMPLEXITY_LEVEL:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')
    export PHASE_COUNT=$(grep -A10 "^$COMPLEXITY_LEVEL:" "$PARAMS_FILE" | grep "phases:" | awk '{print $2}')
    export EPIC_COUNT=$(grep "EPIC_COUNT:" "$PARAMS_FILE" | awk '{print $2}')
    export FEATURES_PER_EPIC=$(grep "FEATURES_PER_EPIC:" "$PARAMS_FILE" | awk '{print $2}')
    export TASKS_PER_FEATURE=$(grep "TASKS_PER_FEATURE:" "$PARAMS_FILE" | awk '{print $2}')
    
    echo "📋 Loaded parameters:"
    echo "   - Project: $PROJECT_NAME"
    echo "   - Complexity: $COMPLEXITY_LEVEL"
    echo "   - Phases: $PHASE_COUNT"
    echo "   - Epics: $EPIC_COUNT"
    echo "   - Features per Epic: $FEATURES_PER_EPIC"
    echo "   - Tasks per Feature: $TASKS_PER_FEATURE"
}

# Validate prerequisite documents exist
validate_prerequisites() {
    local BASE_DIR="$1"
    local PROJECT_NAME="$2"
    local REQUIRED_DOCS="$3"  # space-separated list: "gdd tds roadmap"
    
    echo "🔍 Validating prerequisite documents..."
    
    for DOC_TYPE in $REQUIRED_DOCS; do
        case "$DOC_TYPE" in
            "gdd")
                if [ ! -f "$BASE_DIR/docs/$PROJECT_NAME-GDD.md" ]; then
                    echo "❌ ERROR: GDD not found at $BASE_DIR/docs/$PROJECT_NAME-GDD.md"
                    echo "💡 Run 'generate-game-documents --gdd-only' first"
                    return 1
                fi
                echo "✅ GDD found"
                ;;
            "tds")
                if [ ! -d "$BASE_DIR/docs/TDS" ] || [ -z "$(ls -A "$BASE_DIR/docs/TDS" 2>/dev/null)" ]; then
                    echo "❌ ERROR: TDS sections not found at $BASE_DIR/docs/TDS/"
                    echo "💡 Run 'generate-game-documents --tds-only' first"
                    return 1
                fi
                echo "✅ TDS found"
                ;;
            "roadmap")
                if [ ! -f "$BASE_DIR/docs/$PROJECT_NAME-Roadmap.md" ]; then
                    echo "❌ ERROR: Roadmap not found at $BASE_DIR/docs/$PROJECT_NAME-Roadmap.md"
                    echo "💡 Run 'generate-game-documents --roadmap-only' first"
                    return 1
                fi
                echo "✅ Roadmap found"
                ;;
        esac
    done
    
    echo "✅ All prerequisite documents validated"
    return 0
}