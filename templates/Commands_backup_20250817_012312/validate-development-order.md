# Validate Development Order Command

## Purpose
Validates development sequence compliance against the MVP-focused ordering framework, ensuring proper dependency management and foundation-first development. Provides comprehensive analysis of current project state and recommendations for next development steps.

## Prerequisites
- ✅ project-parameters.yaml configured with development constraints
- ✅ Development ordering framework established
- ✅ Epic and feature specifications exist (if applicable)

## Usage

### Project-Wide Validation
```bash
# Validate entire project development sequence
validate-development-order --scope project

# With detailed analysis
validate-development-order --scope project --detailed

# Include dependency chain analysis
validate-development-order --scope project --show-dependencies
```

### Epic-Specific Validation
```bash
# Validate specific epic against constraints
validate-development-order --epic 1.1

# Validate multiple epics
validate-development-order --epics 1.1,1.2,2.1

# Validate epic with prerequisite analysis
validate-development-order --epic 2.1 --check-prerequisites
```

### Feature-Level Validation
```bash
# Validate specific feature
validate-development-order --feature 1.1.1

# Validate feature dependencies
validate-development-order --feature 3.1.2 --show-blocking-deps

# Batch feature validation
validate-development-order --features 1.1.1,1.1.2,1.2.1
```

### Development Phase Validation
```bash
# Validate current phase completeness
validate-development-order --phase current

# Check readiness for next phase
validate-development-order --phase next --readiness-check

# Validate specific phase transition
validate-development-order --phase-transition foundation-to-interaction
```

## Command Parameters

### Scope Parameters
- `--scope <type>` : Validation scope (project/epic/feature/phase)
- `--epic <id>` : Validate specific epic (e.g., 1.1)
- `--epics <id,id,id>` : Validate multiple epics
- `--feature <id>` : Validate specific feature (e.g., 1.1.1)
- `--features <id,id,id>` : Validate multiple features
- `--phase <type>` : Validate phase (current/next/foundation/interaction/enhancement/polish)

### Analysis Options
- `--detailed` : Comprehensive analysis with recommendations
- `--show-dependencies` : Include dependency chain visualization
- `--check-prerequisites` : Validate prerequisite completion
- `--readiness-check` : Assess readiness for next development step
- `--blocking-only` : Show only blocking issues
- `--warnings-only` : Show only warning-level issues

### Output Options
- `--format <type>` : Output format (table/json/markdown)
- `--export <path>` : Export validation report to file
- `--summary-only` : Show only summary without details
- `--verbose` : Include detailed explanations

## Implementation

You are a specialized development ordering validation assistant. When invoked, perform comprehensive analysis of the current project state against the established MVP-focused development constraints and dependency rules.

### Phase 1: Load Configuration and Context

```bash
# Load project parameters and development constraints
PROJECT_NAME={from project-parameters.yaml}
BASE_DIRECTORY={from project-parameters.yaml}
CURRENT_PHASE={from DEVELOPMENT_CONSTRAINTS.CURRENT_PHASE}
MVP_MODE={from DEVELOPMENT_CONSTRAINTS.MVP_MODE}
PRIORITY_CEILING={from DEVELOPMENT_CONSTRAINTS.PRIORITY_CEILING}
BLOCKED_FEATURES={from DEVELOPMENT_CONSTRAINTS.MVP_BLOCKED_FEATURES}
REQUIRED_FOUNDATIONS={from DEVELOPMENT_CONSTRAINTS.MVP_REQUIRED_FOUNDATIONS}
TAXONOMY_PRIORITIES={from TAXONOMY_PRIORITIES}
DEPENDENCY_RULES={from DEPENDENCY_RULES}

# Load current project state
EPIC_SPECS_PATH={BASE_DIRECTORY}/docs/epics/
EXISTING_EPICS=$(find "$EPIC_SPECS_PATH" -name "Epic-*.md" 2>/dev/null | wc -l)
EXISTING_FEATURES=$(grep -r "FEATURE [0-9]" "$EPIC_SPECS_PATH" 2>/dev/null | wc -l)

echo "🔍 Development Order Validation Report"
echo "======================================"
echo "📊 Current Phase: $CURRENT_PHASE"
echo "🎯 MVP Mode: $MVP_MODE"
echo "📈 Priority Ceiling: $PRIORITY_CEILING"
echo "📋 Existing Epics: $EXISTING_EPICS"
echo "🎮 Existing Features: $EXISTING_FEATURES"
echo ""
```

