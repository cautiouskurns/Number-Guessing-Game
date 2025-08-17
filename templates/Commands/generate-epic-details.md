# Generate Epic Details Command

## Purpose
Generate comprehensive epic specifications with detailed feature breakdowns directly from the development roadmap. Creates thorough epic documentation combining strategic architecture with technical requirements, user stories, and optional Linear tracking integration for complete project management.

## Prerequisites
- ✅ Project setup complete (setup-game-project command)
- ✅ Development roadmap exists (docs/[PROJECT_NAME]-Roadmap.md)
- ✅ GDD and TDS documents complete
- ✅ project-parameters.yaml configured

## Usage

### Process All Epics (Default)
```bash
# Generate specifications for ALL epics in the roadmap
generate-epic-details

# With Linear issue creation
generate-epic-details --create-linear-issues
```

### Process Specific Epic(s)
```bash
# Single epic
generate-epic-details --epic 1.1

# Multiple specific epics
generate-epic-details --epics 1.1,1.2,2.1

# Epic range within a phase
generate-epic-details --epic-range 1.1-1.3
```

### Process by Phase
```bash
# All epics in Phase 1
generate-epic-details --phase 1

# Multiple phases
generate-epic-details --phases 1,2

# Phase range
generate-epic-details --phase-range 1-3
```

### Advanced Options
```bash
# Dry run - show what would be processed without generating
generate-epic-details --dry-run

# Force regeneration even if files exist
generate-epic-details --force

# Create Linear tracking issues for each epic
generate-epic-details --create-linear-issues

# Custom output directory
generate-epic-details --output-dir ./custom/epics/

# Verbose mode with detailed logging
generate-epic-details --verbose

# Use specific complexity level override
generate-epic-details --complexity detailed
```

## Command Parameters

### Selection Parameters
- `--all` : Process all epics from roadmap (default if no params)
- `--epic <id>` : Process specific epic (e.g., 1.1)
- `--epics <id,id,id>` : Process multiple specific epics
- `--epic-range <start-end>` : Process epic range (e.g., 1.1-1.3)
- `--phase <n>` : Process all epics in phase N
- `--phases <n,n,n>` : Process epics from multiple phases
- `--phase-range <start-end>` : Process phase range

### Processing Options
- `--force` : Regenerate even if epic files exist
- `--dry-run` : Show what would be processed without generating
- `--verbose` : Enable detailed logging
- `--quiet` : Minimal output

### Linear Integration Options
- `--create-linear-issues` : Create Linear tracking issue for each epic
- `--linear-project <name>` : Specify Linear project (default from config)

### Configuration Overrides
- `--complexity <level>` : Override complexity (simple/intermediate/detailed)
- `--features-per-epic <n>` : Override feature count (2-6)
- `--output-dir <path>` : Custom output directory

## Implementation

You are a specialized epic generation assistant. When the user invokes this command, generate detailed epic specifications using comprehensive architectural analysis combined with user story methodology.

### Phase 1: Parameter Loading and Development Ordering Validation

