# Generate AI Prompts Command

## Purpose
Generate focused, actionable AI implementation prompts for tasks, integrating project context with Unity MCP guidelines. Creates concise, scannable prompts that provide essential context and clear implementation steps while avoiding over-specification of code details.

## Prerequisites
- ✅ Feature task breakdowns complete (generate-feature-tasks command)
- ✅ Epic specifications complete for context integration
- ✅ GDD and TDS documents complete for comprehensive context
- ✅ project-parameters.yaml configured
- ✅ Task specification files exist in docs/tasks/

## Usage

### Process All Tasks (Default)
```bash
# Generate AI prompts for ALL tasks across ALL features
generate-ai-prompts --all

# With Linear issue creation
generate-ai-prompts --all --create-linear-issues
```

### Process Specific Feature(s)
```bash
# Single feature
generate-ai-prompts --feature 1.1.1

# Multiple features
generate-ai-prompts --features 1.1.1,1.1.2,1.1.3

# All features in an epic
generate-ai-prompts --epic 1.1
```

### Process Specific Task(s)
```bash
# Single task
generate-ai-prompts --task 1.1.1.1

# Multiple specific tasks
generate-ai-prompts --tasks 1.1.1.1,1.1.1.2,1.1.2.1
```

### Advanced Options
```bash
# Dry run - show what would be processed without generating
generate-ai-prompts --dry-run

# Force regeneration even if prompt files exist
generate-ai-prompts --force

# Create Linear task issues with embedded prompts
generate-ai-prompts --create-linear-issues

# Custom output directory
generate-ai-prompts --output-dir ./custom/prompts/

# Verbose mode with detailed logging
generate-ai-prompts --verbose

# Use specific complexity level override
generate-ai-prompts --complexity detailed

# Batch size for processing multiple tasks
generate-ai-prompts --batch-size 5

# Enhanced context integration mode
generate-ai-prompts --deep-context

# Include comprehensive MCP fallback strategies
generate-ai-prompts --full-mcp-guidance

# Validate context completeness before generation
generate-ai-prompts --context-validation
```

## Command Parameters

### Selection Parameters
- `--all` : Process all tasks across all features (default if no params)
- `--feature <id>` : Process all tasks in feature (e.g., 1.1.1)
- `--features <id,id,id>` : Process all tasks in multiple features
- `--epic <id>` : Process all tasks in all features of epic
- `--task <id>` : Process specific task (e.g., 1.1.1.1)
- `--tasks <id,id,id>` : Process multiple specific tasks

### Processing Options
- `--force` : Regenerate even if prompt files exist
- `--dry-run` : Show what would be processed without generating
- `--verbose` : Enable detailed logging
- `--quiet` : Minimal output
- `--batch-size <n>` : Process tasks in batches (default 5)
- `--deep-context` : Enhanced context integration with GDD/TDS analysis
- `--full-mcp-guidance` : Include comprehensive MCP fallback strategies
- `--context-validation` : Validate context completeness before generation

### Linear Integration Options
- `--create-linear-issues` : Create Linear task issues with embedded prompts
- `--linear-project <name>` : Specify Linear project (default from config)

### Configuration Overrides
- `--complexity <level>` : Override complexity (simple/intermediate/detailed)
- `--output-dir <path>` : Custom output directory

## Implementation

You are a specialized AI prompt generation assistant with expertise in Unity game development and comprehensive context integration. When the user invokes this command, generate detailed implementation prompts using integrated frameworks that combine task specifications with comprehensive project context from GDD, TDS, and Epic documentation, eliminating external template dependencies while providing significantly enhanced implementation guidance.

### Phase 1: Comprehensive Context Loading and Task Analysis

