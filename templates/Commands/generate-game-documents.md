# Generate Game Documents Command

## Purpose
Generate comprehensive game documentation including Game Design Document (GDD), Technical Design Specification (TDS), and Development Roadmap. Creates the foundational documentation needed before beginning development, with complexity-aware content generation.

## Prerequisites
- ✅ Project structure created (setup-project-structure command)
- ✅ project-parameters.yaml configured with GAME_IDEA
- ✅ Templates available in project or base location

## Usage

### Generate All Documents (Default)
```bash
# Generate GDD, TDS, and Roadmap
generate-game-documents --all

# With Linear issue creation
generate-game-documents --all --create-linear-issues
```

### Generate Specific Documents
```bash
# Generate only GDD
generate-game-documents --gdd-only

# Generate only TDS
generate-game-documents --tds-only

# Generate only Roadmap
generate-game-documents --roadmap-only

# Generate combinations
generate-game-documents --gdd --tds
generate-game-documents --tds --roadmap
```

### Sequential Generation
```bash
# Generate from a specific point onward
generate-game-documents --from gdd    # GDD, TDS, and Roadmap
generate-game-documents --from tds    # TDS and Roadmap only
generate-game-documents --from roadmap # Roadmap only
```

### Advanced Options
```bash
# Force regeneration even if documents exist
generate-game-documents --force

# Dry run to preview what will be generated
generate-game-documents --dry-run

# Pause between document generation for review
generate-game-documents --pause-between-docs

# Use specific complexity override
generate-game-documents --complexity detailed

# Verbose output
generate-game-documents --verbose
```

## Command Parameters

### Selection Parameters
- `--all` : Generate all documents (default if no params)
- `--gdd-only` : Generate only GDD
- `--tds-only` : Generate only TDS (requires GDD to exist)
- `--roadmap-only` : Generate only Roadmap (requires GDD and TDS)
- `--gdd` : Include GDD in generation
- `--tds` : Include TDS in generation
- `--roadmap` : Include Roadmap in generation
- `--from <doc>` : Generate from specified document onward

### Processing Options
- `--force` : Regenerate even if documents exist
- `--dry-run` : Preview what will be generated
- `--pause-between-docs` : Pause for user confirmation between documents
- `--verbose` : Enable detailed logging
- `--quiet` : Minimal output

### Configuration Overrides
- `--complexity <level>` : Override complexity (simple/intermediate/detailed)
- `--project-path <path>` : Override project directory

### Linear Integration Options
- `--create-linear-issues` : Create Linear tracking issues for each document
- `--linear-project <name>` : Specify Linear project

## Implementation

You are a specialized documentation generation assistant. When the user invokes this command, generate comprehensive game documentation using template-based approaches.

### Phase 1: Parameter Loading and Validation