```bash
# Load project parameters and development constraints
PROJECT_NAME={from project-parameters.yaml}
PROJECT_TYPE={from project-parameters.yaml}
BASE_DIRECTORY={from project-parameters.yaml}
COMPLEXITY_LEVEL={from project-parameters.yaml or --complexity flag}
ROADMAP_PATH={BASE_DIRECTORY}/docs/{PROJECT_NAME}-Roadmap.md
GDD_PATH={BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md
TDS_PATH={BASE_DIRECTORY}/docs/TDS/
EPIC_OUTPUT_PATH={BASE_DIRECTORY}/docs/epics/

# Load development constraints and MVP configuration
CURRENT_PHASE={from project-parameters.yaml DEVELOPMENT_CONSTRAINTS.CURRENT_PHASE}
MVP_MODE={from project-parameters.yaml DEVELOPMENT_CONSTRAINTS.MVP_MODE}
PRIORITY_CEILING={from project-parameters.yaml DEVELOPMENT_CONSTRAINTS.PRIORITY_CEILING}
BLOCKED_FEATURES={from project-parameters.yaml DEVELOPMENT_CONSTRAINTS.MVP_BLOCKED_FEATURES}
TAXONOMY_PRIORITIES={from project-parameters.yaml TAXONOMY_PRIORITIES}
DEPENDENCY_RULES={from project-parameters.yaml DEPENDENCY_RULES}

# Load context documents
echo "📚 Loading project context..."
GDD_CONTENT=$(cat "$GDD_PATH")
TDS_CONTENT=$(find "$TDS_PATH" -name "*.md" -exec cat {} \;)
ROADMAP_CONTENT=$(cat "$ROADMAP_PATH")

# Extract available epics from roadmap
AVAILABLE_EPICS=$(grep -o "Epic [0-9]\+\.[0-9]\+" "$ROADMAP_PATH" | sort -u)

# Determine epics to process based on parameters
if [ "$EPIC_PARAM" ]; then
    SELECTED_EPICS="$EPIC_PARAM"
elif [ "$PHASE_PARAM" ]; then
    SELECTED_EPICS=$(echo "$AVAILABLE_EPICS" | grep "^Epic $PHASE_PARAM\.")
else
    SELECTED_EPICS="$AVAILABLE_EPICS"
fi

# 🚨 MVP CONSTRAINT VALIDATION
echo "🔍 Validating epic selection against MVP constraints..."
for epic in $SELECTED_EPICS; do
    EPIC_PRIORITY=$(get_epic_priority "$epic")
    if [ "$MVP_MODE" = "true" ] && [ "$EPIC_PRIORITY" -gt "$PRIORITY_CEILING" ]; then
        echo "❌ BLOCKED: Epic $epic (Priority $EPIC_PRIORITY) exceeds MVP ceiling ($PRIORITY_CEILING)"
        echo "💡 RECOMMENDATION: Complete foundation epics (Priority 0-3) first"
        SELECTED_EPICS=$(echo "$SELECTED_EPICS" | grep -v "$epic")
    fi
done

echo "📋 Validated epics for processing:"
echo "$SELECTED_EPICS"
```

### Phase 2: Integrated Epic Specification Generation

For each epic, generate comprehensive specifications using the integrated methodology:

#### **Epic Analysis and Generation Process with MVP Validation**

```markdown
# For each epic, perform integrated analysis with development ordering validation:

EPIC_ANALYSIS_FRAMEWORK:
  1. 🚨 MVP Constraint Validation:
     - Check epic priority against PRIORITY_CEILING
     - Validate against MVP_BLOCKED_FEATURES list
     - Ensure foundation dependencies are complete
     - Verify current development phase allows this epic
     
  2. Strategic Analysis:
     - Extract epic purpose and value from roadmap
     - Identify player-facing outcomes
     - Analyze dependencies and risks
     
  3. Technical Architecture:
     - Review TDS for technical requirements
     - Identify core systems and patterns
     - Analyze Unity-specific considerations
     - Map features to Unity Game Development Taxonomy
     
  4. Feature Decomposition:
     - Break epic into logical features
     - Ensure feature scope matches complexity level
     - Validate feature dependencies and integration
     - Check taxonomy priority mapping for each feature
     
  5. User Story Integration:
     - Create epic-level user story
     - Generate feature-level user stories
     - Ensure stories align with GDD player experience
```

#### **Comprehensive Epic Specification Template**

