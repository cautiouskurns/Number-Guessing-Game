# Setup Game Project Pipeline

Automates the complete game development project setup from initial idea to feature-level AI-ready task specifications.

## Usage

```bash
# Standard usage - reads GAME_IDEA from parameters file
/setup-game-project --project-name="[NAME]" --project-type="[Unity2D|Unity3D]" --base-dir="[PATH]" [options]

# Override game idea from command line (optional)
/setup-game-project --idea="[GAME_CONCEPT]" --project-name="[NAME]" --project-type="[Unity2D|Unity3D]" --base-dir="[PATH]" [options]

# Minimal usage - reads most values from parameters file
/setup-game-project [options]
```

## Parameters

### Required (unless in parameters file)
- `--project-name`: Clean project name (e.g., "Nexus Nodes") 
  - *Can be read from parameters file if already set*
- `--project-type`: Unity project type ("Unity2D" or "Unity3D")
  - *Can be read from parameters file if already set*
- `--base-dir`: Absolute path to project root directory
  - *Can be read from parameters file if already set*

### Optional
- `--idea`: Override game concept from parameters file
  - *By default, reads GAME_IDEA from `/Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml`*
- `--complexity`: Project complexity level ("simple", "intermediate", "detailed") 
  - *Default: reads from parameters file or uses "intermediate"*
- `--linear-issues`: Comma-separated AIG issue IDs (default: "AIG-114,AIG-115,AIG-116,AIG-117,AIG-118,AIG-119,AIG-120")
- `--target-epic`: Specific epic to process (default: processes ALL epics from roadmap)
- `--pause-between-phases`: Pause for user confirmation between major phases
- `--dry-run`: Show what would be done without executing
- `--resume-from`: Resume from specific phase (project|gdd|tds|roadmap|epic|features|tasks)

## Examples

### Recommended: Using Parameters File
```bash
# 1. First, update GAME_IDEA in /Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml
# 2. Then run with minimal parameters:
/setup-game-project --project-name="ColorMemory" --project-type="Unity2D" --base-dir="/Users/diarmuidcurran/Documents/AIDev/Projects/ColorMemory"

# Even simpler if parameters file has all values:
/setup-game-project --dry-run
```

### Alternative: Command Line Override
```bash
# You can still provide the idea directly if needed:
/setup-game-project --idea="A puzzle game where players connect energy nodes..." --project-name="Nexus Nodes" --project-type="Unity2D" --base-dir="/Users/username/Unity Projects/NexusNodes" --complexity="intermediate"
```

## Implementation

You are a specialized automation assistant for Unity game development project setup. When the user invokes this command, execute the complete pipeline from game idea to AI-ready task specifications.

### Parameter Flow & Inheritance

The command uses a three-tier parameter priority system:

1. **Command Line Arguments** (Highest Priority)
   - Any parameter provided via `--flag` overrides all other sources
   - Example: `--idea="..."` overrides GAME_IDEA from parameters file

2. **Base Template Parameters** (`/Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml`)
   - Primary source for all parameters not provided on command line
   - Contains GAME_IDEA, PROJECT_NAME, PROJECT_TYPE, BASE_DIRECTORY, COMPLEXITY_LEVEL
   - Also contains all template paths, Linear config, Unity settings
   - Never modified by the command

3. **Built-in Defaults** (Lowest Priority)
   - Fallback values if not in command line or parameters file
   - Example: COMPLEXITY_LEVEL defaults to "intermediate"

**Parameter Reading Order:**
1. Check command line for parameter
2. If not found, check base parameters file
3. If not found, use built-in default
4. Create project-specific parameters file with final values

**Key Advantage:**
- **No more copy-pasting long game ideas!**
- Put your game concept in the parameters file once
- Run the command with just: `/setup-game-project --dry-run`
- Override specific values only when needed

### Dry-Run Output Template

When `--dry-run` flag is used, display the following standardized output format:

```
================================================================================
🔍 DRY-RUN MODE - Setup Game Project Pipeline
================================================================================

📋 PARAMETERS SUMMARY
--------------------
Project Name:     {PROJECT_NAME}
Project Type:     {PROJECT_TYPE}
Base Directory:   {BASE_DIRECTORY}
Complexity:       {COMPLEXITY}
Target Epic:      {TARGET_EPIC or "ALL"}
Linear Issues:    {ENABLED/DISABLED}
Resume From:      {PHASE or "Start"}

📝 GAME CONCEPT
--------------
{First 500 chars of game idea...}

📊 COMPLEXITY CONFIGURATION
--------------------------
Epic Count:           {EPIC_COUNT} epics
Features Per Epic:    {FEATURES_PER_EPIC} features
Tasks Per Feature:    {TASKS_PER_FEATURE} tasks
Est. Total Features:  {TOTAL_FEATURES} features
Est. Total Tasks:     {TOTAL_TASKS} tasks
Documentation Depth:  {COMPLEXITY}

📁 FILE STRUCTURE TO BE CREATED
-------------------------------
{BASE_DIRECTORY}/
├── 📁 docs/
│   ├── 📄 {PROJECT_NAME}-GDD.md
│   ├── 📄 {PROJECT_NAME}-High-Level-Development-Roadmap.md
│   ├── 📁 TDS/
│   │   ├── 📄 Section0.md through Section{N}.md ({N} sections)
│   ├── 📄 Epic-{X.X}-Detailed.md ({EPIC_COUNT} files)
│   └── 📄 Feature-{X.X.X}-Tasks.md ({FEATURE_COUNT} files)
├── 📁 prompts/
│   └── 📁 Feature-{X.X.X}/ ({FEATURE_COUNT} directories)
├── 📁 outputs/
│   └── 📁 prompts/
├── 📁 templates/
│   ├── 📁 TDS/
│   ├── 📁 GDD/
│   └── 📁 Prompts/
├── 📁 Documentation/
│   └── 📄 MCP-Unity-Guidelines.md
└── 📄 project-parameters.yaml

📈 FILES SUMMARY
---------------
Total Directories:    {DIR_COUNT}
Total Files:         {FILE_COUNT}
Configuration Files: {CONFIG_COUNT}
Documentation Files: {DOC_COUNT}
Task Files:         {TASK_COUNT}
Prompt Files:       {PROMPT_COUNT}

🔄 LINEAR ISSUES TO BE PROCESSED
--------------------------------
Phase 1 - Project Structure:    AIG-114 [{STATUS}]
Phase 2 - GDD Generation:       AIG-115 [{STATUS}]
Phase 3 - TDS Generation:       AIG-116 [{STATUS}]
Phase 4 - Roadmap Generation:   AIG-117 [{STATUS}]
Phase 5 - Epic Detailing:       AIG-118 [{STATUS}]
Phase 6 - Feature Tasks:        AIG-119 [{STATUS}]
Phase 7 - AI Prompts:          AIG-120 [{STATUS}]

📋 EPIC BREAKDOWN PREVIEW
------------------------
{For each epic:}
Epic {X.X}: {EPIC_NAME}
├── Features: {FEATURE_COUNT}
├── Tasks: {TASK_COUNT}
├── Est. Hours: {HOUR_RANGE}
└── Priority: {PRIORITY}

Total Epics: {EPIC_COUNT}
Total Features: {TOTAL_FEATURES}
Total Tasks: {TOTAL_TASKS}

🏷️ TAXONOMY DISTRIBUTION PREVIEW
--------------------------------
1.x Core Logic & Systems:    ~{COUNT} tasks
2.x User Interface:          ~{COUNT} tasks
3.x Visual & Graphics:       ~{COUNT} tasks
4.x Physics & Movement:      ~{COUNT} tasks
5.x AI & Behaviors:          ~{COUNT} tasks
6.x Data Management:         ~{COUNT} tasks
7.x Validation & Testing:    ~{COUNT} tasks
8.x Platform & Build:        ~{COUNT} tasks

⏱️ TIME ESTIMATES
----------------
Setup Pipeline:      {SETUP_TIME} minutes
Documentation Gen:   {DOC_TIME} minutes
Epic Processing:     {EPIC_TIME} minutes
Task Generation:     {TASK_TIME} minutes
Total Pipeline:      {TOTAL_TIME} minutes

Development Hours:   {DEV_HOURS} hours
Calendar Time:       {CALENDAR_TIME}

✅ VALIDATION CHECKS
-------------------
[✓] Base directory exists and writable
[✓] Complexity level valid
[✓] Project type supported
[✓] Linear workspace accessible (if enabled)
[✓] Template paths verified
[✓] Git repository check complete

⚠️ WARNINGS (if any)
-------------------
{List any warnings or issues}

================================================================================
🎯 DRY-RUN COMPLETE - No files created or modified
💡 Remove --dry-run flag to execute the pipeline
📊 Estimated completion: {TOTAL_TIME} minutes for {TOTAL_TASKS} AI-ready tasks
================================================================================
```