```bash
# Enhanced Parameter Validation Function
validate_project_parameters() {
    local PARAMS_FILE="$1"
    local COMMAND_TYPE="$2"  # "gdd", "tds", "roadmap"
    
    echo "🔍 Validating project parameters..."
    
    # Load key parameters
    PROJECT_NAME=$(grep "PROJECT_NAME:" "$PARAMS_FILE" | cut -d'"' -f2)
    COMPLEXITY_LEVEL=$(grep "COMPLEXITY_LEVEL:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')
    PHASE_COUNT=$(grep -A10 "^$COMPLEXITY_LEVEL:" "$PARAMS_FILE" | grep "phases:" | awk '{print $2}')
    PHASES_CONFIG=$(grep "PHASES:" "$PARAMS_FILE" | sed 's/.*PHASES: \[\(.*\)\].*/\1/' | tr -d '"')
    
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
   generate-game-documents --complexity simple --force
   
💡 Recommendation: Keep it simple for learning projects!
"
}

# Load project parameters
PROJECT_PATH={from --project-path or current directory}
PARAMS_FILE="{PROJECT_PATH}/project-parameters.yaml"

if [ ! -f "$PARAMS_FILE" ]; then
    echo "❌ Error: project-parameters.yaml not found at $PROJECT_PATH"
    echo "💡 Run 'setup-project-structure' first to create project structure"
    exit 1
fi

# Load all parameters from project-specific file
PROJECT_NAME=$(grep "PROJECT_NAME:" "$PARAMS_FILE" | cut -d'"' -f2)
PROJECT_TYPE=$(grep "PROJECT_TYPE:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')
COMPLEXITY_LEVEL=${from --complexity or $(grep "COMPLEXITY_LEVEL:" "$PARAMS_FILE" | awk '{print $2}' | tr -d '"')}
GAME_IDEA=$(grep -A20 "GAME_IDEA:" "$PARAMS_FILE" | sed -n '/|/,/^$/p' | sed '1d;$d')

# Load template paths from parameters file
GDD_TEMPLATE_PATH=$(grep "PROJECT_GDD_TEMPLATE_PATH:" "$PARAMS_FILE" | cut -d'"' -f2 | sed "s/{PROJECT_NAME}/$PROJECT_NAME/g")
TDS_TEMPLATES_PATH=$(grep "PROJECT_TDS_TEMPLATES_PATH:" "$PARAMS_FILE" | cut -d'"' -f2 | sed "s/{PROJECT_NAME}/$PROJECT_NAME/g")
TDS_COMPLEXITY_MAPPING_PATH=$(grep "TDS_COMPLEXITY_MAPPING_PATH:" "$PARAMS_FILE" | cut -d'"' -f2)

# Validate GAME_IDEA exists
if [ -z "$GAME_IDEA" ]; then
    echo "❌ Error: GAME_IDEA not found in project-parameters.yaml"
    echo "💡 Please add your game concept to the GAME_IDEA section in the parameters file"
    exit 1
fi

# Validate GDD template exists
GDD_TEMPLATE_FILE="$GDD_TEMPLATE_PATH/GDD-Development-Template.md"
if [ ! -f "$GDD_TEMPLATE_FILE" ]; then
    echo "❌ Error: GDD template not found at $GDD_TEMPLATE_FILE"
    echo "💡 Please ensure GDD-Development-Template.md exists in the GDD template path"
    exit 1
fi

# Set document paths
GDD_PATH="{PROJECT_PATH}/docs/{PROJECT_NAME}-GDD.md"
TDS_PATH="{PROJECT_PATH}/docs/TDS/"
ROADMAP_PATH="{PROJECT_PATH}/docs/{PROJECT_NAME}-Roadmap.md"

# Determine which documents to generate
GENERATE_GDD=false
GENERATE_TDS=false
GENERATE_ROADMAP=false

if [ "--all" or no selection params ]; then
    GENERATE_GDD=true
    GENERATE_TDS=true
    GENERATE_ROADMAP=true
elif [ "--from gdd" ]; then
    GENERATE_GDD=true
    GENERATE_TDS=true
    GENERATE_ROADMAP=true
elif [ "--from tds" ]; then
    GENERATE_TDS=true
    GENERATE_ROADMAP=true
elif [ "--from roadmap" ]; then
    GENERATE_ROADMAP=true
else
    # Handle individual selections
    if [ "--gdd-only" or "--gdd" ]; then GENERATE_GDD=true; fi
    if [ "--tds-only" or "--tds" ]; then GENERATE_TDS=true; fi
    if [ "--roadmap-only" or "--roadmap" ]; then GENERATE_ROADMAP=true; fi
fi

# Validate parameters for each document type being generated
if [ "$GENERATE_GDD" = true ]; then
    if ! validate_project_parameters "$PARAMS_FILE" "gdd"; then
        exit 1
    fi
fi

if [ "$GENERATE_TDS" = true ]; then
    if ! validate_project_parameters "$PARAMS_FILE" "tds"; then
        exit 1
    fi
fi

if [ "$GENERATE_ROADMAP" = true ]; then
    if ! validate_project_parameters "$PARAMS_FILE" "roadmap"; then
        exit 1
    fi
fi

# Show generation preview and get confirmation
echo "
================================================================================
🔍 GENERATION PREVIEW
================================================================================

📋 Configuration Detected:
   - Project: $PROJECT_NAME  
   - Complexity: $COMPLEXITY_LEVEL
   - Project Type: $PROJECT_TYPE

📄 Will Generate:
$([ "$GENERATE_GDD" = true ] && echo "   ✅ Game Design Document (GDD) - $COMPLEXITY_LEVEL complexity filtering")
$([ "$GENERATE_TDS" = true ] && echo "   ✅ Technical Design Specification (TDS) - $(case "$COMPLEXITY_LEVEL" in "simple") echo "4 sections (0-3)" ;; "intermediate") echo "6 sections (0-5)" ;; "detailed") echo "8 sections (0-7)" ;; esac)")
$([ "$GENERATE_ROADMAP" = true ] && echo "   ✅ Development Roadmap - $(case "$COMPLEXITY_LEVEL" in "simple") echo "1 phase (Technical MVP only)" ;; "intermediate") echo "3 phases" ;; "detailed") echo "4 phases" ;; esac)")

❓ Does this match your expectations? (y/N)
"

if [ "--auto-confirm" not specified ]; then
    read -r CONFIRM
    if [ "$CONFIRM" != "y" ] && [ "$CONFIRM" != "Y" ]; then
        echo "❌ Generation cancelled. Please check project-parameters.yaml configuration."
        exit 1
    fi
fi

echo "✅ Starting document generation..."
```