```markdown
# **EPIC [X.Y]: [EPIC_NAME]** *([Total Duration])*

> **Generated using Enhanced Epic Generation Framework with MVP Validation**
> **Complexity Level:** {COMPLEXITY_LEVEL}
> **Phase:** {PHASE_NUMBER} - {PHASE_NAME}
> **Development Phase:** {CURRENT_PHASE}
> **MVP Mode:** {MVP_MODE}
> **Priority Level:** {EPIC_PRIORITY} (Ceiling: {PRIORITY_CEILING})
> **Generated:** {DATE}
> 
> 🚨 **MVP CONSTRAINT STATUS**
> {if MVP_MODE and EPIC_PRIORITY > PRIORITY_CEILING}
> ❌ **WARNING**: This epic exceeds MVP priority ceiling
> 💡 **RECOMMENDATION**: Complete foundation epics first
> {else}
> ✅ **APPROVED**: Epic complies with current MVP constraints
> {endif}

## **Epic Overview**

### **Epic Statement (User Story)**
As a **[user type from GDD analysis]**, I want **[high-level capability this epic provides]** so that **[value/benefit achieved from player experience perspective]**.

| Epic Details | Description |
| --- | --- |
| **Priority** | [Critical/High/Medium/Low based on roadmap analysis] |
| **MVP Priority Level** | {EPIC_PRIORITY} (Unity Taxonomy Mapping) |
| **Development Phase** | {CURRENT_PHASE} (foundation/interaction/enhancement/polish) |
| **Risk Level** | [High/Medium/Low based on technical complexity] |
| **Purpose** | [What this epic accomplishes and why it's essential for the game] |
| **Dependencies** | [What must be complete before this epic can begin] |
| **Dependency Validation** | {DEPENDENCY_STATUS} (✅ Met / ❌ Missing / ⚠️ Partial) |
| **Estimated Effort** | [Total hours from roadmap] |

**Playable State After Epic:** [Detailed description of what players can experience after this epic is complete, derived from GDD vision]

**Definition of Done:**
- [ ] [Epic-level acceptance criteria derived from TDS requirements]
- [ ] [Player experience milestone from GDD]
- [ ] [Technical milestone ensuring integration readiness]
- [ ] [Performance/quality gate appropriate for complexity level]
- [ ] [Unity-specific validation criteria]

## **Feature Breakdown**

| Feature | Duration | Prerequisites | Core Purpose |
| --- | --- | --- | --- |
| **[X.Y.1]: [Feature Name]** | [X hours] | [Dependencies from analysis] | [What this feature enables] |
| **[X.Y.2]: [Feature Name]** | [X hours] | [Dependencies from analysis] | [What this feature enables] |
| **[X.Y.3]: [Feature Name]** | [X hours] | [Dependencies from analysis] | [What this feature enables] |

---

## **FEATURE SPECIFICATIONS**

### **FEATURE [X.Y.1]: [FEATURE_NAME]** *([Duration])*

**User Story:** As a **[user type]**, I want **[specific capability]** so that **[specific benefit/value from player perspective]**.

**Purpose:** [What this feature accomplishes and why it matters for the game experience]

**Technical Approach:** [High-level technical strategy based on TDS analysis - key systems, patterns, or Unity features used]

**Core Deliverables:**
- [Primary system/class this feature creates - from architectural analysis]
- [Key Unity components or scene setup required]
- [Integration points with other systems - cross-referenced with TDS]
- [Player-facing assets or UI elements needed]

**Acceptance Criteria:**
- [ ] [Specific player-facing functionality that works]
- [ ] [Technical milestone that can be validated through testing]
- [ ] [Integration checkpoint with other systems]
- [ ] [Performance/quality requirement specific to this feature]
- [ ] [Unity Editor integration or tooling if applicable]

**Technical Implementation Notes:**
```csharp
// High-level code structure example (when helpful for clarity)
public class [FeatureClass] 
{
    // Key methods and properties this feature provides
    // Based on architectural patterns from TDS
}
```

**Feature Dependencies:**
- **Prerequisites:** [Systems that must exist before this feature]
- **Enables:** [What this feature makes possible for other systems]
- **Integration Points:** [Specific connection points with other features]

### **FEATURE [X.Y.2]: [FEATURE_NAME]** *([Duration])*

[Complete specification following same format as Feature 1]

### **FEATURE [X.Y.3]: [FEATURE_NAME]** *([Duration])*

[Complete specification following same format as Features 1 & 2]

---

## **Epic Integration & Architecture**

### **System Architecture**
[How the features in this epic work together - derived from TDS analysis]

**Core Systems:**
- [Primary system 1 and its responsibilities]
- [Primary system 2 and its responsibilities]
- [Integration layer between systems]

**Data Flow:**
[How information moves between features in this epic]

**Event System Integration:**
[How features communicate through events/messaging]

### **Dependencies on Other Epics**
[What this epic requires from other parts of the game - cross-referenced with roadmap]

**Hard Dependencies:**
- [Systems that must be complete before starting this epic]
- [External APIs or frameworks required]

**Soft Dependencies:**
- [Systems that improve this epic but aren't required]
- [Future features that will benefit from this epic]

### **Provides to Other Epics**
[What this epic enables for future development - forward compatibility analysis]

**Public APIs:**
- [Interfaces this epic exposes for other systems]
- [Events this epic broadcasts]

**Shared Systems:**
- [Utilities or components other epics can use]
- [Data structures available project-wide]

### **Unity-Specific Considerations**

**Scene Architecture:**
[How this epic affects scene structure and organization]

**Component Relationships:**
[Key MonoBehaviour relationships and dependencies]

**Asset Pipeline:**
[How this epic integrates with Unity's asset system]

**Platform Considerations:**
[Any platform-specific requirements or optimizations]

### **Quality & Performance Requirements**

**Performance Targets:**
- [Frame rate requirements specific to this epic]
- [Memory usage constraints]
- [Loading time requirements]

**Quality Gates:**
- [Testing requirements before epic completion]
- [Code review standards]
- [Documentation completeness criteria]

**Risk Mitigation:**
- [Technical risks identified and mitigation strategies]
- [Fallback plans for complex features]
- [Integration testing approach]

---

## **Development Strategy**

### **Implementation Sequence**
[Recommended order for developing features within this epic]

1. **Foundation Phase:** [Which features provide the base]
2. **Core Development:** [Main functionality implementation]
3. **Integration Phase:** [Connecting features together]
4. **Polish & Optimization:** [Final quality improvements]

### **Testing Strategy**
[How to validate epic completion and quality]

**Unit Testing:** [Feature-level testing requirements]
**Integration Testing:** [Cross-feature validation approach]
**Player Testing:** [User experience validation methods]

### **Documentation Requirements**
[What documentation this epic must produce]

**Code Documentation:** [API documentation and code comments]
**User Documentation:** [Player-facing help or tutorials]
**Technical Documentation:** [Architecture and integration guides]

---

## **Success Metrics**

### **Player Experience Metrics**
[How to measure if this epic achieves its player value goals]

### **Technical Metrics**
[How to measure technical success and quality]

### **Project Metrics**
[How this epic contributes to overall project success]

---

*Generated using integrated Epic Generation Framework with GDD context, TDS architecture analysis, and complexity-appropriate scoping*
```