### Phase 2: Priority Level Distribution Analysis

```bash
# Analyze current priority distribution
echo "📊 Priority Level Distribution Analysis"
echo "======================================="

declare -a PRIORITY_COUNTS
for i in {0..9}; do
    PRIORITY_COUNTS[$i]=0
done

# Count features by priority level
for epic_file in "$EPIC_SPECS_PATH"/*.md; do
    if [ -f "$epic_file" ]; then
        # Extract features and map to taxonomy priorities
        while IFS= read -r feature_line; do
            FEATURE_ID=$(echo "$feature_line" | grep -o "FEATURE [0-9.]*" | cut -d' ' -f2)
            TAXONOMY_CATEGORY=$(get_feature_taxonomy "$FEATURE_ID")
            PRIORITY_LEVEL=$(get_taxonomy_priority "$TAXONOMY_CATEGORY")
            ((PRIORITY_COUNTS[$PRIORITY_LEVEL]++))
        done < <(grep "FEATURE [0-9]" "$epic_file")
    fi
done

# Display priority distribution
for i in {0..9}; do
    count=${PRIORITY_COUNTS[$i]}
    status="✅"
    if [ "$MVP_MODE" = "true" ] && [ "$i" -gt "$PRIORITY_CEILING" ] && [ "$count" -gt 0 ]; then
        status="❌"
    elif [ "$i" -gt "$PRIORITY_CEILING" ] && [ "$count" -gt 0 ]; then
        status="⚠️"
    fi
    
    echo "  Level $i: $count features $status"
done

echo ""
```

### Phase 3: Dependency Validation

```bash
# Validate dependency rules
echo "🔗 Dependency Validation Analysis"
echo "================================="

BLOCKING_VIOLATIONS=0
WARNING_VIOLATIONS=0

# Check blocking dependencies
echo "🚨 Blocking Dependency Checks:"
for rule in "${DEPENDENCY_RULES.BLOCKING_DEPENDENCIES[@]}"; do
    RULE_NAME=$(echo "$rule" | jq -r '.rule')
    CONSTRAINT=$(echo "$rule" | jq -r '.constraint')
    ERROR_MSG=$(echo "$rule" | jq -r '.error_message')
    
    # Evaluate constraint logic
    VIOLATION=$(evaluate_constraint "$CONSTRAINT")
    
    if [ "$VIOLATION" = "true" ]; then
        echo "  ❌ VIOLATION: $RULE_NAME"
        echo "     → $ERROR_MSG"
        ((BLOCKING_VIOLATIONS++))
    else
        echo "  ✅ COMPLIANT: $RULE_NAME"
    fi
done

# Check warning dependencies
echo ""
echo "⚠️  Warning Dependency Checks:"
for rule in "${DEPENDENCY_RULES.WARNING_DEPENDENCIES[@]}"; do
    RULE_NAME=$(echo "$rule" | jq -r '.rule')
    CONSTRAINT=$(echo "$rule" | jq -r '.constraint')
    WARNING_MSG=$(echo "$rule" | jq -r '.warning_message')
    
    VIOLATION=$(evaluate_constraint "$CONSTRAINT")
    
    if [ "$VIOLATION" = "true" ]; then
        echo "  ⚠️  WARNING: $RULE_NAME"
        echo "     → $WARNING_MSG"
        ((WARNING_VIOLATIONS++))
    else
        echo "  ✅ OPTIMAL: $RULE_NAME"
    fi
done

echo ""
```

### Phase 4: MVP Constraint Analysis

