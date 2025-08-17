# Validate Project Structure Command

## Purpose
Comprehensive validation system for project structure, ensuring epics, features, tasks, and prompts maintain quality, feasibility, and template compliance. Provides quality assurance across all generated artifacts with detailed reporting and fix suggestions.

## Prerequisites
- ✅ Project structure exists (docs/epics/, docs/tasks/, docs/prompts/)
- ✅ project-parameters.yaml configured
- ✅ Generated artifacts to validate (epics, features, tasks, prompts)

## Usage

### Comprehensive Validation
```bash
# Validate entire project structure
validate-project-structure --all

# Validate with detailed reporting
validate-project-structure --all --verbose

# Validate with fix suggestions
validate-project-structure --all --suggest-fixes

# Interactive validation with guided fixes
validate-project-structure --all --interactive
```

### Level-Specific Validation
```bash
# Validate all epics
validate-project-structure --epics

# Validate all features
validate-project-structure --features

# Validate all tasks
validate-project-structure --tasks

# Validate all AI prompts
validate-project-structure --prompts
```

### Targeted Validation
```bash
# Validate specific epic
validate-project-structure --epic 1.1

# Validate specific feature
validate-project-structure --feature 1.1.1

# Validate specific task
validate-project-structure --task 1.1.1.1

# Validate multiple items
validate-project-structure --features 1.1.1,1.1.2,1.1.3

# Validate epic and all its features/tasks
validate-project-structure --epic 1.1 --cascade
```

### Validation Types
```bash
# Structure and template compliance only
validate-project-structure --all --structural

# Content and feasibility analysis
validate-project-structure --all --content

# Dependency and integration validation
validate-project-structure --all --dependencies

# Cross-reference and consistency checks
validate-project-structure --all --cross-reference

# Full validation (default)
validate-project-structure --all --complete
```

### Output and Reporting
```bash
# Generate validation report
validate-project-structure --all --report-format markdown > validation-report.md

# JSON output for automation
validate-project-structure --all --report-format json > validation-results.json

# Fail fast - stop on first error
validate-project-structure --all --fail-fast

# Show only errors and warnings
validate-project-structure --all --errors-only
```

## Command Parameters

### Selection Parameters
- `--all` : Validate entire project structure
- `--epics` : Validate all epic specifications
- `--features` : Validate all feature task breakdowns
- `--tasks` : Validate all individual task specifications
- `--prompts` : Validate all AI implementation prompts
- `--epic <id>` : Validate specific epic (e.g., 1.1)
- `--feature <id>` : Validate specific feature (e.g., 1.1.1)
- `--task <id>` : Validate specific task (e.g., 1.1.1.1)

### Validation Scope
- `--structural` : Template compliance and format validation
- `--content` : Content quality and feasibility analysis
- `--dependencies` : Dependency chain and integration validation
- `--cross-reference` : Cross-document consistency checking
- `--complete` : Full validation (default)
- `--cascade` : Include all child elements when validating parent

### Output Options
- `--verbose` : Detailed validation output
- `--suggest-fixes` : Provide specific fix recommendations
- `--interactive` : Guided validation with fix prompts
- `--report-format <type>` : Output format (markdown/json/text)
- `--errors-only` : Show only errors and warnings
- `--fail-fast` : Stop validation on first critical error

### Processing Options
- `--fix-mode` : Attempt automatic fixes for common issues
- `--backup` : Create backups before applying fixes
- `--dry-run` : Show what would be validated without executing

## Validation Framework

### 1. Structural Validation

#### **Epic Structure Validation**
```markdown
✅ Epic Specifications Check:
- [ ] Epic-{ID}-Specification.md exists in docs/epics/
- [ ] Contains required header metadata
- [ ] Epic Statement (User Story) present
- [ ] Feature Breakdown table complete
- [ ] Definition of Done criteria defined
- [ ] Technical Implementation Notes present
- [ ] File follows Epic template structure

✅ Epic Content Validation:
- [ ] Epic ID matches filename
- [ ] Duration totals match feature breakdown
- [ ] Dependencies reference valid prerequisites
- [ ] Acceptance criteria are measurable
- [ ] Technical approach is feasible for Unity
```

