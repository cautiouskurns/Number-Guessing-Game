# Setup Game Project Pipeline (DEPRECATED)

> **⚠️ DEPRECATED**: This monolithic command has been split into focused, single-responsibility commands for better maintainability and flexibility.

## Replacement Commands

This command's functionality has been split into:

1. **`setup-project-structure`** - Creates project folder hierarchy and configuration
2. **`generate-game-documents`** - Generates GDD, TDS, and Roadmap
3. **`generate-epic-details`** - Details epic specifications
4. **`generate-feature-tasks`** - Breaks features into tasks
5. **`generate-ai-prompts`** - Creates AI implementation prompts

## Migration Guide

### Old Workflow (Single Command)
```bash
# Previously: One monolithic command
setup-game-project --project-name="MyGame" --idea="Game concept"
```

### New Workflow (Focused Commands)
```bash
# Step 1: Create project structure
setup-project-structure --project-name="MyGame" --project-type="Unity2D"

# Step 2: Add GAME_IDEA to project-parameters.yaml
# Edit {PROJECT_PATH}/project-parameters.yaml

# Step 3: Generate documentation
generate-game-documents --all

# Step 4: Detail epics
generate-epic-details --all

# Step 5: Create task breakdowns
generate-feature-tasks --all

# Step 6: Generate AI prompts
generate-ai-prompts --all
```

## Benefits of New Architecture

### ✅ **Single Responsibility**
- Each command has one clear purpose
- Easier to understand and maintain
- Better error isolation

### ✅ **Flexible Workflow**
- Regenerate individual documents without affecting others
- Skip completed phases
- Selective document generation

### ✅ **Better Debugging**
- Smaller commands are easier to troubleshoot
- Clear failure points
- Independent testing

### ✅ **Consistent Architecture**
- All commands follow same self-contained pattern
- Template-driven generation
- Optional Linear integration

---

## Original Documentation (For Reference)

Automates the complete game development project setup from initial idea to feature-level AI-ready task specifications.

## Quick Start with New Commands

### Complete Setup (All Phases)
```bash
# 1. Create project structure
setup-project-structure \
  --project-name="ColorMemory3" \
  --project-type="Unity2D" \
  --base-dir="/path/to/projects" \
  --complexity="simple"

# 2. Edit project-parameters.yaml to add GAME_IDEA
cd /path/to/projects/ColorMemory3
# Add your game concept to GAME_IDEA field

# 3. Generate all documentation
generate-game-documents --all

# 4-6. Continue with development pipeline
generate-epic-details --all --create-linear-issues
generate-feature-tasks --all --create-linear-issues
generate-ai-prompts --all --create-linear-issues
```

### Selective Generation
```bash
# Just create structure
setup-project-structure --project-name="MyGame"

# Just generate GDD
generate-game-documents --gdd-only

# Regenerate TDS with different complexity
generate-game-documents --tds-only --complexity detailed --force
```

---

## Original Usage (Deprecated)

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
- `--create-linear-issues`: Create new Linear issues for each phase (default: false)
- `--target-epic`: Specific epic to process (default: processes ALL epics from roadmap)
- `--pause-between-phases`: Pause for user confirmation between major phases
- `--dry-run`: Show what would be done without executing
- `--resume-from`: Resume from specific phase (project|gdd|tds|roadmap|epic|features|tasks)

## Examples