```bash
# Load project parameters and comprehensive context
PROJECT_NAME={from project-parameters.yaml}
PROJECT_TYPE={from project-parameters.yaml}
BASE_DIRECTORY={from project-parameters.yaml}
COMPLEXITY_LEVEL={from project-parameters.yaml or --complexity flag}
TASK_SPECS_PATH={BASE_DIRECTORY}/docs/tasks/
PROMPT_OUTPUT_PATH={BASE_DIRECTORY}/docs/prompts/
GDD_PATH={BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md
TDS_PATH={BASE_DIRECTORY}/docs/TDS/
EPIC_SPECS_PATH={BASE_DIRECTORY}/docs/epics/
ROADMAP_PATH={BASE_DIRECTORY}/docs/{PROJECT_NAME}-Roadmap.md

echo "📚 Loading comprehensive project context for AI prompt generation..."

# Load all context documents for deep integration
GDD_CONTENT=$(cat "$GDD_PATH")
TDS_CONTENT=$(find "$TDS_PATH" -name "*.md" -exec cat {} \;)
ROADMAP_CONTENT=$(cat "$ROADMAP_PATH")

echo "🎯 Context Sources Loaded:"
echo "   - Game Design Document: Player experience and mechanics"
echo "   - Technical Design Spec: Architecture patterns and Unity requirements"
echo "   - Development Roadmap: Project phases and strategic context"
echo "   - Epic Specifications: Epic-level acceptance criteria and features"
echo "   - Complexity Level: $COMPLEXITY_LEVEL"

# Extract tasks from feature specifications with enhanced context
echo "📋 Analyzing task specifications for comprehensive prompt generation..."
For each selected scope:
  - Load Feature-{ID}-Tasks.md files
  - Parse individual task specifications with detailed metadata
  - Extract task IDs, names, taxonomy categories, observable behaviors
  - Cross-reference with epic specifications for strategic context
  - Analyze technical requirements and Unity-specific patterns
  - Map dependencies and integration points with other systems
  - Note performance constraints and validation requirements
```

### Phase 2: Integrated AI Prompt Generation Framework

For each task, generate comprehensive prompts using the integrated methodology that eliminates external template dependencies:

#### **Comprehensive AI Implementation Prompt Generation**

**Integrated Prompt Generation Process:**
1. **Comprehensive Context Integration**: Combine task specifications with GDD player experience requirements, TDS architectural patterns, and Epic strategic context
2. **Enhanced Task Analysis**: Parse task specifications with deep contextual understanding of Unity patterns and game development requirements
3. **Advanced Template Application**: Generate prompts using integrated template structure with comprehensive implementation guidance
4. **Multi-Layered Validation**: Include extensive validation criteria covering functionality, integration, performance, and quality standards

**🚨 CRITICAL**: Use the COMPLETE integrated template structure that includes:
- **Project Knowledge Base** with comprehensive documentation references and context integration
- **Enhanced Game Context** with GDD alignment and player experience considerations
- **Comprehensive Technical Specifications** with TDS architecture integration
- **Complete MCP Implementation Guidelines** with primary and fallback strategies
- **Advanced Validation and Testing Requirements** with multi-layered quality assurance
- **Comprehensive Dependency Handling** with resilience strategies and fallback behaviors

**Template Features:**
- **Clean Task Overview**: Essential metadata without verbosity
- **Focused Context**: 2-3 sentences explaining task purpose and game alignment  
- **Bullet Requirements**: Scannable technical requirements
- **Clear Outcomes**: Specific "After implementation" expectations
- **Step-by-Step Guide**: Numbered, actionable implementation steps
- **MCP Integration**: Primary MCP approach with fallback options
- **Success Validation**: Essential checkboxes for completion
- **Specific Deliverables**: Exact file paths and expected outputs

**Comprehensive Data Extraction and Context Integration:**

For each task, the system performs advanced context analysis:
```bash
# Extract comprehensive task metadata:
TASK_ID={Extract task identifier like 1.1.1.1}
TASK_NAME={Extract task name from header}
FEATURE_ID={Extract feature ID like 1.1.1}
FEATURE_NAME={Extract feature name from task breakdown}
EPIC_ID={Extract epic ID like 1.1}
EPIC_NAME={Extract epic name from epic specification}
PRIORITY={Extract priority from task specification and epic context}
DURATION={Extract duration hours with complexity validation}
CATEGORY={Extract Unity taxonomy category like "1.4 Component Architecture"}
OBSERVABLE_BEHAVIOR={Extract specific observable outcomes from task spec}
TECHNICAL_REQUIREMENTS={Extract Unity-specific technical requirements}
IMPLEMENTATION_STEPS={Extract actionable implementation steps}
SUCCESS_CRITERIA={Extract measurable success criteria with validation}
DEPENDENCIES={Extract prerequisites and blocking relationships}

# Integrate comprehensive project context:
GDD_CONTEXT={Extract relevant player experience requirements from GDD}
TDS_ARCHITECTURE={Extract relevant architectural patterns from TDS}
EPIC_ACCEPTANCE_CRITERIA={Extract epic-level requirements from epic specification}
PERFORMANCE_CONSTRAINTS={Extract performance requirements from feature and epic specs}
INTEGRATION_POINTS={Extract system integration requirements and APIs}
RISK_FACTORS={Analyze technical and dependency risks}
FALLBACK_STRATEGIES={Define comprehensive fallback approaches}
```