#### **Feature Structure Validation**
```markdown
✅ Feature Task Breakdown Check:
- [ ] Feature-{ID}-Tasks.md exists in docs/tasks/
- [ ] Contains Feature Overview section
- [ ] Task Breakdown Strategy explained
- [ ] All tasks have taxonomy categorization
- [ ] Dependencies clearly mapped
- [ ] Completion criteria defined

✅ Feature Content Validation:
- [ ] Feature ID matches filename and epic reference
- [ ] Task count appropriate for complexity level
- [ ] Total duration matches epic allocation
- [ ] Task dependencies form valid DAG (no cycles)
- [ ] Observable behaviors are specific and measurable
```

#### **Task Structure Validation**
```markdown
✅ Task Specification Check:
- [ ] All tasks include Observable Behavior section
- [ ] Technical Requirements clearly defined
- [ ] Implementation Steps are actionable
- [ ] Success Criteria use checkbox format
- [ ] Dependencies list prerequisites and blocks
- [ ] Testing Requirements specified

✅ Task Content Validation:
- [ ] Taxonomy category is valid from official list
- [ ] Duration is realistic (15-90 minutes for simple)
- [ ] Prerequisites exist and are completable first
- [ ] Success criteria are measurable and testable
- [ ] Technical requirements are Unity-appropriate
```

#### **Prompt Structure Validation**
```markdown
✅ AI Prompt Check:
- [ ] Task-{ID}-Prompt.md exists in docs/prompts/
- [ ] Follows AI-Task-Level-Prompt.md template
- [ ] Contains Project Knowledge Base section
- [ ] Implementation steps are detailed
- [ ] Success criteria match task specification
- [ ] MCP integration guidance present

✅ Prompt Content Validation:
- [ ] Context references point to existing documents
- [ ] Implementation approach is technically sound
- [ ] Verification steps are executable
- [ ] Dependencies align with task specification
```

### 2. Content and Feasibility Validation

#### **Technical Feasibility Analysis**
```markdown
✅ Unity Implementation Feasibility:
- [ ] All Unity APIs referenced actually exist
- [ ] Component architecture follows Unity patterns
- [ ] Performance targets are achievable
- [ ] Platform constraints considered
- [ ] Asset requirements are realistic

✅ Scope and Complexity Analysis:
- [ ] Task scope appropriate for allocated duration
- [ ] Feature complexity matches project level
- [ ] Implementation approach is viable
- [ ] Required expertise level is reasonable
- [ ] Dependencies don't create impossible sequences
```

#### **Content Quality Assessment**
```markdown
✅ Clarity and Completeness:
- [ ] Observable behaviors are unambiguous
- [ ] Technical requirements are specific
- [ ] Success criteria are binary (pass/fail)
- [ ] Implementation steps are actionable
- [ ] Error conditions are considered

✅ Consistency Analysis:
- [ ] Terminology used consistently across documents
- [ ] Naming conventions followed throughout
- [ ] Cross-references are accurate
- [ ] Version compatibility maintained
```

### 3. Dependency and Integration Validation

#### **Dependency Chain Analysis**
```markdown
✅ Prerequisite Validation:
- [ ] All prerequisite tasks/features exist
- [ ] Prerequisites are completable before dependents
- [ ] Circular dependencies detected and flagged
- [ ] External dependencies are available
- [ ] Dependency depth is reasonable

✅ Integration Point Validation:
- [ ] Cross-feature integration points defined
- [ ] API contracts between systems specified
- [ ] Event system compatibility verified
- [ ] Data flow between components mapped
- [ ] State management integration coherent
```

#### **Timeline and Sequencing Analysis**
```markdown
✅ Timeline Feasibility:
- [ ] Critical path is realistic
- [ ] Parallel work opportunities identified
- [ ] Resource conflicts detected
- [ ] Milestone dependencies verified
- [ ] Buffer time included for integration

✅ Development Sequence Validation:
- [ ] Foundation systems built before dependent features
- [ ] UI components created before UI logic
- [ ] Core systems established before specialized features
- [ ] Testing infrastructure available when needed
```

### 4. Cross-Reference and Consistency Validation

#### **Document Cross-Reference Check**
```markdown
✅ Reference Integrity:
- [ ] Epic references in features are valid
- [ ] Feature references in tasks are valid
- [ ] Task references in prompts are valid
- [ ] File paths in context sections exist
- [ ] External document links are accessible

✅ Data Consistency Validation:
- [ ] Duration totals match across documents
- [ ] Priority assignments are consistent
- [ ] Taxonomy categories match official list
- [ ] Naming conventions uniform throughout
- [ ] Version information synchronized
```

## Validation Rules Database