### Standard Output Values

For consistency, use these standard ranges based on complexity:

**Simple Complexity:**
- Epics: 2-3
- Features per Epic: 2-3
- Tasks per Feature: 3-5
- Total Tasks: 20-35
- Setup Time: 15-20 minutes

**Intermediate Complexity:**
- Epics: 3-5
- Features per Epic: 3-4
- Tasks per Feature: 4-7
- Total Tasks: 40-80
- Setup Time: 25-35 minutes

**Detailed Complexity:**
- Epics: 5-8
- Features per Epic: 4-6
- Tasks per Feature: 6-10
- Total Tasks: 80-150
- Setup Time: 35-45 minutes

### Phase 1: Project Infrastructure Setup

1. **Validate Parameters**
   - Verify all required parameters provided
   - Check base directory exists and is writable
   - Validate complexity level is one of: simple, intermediate, detailed
   - Validate Linear workspace access if Linear issues specified
   - Verify Unity project type is valid

2. **Create Project Structure**
   - Create directory structure based on AIG-114 pattern
   - Initialize git repository if needed
   - Set up documentation, prompts, and output directories
   - Copy essential templates from AIDev to project (hybrid approach)

3. **Generate Parameters File**
   
   The command creates a project-specific `project-parameters.yaml` by:
   - **Loading** the base template from `/Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml`
   - **Overriding** with command-line parameters (--project-name, --project-type, --base-dir, --complexity)
   - **Saving** to `{BASE_DIRECTORY}/project-parameters.yaml`
   
   ```yaml
   # Project-specific parameters (inherits from base template)
   # Only the essential parameters that differ from base template are shown here
   
   # CORE PARAMETERS (from command line)
   PROJECT_NAME: "{project-name}"           # From --project-name
   PROJECT_TYPE: "{project-type}"           # From --project-type  
   BASE_DIRECTORY: "{base-dir}"             # From --base-dir
   COMPLEXITY_LEVEL: "{complexity}"         # From --complexity
   
   # AUTO-CALCULATED based on complexity
   SCOPE_CONFIG:
     EPIC_COUNT: {calculated}               # simple: 2-3, intermediate: 3-5, detailed: 5-8
     FEATURES_PER_EPIC: {calculated}        # simple: 2-3, intermediate: 3-4, detailed: 4-6
     TASKS_PER_FEATURE: {calculated}        # simple: 3-5, intermediate: 4-7, detailed: 6-10
   
   # PATHS (all auto-generated from PROJECT_NAME and BASE_DIRECTORY)
   GDD_PATH: "{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md"
   TDS_PATH: "{BASE_DIRECTORY}/docs/TDS/"
   ROADMAP_PATH: "{BASE_DIRECTORY}/docs/{PROJECT_NAME}-High-Level-Development-Roadmap.md"
   
   # GAME CONCEPT (from --idea parameter)
   GAME_IDEA: |
     {idea}
   
   # INHERITED FROM BASE TEMPLATE (not duplicated, referenced)
   # - Template paths (AIDev locations)
   # - Linear configuration
   # - Unity configuration
   # - Complexity scaling factors
   ```
   
   **Note:** The project-specific file only contains overrides and project-specific values. 
   All template paths and standard configurations remain in the base parameters file.