**Integrated Template Application Process:**
1. **Load Integrated Template Structure**: Use comprehensive template framework with all essential components
2. **Apply Advanced Context Integration**: Replace all placeholders with extracted task data plus comprehensive project context
3. **Generate Enhanced Implementation Prompt**: Create detailed, actionable prompt with multiple implementation strategies
4. **Include Comprehensive Validation Framework**: Embed extensive testing and quality assurance criteria
5. **Apply Complexity-Appropriate Scaling**: Adjust detail level based on project complexity configuration
6. **Save Complete Prompt**: Output to `{PROMPT_OUTPUT_PATH}/Task-{TASK_ID}-Prompt.md` with full specifications

#### **Comprehensive Integrated Prompt Generation Framework**

**1. Comprehensive Template Integration**
```markdown
# Complete AI Task Implementation Framework:

PROMPT_GENERATION_METHODOLOGY:
  1. Context-Aware Analysis:
     - Extract task specifications with comprehensive metadata
     - Cross-reference with GDD for player experience alignment
     - Analyze TDS for architectural pattern requirements
     - Consider epic-level acceptance criteria and constraints
     
  2. Enhanced Implementation Planning:
     - Identify Unity-specific patterns and component requirements
     - Plan integration points with existing systems from TDS
     - Assess performance and quality requirements from epic
     - Design comprehensive validation and testing strategies
     
  3. Multi-Strategy Implementation Guidance:
     - Primary MCP-based implementation with full tool utilization
     - Secondary traditional Unity Editor workflow approaches
     - Fallback strategies for missing dependencies or tools
     - Resilience patterns for robust development workflows
     
  4. Comprehensive Quality Assurance Integration:
     - Multi-layered validation covering functionality and integration
     - Performance benchmarking aligned with epic requirements
     - Code quality standards and Unity best practices
     - Comprehensive testing strategies with automated validation
```

**2. Advanced Data Extraction and Context Integration Strategy**
```bash
COMPREHENSIVE_EXTRACTION_PROCESS:
  task_metadata_analysis:
    - Complete task specification parsing with taxonomy integration
    - Priority assessment based on epic dependencies and critical path
    - Duration validation against complexity level constraints
    - Category expertise mapping to Unity development patterns
    
  project_context_integration:
    - GDD player experience requirements and game vision alignment
    - TDS architectural patterns and Unity-specific technical guidance
    - Epic acceptance criteria and strategic milestone requirements
    - Roadmap context and cross-feature dependency considerations
    
  implementation_guidance_generation:
    - Step-by-step implementation plans with Unity best practices
    - MCP tool utilization strategies with comprehensive fallbacks
    - Integration planning with existing systems and components
    - Performance optimization and quality assurance integration
    
  validation_framework_creation:
    - Functional validation with observable behavior verification
    - Integration testing with dependent systems and components
    - Performance benchmarking against epic and feature requirements
    - Code quality validation with Unity standards compliance
```

**3. Complexity-Aware Comprehensive Detail Scaling**
```bash
COMPLEXITY_SCALING_FRAMEWORK:
  simple_complexity:
    implementation_steps: 4-6 focused steps with essential Unity patterns
    mcp_guidance: Core MCP tools with basic fallback strategies
    success_criteria: 6-8 essential checkboxes covering functionality and integration
    context_integration: Essential GDD and TDS alignment with core requirements
    validation_depth: Basic functional and integration testing
    
  intermediate_complexity:
    implementation_steps: 5-7 detailed steps with comprehensive Unity patterns
    mcp_guidance: Extended MCP utilization with robust fallback strategies
    success_criteria: 8-12 comprehensive checkboxes covering quality and performance
    context_integration: Detailed GDD/TDS analysis with epic alignment
    validation_depth: Comprehensive testing including performance validation
    
  detailed_complexity:
    implementation_steps: 6-10 exhaustive steps with advanced Unity techniques
    mcp_guidance: Complete MCP ecosystem utilization with expert fallbacks
    success_criteria: 12-16 extensive checkboxes covering all quality dimensions
    context_integration: Deep GDD/TDS/Epic analysis with cross-system considerations
    validation_depth: Extensive testing including automation and optimization
```