### Phase 2: GDD Generation

If GENERATE_GDD is true:

#### **Template-Based GDD Generation**

```bash
# Generate GDD using the actual GDD-Development-Template.md
echo "Generating GDD using template: $GDD_TEMPLATE_FILE"
echo "Game Concept: $(echo $GAME_IDEA | head -c 100)..."
echo "Complexity Level: $COMPLEXITY_LEVEL"
echo ""

# Create input context for template processing
cat > "{PROJECT_PATH}/temp_gdd_input.md" << EOF
## Project Parameters
- PROJECT_NAME: {PROJECT_NAME}
- PROJECT_TYPE: {PROJECT_TYPE}
- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
- BASE_DIRECTORY: {PROJECT_PATH}

## Game Concept
{GAME_IDEA}

## Template Instructions
Use the GDD-Development-Template.md to generate a comprehensive Game Design Document.
Apply {COMPLEXITY_LEVEL} complexity level filtering as specified in the template.
Focus on the game concept provided above.
Generate all required sections for {COMPLEXITY_LEVEL} complexity.
EOF

echo "✅ Template context prepared"
echo "📄 Input file: {PROJECT_PATH}/temp_gdd_input.md"
echo "📋 Template: $GDD_TEMPLATE_FILE"
echo "📝 Output: $GDD_PATH"
echo ""
echo "⚠️ IMPORTANT: Use the GDD-Development-Template.md to process the input context"
echo "   and generate the complete GDD at the output path."
echo ""
```

#### **GDD Generation Process**

```bash
# The actual GDD generation should use the template
echo "🔄 Processing GDD template..."
echo ""
echo "Template Processing Required:"
echo "1. Load template: $GDD_TEMPLATE_FILE"
echo "2. Apply input context: temp_gdd_input.md"
echo "3. Process for complexity: $COMPLEXITY_LEVEL"
echo "4. Generate output: $GDD_PATH"
echo ""
echo "⚠️  This requires template processing with the game concept"
echo "   to generate the complete GDD according to your template structure."
echo ""

# After template processing, update status
# sed -i '' 's/GDD_COMPLETE: false/GDD_COMPLETE: true/' "$PARAMS_FILE"

echo "✅ GDD template processing setup complete"
```

### Phase 3: TDS Generation

If GENERATE_TDS is true:

```bash
# Validate GDD exists
if [ ! -f "$GDD_PATH" ]; then
    echo "Error: GDD not found. Generate GDD first."
    exit 1
fi

# Validate TDS templates exist
if [ ! -d "$TDS_TEMPLATES_PATH" ]; then
    echo "Error: TDS templates not found at $TDS_TEMPLATES_PATH"
    exit 1
fi

if [ ! -f "$TDS_COMPLEXITY_MAPPING_PATH" ]; then
    echo "Error: TDS complexity mapping not found at $TDS_COMPLEXITY_MAPPING_PATH"
    exit 1
fi

# Determine TDS sections based on complexity
case "$COMPLEXITY_LEVEL" in
    "simple")
        TDS_SECTIONS="0 1 2 3"
        SECTION_COUNT=4
        ;;
    "intermediate")
        TDS_SECTIONS="0 1 2 3 4 5"
        SECTION_COUNT=6
        ;;
    "detailed")
        TDS_SECTIONS="0 1 2 3 4 5 6 7"
        SECTION_COUNT=8
        ;;
esac

echo "Generating $SECTION_COUNT TDS sections using template system..."
echo "Templates: $TDS_TEMPLATES_PATH"
echo "Complexity Mapping: $TDS_COMPLEXITY_MAPPING_PATH"
echo ""

# Generate each TDS section using templates
for SECTION in $TDS_SECTIONS; do
    SECTION_FILE="{TDS_PATH}/Section$SECTION.md"
    
    case $SECTION in
        0) SECTION_NAME="Design Translation Framework" ;;
        1) SECTION_NAME="System Architecture" ;;
        2) SECTION_NAME="Gameplay Architecture" ;;
        3) SECTION_NAME="Class Design" ;;
        4) SECTION_NAME="Data Architecture" ;;
        5) SECTION_NAME="Unity Specific Architecture" ;;
        6) SECTION_NAME="Platform Technical Architecture" ;;
        7) SECTION_NAME="Asset Specification" ;;
    esac
    
    # Find the template for this section
    TEMPLATE_FILE=$(find "$TDS_TEMPLATES_PATH" -name "$SECTION-*-Prompt.md" | head -1)
    
    if [ -f "$TEMPLATE_FILE" ]; then
        echo "Generating Section $SECTION: $SECTION_NAME"
        echo "  Template: $TEMPLATE_FILE"
        echo "  Output: $SECTION_FILE"
        
        # Template processing setup
        echo "  ⚠️  Template processing required with GDD input and complexity mapping"
    else
        echo "  ⚠️  Template not found for Section $SECTION"
    fi
done

echo ""
echo "✅ TDS template processing setup complete"
echo "⚠️  Each section requires template processing with:"
echo "   - Input GDD: $GDD_PATH"
echo "   - Complexity: $COMPLEXITY_LEVEL"
echo "   - Mapping: $TDS_COMPLEXITY_MAPPING_PATH"
```

### Phase 4: Roadmap Generation

If GENERATE_ROADMAP is true:

#### **Complexity-Aware Roadmap Generation**

```bash
# Load complexity-specific phase configuration
PHASE_COUNT=$(grep -A10 "^$COMPLEXITY_LEVEL:" "$PARAMS_FILE" | grep "phases:" | awk '{print $2}')
PHASES_CONFIG=$(grep "PHASES:" "$PARAMS_FILE" | sed 's/.*PHASES: \[\(.*\)\].*/\1/' | tr -d '"')

echo "📑 Generating roadmap with $PHASE_COUNT phases for $COMPLEXITY_LEVEL complexity"

# Set time estimates based on complexity
case "$COMPLEXITY_LEVEL" in
    "simple")
        TOTAL_TIME="3-4 months (130 hours)"
        PHASE_1_TIME="6 weeks (50 hours)"
        ;;
    "intermediate")
        TOTAL_TIME="6-8 months (300 hours)"
        PHASE_1_TIME="8 weeks (80 hours)"
        PHASE_2_TIME="6 weeks (100 hours)"
        PHASE_3_TIME="8 weeks (120 hours)"
        ;;
    "detailed")
        TOTAL_TIME="12-18 months (600+ hours)"
        PHASE_1_TIME="10 weeks (120 hours)"
        PHASE_2_TIME="8 weeks (150 hours)"
        PHASE_3_TIME="10 weeks (200 hours)"
        PHASE_4_TIME="8 weeks (130 hours)"
        ;;
esac
```

