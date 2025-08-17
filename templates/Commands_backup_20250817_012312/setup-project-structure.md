# Setup Project Structure Command

## Purpose
Create a clean, simplified Unity game project folder structure with all necessary directories and configuration files. This command establishes the foundation for your game development project without generating any documentation.

## Prerequisites
- ✅ You have manually copied and customized project-parameters.yaml in the project folder
- ✅ Base directory path is accessible and writable
- ✅ Project name is valid (no special characters)
- ✅ Base parameters template available at `/Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml`

## Usage

### Standard Usage
```bash
# Create project structure with all parameters
setup-project-structure --project-name="MyGame" --project-type="Unity2D" --base-dir="/path/to/projects" --complexity="intermediate"

# Minimal usage (uses defaults)
setup-project-structure --project-name="MyGame"
```

### Advanced Options
```bash
# Dry run to preview what will be created
setup-project-structure --project-name="MyGame" --dry-run

# Skip template copying (structure only)
setup-project-structure --project-name="MyGame" --skip-templates

# Create Linear tracking issue
setup-project-structure --project-name="MyGame" --create-linear-issue

# Verbose output
setup-project-structure --project-name="MyGame" --verbose
```

## Command Parameters

### Required
- `--project-name` : Clean project name (e.g., "ColorMemory3")

### Recommended
- `--project-type` : Unity project type ("Unity2D" or "Unity3D") - default: "Unity2D"
- `--base-dir` : Base directory for project - default: current directory
- `--complexity` : Project complexity ("simple", "intermediate", "detailed") - default: "intermediate"

### Optional
- `--dry-run` : Preview structure without creating files
- `--skip-templates` : Don't copy template files
- `--create-linear-issue` : Create Linear tracking issue
- `--verbose` : Detailed output
- `--game-idea` : Game concept (can be added to parameters file)

## Implementation

You are a specialized project setup assistant. When the user invokes this command, create a clean, organized Unity game project structure.

### Phase 1: Parameter Validation and Setup

```bash
# Enhanced Parameter Validation for Project Setup
validate_setup_parameters() {
    local PROJECT_NAME="$1"
    local PROJECT_TYPE="$2"
    local BASE_DIRECTORY="$3"
    local COMPLEXITY_LEVEL="$4"
    
    echo "🔍 Validating project setup parameters..."
    
    # Validate project name
    if [[ ! "$PROJECT_NAME" =~ ^[a-zA-Z0-9_-]+$ ]]; then
        echo "❌ ERROR: Project name must contain only letters, numbers, underscores, and hyphens"
        echo "   Invalid name: '$PROJECT_NAME'"
        return 1
    fi
    
    # Validate project type
    if [[ "$PROJECT_TYPE" != "Unity2D" && "$PROJECT_TYPE" != "Unity3D" ]]; then
        echo "❌ ERROR: Project type must be 'Unity2D' or 'Unity3D'"
        echo "   Found: '$PROJECT_TYPE'"
        return 1
    fi
    
    # Validate base directory
    if [ ! -d "$BASE_DIRECTORY" ]; then
        echo "❌ ERROR: Base directory does not exist: $BASE_DIRECTORY"
        return 1
    fi
    
    if [ ! -w "$BASE_DIRECTORY" ]; then
        echo "❌ ERROR: Base directory is not writable: $BASE_DIRECTORY"
        return 1
    fi
    
    # Validate complexity level
    case "$COMPLEXITY_LEVEL" in
        "simple"|"intermediate"|"detailed")
            echo "✅ Valid complexity level: $COMPLEXITY_LEVEL"
            ;;
        *)
            echo "❌ ERROR: Invalid complexity level: $COMPLEXITY_LEVEL"
            echo "   Valid options: simple, intermediate, detailed"
            return 1
            ;;
    esac
    
    echo "✅ Parameter validation passed"
    return 0
}

# Load and validate parameters
PROJECT_NAME={from --project-name, required}
PROJECT_TYPE={from --project-type or default "Unity2D"}
BASE_DIRECTORY={from --base-dir or current directory}
COMPLEXITY_LEVEL={from --complexity or default "intermediate"}
GAME_IDEA={from --game-idea, optional}

# Validate all parameters before proceeding
if ! validate_setup_parameters "$PROJECT_NAME" "$PROJECT_TYPE" "$BASE_DIRECTORY" "$COMPLEXITY_LEVEL"; then
    echo "❌ Parameter validation failed. Please fix the issues above."
    exit 1
fi

# Set project path
PROJECT_PATH="$BASE_DIRECTORY/$PROJECT_NAME"

# Check if project already exists
if [ -d "$PROJECT_PATH" ] && [ ! "--force" specified ]; then
    echo "❌ ERROR: Project directory already exists: $PROJECT_PATH"
    echo "💡 Use --force to overwrite, or choose a different project name"
    exit 1
fi

echo "📋 Project Setup Configuration:"
echo "   - Name: $PROJECT_NAME"
echo "   - Type: $PROJECT_TYPE"
echo "   - Complexity: $COMPLEXITY_LEVEL"
echo "   - Location: $PROJECT_PATH"
```