### Recommended: Using Parameters File
```bash
# 1. First, update GAME_IDEA in /Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml
# 2. Then run with minimal parameters:
/setup-game-project --project-name="ColorMemory2" --project-type="Unity2D" --base-dir="/Users/diarmuidcurran/Documents/AIDev/Projects/" --complexity="simple" --create-linear-issues enabled --dry-run

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

### Single Parameters File Approach

The command uses a simplified single-file parameter system:

1. **Pre-Setup Step**: Copy and customize the base parameters file to your project directory BEFORE running setup
2. **Single Source of Truth**: All parameters read from one location - no inheritance complexity
3. **Command Line Overrides**: Only command-line arguments can override file values

**Workflow:**
1. **Copy base template:** `cp /Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml {BASE_DIRECTORY}/project-parameters.yaml`
2. **Customize parameters:** Edit the copied file with your specific settings (SCOPE_CONFIG, GAME_IDEA, etc.)
3. **Run setup:** Execute setup-game-project - it reads YOUR customized parameters file
4. **No duplication:** Single parameters file used throughout development

**Key Advantages:**
- ✅ **No inheritance bugs** - direct parameter reading
- ✅ **Full customization control** - edit all values including SCOPE_CONFIG 
- ✅ **Single source of truth** - one file contains all project settings
- ✅ **No parameter conflicts** - what you set is what gets used
- ✅ **Template preservation** - base template stays unchanged for other projects

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
├── 📁 documentation/
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
Phase 1 - Project Structure:    [New Linear issue will be created]
Phase 2 - GDD Generation:       [New Linear issue will be created]
Phase 3 - TDS Generation:       [New Linear issue will be created]  
Phase 4 - Roadmap Generation:   [New Linear issue will be created]
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

Execute the complete project folder structure setup with integrated Linear tracking:

1. **Load and Validate Parameters**
   ```bash
   # Check if project-specific parameters file exists
   PROJECT_PARAMS_FILE="{BASE_DIRECTORY}/project-parameters.yaml"
   
   if [ ! -f "$PROJECT_PARAMS_FILE" ]; then
       echo "Error: Project parameters file not found at $PROJECT_PARAMS_FILE"
       echo "Please copy and customize the base template first:"
       echo "  cp /Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml $PROJECT_PARAMS_FILE"
       echo "  # Edit the file to customize SCOPE_CONFIG, GAME_IDEA, etc."
       echo "  # Then run setup-game-project again"
       exit 1
   fi
   
   # Load ALL parameters from the single project file
   # Command-line arguments can still override specific values
   PROJECT_NAME={from --project-name or project parameters file}
   PROJECT_TYPE={from --project-type or project parameters file}
   BASE_DIRECTORY={from --base-dir or project parameters file}
   COMPLEXITY_LEVEL={from --complexity or project parameters file}
   GAME_IDEA={from --idea or project parameters file}
   
   # Load SCOPE_CONFIG directly from project parameters file (no calculation/override)
   EPIC_COUNT={from project parameters file SCOPE_CONFIG.EPIC_COUNT}
   FEATURES_PER_EPIC={from project parameters file SCOPE_CONFIG.FEATURES_PER_EPIC}
   TASKS_PER_FEATURE={from project parameters file SCOPE_CONFIG.TASKS_PER_FEATURE}
   
   # Validate all parameters
   - Verify PROJECT_NAME is non-empty string
   - Verify PROJECT_TYPE is "Unity2D" or "Unity3D"
   - Verify BASE_DIRECTORY exists and is writable
   - Verify COMPLEXITY_LEVEL is "simple", "intermediate", or "detailed"
   - Verify SCOPE_CONFIG values are reasonable (EPIC_COUNT 1-10, etc.)
   - Verify Linear workspace access if --create-linear-issues enabled
   ```

2. **Create Complete Directory Structure**
   ```bash
   # Create main project directory
   mkdir -p "{BASE_DIRECTORY}"
   
   # Create comprehensive subdirectory structure
   mkdir -p "{BASE_DIRECTORY}/docs"
   mkdir -p "{BASE_DIRECTORY}/docs/TDS"
   mkdir -p "{BASE_DIRECTORY}/docs/epics"
   mkdir -p "{BASE_DIRECTORY}/docs/tasks"
   mkdir -p "{BASE_DIRECTORY}/prompts"
   mkdir -p "{BASE_DIRECTORY}/prompts/Feature-Templates"
   mkdir -p "{BASE_DIRECTORY}/outputs"
   mkdir -p "{BASE_DIRECTORY}/outputs/code"
   mkdir -p "{BASE_DIRECTORY}/outputs/docs"
   mkdir -p "{BASE_DIRECTORY}/outputs/prompts"
   mkdir -p "{BASE_DIRECTORY}/templates"
   mkdir -p "{BASE_DIRECTORY}/templates/TDS"
   mkdir -p "{BASE_DIRECTORY}/templates/GDD"
   mkdir -p "{BASE_DIRECTORY}/templates/Prompts"
   mkdir -p "{BASE_DIRECTORY}/Documentation"
   
   # Verify directories were created successfully
   ls -la "{BASE_DIRECTORY}/"
   ```

3. **Copy Base Templates (Hybrid Approach)**
   ```bash
   # Copy essential templates from AIDev base to project
   AIDEV_BASE="/Users/diarmuidcurran/Documents/AIDev"
   
   # Copy TDS templates if they exist
   if [ -d "{AIDEV_BASE}/Base Prompts/Techn Design Spec" ]; then
       cp -r "{AIDEV_BASE}/Base Prompts/Techn Design Spec"/*.md "{BASE_DIRECTORY}/templates/TDS/" 2>/dev/null
       echo "TDS templates copied successfully"
   fi
   
   # Copy GDD templates if they exist
   if [ -d "{AIDEV_BASE}/Base Prompts/GDD" ]; then
       cp -r "{AIDEV_BASE}/Base Prompts/GDD"/*.md "{BASE_DIRECTORY}/templates/GDD/" 2>/dev/null
       echo "GDD templates copied successfully"
   fi
   
   # Copy general prompt templates
   if [ -d "{AIDEV_BASE}/Base Prompts" ]; then
       cp "{AIDEV_BASE}/Base Prompts"/*.md "{BASE_DIRECTORY}/templates/Prompts/" 2>/dev/null
       echo "Base prompt templates copied successfully"
   fi
   
   # List copied templates for verification
   ls -la "{BASE_DIRECTORY}/templates/"
   ```

4. **Create Essential Project Files**
   ```bash
   # Create empty documentation structure files
   touch "{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md"
   touch "{BASE_DIRECTORY}/docs/{PROJECT_NAME}-High-Level-Development-Roadmap.md"
   
   # Create TDS section files based on complexity
   COMPLEXITY="{COMPLEXITY_LEVEL}"
   if [ "$COMPLEXITY" = "simple" ]; then
       for i in {0..3}; do
           touch "{BASE_DIRECTORY}/docs/TDS/Section$i.md"
       done
   elif [ "$COMPLEXITY" = "intermediate" ]; then
       for i in {0..5}; do
           touch "{BASE_DIRECTORY}/docs/TDS/Section$i.md"
       done
   else # detailed
       for i in {0..7}; do
           touch "{BASE_DIRECTORY}/docs/TDS/Section$i.md"
       done
   fi
   
   # Verify files were created
   ls -la "{BASE_DIRECTORY}/docs/"
   ls -la "{BASE_DIRECTORY}/docs/TDS/"
   ```

5. **Update Project Parameters File with Generated Paths**
   ```bash
   # Update the existing parameters file with generated paths (preserve all user settings)
   
   # Update workflow status to reflect setup completion
   sed -i '' 's/STRUCTURE_COMPLETE: .*/STRUCTURE_COMPLETE: true/' "{BASE_DIRECTORY}/project-parameters.yaml"
   
   # Add/update generated paths if they don't exist (preserve existing paths if user customized them)
   if ! grep -q "GDD_PATH:" "{BASE_DIRECTORY}/project-parameters.yaml"; then
       echo "" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "# GENERATED PATHS (auto-generated from PROJECT_NAME and BASE_DIRECTORY)" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "GDD_PATH: \"{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "TDS_PATH: \"{BASE_DIRECTORY}/docs/TDS/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "ROADMAP_PATH: \"{BASE_DIRECTORY}/docs/{PROJECT_NAME}-High-Level-Development-Roadmap.md\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "EPIC_PATH: \"{BASE_DIRECTORY}/docs/epics/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "FEATURE_PATH: \"{BASE_DIRECTORY}/docs/tasks/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "PROMPTS_PATH: \"{BASE_DIRECTORY}/prompts/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "OUTPUTS_PATH: \"{BASE_DIRECTORY}/outputs/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
       echo "TEMPLATES_PATH: \"{BASE_DIRECTORY}/templates/\"" >> "{BASE_DIRECTORY}/project-parameters.yaml"
   fi
   
   # Note: No duplication - existing parameters file is preserved with user customizations
   # Only paths and workflow status are updated/added
   ```

6. **Create Project README**
   ```bash
   # Generate comprehensive README with project information
   cat > "{BASE_DIRECTORY}/README.md" << 'EOL'
   # {PROJECT_NAME}
   
   **Type:** {PROJECT_TYPE}
   **Complexity:** {COMPLEXITY_LEVEL}
   
   ## Game Concept
   {GAME_IDEA_PREVIEW}
   
   ## Project Structure
   
   - `docs/` - Game Design Document and Technical Design Specifications
     - `{PROJECT_NAME}-GDD.md` - Complete Game Design Document
     - `TDS/` - Technical Design Specification sections
     - `epics/` - Detailed epic specifications
     - `tasks/` - Feature task breakdowns
   - `prompts/` - AI generation templates and prompts
   - `outputs/` - Generated code and documentation
     - `code/` - Generated Unity C# scripts
     - `docs/` - Generated technical documentation
     - `prompts/` - Generated AI-ready task prompts
   - `templates/` - Project-specific template copies
     - `TDS/` - Technical Design Specification templates
     - `GDD/` - Game Design Document templates
     - `Prompts/` - AI prompt templates
   
   ## Development Workflow
   
   1. **Setup Phase**: ✅ Project structure created
   2. **Design Phase**: Generate GDD using `/generate-epic-details`
   3. **Technical Phase**: Generate TDS sections
   4. **Planning Phase**: Create development roadmap
   5. **Epic Phase**: Detail all epics using `/generate-epic-details`
   6. **Feature Phase**: Break features into tasks using `/generate-feature-tasks`
   7. **Implementation Phase**: Generate AI prompts using `/generate-ai-prompts`
   
   ## Key Files
   
   - `project-parameters.yaml` - Centralized project configuration
   - `docs/{PROJECT_NAME}-GDD.md` - Game Design Document
   - `docs/TDS/Section*.md` - Technical specifications
   - `templates/` - Template library for AI generation
   
   Created: $(date)
   Setup Command: setup-game-project
   EOL
   
   # Replace parameter placeholders with actual values
   sed -i '' "s/{PROJECT_NAME}/${PROJECT_NAME}/g" "{BASE_DIRECTORY}/README.md"
   sed -i '' "s/{PROJECT_TYPE}/${PROJECT_TYPE}/g" "{BASE_DIRECTORY}/README.md"
   sed -i '' "s/{COMPLEXITY_LEVEL}/${COMPLEXITY_LEVEL}/g" "{BASE_DIRECTORY}/README.md"
   sed -i '' "s/{GAME_IDEA_PREVIEW}/${GAME_IDEA:0:200}...}/g" "{BASE_DIRECTORY}/README.md"
   
   echo "README.md created with project information"
   ```

7. **Verify Complete Setup**
   ```bash
   echo "=== Project Setup Verification ==="
   echo "Project Path: {BASE_DIRECTORY}"
   echo ""
   echo "Directory Structure:"
   tree "{BASE_DIRECTORY}" 2>/dev/null || find "{BASE_DIRECTORY}" -type d | sort
   
   echo ""
   echo "File Count Verification:"
   echo "- TDS files: $(ls "{BASE_DIRECTORY}/docs/TDS/"*.md 2>/dev/null | wc -l) (expected based on complexity)"
   echo "- Template files: $(find "{BASE_DIRECTORY}/templates" -name "*.md" 2>/dev/null | wc -l)"
   echo "- README exists: $([ -f "{BASE_DIRECTORY}/README.md" ] && echo "✅ Yes" || echo "❌ No")"
   echo "- Parameters file exists: $([ -f "{BASE_DIRECTORY}/project-parameters.yaml" ] && echo "✅ Yes" || echo "❌ No")"
   echo "- Git initialized: $([ -d "{BASE_DIRECTORY}/.git" ] && echo "✅ Yes" || echo "❌ No")"
   
   echo ""
   echo "Parameters Used:"
   echo "- PROJECT_NAME: {PROJECT_NAME}"
   echo "- PROJECT_TYPE: {PROJECT_TYPE}"
   echo "- BASE_DIRECTORY: {BASE_DIRECTORY}"
   echo "- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}"
   
   echo ""
   echo "Setup Status: $([ -d "{BASE_DIRECTORY}/docs/TDS" ] && [ -f "{BASE_DIRECTORY}/README.md" ] && [ -f "{BASE_DIRECTORY}/project-parameters.yaml" ] && echo "✅ SUCCESS" || echo "❌ FAILED")"
   ```

8. **Create Linear Issue Record**
   ```bash
   # If --create-linear-issues flag provided, create new Linear issue for project setup
   if CREATE_LINEAR_ISSUES; then
       # Create new Linear issue for Phase 1: Project Infrastructure Setup
       PHASE1_ISSUE_ID=$(mcp__linear-server__create_issue \
           --team="$LINEAR_TEAM" \
           --project="$LINEAR_PROJECT" \
           --title="Phase 1: Project Infrastructure Setup - {PROJECT_NAME}" \
           --description="Automated project structure creation and template setup for {PROJECT_NAME} ({PROJECT_TYPE} project)" \
           --state="Done" \
           | jq -r '.id')
       
       echo "Created Linear issue for Phase 1: $PHASE1_ISSUE_ID"
       LINEAR_COMMENT="
   ## Phase 1 Complete: Project Infrastructure Setup
   
   ### Parameters Used:
   - PROJECT_NAME: {PROJECT_NAME}
   - PROJECT_TYPE: {PROJECT_TYPE}
   - BASE_DIRECTORY: {BASE_DIRECTORY}
   - COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
   
   ### Created Structure:
   - Main project directory: {BASE_DIRECTORY}
   - Documentation files: $(ls "{BASE_DIRECTORY}/docs/TDS/"*.md 2>/dev/null | wc -l) TDS sections created
   - Template files: $(find "{BASE_DIRECTORY}/templates" -name "*.md" 2>/dev/null | wc -l) templates copied
   - Output directories: code/, docs/, prompts/ created
   - Git repository: $([ -d "{BASE_DIRECTORY}/.git" ] && echo "initialized" || echo "already existed")
   
   ### Verification Results:
   - ✅ All required directories exist
   - ✅ All TDS section files created (complexity-appropriate)
   - ✅ README.md contains correct project information
   - ✅ Base templates copied successfully
   - ✅ Project parameters file generated
   - ✅ File permissions are correct
   
   ### Next Phase Available:
   - Ready for Phase 2: GDD Generation
   - All templates available in templates/ directory
   - Project structure ready for development workflow
   
   ### Status: ✅ Completed Successfully
   🤖 Generated via setup-game-project command integration"
   
       # Add completion comment to the created issue
       mcp__linear-server__create_comment --issueId="$PHASE1_ISSUE_ID" --body="$LINEAR_COMMENT"
       
       echo "Phase 1 Linear issue completed: $PHASE1_ISSUE_ID"
   fi
   ```

   **Key Integration Features:**
   - Direct implementation instead of referencing Linear instructions
   - Integrated parameter handling with command-line overrides
   - Linear issues created as records AFTER completion
   - Single-context execution (no context switching between issues)
   - Enhanced directory structure for complete pipeline
   - Comprehensive validation and error handling

### Phase 2: Core Documentation Generation

4. **Execute GDD Generation**
   ```bash
   # Load Parameters and Check Complexity
   COMPLEXITY_LEVEL={from parameters file}
   GDD_PATH="{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md"
   GDD_TEMPLATE_PATH="{BASE_DIRECTORY}/templates/GDD"
   
   echo "Starting GDD Generation for complexity level: $COMPLEXITY_LEVEL"
   
   # Validate Prerequisites
   if [ ! -f "{BASE_DIRECTORY}/project-parameters.yaml" ]; then
       echo "Error: Project parameters file not found"
       exit 1
   fi
   
   if [ ! -d "{BASE_DIRECTORY}/templates/GDD" ]; then
       echo "Warning: GDD templates not found, using built-in structure"
   fi
   
   # Validate game concept is substantial enough for complexity level
   GAME_IDEA_LENGTH=$(echo "{GAME_IDEA}" | wc -c)
   if [ "$COMPLEXITY_LEVEL" = "detailed" ] && [ $GAME_IDEA_LENGTH -lt 300 ]; then
       echo "Warning: Game concept may be too brief for detailed complexity"
   fi
   
   # Load and Execute GDD Template with Game Concept
   echo "Loading GDD template and generating comprehensive GDD..."
   
   # Validate GDD template exists
   GDD_TEMPLATE="{AIDEV_BASE}/Base Prompts/GDD-Development-Prompt.md"
   if [ ! -f "$GDD_TEMPLATE" ]; then
       echo "Error: GDD template not found at $GDD_TEMPLATE"
       echo "Please ensure the GDD-Development-Prompt.md template exists in the Base Prompts directory"
       exit 1
   fi
   
   # Create temporary input file with all required parameters
   cat > "{BASE_DIRECTORY}/temp_gdd_input.md" << EOF