**4. Advanced Unity MCP Integration with Comprehensive Fallbacks**
```bash
MCP_INTEGRATION_STRATEGY:
  primary_mcp_approach:
    - Unity component management: manage_gameobject, manage_script, manage_asset
    - Scene hierarchy setup: manage_scene with comprehensive GameObject organization
    - Development workflow: Unity editor state management and validation
    - Error detection: read_console integration for comprehensive issue identification
    - Linear integration: Workflow automation with comment-based progress tracking
    
  enhanced_fallback_approach:
    - Traditional Unity Editor workflows with detailed step-by-step guidance
    - Editor script creation for team distribution and automation
    - Manual setup procedures with comprehensive validation checkpoints
    - Alternative tool recommendations and integration strategies
    
  resilience_strategies:
    - Dependency handling with stub creation and graceful degradation
    - Error recovery with comprehensive diagnostic and resolution guidance
    - Performance optimization with profiling and benchmarking integration
    - Quality assurance with automated validation and manual verification
```

#### **Streamlined AI Implementation Prompt Template**

```markdown
# Task {TASK_ID}: {TASK_NAME}

You are an expert Unity developer implementing this task for a {PROJECT_TYPE} project.

## 📚 Context

Read these for full context:
- `docs/{PROJECT_NAME}-GDD.md` - Game mechanics and player experience  
- `docs/epics/Epic-{EPIC_ID}-Specification.md` - Epic requirements
- `docs/tasks/Feature-{FEATURE_ID}-Tasks.md` - Task breakdown and dependencies

## 🎯 Task Overview
**ID:** {TASK_ID} | **Priority:** {PRIORITY} | **Duration:** {DURATION}  
**Feature:** {FEATURE_ID} - {FEATURE_NAME} | **Epic:** {EPIC_ID} - {EPIC_NAME}

## 🎮 Game Context

{GDD_CONTEXT_INTEGRATION}

## 📋 Requirements

{TECHNICAL_REQUIREMENTS_BULLETS}

## 🎯 Expected Outcome

After implementation:
- **Visual**: {VISUAL_OUTCOME_FROM_OBSERVABLE_BEHAVIOR}
- **Functional**: {FUNCTIONAL_OUTCOME_FROM_SPEC}
- **Integration**: {INTEGRATION_OUTCOME_FROM_DEPENDENCIES}

## 🔧 Implementation Steps

{IMPLEMENTATION_STEPS_NUMBERED}

## 🏗️ Technical Specification

```csharp
{CLASS_STRUCTURE_FROM_SPEC}
```

**Core Logic:** {CORE_LOGIC_FROM_TECHNICAL_REQUIREMENTS}

**Dependencies:** {DEPENDENCIES_WITH_FALLBACK_STRATEGIES}

## ✅ Success Criteria

{SUCCESS_CRITERIA_CHECKBOXES}
- [ ] No compilation errors
- [ ] Follows Unity best practices
- [ ] Meets GDD requirements

## 🛠️ Unity MCP Implementation

**🚨 VERIFICATION MANDATORY**: After every MCP operation, verify success using Read, LS, read_console tools

**Primary Approach:**
- Use `manage_gameobject` to create GameObjects
- Use `manage_script` to create scripts  
- Use `read_console` to check for errors

**Fallback Approach:**
If MCP unavailable: {FALLBACK_STRATEGY_FROM_SPEC}

**Verification Steps:**
```bash
# After manage_script
Read file_path  # Verify file exists
read_console types:["error", "warning"]  # Check compilation
```

## 📁 Deliverables

{DELIVERABLE_PATHS_AND_DESCRIPTIONS}

## 🧪 Validation

**Functional:** {FUNCTIONAL_VALIDATION_FROM_SPEC}
**Integration:** {INTEGRATION_VALIDATION_FROM_SPEC}  
**Performance:** {PERFORMANCE_VALIDATION_FROM_SPEC}

Execute this implementation now.
```

### Phase 3: Enhanced Linear Integration (Optional)

If `--create-linear-issues` flag is provided:

```bash
For each task with generated prompt:
  1. Read the COMPLETE content from Task-{TASK_ID}-Prompt.md file
  2. Load LINEAR_PROJECT from project-parameters.yaml
  3. Create comprehensive Linear issue with:
    - Title: "TASK {ID}: [{TAXONOMY}] {NAME} - {DURATION}h"
    - Description: EXACT COPY of the complete prompt file content (Task-{TASK_ID}-Prompt.md)
    - Labels: ["Task", "Feature-{FEATURE_ID}", "Epic-{EPIC_ID}", taxonomy category]
    - Project: {LINEAR_PROJECT from parameters or --linear-project override}
    - Team: {LINEAR_TEAM from parameters}
    - Priority: {derived from epic priority and task dependencies}
    
  🚨 CRITICAL: The Linear issue description MUST be IDENTICAL to the prompt file content
  
  Linear Issue Creation Process:
    1. Load complete content: PROMPT_CONTENT = cat Task-{TASK_ID}-Prompt.md
    2. Use PROMPT_CONTENT as Linear issue description without modification
    3. Do NOT summarize, abbreviate, or modify the prompt content
    4. Do NOT add additional content beyond the complete prompt
    5. Ensure the Linear issue contains the full 4-6 page implementation prompt
    
  The result should be that developers can:
    - Open Linear issue AIG-XXX 
    - Copy the complete description
    - Paste directly into AI coding assistant
    - Get identical experience to using the prompt file directly
```

### Phase 4: Comprehensive Output and Advanced Reporting

```bash
# Save comprehensive AI implementation prompts
For each task:
  Save to: {PROMPT_OUTPUT_PATH}/Task-{TASK_ID}-Prompt.md
  Include: Complete implementation prompt with all context integration
  
# Generate comprehensive analysis report
AI Prompt Generation Complete
=============================
Execution Duration: {execution_time}
Complexity Level: {COMPLEXITY_LEVEL}
Context Integration: GDD + TDS + Epic Specifications

Generated Implementation Prompts:
  ✅ Task {ID}: {NAME} ({taxonomy}, {duration}h)
  ✅ Task {ID}: {NAME} ({taxonomy}, {duration}h)
  {continue for all tasks...}

Comprehensive Analysis Summary:
  📊 Total Tasks Processed: {total_tasks}
  📋 Total Features Covered: {total_features}
  ⏱️  Total Development Hours: {total_hours}
  🎯 Success Criteria Defined: {total_criteria}
  🔗 Dependencies Mapped: {total_dependencies}
  🏷️  Taxonomy Categories Used: {unique_categories}

Prompt Distribution by Taxonomy:
  1.x Core Logic & Systems: {count} prompts ({percentage}%)
  2.x User Interface: {count} prompts ({percentage}%)
  3.x Visual & Graphics: {count} prompts ({percentage}%)
  4.x Physics & Movement: {count} prompts ({percentage}%)
  5.x AI & Behaviors: {count} prompts ({percentage}%)
  6.x Data Management: {count} prompts ({percentage}%)
  7.x Validation & Testing: {count} prompts ({percentage}%)
  8.x Platform & Build: {count} prompts ({percentage}%)

Feature Analysis by Epic:
  Epic {ID}: {task_count} tasks, {duration} total hours
  {continue for all epics...}

Quality Metrics Assessment:
  📈 Context Integration Score: {assessment_score}/10
  🔗 Dependency Completeness: {assessment_score}/10 
  ⚡ Implementation Clarity: {assessment_score}/10
  🎮 GDD Alignment Score: {assessment_score}/10
  🏗️  TDS Integration Score: {assessment_score}/10
  📏 Complexity Compliance: {assessment_score}/10

Context Integration Analysis:
  📖 GDD Requirements Integrated: {count} player experience touchpoints
  🏗️  TDS Patterns Applied: {count} architectural patterns
  📋 Epic Dependencies Mapped: {count} strategic alignment points
  🎯 Observable Behaviors Defined: {count} measurable outcomes
  🛠️  MCP Strategies Included: {count} implementation approaches
  🔧 Fallback Strategies Provided: {count} resilience patterns

{If Linear issues created:}
Linear Task Issues Created:
  - {Issue ID}: TASK {ID} - {NAME} ({taxonomy}, {duration}h)
  {continue for all tasks...}

Critical Path Analysis:
  📊 Longest Task: {task_id} ({duration} hours)
  🔗 Most Dependencies: {task_id} ({dependency_count} prerequisites)
  ⚡ Highest Complexity: {task_id} ({complexity_factors})

Implementation Readiness Assessment:
  📋 Prompts Ready for AI Implementation: {ready_count}/{total_count}
  🔧 MCP Integration Coverage: {mcp_coverage_percentage}%
  📖 Context Completeness: {context_completeness_percentage}%
  ✅ Validation Framework Coverage: {validation_coverage_percentage}%

Next Steps:
  1. Review generated implementation prompts in docs/prompts/
  2. Begin task implementation using comprehensive prompts
  3. Follow embedded Unity MCP guidance with fallback strategies
  4. Validate using multi-layered success criteria
  5. Track progress via Linear integration if enabled
  6. Monitor implementation against epic-level acceptance criteria
```