### Phase 2: Directory Structure Creation

```bash
# Create simplified directory structure
echo "Creating project structure at: {PROJECT_PATH}"

# Main project directory
mkdir -p "{PROJECT_PATH}"

# Documentation directories
mkdir -p "{PROJECT_PATH}/docs"
mkdir -p "{PROJECT_PATH}/docs/TDS"
mkdir -p "{PROJECT_PATH}/docs/epics"
mkdir -p "{PROJECT_PATH}/docs/tasks"
mkdir -p "{PROJECT_PATH}/docs/prompts"

# Template directories
mkdir -p "{PROJECT_PATH}/templates"
mkdir -p "{PROJECT_PATH}/templates/TDS"
mkdir -p "{PROJECT_PATH}/templates/GDD"
mkdir -p "{PROJECT_PATH}/templates/Prompts"

echo "✅ Directory structure created successfully"
```

### Phase 3: Template Copying

```bash
# Copy essential templates from base location
if [ "--skip-templates" not specified ]; then
    AIDEV_BASE="/Users/diarmuidcurran/Documents/AIDev"
    
    # Copy TDS templates
    if [ -d "{AIDEV_BASE}/Base Prompts/Techn Design Spec" ]; then
        cp -r "{AIDEV_BASE}/Base Prompts/Techn Design Spec"/*.md "{PROJECT_PATH}/templates/TDS/" 2>/dev/null
        echo "✅ TDS templates copied"
    fi
    
    # Copy GDD templates
    if [ -d "{AIDEV_BASE}/Base Prompts/GDD" ]; then
        cp -r "{AIDEV_BASE}/Base Prompts/GDD"/*.md "{PROJECT_PATH}/templates/GDD/" 2>/dev/null
        echo "✅ GDD templates copied"
    fi
    
    # Copy prompt templates
    if [ -d "{AIDEV_BASE}/Base Prompts" ]; then
        cp "{AIDEV_BASE}/Base Prompts"/*.md "{PROJECT_PATH}/templates/Prompts/" 2>/dev/null
        echo "✅ Prompt templates copied"
    fi
fi
```

### Phase 4: Configuration File Validation

```bash
# Validate project parameters file exists (user should copy and edit manually)
PARAMS_FILE="{PROJECT_PATH}/project-parameters.yaml"

if [ ! -f "$PARAMS_FILE" ]; then
    echo "❌ Error: project-parameters.yaml not found at {PROJECT_PATH}"
    echo ""
    echo "Please follow these steps:"
    echo "1. Copy the base parameters template:"
    echo "   cp '/Users/diarmuidcurran/Documents/AIDev/Base Prompts/0_Params/project-parameters.yaml' '{PROJECT_PATH}/project-parameters.yaml'"
    echo "2. Edit {PROJECT_PATH}/project-parameters.yaml to customize:"
    echo "   - PROJECT_NAME: {PROJECT_NAME}"
    echo "   - PROJECT_TYPE: {PROJECT_TYPE}"
    echo "   - COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}"
    echo "   - GAME_IDEA: [Your game concept]"
    echo "3. Run this command again"
    exit 1
fi

# Load and validate key parameters
echo "✅ Found project parameters file"
echo "📋 Validating configuration..."

# Basic validation that required fields exist
if ! grep -q "PROJECT_NAME:" "$PARAMS_FILE"; then
    echo "⚠️ Warning: PROJECT_NAME not found in parameters file"
fi

if ! grep -q "GAME_IDEA:" "$PARAMS_FILE"; then
    echo "⚠️ Warning: GAME_IDEA not found in parameters file"
fi

# Update structure completion status
sed -i '' 's/STRUCTURE_COMPLETE: .*/STRUCTURE_COMPLETE: true/' "$PARAMS_FILE" 2>/dev/null || echo "✅ Parameters file validated"

echo "✅ Project parameters validated"
```

### Phase 5: README Generation