#### **Roadmap Generation Template (Complexity-Filtered)**

```markdown
# {PROJECT_NAME} - Development Roadmap

> **Generated using milestone framework approach**
> **Complexity Level:** {COMPLEXITY_LEVEL}
> **Project Type:** {PROJECT_TYPE}
> **Generated:** {DATE}

---

## Project Summary

**Game Type:** {From GDD analysis}
**Development Time:** {TOTAL_TIME}
**Platform:** {PROJECT_TYPE}
**Key Challenge:** {Identify from concept}

---

## Development Phases

### PHASE 1: TECHNICAL MVP ({PHASE_1_TIME})
**Goal:** Prove core systems work technically - validate concept feasibility
**Validation:** Core mechanics functional and demonstrable
**Playable State:** {Basic interaction description}

**Key Epics:**
- **Epic 1.1:** {Core System 1}
- **Epic 1.2:** {Core System 2}
- **Epic 1.3:** {Core System 3}

{% if COMPLEXITY_LEVEL != "simple" %}
### PHASE 2: VERTICAL SLICE ({PHASE_2_TIME})
**Goal:** Complete one full gameplay loop - prove game is engaging
**Validation:** Full gameplay cycle from start to finish
**Playable State:** {Complete gameplay loop description}

**Key Epics:**
- **Epic 2.1:** {Gameplay System 1}
- **Epic 2.2:** {Gameplay System 2}
- **Epic 2.3:** {Gameplay System 3}

### PHASE 3: PLAYABLE BETA ({PHASE_3_TIME})
**Goal:** All systems integrated - feature complete but rough
**Validation:** All planned features working together
**Playable State:** {Complete game experience description}

**Key Epics:**
- **Epic 3.1:** {Integration Epic 1}
- **Epic 3.2:** {Integration Epic 2}
- **Epic 3.3:** {Integration Epic 3}
{% endif %}

{% if COMPLEXITY_LEVEL == "detailed" %}
### PHASE 4: RELEASE VERSION ({PHASE_4_TIME})
**Goal:** Launch-ready with polish and optimization
**Validation:** Professional quality, zero critical bugs
**Playable State:** {Polished final experience description}

**Key Epics:**
- **Epic 4.1:** {Polish Epic 1}
- **Epic 4.2:** {Polish Epic 2}
- **Epic 4.3:** {Release Epic}
{% endif %}

---

## Milestone Validation

**Technical MVP Success:** {Specific technical criteria}
{% if COMPLEXITY_LEVEL != "simple" %}
**Vertical Slice Success:** {Specific gameplay criteria}
**Playable Beta Success:** {Specific integration criteria}
{% endif %}
{% if COMPLEXITY_LEVEL == "detailed" %}
**Release Ready:** {Specific quality criteria}
{% endif %}

**Critical Path:** {Essential dependency chain}
**Biggest Risk:** {Main development risk and mitigation}

---

{% if COMPLEXITY_LEVEL == "simple" %}
## Simple Complexity Optimizations
- Focus on Technical MVP only - proof of concept completion
- Leverage Unity built-in systems rather than custom frameworks
- Single developer workflow with clear validation gates
- Learning project scope - no commercial polish required

**Next Steps:**
1. Review roadmap feasibility
2. Generate detailed epic specifications
3. Begin Phase 1 development
{% else %}
## Epic Breakdown Summary
- Total Epics: {EPIC_COUNT} across {PHASE_COUNT} phases
- Development Approach: {COMPLEXITY_LEVEL} methodology
- Validation Gates: {MILESTONE_COUNT} major milestones

**Critical Dependencies:** {List key blockers}
**Resource Requirements:** {Team/tool needs}
{% endif %}
```