```bash
# Validate MVP constraints
echo "🎯 MVP Constraint Analysis"
echo "========================="

MVP_VIOLATIONS=0

# Check priority ceiling compliance
if [ "$MVP_MODE" = "true" ]; then
    echo "🚨 MVP Mode Active - Validating Constraints:"
    
    # Check for features exceeding priority ceiling
    HIGH_PRIORITY_COUNT=0
    for i in $(seq $((PRIORITY_CEILING + 1)) 9); do
        HIGH_PRIORITY_COUNT=$((HIGH_PRIORITY_COUNT + PRIORITY_COUNTS[$i]))
    done
    
    if [ "$HIGH_PRIORITY_COUNT" -gt 0 ]; then
        echo "  ❌ VIOLATION: $HIGH_PRIORITY_COUNT features exceed priority ceiling ($PRIORITY_CEILING)"
        echo "     → Move high-priority features to later development phases"
        ((MVP_VIOLATIONS++))
    else
        echo "  ✅ COMPLIANT: All features within priority ceiling"
    fi
    
    # Check for blocked feature types
    echo ""
    echo "🚫 Blocked Feature Analysis:"
    for blocked_feature in "${BLOCKED_FEATURES[@]}"; do
        FOUND_BLOCKED=$(grep -r -i "$blocked_feature" "$EPIC_SPECS_PATH" 2>/dev/null | wc -l)
        if [ "$FOUND_BLOCKED" -gt 0 ]; then
            echo "  ❌ VIOLATION: Found $FOUND_BLOCKED instances of blocked feature: $blocked_feature"
            ((MVP_VIOLATIONS++))
        else
            echo "  ✅ CLEAN: No blocked features found: $blocked_feature"
        fi
    done
    
    # Check foundation requirements
    echo ""
    echo "🏗️  Foundation Requirements Analysis:"
    for foundation in "${REQUIRED_FOUNDATIONS[@]}"; do
        FOUNDATION_STATUS=$(check_foundation_completion "$foundation")
        if [ "$FOUNDATION_STATUS" = "incomplete" ]; then
            echo "  ❌ MISSING: $foundation"
            ((MVP_VIOLATIONS++))
        else
            echo "  ✅ COMPLETE: $foundation"
        fi
    done
else
    echo "ℹ️  MVP Mode disabled - skipping MVP constraint validation"
fi

echo ""
```

### Phase 5: Development Phase Assessment

```bash
# Assess current development phase
echo "📈 Development Phase Assessment"
echo "==============================="

echo "Current Phase: $CURRENT_PHASE"

case "$CURRENT_PHASE" in
    "foundation")
        echo "🏗️  Foundation Phase Analysis:"
        check_foundation_phase_requirements
        ;;
    "interaction")
        echo "🎮 Interaction Phase Analysis:"
        check_interaction_phase_requirements
        ;;
    "enhancement")
        echo "✨ Enhancement Phase Analysis:"
        check_enhancement_phase_requirements
        ;;
    "polish")
        echo "🎨 Polish Phase Analysis:"
        check_polish_phase_requirements
        ;;
    *)
        echo "❓ Unknown phase: $CURRENT_PHASE"
        ;;
esac

echo ""
```

### Phase 6: Recommendations and Next Steps

```bash
# Generate recommendations
echo "💡 Recommendations and Next Steps"
echo "================================="

TOTAL_VIOLATIONS=$((BLOCKING_VIOLATIONS + MVP_VIOLATIONS))

if [ "$TOTAL_VIOLATIONS" -eq 0 ]; then
    echo "🎉 EXCELLENT: Development order is compliant with all constraints!"
    echo ""
    echo "🚀 Recommended Next Steps:"
    generate_next_step_recommendations
else
    echo "⚠️  ISSUES FOUND: $TOTAL_VIOLATIONS constraint violations detected"
    echo ""
    echo "🔧 Required Actions:"
    
    if [ "$BLOCKING_VIOLATIONS" -gt 0 ]; then
        echo "  🚨 CRITICAL: $BLOCKING_VIOLATIONS blocking dependency violations"
        echo "     → These MUST be resolved before continuing development"
    fi
    
    if [ "$MVP_VIOLATIONS" -gt 0 ]; then
        echo "  🎯 MVP: $MVP_VIOLATIONS MVP constraint violations"
        echo "     → Consider deferring features or completing foundations first"
    fi
    
    if [ "$WARNING_VIOLATIONS" -gt 0 ]; then
        echo "  ⚠️  OPTIMIZE: $WARNING_VIOLATIONS optimization opportunities"
        echo "     → Address these for better development flow"
    fi
fi

echo ""
echo "📊 Validation Summary:"
echo "  ✅ Compliant Features: $((EXISTING_FEATURES - TOTAL_VIOLATIONS))"
echo "  ❌ Violations Found: $TOTAL_VIOLATIONS"
echo "  📈 Current Phase Progress: $(calculate_phase_progress)%"
echo "  🎯 MVP Readiness: $(calculate_mvp_readiness)"

echo ""
echo "Generated: $(date)"
echo "Report saved to: ./validation-report-$(date +%Y%m%d).md"
```