### Phase 2: Core Documentation Generation

4. **Execute GDD Generation (AIG-115 Pattern)**
   - **Linear Integration**: Update issue AIG-115 status to "In Progress"
   - Load GDD template from {GDD_TEMPLATE_PATH}
   - Update target Linear issue with game idea
   - Execute GDD generation workflow using enhanced template
   - Validate GDD completeness before proceeding
   - Save project-specific GDD to {GDD_PATH}
   - **Linear Integration**: Add completion comment and update status to "Done"

5. **Execute TDS Generation (AIG-116 Pattern)**  
   - **Linear Integration**: Update issue AIG-116 status to "In Progress"
   - Load TDS templates from {TDS_TEMPLATES_PATH}/Section[0-7].md
   - Reference {TDS_COMPLEXITY_MAPPING_PATH} to determine which sections/subsections to include
   - Process GDD to generate TDS sections based on complexity level
   - Apply appropriate technical depth and feature scope per complexity level
   - Use user confirmation between sections if --pause-between-phases
   - Validate each section before proceeding
   - Save project-specific sections to {TDS_PATH}/Section[0-7].md (only generated sections)
   - **Linear Integration**: Add completion comment with section count and update status to "Done"

6. **Execute Roadmap Generation (AIG-117 Pattern)**
   - **Linear Integration**: Update issue AIG-117 status to "In Progress"
   - Generate high-level development roadmap from GDD/TDS
   - Extract epics and milestone framework
   - Save to {ROADMAP_PATH}
   - **Linear Integration**: Add completion comment with epic count and update status to "Done"

### Phase 3: Epic Processing

7. **Execute Epic Detailing (AIG-118 Pattern)**
   - **Linear Integration**: Update issue AIG-118 status to "In Progress"
   - Process ALL epics from roadmap (or --target-epic if specified)
   - Generate detailed epic specifications with features for each epic
   - Update TARGET_EPIC in parameters file for each epic processed
   - Save to {BASE_DIRECTORY}/docs/Epic-{EPIC_NUMBER}-Detailed.md for each epic
   - **Linear Integration**: Add completion comment with processed epics list and update status to "Done"

### Phase 4: Feature Task Generation

8. **Execute Feature-to-Tasks (AIG-119 Pattern)**
   - **Linear Integration**: Update issue AIG-119 status to "In Progress"
   - Process all features in ALL processed epics (complete feature coverage)
   - Generate task breakdown with taxonomy categories for each feature
   - Ensure specific behavior descriptions and observable outcomes
   - Save to {DOCS_OUTPUT_PATH}/Feature-{FEATURE_NUMBER}-Tasks.md for each feature
   - **Linear Integration**: Add completion comment with feature count and task count, update status to "Done"

9. **Execute Tasks-to-AI-Prompts (AIG-120 Pattern)**
   - **Linear Integration**: Update issue AIG-120 status to "In Progress"
   - Create Linear issues for ALL tasks across ALL processed epics. Only ever process 5 Linear issues at a time to avoid memory issues. Ask to proceed between each batch.  
   - Generate AI-ready prompts with specific behaviors embedded
   - Apply correct taxonomy labels automatically
   - Save prompts to {CODE_OUTPUT_PATH}/prompts/
   - Result: Complete project ready for implementation
   - **Linear Integration**: Add completion comment with created issue count and update status to "Done"

### Linear Workflow Integration

Each phase includes Linear issue tracking and status updates:

**Phase Start Actions:**
```bash
# Update Linear issue status to "In Progress"
mcp__linear-server__update_issue --id="{ISSUE_ID}" --state="In Progress"
```