### Unity Game Development Taxonomy Validation
```yaml
Valid_Taxonomy_Categories:
  1.x_Core_Logic:
    - "1.1 Singleton Patterns"
    - "1.2 Event Systems" 
    - "1.3 State Machines"
    - "1.4 Component Architecture"
    - "1.5 Testing & Debugging"
    - "1.6 Error Handling"
    - "1.7 Input Systems"
    - "1.8 UI Systems"

  2.x_User_Interface:
    - "2.1 UI Components"
    - "2.2 Menu Systems"
    - "2.3 HUD Elements"
    - "2.4 UI Animation"
    - "2.5 Responsive Design"

  # Continue for all taxonomy categories...
```

### Complexity Level Constraints
```yaml
Simple_Project_Constraints:
  tasks_per_feature: 3-5
  max_task_duration: 90 minutes
  total_features: 6-9
  total_tasks: 18-45
  taxonomy_coverage: Core categories only

Intermediate_Project_Constraints:
  tasks_per_feature: 4-7
  max_task_duration: 120 minutes
  total_features: 9-15
  total_tasks: 45-105
  taxonomy_coverage: Core + UI + specialized

Detailed_Project_Constraints:
  tasks_per_feature: 6-10
  max_task_duration: 180 minutes
  total_features: 15-24
  total_tasks: 105-240
  taxonomy_coverage: Full taxonomy utilization
```

### Required Document Sections
```yaml
Epic_Required_Sections:
  - "Epic Overview"
  - "Feature Breakdown"
  - "FEATURE SPECIFICATIONS"
  - "Definition of Done"

Feature_Required_Sections:
  - "FEATURE OVERVIEW"
  - "TASK BREAKDOWN STRATEGY"
  - "CONSTITUENT TASKS"
  - "FEATURE COMPLETION CRITERIA"

Task_Required_Sections:
  - "Observable Behavior"
  - "Technical Requirements"
  - "Implementation Steps"
  - "Success Criteria"
  - "Dependencies"

Prompt_Required_Sections:
  - "Project Knowledge Base"
  - "Task Overview"
  - "Game Context"
  - "Implementation Steps"
  - "Success Criteria"
  - "Unity MCP Implementation"
```

## Error Classification and Reporting

### Critical Errors (Fail Build)
```markdown
🚫 CRITICAL ERRORS:
- Missing required documents
- Circular dependencies detected
- Invalid taxonomy categories
- Impossible dependency chains
- Duration mismatches between levels
- Template structure violations
```

### Warnings (Review Required)
```markdown
⚠️  WARNINGS:
- Unusually long task durations
- Missing optional sections
- Unclear observable behaviors
- Potential integration conflicts
- Performance targets too aggressive
- Limited testing requirements
```

### Suggestions (Best Practices)
```markdown
💡 SUGGESTIONS:
- Consider splitting large tasks
- Add more specific success criteria
- Include error handling considerations
- Enhance testing requirements
- Improve integration documentation
- Add performance considerations
```

## Validation Output Examples

### Successful Validation
```bash
$ validate-project-structure --epic 1.1

🔍 Validating Epic 1.1: Core Game Logic System
=====================================

✅ STRUCTURAL VALIDATION
   ✅ Epic-1.1-Specification.md exists and well-formed
   ✅ All required sections present
   ✅ Feature breakdown table complete
   
✅ CONTENT VALIDATION
   ✅ Duration totals match (50 hours)
   ✅ Dependencies are valid
   ✅ Technical approach feasible
   
✅ FEATURE VALIDATION
   ✅ Feature 1.1.1: 4 tasks, 15 hours ✅
   ✅ Feature 1.1.2: 4 tasks, 20 hours ✅
   ✅ Feature 1.1.3: 4 tasks, 15 hours ✅
   
✅ DEPENDENCY VALIDATION
   ✅ No circular dependencies
   ✅ All prerequisites exist
   ✅ Critical path is viable

🎯 VALIDATION RESULT: PASSED
   - 0 Critical Errors
   - 0 Warnings  
   - 2 Suggestions

💡 SUGGESTIONS:
   - Consider adding error handling tasks in Feature 1.1.2
   - Feature 1.1.3 could benefit from more testing tasks
```