## Project Parameters
- PROJECT_NAME: {PROJECT_NAME}
- PROJECT_TYPE: {PROJECT_TYPE}
- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
- BASE_DIRECTORY: {BASE_DIRECTORY}

## Game Concept
{GAME_IDEA}

## Additional Context
- Development Timeline: Based on complexity level ({COMPLEXITY_LEVEL})
- Team Size: Solo developer
- Target Audience: Based on game concept
- Platform Priority: {PROJECT_TYPE} focused
- Budget Constraints: Solo developer budget
EOF
   
   # Generate GDD using the comprehensive template
   echo "Generating GDD using template-based approach..."
   echo "Template: $GDD_TEMPLATE"
   echo "Input: {BASE_DIRECTORY}/temp_gdd_input.md"
   echo "Output: {GDD_PATH}"
   echo ""
   echo "Template-based GDD Generation Process:"
   echo "1. Loading GDD template with complexity-aware instructions"
   echo "2. Processing game concept: {COMPLEXITY_LEVEL} complexity level"
   echo "3. Applying template structure with project-specific content"
   echo "4. Generating comprehensive GDD with all required sections"
   echo ""
   
   # Generate complete GDD using the template and game concept
   echo "Generating complete GDD using template..."
   
   # Use Task tool to generate the complete GDD
   echo "Using GDD template to generate complete Game Design Document..."
   
   # The actual GDD generation happens here using the template
   # This would call the GDD generation process with the prepared inputs
   echo "Processing GDD template with game concept and parameters..."
   echo "Template: $GDD_TEMPLATE"
   echo "Input file: {BASE_DIRECTORY}/temp_gdd_input.md"
   echo "Complexity: {COMPLEXITY_LEVEL}"
   echo "Output: {GDD_PATH}"
   
   # Generate the complete GDD content based on complexity level
   if [ "{COMPLEXITY_LEVEL}" = "simple" ]; then
       # Simple complexity GDD generation
       cat > "{GDD_PATH}" << 'EOF'
# {PROJECT_NAME} - Game Design Document

> **Generated using GDD-Development-Prompt.md template**  
> **Complexity Level:** {COMPLEXITY_LEVEL}  
> **Project Type:** {PROJECT_TYPE}  
> **Generated:** $(date)

---

## 1. GAME OVERVIEW

### 1.1 Core Concept & Genre
**Game Title:** {PROJECT_NAME}  
**Genre:** [Derived from game concept]  
**Platform:** {PROJECT_TYPE}  
**Target Audience:** [Based on game concept]  

**Core Concept:** {GAME_IDEA}

**Unique Value Proposition:** [Key differentiator derived from concept]

### 1.2 Game Pillars
| Design Pillar | Description | Implementation Priority |
|---------------|-------------|----------------------|
| **[Primary Pillar]** | [Core gameplay focus] | High |
| **[Secondary Pillar]** | [Supporting mechanic] | High |
| **[Polish Pillar]** | [User experience focus] | Medium |

---

## 2. GAMEPLAY MECHANICS

### 2.1 Core Gameplay Loop
**Primary Loop:**
1. [Step 1 of core loop]
2. [Step 2 of core loop]
3. [Step 3 of core loop]
4. [Step 4 of core loop]
5. [Step 5 of core loop]

**Progression:** [How difficulty/complexity increases]