**Phase Complete Actions:**
```bash
# Add completion comment with summary
mcp__linear-server__create_comment --issueId="{ISSUE_ID}" --body="✅ **Phase Complete**: {PHASE_NAME}

## Summary
- Generated: {DELIVERABLES_COUNT} deliverables
- Output Location: {OUTPUT_PATH}
- Next Phase: {NEXT_PHASE}

## Files Created:
{FILE_LIST}

🤖 Generated via setup-game-project workflow"

# Update status to Done
mcp__linear-server__update_issue --id="{ISSUE_ID}" --state="Done"
```

**Issue Mapping:**
- **Phase 1 (Project Structure)**: AIG-114
- **Phase 2 (GDD)**: AIG-115  
- **Phase 3 (TDS)**: AIG-116
- **Phase 4 (Roadmap)**: AIG-117
- **Phase 5 (Epic Details)**: AIG-118
- **Phase 6 (Feature Tasks)**: AIG-119
- **Phase 7 (AI Prompts)**: AIG-120

**Error Handling:**
- If Linear integration fails, continue workflow but log warning
- Provide manual Linear update instructions in case of API issues
- Track Linear integration status in parameters file

### Error Handling & Validation

Each phase includes comprehensive validation:

1. **Pre-Phase Validation**
   - Check prerequisites are met
   - Verify previous phase outputs exist and are complete
   - Validate parameters are populated correctly

2. **Post-Phase Validation**
   - Verify output documents were created successfully
   - Check content quality and completeness
   - Update parameters file with new values

3. **Failure Recovery**
   - Support resume from any phase with --resume-from
   - Rollback capability for failed phases
   - Clear error messages with suggested fixes

### Success Metrics

At completion, the project will have:

- ✅ **Complete Project Structure**: All directories and base files
- ✅ **Comprehensive Documentation**: GDD, 8 TDS sections, roadmap, epic details  
- ✅ **Feature Task Breakdowns**: All features broken into categorized tasks
- ✅ **AI-Ready Linear Issues**: 15-40 executable tasks with specific behaviors
- ✅ **Automatic Organization**: All tasks labeled with taxonomy categories
- ✅ **Parameter File**: All paths and settings configured for future use

### Output Summary

```bash
🎮 Project Setup Complete: {PROJECT_NAME}
📁 Base Directory: {BASE_DIRECTORY}
📋 Documents Generated: 
   - Game Design Document (GDD)
   - Technical Design Specification (8 sections)
   - Development Roadmap with {EPIC_COUNT} epics
   - ALL Epic Detailed Specifications ({PROCESSED_EPICS})
📝 Tasks Generated: {TASK_COUNT} AI-ready tasks across all epics
🏷️  Taxonomy Labels Applied: Automatic categorization
⏱️  Estimated Implementation Time: {TOTAL_HOURS} hours (complete game)
🚀 Ready for Development: Execute Linear issues to begin coding

Epic Breakdown:
- Epic 1.1: {EPIC_1_TASK_COUNT} tasks ({EPIC_1_HOURS} hours)
- Epic 1.2: {EPIC_2_TASK_COUNT} tasks ({EPIC_2_HOURS} hours)  
- Epic 1.3: {EPIC_3_TASK_COUNT} tasks ({EPIC_3_HOURS} hours)

Next Steps:
1. Review generated documentation for all epics
2. Execute Linear task issues by epic priority
3. Use taxonomy labels to filter tasks by expertise area
4. Can work on epics sequentially or in parallel
5. Monitor progress through Linear issue completion
```

## 🏗️ Path Architecture

### **Template Sources (AIDev Folder - Read Only)**
- **Templates**: Located in `/Users/diarmuidcurran/Documents/AIDev/Base Prompts/`
- **TDS Templates**: `{AIDEV_BASE_PATH}/Base Prompts/Techn Design Spec/Section[0-7].md`  
- **Complexity Mapping**: `{TDS_COMPLEXITY_MAPPING_PATH}` 
- **GDD Templates**: `{GDD_TEMPLATE_PATH}/`
- **Purpose**: Master templates shared across all projects