### Validation with Issues
```bash
$ validate-project-structure --feature 1.1.2

🔍 Validating Feature 1.1.2: Input Validation & Processing System
=======================================================

✅ STRUCTURAL VALIDATION
   ✅ Feature-1.1.2-Tasks.md exists and well-formed
   ✅ All required sections present
   
⚠️  CONTENT VALIDATION
   ✅ Duration total matches epic (20 hours)
   🚫 Task 1.1.2.3 depends on non-existent Task 1.1.1.5
   ⚠️  Task 1.1.2.1 duration (8 hours) exceeds simple project limit (90min)
   
⚠️  DEPENDENCY VALIDATION
   🚫 Circular dependency: 1.1.2.2 → 1.1.2.3 → 1.1.2.2
   ✅ All other prerequisites exist

🚫 VALIDATION RESULT: FAILED
   - 2 Critical Errors
   - 1 Warning
   - 0 Suggestions

🔧 SUGGESTED FIXES:
   1. Remove invalid dependency on Task 1.1.1.5
   2. Break Task 1.1.2.1 into smaller tasks (max 90min each)
   3. Resolve circular dependency in tasks 1.1.2.2 ↔ 1.1.2.3

📝 Run with --suggest-fixes to see detailed fix recommendations
```

### Interactive Validation Mode
```bash
$ validate-project-structure --task 1.1.1.1 --interactive

🔍 Validating Task 1.1.1.1: Core NumberGenerator Class Implementation

⚠️  Issue Found: Task duration (6 hours) exceeds simple project limit (90 minutes)

🔧 Suggested Fixes:
1. Split into 2-3 smaller tasks
2. Reduce scope to core functionality only
3. Move advanced features to separate task

Select fix option (1-3) or 's' to skip: 1

✏️  Proposed Task Split:
   - Task 1.1.1.1a: Basic NumberGenerator Class (90 min)
   - Task 1.1.1.1b: Singleton Pattern Implementation (60 min)
   - Task 1.1.1.1c: Interface and Integration (90 min)

Apply this split? (y/n): y

✅ Task split applied successfully
📝 Updated Feature-1.1.1-Tasks.md

Continue validation? (y/n): y
```

## Integration with Other Commands

### Validation in Workflow
```bash
# 1. Generate project structure
generate-epic-details --all
generate-feature-tasks --all
generate-ai-prompts --all

# 2. Validate everything
validate-project-structure --all

# 3. Fix issues and re-validate
validate-project-structure --all --suggest-fixes
validate-project-structure --all --interactive

# 4. Proceed with development
execute-linear AIG-150,AIG-151,AIG-152
```

### Continuous Validation
```bash
# Add validation to git hooks
echo "validate-project-structure --all --fail-fast" > .git/hooks/pre-commit

# Validation as part of CI/CD
validate-project-structure --all --report-format json > validation-results.json
```

## Configuration

### Validation Rules Configuration
Create `.claude/validation-rules.yaml`:
```yaml
validation_rules:
  structural:
    enforce_template_compliance: true
    require_all_sections: true
    check_file_naming: true
    
  content:
    max_task_duration_minutes: 90  # for simple projects
    min_success_criteria_count: 3
    require_observable_behaviors: true
    
  dependencies:
    detect_circular_deps: true
    validate_prerequisites: true
    check_integration_points: true
    
  cross_reference:
    validate_file_paths: true
    check_document_links: true
    verify_taxonomy_categories: true

complexity_overrides:
  simple:
    max_task_duration: 90
    max_tasks_per_feature: 5
  intermediate:
    max_task_duration: 120
    max_tasks_per_feature: 7
  detailed:
    max_task_duration: 180
    max_tasks_per_feature: 10

custom_taxonomy:
  allow_custom_categories: false
  require_official_taxonomy: true
  
fix_suggestions:
  auto_fix_safe_issues: false
  create_backups: true
  interactive_mode_default: true
```

## Best Practices

### When to Run Validation
1. **After generation** - Validate immediately after running generate commands
2. **Before Linear creation** - Ensure quality before creating issues
3. **Pre-development** - Validate before starting implementation
4. **After modifications** - Re-validate when documents are updated
5. **Pre-release** - Final validation before project delivery

### Validation Workflow
1. **Quick Check**: `validate-project-structure --all --errors-only`
2. **Detailed Review**: `validate-project-structure --all --verbose`
3. **Fix Issues**: `validate-project-structure --all --interactive`
4. **Final Validation**: `validate-project-structure --all --complete`

## Summary

This validation command provides comprehensive quality assurance for the entire project structure, ensuring that epics, features, tasks, and prompts maintain high quality, technical feasibility, and template compliance. It serves as a critical quality gate before proceeding with development or Linear issue creation.