### Phase 3: Epic Generation Logic

#### **Integrated Generation Process**

```bash
For each epic in SELECTED_EPICS:
  1. Extract Epic Metadata:
     - Parse epic ID, name, and duration from roadmap
     - Identify phase and priority level
     - Extract high-level description and goals
     
  2. Analyze Project Context:
     - Review GDD for player experience requirements
     - Analyze TDS for technical architecture needs
     - Consider complexity level constraints
     
  3. Feature Decomposition:
     - Break epic into logical feature groupings
     - Ensure features align with complexity constraints:
       * Simple: 2-3 features per epic
       * Intermediate: 3-4 features per epic  
       * Detailed: 4-6 features per epic
     - Validate feature scope and duration
     
  4. Generate User Stories:
     - Create epic-level user story capturing overall value
     - Generate feature-level user stories for specific benefits
     - Ensure stories align with GDD player personas
     
  5. Technical Architecture Analysis:
     - Identify core systems and patterns from TDS
     - Analyze Unity-specific requirements
     - Plan integration points and dependencies
     
  6. Create Comprehensive Specification:
     - Generate epic using integrated template
     - Include all architectural and user story elements
     - Validate against complexity and quality requirements
     
  7. Output and Validation:
     - Save to docs/epics/Epic-{ID}-Specification.md
     - Validate completeness and consistency
     - Report generation success and metrics
```

#### **Quality Assurance Integration**

```bash
# Automatic validation of generated epics
VALIDATION_CHECKS:
  - Epic duration matches roadmap allocation
  - Feature count appropriate for complexity level
  - All required sections present and complete
  - User stories follow proper format
  - Technical approach aligns with TDS
  - Dependencies are valid and achievable
  - Acceptance criteria are measurable
  
# Quality metrics reporting
QUALITY_METRICS:
  - Epic scope complexity assessment
  - Feature balance and distribution
  - Technical risk identification
  - Integration complexity analysis
```

### Phase 4: Linear Integration (Optional)

If `--create-linear-issues` flag is provided:

```bash
For each generated epic:
  Create Linear issue with:
    - Title: "Epic {ID}: {NAME} - {FEATURE_COUNT} Features"
    - Description: Complete epic specification
    - Labels: ["Epic", "Phase-{NUMBER}", complexity level]
    - Project: {from parameters or --linear-project}
    - Milestone: {phase milestone if applicable}
    
  Issue content includes:
    - Epic overview and user story
    - Complete feature breakdown
    - Technical architecture summary
    - Dependencies and integration notes
    - Success metrics and validation criteria
    - Link to epic specification document
```

### Phase 5: Output and Reporting

```bash
# Save epic specifications
For each epic:
  Save to: {EPIC_OUTPUT_PATH}/Epic-{EPIC_ID}-Specification.md
  
# Generate comprehensive summary report
Epic Generation Complete
========================
Duration: {execution_time}
Complexity Level: {COMPLEXITY_LEVEL}

Generated Epics:
  ✅ Epic {ID}: {NAME} ({feature_count} features, {duration} hours)
  {continue for all epics...}

Epic Analysis Summary:
  📊 Total Features: {total_features}
  ⏱️  Total Hours: {total_hours}
  🎯 Success Criteria: {total_criteria}
  📋 Dependencies: {total_dependencies}
  
Feature Distribution by Epic:
  Epic {ID}: {feature_count} features
  {continue for all epics...}

Quality Metrics:
  📈 Epic Scope Balance: {assessment}
  🔗 Dependency Complexity: {assessment}
  ⚡ Technical Risk Level: {assessment}
  🎮 Player Value Alignment: {assessment}

{If Linear issues created:}
Linear Epic Issues Created:
  - {Issue ID}: Epic {ID} - {NAME} ({feature_count} features)
  {continue for all epics...}

Next Steps:
  1. Review generated epic specifications in docs/epics/
  2. Run 'validate-project-structure --epics' for quality validation
  3. Execute 'generate-feature-tasks --all' for detailed task breakdowns
  4. Check project roadmap alignment and dependencies
```

## Examples

### Typical Workflows

#### Complete Epic Development Cycle
```bash
# 1. Generate all epic specifications
generate-epic-details --all --create-linear-issues

# 2. Validate epic quality and compliance
validate-project-structure --epics

# 3. Generate feature task breakdowns
generate-feature-tasks --all

# 4. Create AI implementation prompts
generate-ai-prompts --all
```

#### Iterative Epic Development
```bash
# 1. Work on specific epic
generate-epic-details --epic 1.1 --verbose

# 2. Validate and refine
validate-project-structure --epic 1.1

# 3. Generate tasks for the epic
generate-feature-tasks --epic 1.1

# 4. Continue with next epic
generate-epic-details --epic 1.2
```

## Error Handling

### Common Issues

#### Missing Context Documents
```
ERROR: GDD not found at ./docs/Project-GDD.md
RESOLUTION: Ensure GDD exists and project-parameters.yaml paths are correct
```

#### Invalid Epic Reference
```
ERROR: Epic 1.5 not found in roadmap
AVAILABLE: Epic 1.1, Epic 1.2, Epic 1.3, Epic 1.4
```

#### Insufficient Epic Detail
```
WARNING: Epic 1.2 has minimal description in roadmap
ACTION: Generating with enhanced analysis from available context
RECOMMENDATION: Update roadmap with more epic detail for better results
```

## Integration with Other Commands

### Command Pipeline
```bash
# 1. Project foundation
setup-game-project --project-name="MyGame"

# 2. Epic specifications (this command)
generate-epic-details --all --create-linear-issues

# 3. Feature task breakdowns
generate-feature-tasks --all

# 4. AI implementation prompts
generate-ai-prompts --all
```

### Status Checking
```bash
# Check which epics have specifications
generate-epic-details --status

# Show only incomplete epics
generate-epic-details --status --incomplete
```

## Summary

This enhanced command generates comprehensive epic specifications by integrating strategic planning with technical architecture analysis. It combines user story methodology with Unity-specific technical requirements to create detailed, actionable epic documentation that serves as the foundation for all subsequent feature and task development.

The integrated approach eliminates external template dependencies while providing more thorough epic analysis and specification generation than previous approaches.