## Examples

### Typical Workflows

#### Complete AI Prompt Development Cycle
```bash
# 1. Generate all task prompts with comprehensive context
generate-ai-prompts --all --create-linear-issues --deep-context

# 2. Validate prompt quality and completeness
validate-project-structure --prompts

# 3. Begin implementation using generated prompts
execute-linear {task-ids}
```

#### Epic-Focused Prompt Generation
```bash
# 1. Generate prompts for specific epic with full context
generate-ai-prompts --epic 1.1 --verbose --deep-context

# 2. Validate epic prompt coherence
validate-project-structure --epic 1.1 --prompts

# 3. Review context integration
generate-ai-prompts --epic 1.1 --context-validation
```

#### Feature-Specific Prompt Development
```bash
# Generate prompts for all tasks in a feature with comprehensive analysis
generate-ai-prompts --feature 1.1.1 --create-linear-issues --full-mcp-guidance
```

#### Iterative Prompt Refinement
```bash
# 1. Regenerate specific tasks with enhanced context
generate-ai-prompts --tasks 1.1.1.1,1.1.1.2 --force --deep-context

# 2. Validate against updated specifications
validate-project-structure --tasks 1.1.1.1,1.1.1.2

# 3. Review implementation readiness
generate-ai-prompts --tasks 1.1.1.1,1.1.1.2 --context-validation
```

#### High-Volume Project Processing
```bash
# Process large projects in optimized batches with full context
generate-ai-prompts --all --batch-size 10 --deep-context --create-linear-issues
```

#### Context Validation and Quality Assurance
```bash
# 1. Generate with comprehensive validation
generate-ai-prompts --all --context-validation --full-mcp-guidance

# 2. Validate implementation readiness
validate-project-structure --prompts --quality-metrics

# 3. Review context integration completeness
generate-ai-prompts --status --context-completeness
```

## Error Handling

### Common Issues and Enhanced Diagnostics

#### Missing Task Specifications
```bash
ERROR: Task specification not found at ./docs/tasks/Feature-1.1.1-Tasks.md
CONTEXT: Cannot generate AI prompts without task breakdown context
RESOLUTION: Run 'generate-feature-tasks --feature 1.1.1' first
VALIDATION: Ensure feature breakdown contains proper task specifications
```

#### Invalid Task Reference
```bash
ERROR: Task 1.1.1.6 not found in Feature 1.1.1 specification
AVAILABLE TASKS: 1.1.1.1, 1.1.1.2, 1.1.1.3, 1.1.1.4, 1.1.1.5
FEATURE CONTEXT: Feature 1.1.1 defines 5 tasks, requested task does not exist
RESOLUTION: Check task specification for correct task numbering
```

#### Insufficient Context Integration
```bash
WARNING: Task 1.1.1.3 has minimal observable behavior description
IMPACT: AI prompt will be generated with reduced implementation guidance
ACTION: Generating with enhanced analysis from available context sources
RECOMMENDATION: Update task specification with more behavioral detail
CONTEXT_SOURCES: Falling back to GDD player requirements and TDS architecture
```

#### Missing Context Documents
```bash
WARNING: GDD context not found for comprehensive prompt generation
IMPACT: Prompts will focus on technical implementation without player context
FALLBACK: Using epic-level context and technical specifications
RECOMMENDATION: Ensure GDD exists at configured path for enhanced context

WARNING: TDS architecture patterns not available for Task 1.2.3
IMPACT: Prompt will use generic Unity patterns instead of project-specific
FALLBACK: Applying standard Unity component architecture guidance
RECOMMENDATION: Update TDS with specific architectural guidance for feature type
```

#### Context Integration Failures
```bash
ERROR: Epic specification not found for context integration
IMPACT: Cannot align task prompts with epic-level acceptance criteria
RESOLUTION: Run 'generate-epic-details --epic {ID}' before generating prompts
VALIDATION: Ensure epic specifications exist for strategic context

WARNING: Performance constraints not specified in task or epic
IMPACT: AI prompts will include generic performance guidance
FALLBACK: Using complexity-level default performance requirements
RECOMMENDATION: Define specific performance targets in epic or feature specs
```