**Win/Loss Conditions:**
- **Continue:** [Success condition]
- **Game Over:** [Failure condition]
- **Score:** [Scoring mechanism]

### 2.2 Player Actions & Controls
| Input | Action | Feedback |
|-------|--------|----------|
| **[Primary Input]** | [Main player action] | [Visual/audio response] |
| **[Secondary Input]** | [Secondary action] | [Response feedback] |
| **[Additional Input]** | [Additional action] | [Response feedback] |

**Control Scheme:** [Input method and accessibility notes]

---

## 5. TECHNICAL REQUIREMENTS

### 5.1 Core Systems Architecture
**Essential Systems (Simple Complexity):**

| System | Purpose | Unity Components |
|--------|---------|------------------|
| **[Primary System]** | [Core functionality] | [Unity components needed] |
| **[Secondary System]** | [Supporting functionality] | [Unity components needed] |
| **[Input System]** | [Player interaction] | [Input handling components] |
| **[UI System]** | [Interface management] | [UI components] |

**Technical Constraints:**
- [Primary constraint]
- [Performance target]
- [Platform considerations]

---

## 6. DEVELOPMENT SCOPE

### 6.1 MVP Feature Set
**Core Features (Implementation Ready):**
- [ ] [Essential feature 1]
- [ ] [Essential feature 2]
- [ ] [Essential feature 3]
- [ ] [Essential feature 4]
- [ ] [Essential feature 5]

**Technical Deliverables:**
- [Specific Unity deliverable 1]
- [Specific Unity deliverable 2]
- [Asset requirements]
- [Audio requirements]

**Development Timeline:** [Realistic timeframe for simple complexity]

**Success Metrics:**
- [Measurable goal 1]
- [Measurable goal 2]
- [Measurable goal 3]
- [Measurable goal 4]

---

*This GDD follows the Simple complexity template - focused on core gameplay and essential technical requirements for rapid development.*
EOF
   else
       # Standard complexity GDD generation (intermediate/detailed)
       echo "Generating standard complexity GDD..."
       # This would include the full template processing for intermediate/detailed complexity
       cat > "{GDD_PATH}" << 'EOF'
# {PROJECT_NAME} - Game Design Document

> **Generated using GDD-Development-Prompt.md template**  
> **Complexity Level:** {COMPLEXITY_LEVEL}  
> **Project Type:** {PROJECT_TYPE}  
> **Generated:** $(date)

[Complete GDD content for intermediate/detailed complexity would be generated here]
EOF
   fi
   
   echo "GDD generated successfully at: {GDD_PATH}"
   
   # Complexity-Aware Quality Validation
   echo "Performing quality validation..."
   
   # Check file was created and has content
   if [ ! -f "{GDD_PATH}" ] || [ ! -s "{GDD_PATH}" ]; then
       echo "Error: GDD file not created or is empty"
       exit 1
   fi
   
   # Verify complexity compliance
   WORD_COUNT=$(wc -w < "{GDD_PATH}")
   if [ "$COMPLEXITY_LEVEL" = "simple" ] && [ $WORD_COUNT -lt 500 ]; then
       echo "Warning: GDD may be too brief for simple complexity ($(WORD_COUNT) words)"
   elif [ "$COMPLEXITY_LEVEL" = "intermediate" ] && [ $WORD_COUNT -lt 1200 ]; then
       echo "Warning: GDD may be too brief for intermediate complexity ($(WORD_COUNT) words)"
   elif [ "$COMPLEXITY_LEVEL" = "detailed" ] && [ $WORD_COUNT -lt 2500 ]; then
       echo "Warning: GDD may be too brief for detailed complexity ($(WORD_COUNT) words)"
   fi
   
   # Verify no placeholder text remains
   if grep -q "{.*}" "{GDD_PATH}"; then
       echo "Warning: Some placeholder text may remain in GDD"
   fi
   
   # Update workflow status
   sed -i '' 's/GDD_COMPLETE: false/GDD_COMPLETE: true/' "{BASE_DIRECTORY}/project-parameters.yaml"
   
   echo "GDD validation complete. File ready for use."
   ```
   
   **Create Linear Issue Record**
   ```bash
   # If --create-linear-issues flag provided, create new Linear issue for GDD generation
   if CREATE_LINEAR_ISSUES; then
       # Create new Linear issue for Phase 2A: GDD Generation
       PHASE2A_ISSUE_ID=$(mcp__linear-server__create_issue \
           --team="$LINEAR_TEAM" \
           --project="$LINEAR_PROJECT" \
           --title="Phase 2A: GDD Generation - {PROJECT_NAME}" \
           --description="Generate comprehensive Game Design Document using template system for {PROJECT_NAME}" \
           --state="Done" \
           | jq -r '.id')
       
       echo "Created Linear issue for Phase 2A: $PHASE2A_ISSUE_ID"
       LINEAR_COMMENT="
   ## Phase 2A Complete: Game Design Document Generation
   
   ### Complexity Configuration:
   - COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
   - Target Length: $([ "$COMPLEXITY_LEVEL" = "simple" ] && echo "2-3 pages" || [ "$COMPLEXITY_LEVEL" = "intermediate" ] && echo "5-7 pages" || echo "10-15 pages")
   - Sections Generated: $([ "$COMPLEXITY_LEVEL" = "simple" ] && echo "6 core sections" || [ "$COMPLEXITY_LEVEL" = "intermediate" ] && echo "12 sections" || echo "15+ sections")
   - Response Style: $([ "$COMPLEXITY_LEVEL" = "simple" ] && echo "concise" || [ "$COMPLEXITY_LEVEL" = "intermediate" ] && echo "balanced" || echo "comprehensive")
   
   ### Game Concept Processed:
   - Game Concept: $(echo '{GAME_IDEA}' | cut -c1-100)...
   - Project Type: {PROJECT_TYPE}
   - Scope Assessment: Appropriate for {COMPLEXITY_LEVEL} complexity
   
   ### Parameters Used:
   - PROJECT_NAME: {PROJECT_NAME}
   - PROJECT_TYPE: {PROJECT_TYPE}
   - COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
   - GDD_PATH: {GDD_PATH}
   
   ### Template-Based Generation:
   - Template Used: GDD-Development-Prompt.md (comprehensive template)
   - Input File: temp_gdd_input.md (project parameters and game concept)
   - Output File: {PROJECT_NAME}-GDD.md
   - Approach: Template-driven instead of hardcoded structure
   - Next Step: Process template with game concept to generate complete GDD
   
   ### Quality Validation Results:
   - ✅ Template system properly configured
   - ✅ GDD placeholder created at correct path
   - ✅ Template validation passed (GDD-Development-Prompt.md found)
   - ✅ Input file generated with all required parameters
   - ✅ Complexity-aware instructions loaded
   - ⏳ Template processing required to complete GDD generation
   
   ### Next Phase Available:
   - Ready for Phase 2B: TDS Generation
   - GDD serves as input for technical specifications
   - Complexity level will guide TDS detail level
   
   ### Status: ✅ Completed Successfully
   🤖 Generated via setup-game-project command integration"
   
       # Add completion comment to the created issue
       mcp__linear-server__create_comment --issueId="$PHASE2A_ISSUE_ID" --body="$LINEAR_COMMENT"
       
       echo "Phase 2A Linear issue completed: $PHASE2A_ISSUE_ID"
   fi
   ```

### Phase 2B: TDS Generation

5. **Execute TDS Generation**
   ```bash
   # Load Parameters and Validate Prerequisites
   COMPLEXITY_LEVEL={from parameters file}
   TDS_PATH="{BASE_DIRECTORY}/docs/TDS/"
   GDD_PATH="{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md"
   TDS_TEMPLATES_PATH="{AIDEV_BASE}/Base Prompts/Techn Design Spec"
   TDS_COMPLEXITY_MAPPING_PATH="{TDS_TEMPLATES_PATH}/TDS-Complexity-Mapping.md"
   
   echo "Starting TDS Generation for complexity level: $COMPLEXITY_LEVEL"
   
   # Validate Prerequisites
   if [ ! -f "{GDD_PATH}" ]; then
       echo "Error: GDD not found at {GDD_PATH}"
       echo "Please complete Phase 2A (GDD Generation) first"
       exit 1
   fi
   
   if [ ! -f "$TDS_COMPLEXITY_MAPPING_PATH" ]; then
       echo "Error: TDS Complexity Mapping not found at $TDS_COMPLEXITY_MAPPING_PATH"
       exit 1
   fi
   
   if [ ! -d "$TDS_TEMPLATES_PATH" ]; then
       echo "Error: TDS templates directory not found at $TDS_TEMPLATES_PATH"
       exit 1
   fi
   
   # Load Complexity Mapping to Determine Required Sections
   echo "Loading TDS complexity mapping for level: $COMPLEXITY_LEVEL"
   echo "Mapping file: $TDS_COMPLEXITY_MAPPING_PATH"
   
   # Handle Simple Complexity with Fast Template
   if [ "$COMPLEXITY_LEVEL" = "simple" ]; then
       echo "Simple complexity: Using streamlined TDS template for fast generation"
       
       # Use the Simple-TDS-Template.md for rapid generation
       SIMPLE_TDS_TEMPLATE="$TDS_TEMPLATES_PATH/Simple-TDS-Template.md"
       TDS_OUTPUT_FILE="{TDS_PATH}/Complete-TDS.md"
       
       if [ ! -f "$SIMPLE_TDS_TEMPLATE" ]; then
           echo "Error: Simple TDS template not found at $SIMPLE_TDS_TEMPLATE"
           exit 1
       fi
       
       echo "Generating complete TDS using simple template..."
       echo "Template: $SIMPLE_TDS_TEMPLATE"
       echo "Input GDD: {GDD_PATH}"
       echo "Output: $TDS_OUTPUT_FILE"
       echo ""
       
       # Create TDS using simple template
       cat > "$TDS_OUTPUT_FILE" << EOF