#### **Roadmap Generation Logic**

```bash
# Validate prerequisites
if [ ! -f "$GDD_PATH" ] || [ ! -d "$TDS_PATH" ]; then
    echo "Error: GDD and TDS required for roadmap generation"
    exit 1
fi

# Find roadmap template
ROADMAP_TEMPLATE="{PROJECT_PATH}/templates/Prompts/High-Level-Milestone-Framework-Generation-Prompt.md"
if [ ! -f "$ROADMAP_TEMPLATE" ]; then
    echo "Warning: Roadmap template not found at $ROADMAP_TEMPLATE"
    echo "Using standard milestone framework approach"
fi

echo "Generating Development Roadmap..."
echo "Input GDD: $GDD_PATH"
echo "Input TDS: $TDS_PATH"
echo "Complexity: $COMPLEXITY_LEVEL"
echo "Output: $ROADMAP_PATH"
echo ""

# Create roadmap input context
cat > "{PROJECT_PATH}/temp_roadmap_input.md" << EOF
## Project Parameters
- PROJECT_NAME: {PROJECT_NAME}
- PROJECT_TYPE: {PROJECT_TYPE}
- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
- BASE_DIRECTORY: {PROJECT_PATH}

## Input Documents
- GDD_PATH: $GDD_PATH
- TDS_PATH: $TDS_PATH

## Required TDS Sections
$(for SECTION in $TDS_SECTIONS; do
  echo "- Section $SECTION: $TDS_PATH/Section$SECTION.md"
done)

## Game Concept
{GAME_IDEA}

## Milestone Framework Requirements
- 4 phases: Technical MVP → Vertical Slice → Playable Beta → Release
- Epic numbering convention (1.1-1.4, 2.1-2.4, etc.)
- Realistic timeline based on $COMPLEXITY_LEVEL complexity level
- Critical path and dependency identification
- Risk assessment with mitigation strategies
EOF

echo "✅ Roadmap input context prepared"
echo "📄 Template: $ROADMAP_TEMPLATE"
echo "📝 Output: $ROADMAP_PATH"
echo ""
echo "⚠️  IMPORTANT: Use the High-Level-Milestone-Framework-Generation-Prompt.md template"
echo "   to process the GDD and TDS inputs and generate the development roadmap"
echo "   following the exact format specified in the template."
```

### Phase 5: Summary and Reporting

```bash
echo "
================================================================================
📚 DOCUMENTATION GENERATION COMPLETE
================================================================================

📁 Project: {PROJECT_NAME}
📂 Location: {PROJECT_PATH}

📄 Documents Generated:
$([ "$GENERATE_GDD" = true ] && echo "   ✅ Game Design Document (GDD)")
$([ "$GENERATE_TDS" = true ] && echo "   ✅ Technical Design Specification ($SECTION_COUNT sections)")
$([ "$GENERATE_ROADMAP" = true ] && echo "   ✅ Development Roadmap (4 phases, $EPIC_COUNT epics)")

📊 Configuration:
   - Complexity: {COMPLEXITY_LEVEL}
   - Project Type: {PROJECT_TYPE}
   - Epic Count: {EPIC_COUNT}

📈 Scope Summary:
   - Development Phases: 4 (MVP → Vertical Slice → Beta → Release)
   - Total Epics: {EPIC_COUNT}
   - Estimated Timeline: {TIMELINE}
   - Documentation Pages: ~{PAGE_COUNT}

✅ Next Steps:
   1. Review generated documentation
   2. Run 'generate-epic-details --all' to detail epics
   3. Run 'generate-feature-tasks --all' to create task breakdowns
   4. Run 'generate-ai-prompts --all' to generate implementation prompts

💡 Quick Commands:
   # Detail all epics from roadmap
   generate-epic-details --all --create-linear-issues
   
   # Or start with Phase 1 epics only
   generate-epic-details --phase 1 --create-linear-issues

================================================================================
"
```