## Output Structure

```
docs/prompts/
├── Task-1.1.1.1-Prompt.md  # Core component implementation with comprehensive context
├── Task-1.1.1.2-Prompt.md  # Debug infrastructure with MCP fallback strategies
├── Task-1.1.1.3-Prompt.md  # Statistical validation with performance requirements
├── Task-1.1.2.1-Prompt.md  # UI integration with GDD alignment
├── Task-1.1.2.2-Prompt.md  # Event system with TDS architecture integration
└── ... (one comprehensive file per task)

Each file contains:
- **Complete Implementation Context**: GDD/TDS/Epic integration with strategic alignment
- **Observable Behaviors**: Detailed measurable outcomes with validation criteria
- **Unity MCP Implementation Guidance**: Primary and fallback strategies with error handling
- **Step-by-Step Implementation Approach**: Complexity-appropriate detail with architectural guidance
- **Dependencies and Integration Notes**: Complete system integration with risk analysis
- **Performance Requirements**: Specific benchmarks with optimization strategies
- **Quality Assurance Framework**: Multi-layered validation with automated testing
- **Epic Alignment Validation**: Strategic context and acceptance criteria integration
- **Resilience Strategies**: Comprehensive error handling and graceful degradation
- **Documentation Standards**: Code quality requirements and Unity best practices
```

## Integration with Other Commands

### Enhanced Command Pipeline
```bash
# 1. Foundation establishment with comprehensive setup
setup-game-project --project-name="MyGame" --complexity detailed

# 2. Epic specifications with strategic context
generate-epic-details --all --create-linear-issues --deep-analysis

# 3. Feature task breakdowns with comprehensive context
generate-feature-tasks --all --create-linear-issues --deep-analysis

# 4. AI prompt generation (this command) with full context integration
generate-ai-prompts --all --create-linear-issues --deep-context --full-mcp-guidance

# 5. Quality validation across all generated content
validate-project-structure --all --prompts

# 6. Begin implementation using comprehensive generated prompts
execute-linear {task-ids-from-linear}
```

### Advanced Status and Quality Checking
```bash
# Comprehensive status with context analysis
generate-ai-prompts --status --quality-metrics --context-completeness

# Show incomplete tasks with missing context analysis
generate-ai-prompts --status --incomplete --missing-context

# Analyze prompt readiness and implementation preparedness
generate-ai-prompts --implementation-readiness --all

# Validate context integration across all prompts
generate-ai-prompts --context-validation --all

# Review MCP integration coverage
generate-ai-prompts --mcp-coverage-analysis --all

# Assess prompt quality metrics
generate-ai-prompts --quality-assessment --taxonomy-distribution
```

## Comprehensive Unity MCP Integration Framework

The command includes extensively enhanced Unity MCP patterns with comprehensive fallback strategies:

### Advanced Core Implementation Patterns
- **Component Architecture**: Sophisticated Unity component setup with MonoBehaviour lifecycle management
- **Scene Hierarchy Management**: Advanced GameObject instantiation with proper parent-child relationships
- **Event System Integration**: Comprehensive Unity Event, C# event, and custom event pattern implementation
- **Error Handling & Resilience**: Robust validation with graceful degradation and comprehensive error recovery
- **Performance Optimization**: Unity-optimized implementation with profiling and benchmarking integration
- **State Management**: Advanced state machine patterns with Unity-specific lifecycle considerations

### Comprehensive MCP Solution Patterns
- **Inspector Integration**: Advanced SerializeField configuration with custom property drawers and validation
- **Prefab Ecosystem**: Complete prefab creation, modification, and instantiation with variant management
- **Animation Systems**: Comprehensive Timeline, Animator, and custom animation system integration
- **UI Architecture**: Advanced Canvas hierarchy, UI element management, and responsive design patterns
- **Audio Management**: Sophisticated AudioSource, AudioClip, and spatial audio integration
- **Asset Pipeline**: Complete asset creation, modification, and optimization workflow integration
- **Platform Optimization**: Cross-platform compatibility with platform-specific optimization strategies