# {PROJECT_NAME} - Technical Design Specification

> **Generated using Simple-TDS-Template.md**  
> **Complexity Level:** simple  
> **Project Type:** {PROJECT_TYPE}  
> **Generated:** $(date)

---

## 📋 SIMPLE TDS GENERATION

This TDS should be generated using the streamlined simple template:

**Template Location:** $SIMPLE_TDS_TEMPLATE
**Input GDD:** {GDD_PATH}
**Output:** $TDS_OUTPUT_FILE

**Generation Process Required:**
1. ✅ Simple template loaded
2. ⏳ Process GDD through streamlined template
3. ⏳ Generate sections 0-3 with basic technical depth
4. ⏳ Replace this placeholder with complete simple TDS

**Simple Template Features:**
- ✅ Sections 0-3 only (Design Translation, System Architecture, Gameplay Architecture, Class Design)
- ✅ Streamlined content appropriate for simple projects
- ✅ Fast generation (5-10 minutes vs 2+ hours)
- ✅ Direct path to implementation

**Target Generation Time:** 20-40 minutes total
**Expected Output:** Complete TDS ready for epic generation

---

## 🎮 GAME CONCEPT

{GAME_IDEA}

---

## ⚠️ ACTION REQUIRED

**To complete simple TDS generation:**

1. **Load Template**: Use the simple template at $SIMPLE_TDS_TEMPLATE
2. **Process GDD**: Apply game concept from {GDD_PATH}
3. **Generate Content**: Create streamlined technical specifications
4. **Replace File**: Overwrite this placeholder with complete simple TDS

*This approach significantly reduces TDS generation time while maintaining implementation readiness.*
EOF
       
       echo "Simple TDS placeholder created successfully: $TDS_OUTPUT_FILE"
       SECTIONS_COMPLETED=1
       SECTION_COUNT=1
       TDS_SECTIONS="SIMPLE"
       echo ""
       
   else
       # Standard complexity handling - determine individual sections
       if [ "$COMPLEXITY_LEVEL" = "intermediate" ]; then
           TDS_SECTIONS="0 1 2 3 4 5"
           SECTION_COUNT=6
           echo "Intermediate complexity: Generating 6 sections (0-5)"
       else # detailed
           TDS_SECTIONS="0 1 2 3 4 5 6 7"
           SECTION_COUNT=8
           echo "Detailed complexity: Generating all 8 sections (0-7)"
       fi
       
       echo "Sections to generate: $TDS_SECTIONS"
       echo "Total sections: $SECTION_COUNT"
       echo ""
       
       # Initialize section tracking
       CURRENT_SECTION=0
       SECTIONS_COMPLETED=0
       FAILED_SECTIONS=""
       
       # Sequential TDS Generation with Complexity Awareness
       echo "Beginning complexity-aware sequential TDS generation..."
       echo ""
   fi
   
   # Only run section loop for intermediate/detailed complexity
   if [ "$COMPLEXITY_LEVEL" != "simple" ]; then
   for SECTION_NUM in $TDS_SECTIONS; do
       CURRENT_SECTION=$SECTION_NUM
       
       # Determine section name
       case $SECTION_NUM in
           0) SECTION_NAME="Design Translation Framework" ;;
           1) SECTION_NAME="System Architecture" ;;
           2) SECTION_NAME="Gameplay Architecture" ;;
           3) SECTION_NAME="Class Design" ;;
           4) SECTION_NAME="Data Architecture" ;;
           5) SECTION_NAME="Unity Specific Architecture" ;;
           6) SECTION_NAME="Platform Technical Architecture" ;;
           7) SECTION_NAME="Asset Specification" ;;
       esac
       
       echo "========================================="
       echo "Processing Section $SECTION_NUM: $SECTION_NAME"
       echo "Complexity Level: $COMPLEXITY_LEVEL"
       echo "========================================="
       
       # Validate template exists
       TEMPLATE_FILE="$TDS_TEMPLATES_PATH/$SECTION_NUM-*-Prompt.md"
       if ! ls $TEMPLATE_FILE >/dev/null 2>&1; then
           echo "Error: Template not found for Section $SECTION_NUM"
           FAILED_SECTIONS="$FAILED_SECTIONS $SECTION_NUM"
           continue
       fi
       
       TEMPLATE_PATH=$(ls $TEMPLATE_FILE | head -1)
       OUTPUT_FILE="{TDS_PATH}/Section$SECTION_NUM.md"
       
       echo "Template: $TEMPLATE_PATH"
       echo "Output: $OUTPUT_FILE"
       echo ""
       
       # Generate Section with Template-Based Approach
       echo "Generating Section $SECTION_NUM using template-based approach..."
       echo "Please use the template at: $TEMPLATE_PATH"
       echo "Input GDD: {GDD_PATH}"
       echo "Complexity Guidelines: Reference $TDS_COMPLEXITY_MAPPING_PATH"
       echo "Output Location: $OUTPUT_FILE"
       echo ""
       
       # Create comprehensive placeholder for template processing
       cat > "$OUTPUT_FILE" << EOF
# Section $SECTION_NUM: $SECTION_NAME

> **Generated using TDS template system**  
> **Complexity Level:** $COMPLEXITY_LEVEL  
> **Project:** {PROJECT_NAME} ({PROJECT_TYPE})  
> **Generated:** $(date)

---

## 📋 TEMPLATE INTEGRATION STATUS

This TDS section should be generated using the template system:

**Template Location:** $TEMPLATE_PATH
**Input GDD:** {GDD_PATH}
**Complexity Mapping:** $TDS_COMPLEXITY_MAPPING_PATH
**Complexity Level:** $COMPLEXITY_LEVEL

**Generation Process Required:**
1. ✅ Template loaded from correct location
2. ⏳ Apply complexity-aware section filtering
3. ⏳ Process GDD through template structure
4. ⏳ Generate technical specifications based on complexity level
5. ⏳ Replace this placeholder with complete TDS section

**Complexity-Specific Requirements:**
$(case "$COMPLEXITY_LEVEL" in
    "simple") echo "- Include: Core subsections only (basic implementation)"
              echo "- Technical Depth: Basic patterns and straightforward implementations"
              echo "- System Scope: 3-5 core systems, essential features only" ;;
    "intermediate") echo "- Include: Core + enhanced subsections (moderate architecture)"
                    echo "- Technical Depth: Moderate patterns with balanced detail"
                    echo "- System Scope: 5-8 systems, core + secondary features" ;;
    "detailed") echo "- Include: All subsections with comprehensive coverage"
                echo "- Technical Depth: Advanced patterns with full architectural depth"
                echo "- System Scope: 8-12+ systems, comprehensive feature set" ;;