```bash
# Create project README
cat > "{PROJECT_PATH}/README.md" << EOF
# {PROJECT_NAME}

**Type:** {PROJECT_TYPE}
**Complexity:** {COMPLEXITY_LEVEL}
**Created:** $(date)

## Project Structure

\`\`\`
{PROJECT_NAME}/
├── docs/                      # All project documentation
│   ├── {PROJECT_NAME}-GDD.md # Game Design Document
│   ├── {PROJECT_NAME}-Roadmap.md # Development Roadmap
│   ├── TDS/                  # Technical Design Specifications
│   │   └── Section[0-7].md   # TDS sections (based on complexity)
│   ├── epics/                # Epic specifications
│   │   └── Epic-X.X-Specification.md
│   ├── tasks/                # Feature task breakdowns
│   │   └── Feature-X.X.X-Tasks.md
│   └── prompts/              # AI implementation prompts
│       └── Task-X.X.X.X-Prompt.md
├── templates/                 # Reference templates (copied from base)
│   ├── TDS/                  # TDS section templates
│   ├── GDD/                  # Game design templates
│   └── Prompts/              # AI prompt templates
├── project-parameters.yaml   # Project configuration
└── README.md                 # This file
\`\`\`

## Development Workflow

### Phase 1: Project Setup ✅
- Project structure created
- Templates copied
- Configuration initialized

### Phase 2: Documentation Generation
Run \`generate-game-documents\` to create:
- Game Design Document (GDD)
- Technical Design Specification (TDS)
- Development Roadmap

### Phase 3: Epic Processing
Run \`generate-epic-details --all\` to create detailed epic specifications

### Phase 4: Task Generation
Run \`generate-feature-tasks --all\` to break features into tasks

### Phase 5: AI Prompts
Run \`generate-ai-prompts --all\` to create implementation prompts

## Configuration

Project settings are stored in \`project-parameters.yaml\`

## Next Steps

1. The project structure is ready
2. Parameters file has been validated
3. Run \`generate-game-documents\` to create foundational documentation
4. Continue with the development workflow

---
Generated by setup-project-structure command
EOF

echo "✅ README created"
```

### Phase 6: Verification and Reporting

```bash
# Verify structure creation
echo ""
echo "================================================================================
🎉 PROJECT STRUCTURE CREATED SUCCESSFULLY
================================================================================

📁 Project Location: {PROJECT_PATH}

📋 Configuration:
   - Project Name: {PROJECT_NAME}
   - Project Type: {PROJECT_TYPE}
   - Complexity: {COMPLEXITY_LEVEL}
   - Parameters File: ✅ Created

📂 Directory Structure:
   - Documentation: ✅ docs/ (main documentation folder)
     - TDS: ✅ docs/TDS/ (technical specifications)
     - Epics: ✅ docs/epics/ (epic specifications)
     - Tasks: ✅ docs/tasks/ (task breakdowns)
     - Prompts: ✅ docs/prompts/ (AI prompts)
   - Templates: ✅ templates/ (reference templates)

📄 Files Created:
   - project-parameters.yaml: ✅ Configuration file
   - README.md: ✅ Project documentation
   - Templates: $(find "{PROJECT_PATH}/templates" -name "*.md" | wc -l) files copied

✅ Ready for Next Phase:
   Run 'generate-game-documents' to create GDD, TDS, and Roadmap

💡 Quick Start:
   cd {PROJECT_PATH}
   # Edit project-parameters.yaml to add GAME_IDEA
   generate-game-documents --all

================================================================================
"
```

### Dry-Run Mode Output

When `--dry-run` flag is used:

```
================================================================================
🔍 DRY-RUN MODE - Setup Project Structure
================================================================================

📋 PARAMETERS SUMMARY
--------------------
Project Name:     {PROJECT_NAME}
Project Type:     {PROJECT_TYPE}
Base Directory:   {BASE_DIRECTORY}
Complexity:       {COMPLEXITY_LEVEL}

📁 PROJECT STRUCTURE TO BE CREATED
----------------------------------
{PROJECT_PATH}/
├── 📁 docs/                      # All project documentation
│   ├── 📄 {PROJECT_NAME}-GDD.md  # Game Design Document
│   ├── 📄 {PROJECT_NAME}-Roadmap.md # Development Roadmap
│   ├── 📁 TDS/                   # Technical specifications
│   │   └── Section[0-7].md
│   ├── 📁 epics/                 # Epic specifications
│   ├── 📁 tasks/                 # Task breakdowns
│   └── 📁 prompts/               # AI prompts
├── 📁 templates/                  # Reference templates
│   ├── 📁 TDS/
│   ├── 📁 GDD/
│   └── 📁 Prompts/
├── 📄 project-parameters.yaml    # Configuration
└── 📄 README.md                  # Project overview

📂 DIRECTORIES TO CREATE
------------------------
Total Directories:    9
- Documentation:      5 (docs + 4 subdirs)
- Templates:         4 (templates + 3 subdirs)

📄 FILES TO CREATE
-----------------
- project-parameters.yaml (configuration file)
- README.md (project documentation)

📋 TEMPLATES TO COPY
-------------------
From: /Users/diarmuidcurran/Documents/AIDev/Base Prompts/
- TDS Templates: ~8 files (Section 0-7 templates)
- GDD Templates: ~2-3 files
- Prompt Templates: ~10-15 files

📊 CONFIGURATION PREVIEW
------------------------
project-parameters.yaml will include:
- PROJECT_NAME: {PROJECT_NAME}
- PROJECT_TYPE: {PROJECT_TYPE}
- BASE_DIRECTORY: {PROJECT_PATH}
- COMPLEXITY_LEVEL: {COMPLEXITY_LEVEL}
- SCOPE_CONFIG:
  - EPIC_COUNT: {Based on complexity}
  - FEATURES_PER_EPIC: {Based on complexity}
  - TASKS_PER_FEATURE: {Based on complexity}

✅ VALIDATION CHECKS
-------------------
[✓] Base directory exists and is writable
[✓] Project name is valid (no special characters)
[✓] Complexity level is valid
[✓] Template source directory exists

================================================================================
🎯 DRY-RUN COMPLETE - No files created or modified
💡 Remove --dry-run flag to execute the setup
📊 Estimated time: < 1 minute for structure creation
================================================================================

Next Steps:
1. Run without --dry-run to create the structure
2. Edit project-parameters.yaml to add GAME_IDEA
3. Run 'generate-game-documents --all' to create documentation
```

### Linear Integration (Optional)

If `--create-linear-issue` flag is provided:

```bash
# Create Linear tracking issue
Create Linear issue with:
  - Title: "Project Structure Setup: {PROJECT_NAME}"
  - Description: "Created project structure and configuration for {PROJECT_NAME}"
  - Labels: ["setup", "infrastructure"]
  - State: "Done"
  
Issue content includes:
  - Project configuration details
  - Directory structure created
  - Templates copied
  - Next steps
```

## Examples

### Basic Setup
```bash
setup-project-structure --project-name="ColorMemory3"
```

### Full Configuration
```bash
setup-project-structure \
  --project-name="ColorMemory3" \
  --project-type="Unity2D" \
  --base-dir="/Users/user/Projects" \
  --complexity="simple"
```

### With Game Idea
```bash
setup-project-structure \
  --project-name="PuzzleQuest" \
  --game-idea="A match-3 puzzle game with RPG elements"
```

### Dry Run
```bash
setup-project-structure --project-name="TestGame" --dry-run
```

## Error Handling

### Common Issues

#### Base Directory Not Writable
```
ERROR: Cannot write to base directory: /path/to/dir
RESOLUTION: Check permissions or choose different location
```

#### Project Already Exists
```
ERROR: Project directory already exists: /path/to/project
RESOLUTION: Choose different name or remove existing directory
```

#### Templates Not Found
```
WARNING: Template directory not found
ACTION: Continuing without templates
RESOLUTION: Templates can be added manually later
```

## Output Structure

```
{PROJECT_NAME}/
├── docs/                      # All documentation
│   ├── {PROJECT_NAME}-GDD.md # Game Design Document
│   ├── {PROJECT_NAME}-Roadmap.md # Development Roadmap
│   ├── TDS/                  # Technical Design Specs
│   │   └── Section[0-7].md
│   ├── epics/                # Epic specifications
│   │   └── Epic-X.X-Specification.md
│   ├── tasks/                # Feature task breakdowns
│   │   └── Feature-X.X.X-Tasks.md
│   └── prompts/              # AI implementation prompts
│       └── Task-X.X.X.X-Prompt.md
├── templates/                 # Copied templates (reference)
│   ├── TDS/
│   ├── GDD/
│   └── Prompts/
├── project-parameters.yaml   # Configuration
└── README.md                 # Project overview
```

## Summary

This command creates a clean, simplified Unity game project structure focused on documentation and organization. It provides the foundation for the entire game development workflow without unnecessary folders or complexity.