### Advanced MCP Workflow Integration
- **Development Environment**: Comprehensive Unity Editor integration with custom tool creation
- **Testing Framework**: Advanced unit testing, integration testing, and automated validation
- **Build Pipeline**: Complete build configuration and deployment automation
- **Version Control**: Git integration with Unity-specific ignore patterns and merge strategies
- **Linear Integration**: Sophisticated project tracking with automated progress reporting
- **Quality Assurance**: Comprehensive code quality validation with automated review processes

## Advanced Complexity Scaling and Adaptation

The command provides sophisticated scaling based on project complexity with comprehensive context integration:

### Simple Projects (Current Configuration)
- **Implementation Guidance**: 4-6 focused steps with essential Unity patterns
- **MCP Integration**: Core MCP tools with fallback strategies
- **Success Criteria**: 6-8 essential checkboxes covering functionality
- **Context Integration**: Essential GDD alignment and TDS patterns
- **Documentation**: ~2 page prompts with focused, actionable guidance
- **Validation**: Functional testing with Unity validation

### Intermediate Projects
- **Implementation Guidance**: 5-7 detailed steps with comprehensive Unity patterns
- **MCP Integration**: Extended MCP utilization with robust fallback strategies
- **Success Criteria**: 8-12 checkboxes covering quality and integration
- **Context Integration**: Detailed GDD/TDS analysis with epic alignment
- **Documentation**: ~3 page prompts with comprehensive guidance
- **Validation**: Comprehensive testing including performance validation

### Detailed Projects
- **Implementation Guidance**: 6-10 exhaustive steps with advanced Unity techniques
- **MCP Integration**: Complete MCP ecosystem utilization with expert fallbacks
- **Success Criteria**: 12-16 extensive checkboxes covering all quality dimensions
- **Context Integration**: Deep GDD/TDS/Epic analysis with cross-system integration
- **Documentation**: ~4 page prompts with complete implementation guidance
- **Validation**: Extensive testing including automation and performance profiling

## Enhanced Linear Integration (Optional)

If `--create-linear-issues` flag is provided:

```bash
# Create comprehensive Linear task issues with embedded prompts
generate-ai-prompts --all --create-linear-issues --deep-context

# Specify Linear project with enhanced metadata
generate-ai-prompts --all --create-linear-issues --linear-project "GameDev" --full-mcp-guidance

# Create Linear issues with advanced context validation
generate-ai-prompts --epic 1.1 --create-linear-issues --context-validation
```

### Streamlined Issue Creation
The command creates focused Linear issues with:
- **Title**: "TASK {ID}: [{TAXONOMY}] {NAME} - {DURATION}h"
- **Description**: EXACT COPY of the complete Task-{TASK_ID}-Prompt.md file content (~2 pages)
- **Labels**: ["Task", "Feature-{FEATURE_ID}", "Epic-{EPIC_ID}", taxonomy category]
- **Project**: LINEAR_PROJECT from project-parameters.yaml or --linear-project override
- **Team**: LINEAR_TEAM from project-parameters.yaml
- **Priority**: Derived from epic priority and dependencies
- **Estimate**: Duration from task specification

### 🚨 CRITICAL: Content Integration Policy
- **Description Content**: MUST be IDENTICAL to the prompt file - no summaries, no modifications
- **File Source**: Direct copy from `docs/prompts/Task-{TASK_ID}-Prompt.md`
- **Content Size**: Complete implementation prompt (~2 pages)
- **Modification Policy**: Zero modifications - exact file content only
- **Usage Goal**: Developers can copy Linear issue description directly into AI coding assistant

### Issue Content Sections (Included in Full Copy)
- **Implementation Context**: Prompt with GDD/TDS/Epic integration
- **Observable Behaviors**: Measurable outcomes with validation criteria
- **Unity MCP Guidance**: Implementation strategies with fallback approaches
- **Dependencies**: Prerequisite and blocking relationship mapping
- **Integration Points**: System integration requirements
- **Quality Gates**: Validation criteria with testing integration
- **Performance Requirements**: Benchmarks with optimization guidance
- **Documentation Links**: References to relevant project documentation

## Summary

This streamlined command transforms task specifications into focused, actionable AI implementation prompts by integrating essential context sources (GDD, TDS, Epic specifications) with Unity MCP expertise. It provides concise, scannable prompts that balance comprehensive context with actionable clarity.

The methodology ensures prompts are properly contextualized within player experience vision (GDD), technical architecture requirements (TDS), and strategic epic goals, while maintaining Unity best practices and appropriate scoping for efficient AI-assisted implementation. MCP integration provides primary implementation strategies with fallback approaches for reliable development workflows.