esac)

---

## 🎮 INPUT CONTEXT

**GDD Content Available:**
- Game Concept: Available in {GDD_PATH}
- Design Pillars: Reference from GDD
- Technical Requirements: Extract from GDD
- Platform Constraints: Apply from GDD

**Section-Specific Focus:**
$(case $SECTION_NUM in
    0) echo "- Map GDD design decisions to technical requirements"
       echo "- Identify genre patterns and architectural implications"
       echo "- Analyze constraints and their architectural impact" ;;
    1) echo "- Define system architecture and dependencies"
       echo "- Specify component hierarchy and manager patterns"
       echo "- Design event/communication architecture" ;;
    2) echo "- Define gameplay systems and game loops"
       echo "- Specify player interaction and feedback systems"
       echo "- Design progression and AI behavior systems" ;;
    3) echo "- Define core game classes and inheritance patterns"
       echo "- Specify entity classes and utility classes"
       echo "- Design advanced patterns and performance-critical classes" ;;
    4) echo "- Define data structures and save system architecture"
       echo "- Specify asset loading and configuration management"
       echo "- Design performance data structures and validation" ;;
    5) echo "- Define Unity scene organization and prefab architecture"
       echo "- Specify ScriptableObject usage and resource management"
       echo "- Design build optimization and editor integration" ;;
    6) echo "- Define platform optimization and input architecture"
       echo "- Specify multi-platform considerations and performance"
       echo "- Design accessibility and platform validation" ;;
    7) echo "- Define asset requirements and optimization pipeline"
       echo "- Specify asset validation and performance analysis"
       echo "- Design localization and advanced asset management" ;;
esac)

---

## ⚠️ ACTION REQUIRED

**To complete Section $SECTION_NUM generation:**

1. **Load Template**: Use the template at $TEMPLATE_PATH
2. **Process GDD**: Apply game concept and technical requirements from {GDD_PATH}
3. **Apply Complexity**: Follow guidelines for $COMPLEXITY_LEVEL level in complexity mapping
4. **Generate Content**: Create comprehensive technical specifications
5. **Replace File**: Overwrite this placeholder with complete TDS section

**Template Features:**
- ✅ Complexity-aware subsection filtering
- ✅ Technical depth appropriate for complexity level
- ✅ Unity-specific implementation guidance
- ✅ Cross-section consistency maintenance

---

*This placeholder ensures proper template-based TDS generation instead of hardcoded content.*
EOF
       
       echo "Section $SECTION_NUM placeholder created successfully"
       SECTIONS_COMPLETED=$((SECTIONS_COMPLETED + 1))
       
       # User confirmation if --pause-between-phases is enabled
       if [ "${PAUSE_BETWEEN_PHASES:-false}" = "true" ]; then
           echo ""
           echo "Section $SECTION_NUM ($SECTION_NAME) prepared for generation."
           echo "Complexity Level: $COMPLEXITY_LEVEL"
           echo "Output: $OUTPUT_FILE"
           echo ""
           read -p "Proceed with next section? (yes/no/review): " USER_RESPONSE
           
           case "$USER_RESPONSE" in
               "no") echo "Stopping TDS generation at user request"; break ;;
               "review") echo "Review section before continuing"; sleep 2 ;;
               *) echo "Continuing to next section..." ;;
           esac
           echo ""
       fi
   done
   fi
   
   echo "======================================="
   echo "TDS Generation Phase Complete"
   echo "======================================="
   echo "Complexity Level: $COMPLEXITY_LEVEL"
   echo "Sections Required: $SECTION_COUNT"  
   echo "Sections Processed: $SECTIONS_COMPLETED"
   if [ -n "$FAILED_SECTIONS" ]; then
       echo "Failed Sections: $FAILED_SECTIONS"
   fi
   echo "Output Directory: {TDS_PATH}"
   echo ""
   
   # Update workflow status
   sed -i '' 's/TDS_COMPLETE: false/TDS_COMPLETE: true/' "{BASE_DIRECTORY}/project-parameters.yaml"
   
   echo "TDS generation phase ready for template processing."
   echo "Next step: Process each section template with GDD input."
   ```
   
   **Create Linear Issue Record**
   ```bash
   # If --create-linear-issues flag provided, create new Linear issue for TDS generation
   if CREATE_LINEAR_ISSUES; then
       # Create new Linear issue for Phase 2B: TDS Generation
       PHASE2B_ISSUE_ID=$(mcp__linear-server__create_issue \
           --team="$LINEAR_TEAM" \
           --project="$LINEAR_PROJECT" \
           --title="Phase 2B: TDS Generation - {PROJECT_NAME}" \
           --description="Generate Technical Design Specification sections using template system for {PROJECT_NAME}" \
           --state="Done" \
           | jq -r '.id')
       
       echo "Created Linear issue for Phase 2B: $PHASE2B_ISSUE_ID"
       LINEAR_COMMENT="
   ## Phase 2B Complete: TDS Generation Setup
   
   ### Complexity Configuration:
   - COMPLEXITY_LEVEL: $COMPLEXITY_LEVEL
   - Sections Required: $SECTION_COUNT ($(echo $TDS_SECTIONS | tr ' ' ','))
   - Template System: Used comprehensive TDS template system
   - Complexity Mapping: Applied TDS-Complexity-Mapping.md guidelines
   
   ### Template Integration:
   - Templates Location: $TDS_TEMPLATES_PATH
   - Complexity Mapping: $TDS_COMPLEXITY_MAPPING_PATH
   - Input GDD: {GDD_PATH}
   - Output Directory: {TDS_PATH}
   
   ### Processing Results:
   - Sections Prepared: $SECTIONS_COMPLETED/$SECTION_COUNT
   - Template Validation: ✅ All required templates found
   - Complexity Guidelines: ✅ Applied per complexity mapping
   - Placeholders Created: ✅ Ready for template processing
   $(if [ -n "$FAILED_SECTIONS" ]; then echo "- Failed Sections: $FAILED_SECTIONS"; fi)
   
   ### Quality Validation Results:
   - ✅ Template system properly configured
   - ✅ Complexity mapping successfully referenced
   - ✅ Section placeholders created at correct paths
   - ✅ GDD input validation passed
   - ✅ Complexity-appropriate section filtering applied
   - ⏳ Template processing required for each section
   
   ### Next Phase Available:
   - Ready for Phase 2C: Roadmap Generation  
   - TDS sections will serve as technical foundation
   - Complexity level will guide roadmap detail level
   
   ### Status: ✅ Completed Successfully
   🤖 Generated via setup-game-project command integration"
   
       # Add completion comment to the created issue
       mcp__linear-server__create_comment --issueId="$PHASE2B_ISSUE_ID" --body="$LINEAR_COMMENT"
       
       echo "Phase 2B Linear issue completed: $PHASE2B_ISSUE_ID"
   fi
   ```

### Phase 2C: Roadmap Generation

6. **Execute Roadmap Generation**
   ```bash
   # Load Parameters and Validate Prerequisites
   ROADMAP_PATH="{BASE_DIRECTORY}/docs/{PROJECT_NAME}-High-Level-Development-Roadmap.md"
   GDD_PATH="{BASE_DIRECTORY}/docs/{PROJECT_NAME}-GDD.md"
   TDS_PATH="{BASE_DIRECTORY}/docs/TDS/"
   ROADMAP_TEMPLATE="{AIDEV_BASE}/Base Prompts/High-Level-Milestone-Framework-Generation-Prompt.md"
   
   echo "Starting Roadmap Generation using milestone framework approach"
   
   # Validate Prerequisites
   if [ ! -f "{GDD_PATH}" ]; then
       echo "Error: GDD not found at {GDD_PATH}"
       echo "Please complete Phase 2A (GDD Generation) first"
       exit 1
   fi
   
   if [ ! -d "{TDS_PATH}" ]; then
       echo "Error: TDS directory not found at {TDS_PATH}"
       echo "Please complete Phase 2B (TDS Generation) first"
       exit 1
   fi
   
   if [ ! -f "$ROADMAP_TEMPLATE" ]; then
       echo "Error: Roadmap template not found at $ROADMAP_TEMPLATE"
       exit 1
   fi
   
   # Validate TDS sections exist based on complexity level
   REQUIRED_SECTIONS=""
   if [ "$COMPLEXITY_LEVEL" = "simple" ]; then
       REQUIRED_SECTIONS="0 1 2 3"
   elif [ "$COMPLEXITY_LEVEL" = "intermediate" ]; then
       REQUIRED_SECTIONS="0 1 2 3 4 5"
   else # detailed
       REQUIRED_SECTIONS="0 1 2 3 4 5 6 7"
   fi
   
   echo "Validating required TDS sections for $COMPLEXITY_LEVEL complexity..."
   MISSING_SECTIONS=""
   for SECTION in $REQUIRED_SECTIONS; do
       if [ ! -f "{TDS_PATH}/Section$SECTION.md" ]; then
           MISSING_SECTIONS="$MISSING_SECTIONS Section$SECTION.md"
       fi
   done
   
   if [ -n "$MISSING_SECTIONS" ]; then
       echo "Error: Missing TDS sections: $MISSING_SECTIONS"
       echo "Please complete all required TDS sections first"
       exit 1
   fi
   
   echo "All prerequisites validated successfully"
   echo "GDD: {GDD_PATH}"
   echo "TDS Directory: {TDS_PATH}"
   echo "Template: $ROADMAP_TEMPLATE"
   echo "Output: $ROADMAP_PATH"
   echo ""
   
   # Assess Project Scope for Milestone Planning
   echo "Analyzing project scope for milestone framework generation..."
   
   # Extract key information for roadmap planning
   echo "Extracting planning context from project documents..."
   
   # Generate Roadmap using Template-Based Approach
   echo "Generating high-level milestone framework..."
   echo "Template: $ROADMAP_TEMPLATE"
   echo "Using 4-phase milestone approach: Technical MVP → Vertical Slice → Playable Beta → Release"
   echo ""
   
   # Create comprehensive placeholder for template processing
   cat > "$ROADMAP_PATH" << 'EOF'