### **Project Outputs (Unity Project Folder - Generated)**
- **Project Base**: `{BASE_DIRECTORY}` (Unity project root)
- **Documentation**: `{BASE_DIRECTORY}/docs/` (project-specific docs)
- **Generated Code**: `{BASE_DIRECTORY}/outputs/` (AI-generated scripts)
- **AI Prompts**: `{BASE_DIRECTORY}/prompts/` (project-specific prompts)
- **Purpose**: Project-specific files that will be created/modified

### **Hybrid Template Copies (Project-Specific)**
- **TDS Templates**: `{BASE_DIRECTORY}/templates/TDS/` (copied from AIDev)
- **GDD Template**: `{BASE_DIRECTORY}/templates/GDD/` (copied from AIDev)
- **Prompt Templates**: `{BASE_DIRECTORY}/templates/Prompts/` (copied from AIDev)
- **Purpose**: Self-contained project with essential templates for reference and customization

### **Workflow**
1. **Load master templates** from AIDev folder (read-only)
2. **Copy essential templates** to project for self-containment
3. **Generate project-specific content** using templates
4. **Save outputs** to Unity project folder
5. **Keep master templates unchanged** for reuse across projects

## Execution Flow

When invoked, this command will:

1. **Validate inputs** and create project structure
2. **Generate parameters file** with all paths configured
3. **Execute AIG-115**: Generate comprehensive GDD
4. **Execute AIG-116**: Generate 8-section TDS  
5. **Execute AIG-117**: Generate development roadmap
6. **Execute AIG-118**: Detail ALL epics from roadmap (or specific epic if specified)
7. **Execute AIG-119**: Break all features across all epics into categorized tasks
8. **Execute AIG-120**: Create AI-ready Linear issues for all tasks with taxonomy labels
9. **Report completion** with epic-by-epic breakdown and next steps

**Total Time**: 
- **All Epics (Default)**: 25-40 minutes for complete game pipeline
- **Single Epic**: 15-25 minutes for targeted development
**Output**: 
- **All Epics**: 40-80 ready-to-execute AI coding tasks (complete game)
- **Single Epic**: 15-25 tasks for specific game area
**Organization**: Automatic taxonomy-based categorization for skill-based assignment

This command transforms a simple game idea into a complete, organized development pipeline with categorized, AI-ready coding tasks in under 40 minutes.

## Usage Examples

### Complete Game Setup (Default - All Epics)
```bash
/setup-game-project \
  --idea="A puzzle game where players connect energy nodes to power a city" \
  --project-name="Nexus Nodes" \
  --project-type="Unity2D" \
  --base-dir="/Users/username/Unity Projects/NexusNodes" \
  --complexity="intermediate"
```
**Result**: Complete game specification with all epics processed (40-80 tasks)

### Single Epic Focus
```bash
/setup-game-project \
  --idea="Classic Snake game with modern twists" \
  --project-name="Snake Plus" \
  --project-type="Unity2D" \
  --base-dir="/Users/username/Unity Projects/SnakePlus" \
  --complexity="simple" \
  --target-epic="1.1"
```
**Result**: Core gameplay epic only (15-25 tasks)

### Development Workflow Integration
```bash
/setup-game-project \
  --idea="Tower defense with resource management" \
  --project-name="Tower Command" \
  --project-type="Unity3D" \
  --base-dir="/Users/username/Unity Projects/TowerCommand" \
  --complexity="detailed" \
  --linear-issues="AIG-101,AIG-102,AIG-103,AIG-104,AIG-105,AIG-106,AIG-107" \
  --pause-between-phases
```
**Result**: Complete game with Linear integration and user confirmation points

### Complexity Level Examples
```bash
# Simple: Quick prototype, minimal features (20-35 tasks total)
--complexity="simple"

# Intermediate: Standard game, balanced features (40-80 tasks total) 
--complexity="intermediate"

# Detailed: Comprehensive game, advanced features (80-150 tasks total)
--complexity="detailed"
```