## Helper Functions

### Constraint Evaluation
```bash
evaluate_constraint() {
    local constraint="$1"
    # Parse and evaluate constraint logic
    # Example: "taxonomy:2.* requires taxonomy:1.1,1.2,1.3,1.4"
    # Returns "true" if violation exists, "false" if compliant
}

get_taxonomy_priority() {
    local taxonomy="$1"
    # Map taxonomy category to priority level using TAXONOMY_PRIORITIES
    echo "${TAXONOMY_PRIORITIES[$taxonomy]:-9}"
}

check_foundation_completion() {
    local foundation="$1"
    # Check if foundation requirement is complete
    # Returns "complete" or "incomplete"
}

generate_next_step_recommendations() {
    # Analyze current state and suggest next development actions
    echo "  1. Complete remaining foundation features (Priority 0-1)"
    echo "  2. Implement core interaction systems (Priority 2-3)"
    echo "  3. Add basic user interface elements"
    echo "  4. Establish testing and debugging infrastructure"
}
```

## Example Output

```
🔍 Development Order Validation Report
======================================
📊 Current Phase: foundation
🎯 MVP Mode: true
📈 Priority Ceiling: 3
📋 Existing Epics: 2
🎮 Existing Features: 6

📊 Priority Level Distribution Analysis
=======================================
  Level 0: 2 features ✅
  Level 1: 3 features ✅
  Level 2: 1 features ✅
  Level 3: 0 features ✅
  Level 4: 0 features ✅
  Level 5: 0 features ✅
  Level 6: 0 features ✅
  Level 7: 0 features ✅
  Level 8: 0 features ✅
  Level 9: 0 features ✅

🔗 Dependency Validation Analysis
=================================
🚨 Blocking Dependency Checks:
  ✅ COMPLIANT: No UI features before core logic exists
  ✅ COMPLIANT: No visual effects before basic UI exists
  ✅ COMPLIANT: No advanced features before MVP foundation

⚠️  Warning Dependency Checks:
  ✅ OPTIMAL: Testing should accompany core features
  ✅ OPTIMAL: Performance optimization should follow functionality

🎯 MVP Constraint Analysis
=========================
🚨 MVP Mode Active - Validating Constraints:
  ✅ COMPLIANT: All features within priority ceiling

🚫 Blocked Feature Analysis:
  ✅ CLEAN: No blocked features found: Complex animations and visual effects
  ✅ CLEAN: No blocked features found: Particle systems and shaders
  ✅ CLEAN: No blocked features found: Advanced audio systems and music

🏗️  Foundation Requirements Analysis:
  ✅ COMPLETE: Core game logic and mechanics complete
  ✅ COMPLETE: Basic debugging and logging infrastructure
  ✅ COMPLETE: Statistical validation systems operational
  ❌ MISSING: Unit testing framework established
  ❌ MISSING: Basic user input and interaction working

💡 Recommendations and Next Steps
=================================
⚠️  ISSUES FOUND: 2 constraint violations detected

🔧 Required Actions:
  🎯 MVP: 2 MVP constraint violations
     → Consider deferring features or completing foundations first

📊 Validation Summary:
  ✅ Compliant Features: 4
  ❌ Violations Found: 2
  📈 Current Phase Progress: 67%
  🎯 MVP Readiness: Foundation Incomplete

Generated: 2024-01-15 14:30:00
Report saved to: ./validation-report-20240115.md
```

## Integration with Other Commands

### Command Pipeline
```bash
# 1. Validate before epic generation
validate-development-order --scope project

# 2. Generate compliant epics
generate-epic-details --all

# 3. Validate after epic creation
validate-development-order --scope project --detailed

# 4. Continue with feature tasks if compliant
generate-feature-tasks --all
```

## Summary

This command provides comprehensive validation of development sequence compliance, ensuring MVP-focused development and proper dependency management. It identifies violations, provides actionable recommendations, and guides the development team toward foundation-first implementation strategies.