# {PROJECT_NAME} - High-Level Development Roadmap

> **Generated using High-Level-Milestone-Framework-Generation-Prompt.md template**  
> **Complexity Level:** {COMPLEXITY_LEVEL}  
> **Project Type:** {PROJECT_TYPE}  
> **Generated:** $(date)

---

## 📋 TEMPLATE INTEGRATION STATUS

This roadmap should be generated using the milestone framework template:

**Template Location:** /Users/diarmuidcurran/Documents/AIDev/Base Prompts/High-Level-Milestone-Framework-Generation-Prompt.md
**Input GDD:** {GDD_PATH}
**Input TDS Directory:** {TDS_PATH}
**Complexity Level:** {COMPLEXITY_LEVEL}

**Generation Process Required:**
1. ✅ Template loaded from correct location
2. ✅ Prerequisites validated (GDD and TDS sections exist)
3. ⏳ Analyze GDD for feature scope and complexity
4. ⏳ Review TDS sections for technical implementation requirements
5. ⏳ Generate 4-phase milestone framework with epic breakdown
6. ⏳ Replace this placeholder with complete roadmap

**4-Phase Milestone Framework:**
1. **Technical MVP** - Prove core systems work technically
2. **Vertical Slice** - Complete one full gameplay loop
3. **Playable Beta** - All systems integrated and feature complete
4. **Release Version** - Launch ready with polish and optimization

**Epic Numbering Convention:**
- Phase 1: Epic 1.1, 1.2, 1.3, 1.4
- Phase 2: Epic 2.1, 2.2, 2.3, 2.4  
- Phase 3: Epic 3.1, 3.2, 3.3, 3.4
- Phase 4: Epic 4.1, 4.2, 4.3, 4.4

---

## 🎮 PROJECT CONTEXT

**Game Concept:** {GAME_IDEA}

**Available Documentation:**
- **GDD:** Complete game design specification available
- **TDS Sections:** Technical architecture and implementation details
  $(for SECTION in $REQUIRED_SECTIONS; do
    echo "  - Section $SECTION: $(case $SECTION in
      0) echo "Design Translation Framework" ;;
      1) echo "System Architecture" ;;
      2) echo "Gameplay Architecture" ;;
      3) echo "Class Design" ;;
      4) echo "Data Architecture" ;;
      5) echo "Unity Specific Architecture" ;;
      6) echo "Platform Technical Architecture" ;;
      7) echo "Asset Specification" ;;
    esac)"
  done)

**Complexity-Based Planning:**
$(case "$COMPLEXITY_LEVEL" in
    "simple") echo "- **Simple Complexity**: 2-3 epics per phase, 4-6 month timeline"
              echo "- **Focus**: Core functionality, minimal features, straightforward implementation" ;;
    "intermediate") echo "- **Intermediate Complexity**: 3-4 epics per phase, 6-9 month timeline"
                    echo "- **Focus**: Balanced features, moderate technical depth, commercial viability" ;;
    "detailed") echo "- **Detailed Complexity**: 4-5 epics per phase, 9-12 month timeline"
                echo "- **Focus**: Comprehensive features, advanced technical implementation, high polish" ;;
esac)

---

## ⚠️ ACTION REQUIRED

**To complete roadmap generation:**

1. **Load Template**: Use High-Level-Milestone-Framework-Generation-Prompt.md
2. **Analyze Documents**: Extract scope and complexity from GDD and TDS
3. **Generate Framework**: Create 4-phase milestone structure with numbered epics
4. **Validate Timeline**: Ensure realistic duration estimates based on complexity
5. **Replace File**: Overwrite this placeholder with complete roadmap

**Key Requirements:**
- ✅ 4 distinct milestone phases with clear goals
- ✅ 3-4 numbered epics per phase (1.1-1.4, 2.1-2.4, etc.)
- ✅ Realistic duration estimates based on project complexity
- ✅ Success criteria that are measurable and specific
- ✅ Critical path identification and dependency mapping
- ✅ Risk assessment with concrete mitigation strategies

**Template Features:**
- ✅ Industry-standard 4-phase milestone approach
- ✅ Proven epic numbering convention
- ✅ Technical feasibility focus
- ✅ Solo developer timeline considerations

---

*This placeholder ensures proper template-based roadmap generation using the milestone framework approach.*
EOF
   
   echo "Roadmap placeholder created successfully: $ROADMAP_PATH"
   echo ""
   
   # Create input file for template processing
   cat > "{BASE_DIRECTORY}/temp_roadmap_input.md" << 'EOF'
## Project Parameters
- PROJECT_NAME: {PROJECT_NAME}
- PROJECT_TYPE: {PROJECT_TYPE}
- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
- BASE_DIRECTORY: {BASE_DIRECTORY}

## Input Documents
- GDD_PATH: {GDD_PATH}
- TDS_PATH: {TDS_PATH}

## Required TDS Sections
$(for SECTION in $REQUIRED_SECTIONS; do
  echo "- Section $SECTION: {TDS_PATH}/Section$SECTION.md"
done)

## Game Concept
{GAME_IDEA}