### Linear Integration (Optional)

If `--create-linear-issues` flag is provided:

```bash
# Create Linear issues for each document generated
if [ "$GENERATE_GDD" = true ]; then
    Create Linear issue:
    - Title: "GDD Generation: {PROJECT_NAME}"
    - Description: "Generated Game Design Document"
    - State: "Done"
fi

if [ "$GENERATE_TDS" = true ]; then
    Create Linear issue:
    - Title: "TDS Generation: {PROJECT_NAME}"
    - Description: "Generated {SECTION_COUNT} TDS sections"
    - State: "Done"
fi

if [ "$GENERATE_ROADMAP" = true ]; then
    Create Linear issue:
    - Title: "Roadmap Generation: {PROJECT_NAME}"
    - Description: "Generated development roadmap with {EPIC_COUNT} epics"
    - State: "Done"
fi
```

## Examples

### Generate All Documentation
```bash
generate-game-documents --all
```

### Generate Only GDD
```bash
generate-game-documents --gdd-only
```

### Generate TDS and Roadmap
```bash
generate-game-documents --tds --roadmap
```

### Regenerate with Different Complexity
```bash
generate-game-documents --all --complexity detailed --force
```

### Generate from TDS Onward
```bash
# If GDD already exists and is good
generate-game-documents --from tds
```

## Error Handling

### Common Issues

#### Missing Game Idea
```
ERROR: GAME_IDEA not found in project-parameters.yaml
RESOLUTION: Edit project-parameters.yaml and add your game concept
```

#### Missing Prerequisites
```
ERROR: GDD required for TDS generation
RESOLUTION: Generate GDD first or use --from gdd
```

#### Documents Already Exist
```
WARNING: Documents already exist
ACTION: Use --force to regenerate
```

## Output Structure

```
docs/
├── {PROJECT_NAME}-GDD.md
├── {PROJECT_NAME}-High-Level-Development-Roadmap.md
└── TDS/
    ├── Section0.md (Design Translation)
    ├── Section1.md (System Architecture)
    ├── Section2.md (Gameplay Architecture)
    ├── Section3.md (Class Design)
    ├── Section4.md (Data Architecture)*
    ├── Section5.md (Unity Specific)*
    ├── Section6.md (Platform Technical)**
    └── Section7.md (Asset Specification)**

* Only for intermediate/detailed complexity
** Only for detailed complexity
```

## Integration with Other Commands

### Command Pipeline
```bash
# 1. Create project structure
setup-project-structure --project-name="MyGame"

# 2. Generate documentation (this command)
generate-game-documents --all

# 3. Detail epics
generate-epic-details --all --create-linear-issues

# 4. Create task breakdowns
generate-feature-tasks --all --create-linear-issues

# 5. Generate AI prompts
generate-ai-prompts --all --create-linear-issues
```

## Complexity Scaling

The command automatically adjusts based on project complexity:

### Simple Projects
- GDD: 3-5 pages, 3-4 core systems
- TDS: 4 sections (0-3)
- Roadmap: 8-10 epics total
- Timeline: 3-4 months

### Intermediate Projects
- GDD: 5-8 pages, 5-6 systems
- TDS: 6 sections (0-5)
- Roadmap: 12-14 epics total
- Timeline: 6-8 months

### Detailed Projects
- GDD: 8-12 pages, 7-8 systems
- TDS: 8 sections (0-7)
- Roadmap: 16-20 epics total
- Timeline: 9-12 months

## Summary

This command sets up template-based generation for comprehensive game documentation using your established template system. It properly references your GDD-Development-Template.md, TDS templates, and complexity mapping to ensure documents follow your proven structure and are adjusted to your project's complexity level.