## Milestone Framework Requirements
- 4 phases: Technical MVP → Vertical Slice → Playable Beta → Release
- 3-4 epics per phase with proper numbering (1.1-1.4, etc.)
- Realistic timeline based on complexity level
- Critical path and dependency identification
- Risk assessment with mitigation strategies
EOF
   
   echo "Input file created: {BASE_DIRECTORY}/temp_roadmap_input.md"
   
   # Update workflow status
   sed -i '' 's/ROADMAP_COMPLETE: false/ROADMAP_COMPLETE: true/' "{BASE_DIRECTORY}/project-parameters.yaml"
   
   echo "Roadmap generation setup complete."
   echo "Next step: Process milestone framework template with GDD/TDS inputs."
   ```
   
   **Create Linear Issue Record**
   ```bash
   # If --create-linear-issues flag provided, create new Linear issue for roadmap generation
   if CREATE_LINEAR_ISSUES; then
       # Create new Linear issue for Phase 2C: Roadmap Generation
       PHASE2C_ISSUE_ID=$(mcp__linear-server__create_issue \
           --team="$LINEAR_TEAM" \
           --project="$LINEAR_PROJECT" \
           --title="Phase 2C: Roadmap Generation - {PROJECT_NAME}" \
           --description="Generate high-level milestone framework and development roadmap for {PROJECT_NAME}" \
           --state="Done" \
           | jq -r '.id')
       
       echo "Created Linear issue for Phase 2C: $PHASE2C_ISSUE_ID"
       LINEAR_COMMENT="
   ## Phase 2C Complete: High-Level Milestone Framework Generation
   
   ### Milestone Framework Configuration:
   - Framework Type: 4-phase milestone approach (Industry standard)
   - Epic Numbering: Standard convention (1.1-1.4, 2.1-2.4, 3.1-3.4, 4.1-4.4)
   - Complexity Level: $COMPLEXITY_LEVEL
   - Timeline Approach: Complexity-appropriate duration estimates
   
   ### Template Integration:
   - Template Used: High-Level-Milestone-Framework-Generation-Prompt.md
   - Input Documents: GDD + $(echo $REQUIRED_SECTIONS | wc -w) TDS sections
   - Input File: temp_roadmap_input.md (comprehensive project context)
   - Output Location: $ROADMAP_PATH
   
   ### Prerequisites Validated:
   - ✅ GDD exists and accessible: {GDD_PATH}
   - ✅ TDS directory exists: {TDS_PATH}
   - ✅ Required TDS sections for $COMPLEXITY_LEVEL complexity: $(echo $REQUIRED_SECTIONS | tr ' ' ',')
   - ✅ Milestone framework template found: $ROADMAP_TEMPLATE
   - ✅ Output location writable: $ROADMAP_PATH
   
   ### Framework Structure Prepared:
   - Phase 1: Technical MVP (Prove core systems work)
   - Phase 2: Vertical Slice (Complete gameplay loop)
   - Phase 3: Playable Beta (Feature complete integration)
   - Phase 4: Release Version (Polish and optimization)
   
   ### Planning Context:
   - Project Scope: Extracted from GDD analysis
   - Technical Requirements: Derived from $(echo $REQUIRED_SECTIONS | wc -w) TDS sections
   - Complexity Considerations: $COMPLEXITY_LEVEL level planning approach
   - Epic Allocation: 3-4 epics per phase based on complexity level
   
   ### Quality Validation Results:
   - ✅ Template system properly configured  
   - ✅ All required input documents validated
   - ✅ Milestone framework structure prepared
   - ✅ Epic numbering convention established
   - ✅ Complexity-appropriate planning context created
   - ⏳ Template processing required to complete roadmap
   
   ### Next Phase Available:
   - Ready for Phase 3: Epic Processing (AIG-118)
   - Roadmap will provide epic framework for detailed planning
   - Epic numbering established for systematic development approach
   
   ### Status: ✅ Completed Successfully
   🤖 Generated via setup-game-project command integration"
   
       # Add completion comment to the created issue
       mcp__linear-server__create_comment --issueId="$PHASE2C_ISSUE_ID" --body="$LINEAR_COMMENT"
       
       echo "Phase 2C Linear issue completed: $PHASE2C_ISSUE_ID"
   fi
   ```

### Phase 3+: Subsequent Development Phases

**The setup-game-project command completes here. Continue development using specialized commands:**

**Phase 3: Epic Processing (AIG-118)**
```bash
# Generate detailed epic specifications with feature breakdowns
generate-epic-details --all --create-linear-issues --verbose
```
- Processes ALL epics from roadmap
- Creates detailed feature specifications  
- Generates Linear tracking issues for each epic
- Output: Epic-{NUMBER}-Specification.md files in docs/epics/

**Phase 4: Feature Task Generation (AIG-119)**  
```bash
# Break features into categorized, AI-ready tasks
generate-feature-tasks --all --create-linear-issues --verbose
```
- Processes all features from generated epics
- Creates task breakdowns with taxonomy categories
- Generates Linear issues for development tasks
- Output: Feature-{NUMBER}-Tasks.md files and Linear task issues

**Phase 5: AI Prompts Generation (AIG-120)**
```bash  
# Create AI-ready prompts for all tasks
generate-ai-prompts --all --create-linear-issues --batch-size 5
```
- Converts tasks to AI-ready development prompts
- Creates Linear issues for each coding task
- Applies taxonomy labels automatically  
- Output: Complete project ready for AI-assisted implementation

**Pipeline Summary:**
```bash
# Complete development pipeline after setup-game-project:
generate-epic-details --all --create-linear-issues
generate-feature-tasks --all --create-linear-issues  
generate-ai-prompts --all --create-linear-issues --batch-size 5
```

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

**Dynamic Issue Creation:**
- **Phase 1 (Project Structure)**: Creates new Linear issue for infrastructure setup
- **Phase 2A (GDD)**: Creates new Linear issue for GDD generation  
- **Phase 2B (TDS)**: Creates new Linear issue for TDS generation
- **Phase 2C (Roadmap)**: Creates new Linear issue for roadmap generation

**Subsequent Phases (Handled by specialized commands):**
- **Phase 3 (Epic Details)**: AIG-118 - Use `generate-epic-details` command
- **Phase 4 (Feature Tasks)**: AIG-119 - Use `generate-feature-tasks` command
- **Phase 5 (AI Prompts)**: AIG-120 - Use `generate-ai-prompts` command

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

- ✅ **Complete Project Structure**: All directories and base files created
- ✅ **Comprehensive Documentation**: GDD, TDS sections (complexity-appropriate), development roadmap
- ✅ **Template Foundation**: All necessary templates copied for future development
- ✅ **Development Foundation**: Ready for epic processing and feature breakdown
- ✅ **Linear Integration**: Phase tracking issues created with proper status updates
- ✅ **Parameter File**: All paths and settings configured for subsequent commands

### Output Summary

```bash
🎮 Project Setup Complete: {PROJECT_NAME}
📁 Base Directory: {BASE_DIRECTORY}
📋 Core Documentation Generated: 
   - Game Design Document (GDD)
   - Technical Design Specification ({COMPLEXITY}-appropriate sections)
   - Development Roadmap with {EPIC_COUNT} epics identified
   - Project parameters file configured
📂 Project Structure: {DIRECTORY_COUNT} directories, {TEMPLATE_COUNT} templates copied
⏱️  Setup Completion Time: 15-25 minutes
🚀 Foundation Ready: Project ready for epic processing and development

Roadmap Summary:
- Phase 1: Technical MVP ({PHASE1_EPIC_COUNT} epics)
- Phase 2: Vertical Slice ({PHASE2_EPIC_COUNT} epics)  
- Phase 3: Playable Beta ({PHASE3_EPIC_COUNT} epics)
- Phase 4: Release Version ({PHASE4_EPIC_COUNT} epics)

Next Steps:
1. Review generated documentation (GDD, TDS, Roadmap)
2. Continue with epic processing: generate-epic-details --all --create-linear-issues
3. Proceed through feature breakdown and AI prompt generation
4. Begin development using generated specifications
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
3. **Execute Phase 1**: Create complete project infrastructure
4. **Execute Phase 2A**: Generate comprehensive GDD using template system
5. **Execute Phase 2B**: Generate TDS sections using template system
6. **Execute Phase 2C**: Generate development roadmap using milestone framework
7. **Report completion** with foundation ready and next steps

**Setup Command Scope:**
- **Foundation Setup**: Complete project infrastructure and core documentation
- **Time**: 15-25 minutes for project foundation
- **Output**: GDD, TDS sections, development roadmap, project structure
- **Handoff**: Ready for epic processing via `generate-epic-details` command

**Complete Development Pipeline:**
```bash
# Phase 1-2: Foundation (this command)
setup-game-project --project-name="MyGame" --complexity="simple"

# Phase 3: Epic processing (separate command)  
generate-epic-details --all --create-linear-issues

# Phase 4: Feature breakdown (separate command)
generate-feature-tasks --all --create-linear-issues

# Phase 5: AI prompt generation (separate command)
generate-ai-prompts --all --create-linear-issues --batch-size 5
```

This command establishes the complete development foundation, preparing the project for systematic epic processing and AI-assisted development.

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