# Execute Linear Issue Command

Automatically execute Linear issues containing embedded AI implementation prompts using Unity MCP tools and provide real-time progress tracking.

## Purpose

This command reads Linear issues with embedded AI prompts, extracts the executable prompt content, runs the implementation using Unity MCP tools, and updates the Linear issue with completion status and results.

## Prerequisites

- ✅ Linear MCP integration configured
- ✅ Unity MCP tools available (if implementing Unity tasks)
- ✅ Linear issues contain embedded prompts in standardized format
- ✅ Project context matches the Linear issue requirements

## Usage

### Basic Execution
```bash
# Execute a single Linear issue
execute-linear AIG-130

# Execute multiple issues in sequence
execute-linear AIG-130,AIG-131,AIG-132

# Execute with custom project context
execute-linear AIG-130 --project-path "/path/to/unity/project"
```

### Execution Options
```bash
# Dry run - show what would be executed without running
execute-linear AIG-130 --dry-run

# Verbose mode with detailed logging
execute-linear AIG-130 --verbose

# Skip Linear status updates (useful for testing)
execute-linear AIG-130 --no-linear-updates

# Force execution even if issue is already marked complete
execute-linear AIG-130 --force

# Execute with specific MCP validation level
execute-linear AIG-130 --validation-level strict

# Custom timeout for long-running tasks (in minutes)
execute-linear AIG-130 --timeout 15
```

### Status and Progress Options
```bash
# Update Linear issue status before execution
execute-linear AIG-130 --set-status "In Progress"

# Add custom completion comment
execute-linear AIG-130 --completion-message "Implementation completed with custom validation"

# Tag specific team members on completion
execute-linear AIG-130 --notify-users "diarmuidcurran01,teammate2"

# Create follow-up issue on completion
execute-linear AIG-130 --create-followup "Code Review Required"
```

### Unity-Specific Options
```bash
# Execute with specific Unity version validation
execute-linear AIG-130 --unity-version 2023.3

# Skip Unity console error checking
execute-linear AIG-130 --skip-unity-validation

# Generate Unity setup script as fallback
execute-linear AIG-130 --generate-fallback-script

# Custom Unity project validation
execute-linear AIG-130 --validate-unity-setup
```

## Command Parameters

### Required Parameters
- **Issue ID**: Linear issue identifier (e.g., AIG-130, PROJ-45)

### Selection Parameters
- `--issues [list]`: Comma-separated list of issue IDs
- `--project-path [path]`: Custom Unity project path (default: current directory)
- `--load-params [file]`: Load project parameters from YAML file (default: project-parameters.yaml)

### Execution Control
- `--dry-run`: Show execution plan without implementing
- `--force`: Execute even if issue marked complete
- `--timeout [minutes]`: Maximum execution time (default: 10 minutes)
- `--validation-level [none|basic|strict]`: MCP validation depth (default: basic)

### Linear Integration
- `--set-status [status]`: Update issue status before execution
- `--completion-message [text]`: Custom completion comment
- `--notify-users [list]`: Tag users on completion
- `--create-followup [title]`: Create follow-up issue
- `--no-linear-updates`: Skip all Linear status updates
- `--preserve-description`: Keep original issue description intact (default: true)

### Unity Options
- `--unity-version [version]`: Validate specific Unity version
- `--skip-unity-validation`: Skip Unity console error checking
- `--generate-fallback-script`: Create Editor script alternative
- `--validate-unity-setup`: Verify Unity project configuration
- `--exit-play-mode`: Force Unity to exit play mode after execution (default: true)

### Output Control
- `--verbose`: Detailed execution logging
- `--quiet`: Minimal output (errors only)
- `--output-format [text|json|markdown]`: Execution report format

## Execution Process

### 1. Issue Analysis
- Fetch Linear issue details using MCP
- Validate issue contains embedded prompt in expected format
- Extract prompt content from "📋 COPY-PASTE READY PROMPT:" section
- Parse task metadata (ID, priority, estimated duration)

### 2. Context Validation
- Verify Unity project context matches task requirements
- Check for prerequisite dependencies
- Validate MCP tools availability
- Confirm project file structure

### 3. Unity State Management & Execution
- **CRITICAL: Check Unity editor state (play mode, compilation status)**
- **Exit play mode if currently active (ensure clean state)**
- Execute extracted prompt using appropriate MCP tools
- Monitor Unity console for errors and warnings
- Track progress against success criteria from prompt
- **MANDATORY: Force Unity to exit play mode after any tests**
- Handle timeout and error conditions gracefully
- Verify Unity returns to edit mode before proceeding

### 4. Results Processing
- Validate implementation against success criteria
- Generate execution summary with metrics
- Capture any error logs or warnings
- Document deliverables created

### 5. Linear Updates & Project Association
- Load project configuration from project-parameters.yaml
- Add issue to associated Linear project (from LINEAR_PROJECT parameter)
- Update issue status to "In Review" or "Complete"
- **Add completion summary as COMMENT (preserves original description for reruns)**
- Attach execution logs and metrics to comment
- Create follow-up issues if specified
- Maintain issue description integrity for reexecution capability

## Embedded Prompt Format

The command expects Linear issues to contain prompts in this format:

```markdown
## 🤖 AI Implementation Prompt

### 📋 COPY-PASTE READY PROMPT:

[FULL EXECUTABLE PROMPT CONTENT HERE]

---

**Usage:** Copy the prompt text above and paste directly into an AI conversation...
```

## Error Handling

### Common Issues and Solutions

**Issue Not Found:**
```bash
❌ Error: Linear issue AIG-130 not found
💡 Solution: Verify issue ID and Linear access permissions
```

**No Embedded Prompt:**
```bash
❌ Error: No embedded prompt found in issue AIG-130
💡 Solution: Run generate-ai-prompts --update-linear-issues to add prompts
```

**Unity Project Issues:**
```bash
❌ Error: Unity project not found or invalid
💡 Solution: Use --project-path or run from Unity project directory
```

**MCP Tool Failures:**
```bash
❌ Error: Unity MCP tools not responding
💡 Solution: Use --generate-fallback-script for Editor script alternative
```

### Retry and Recovery
- Automatic retry on transient MCP failures
- Fallback to Editor scripts when MCP unavailable
- Partial completion tracking and resume capability
- Detailed error logging for debugging

## Success Criteria Validation

The command automatically validates implementation against success criteria:

```bash
✅ Validating Success Criteria:
   ✅ Four buttons visible and properly arranged in 2x2 grid
   ✅ Each button displays correct color (Red, Blue, Green, Yellow)
   ✅ Layout scales appropriately for different screen sizes
   ⚠️  Button visual boundaries need refinement
   
🎯 Success Rate: 75% (3/4 criteria met)
📝 Manual verification required for visual boundaries
```

## Output Examples

### Successful Execution
```bash
$ execute-linear AIG-130

🚀 Executing Linear Issue: AIG-130
📋 Task: Create Button Layout & Components
⏱️  Estimated Duration: 1.0 hours
🎯 Priority: Critical

📊 Progress:
[████████████████████] 100% - Implementation Complete

✅ Results:
   - Canvas GameObject created with proper configuration
   - 4 Button GameObjects with correct colors
   - Grid Layout Group configured for 2x2 arrangement
   - Responsive scaling validated

📈 Metrics:
   - Execution Time: 3.2 minutes
   - Success Criteria Met: 4/4 (100%)
   - Unity Errors: 0
   - Unity Warnings: 0

🔗 Linear Updated:
   - Status: Complete
   - Comment: Implementation successful with full validation
   - Completion Time: 2025-08-16 15:45:23
```

### Dry Run Output
```bash
$ execute-linear AIG-130 --dry-run

🔍 DRY RUN: Linear Issue AIG-130

📋 Would Execute:
   Task: Create Button Layout & Components
   Duration: 1.0 hours
   Priority: Critical

🛠️ Planned MCP Actions:
   1. Create Canvas with Screen Space Overlay
   2. Add CanvasScaler component
   3. Create ButtonPanel with Grid Layout Group
   4. Generate 4 Button GameObjects with colors
   5. Configure responsive scaling

✅ Validation Checks:
   - Unity project detected: ColorMemory3
   - MCP tools available: ✅
   - Prerequisites met: ✅
   - Estimated completion: 3-5 minutes

💡 To execute: execute-linear AIG-130
```

## Unity State Management Requirements

**CRITICAL: Unity Play Mode Cleanup**
The execute-linear command MUST manage Unity's editor state to prevent workflow issues:

- Unity MUST exit play mode after any test execution
- Validate Unity state before and after each operation
- Force exit play mode on timeouts or errors  
- Log Unity state transitions for debugging

**State Validation Checklist:**
- ✅ Check if Unity is in play mode before execution
- ✅ Exit play mode if active (clean slate)
- ✅ Execute implementation/tests
- ✅ **MANDATORY: Exit play mode after completion**
- ✅ Verify Unity is in edit mode before Linear updates
- ✅ Log any state management issues

**Error Handling Pattern:**
```bash
# Pseudo-code for Unity state management
if unity_in_play_mode():
    log("Unity is in play mode, exiting...")
    unity_exit_play_mode()
    wait_for_edit_mode()

execute_implementation()

# CRITICAL: Always exit play mode
if unity_in_play_mode():
    log("Forcing Unity to exit play mode...")
    unity_exit_play_mode()
    wait_for_edit_mode()
    
if not unity_in_edit_mode():
    error("Failed to return Unity to edit mode")
```

## Linear Integration Workflow Fixes

**Issue Description Preservation:**
- Original issue descriptions MUST be preserved to allow reruns
- Completion summaries go in COMMENTS, not description updates
- Use `mcp__linear-server__create_comment` instead of `update_issue` for results

**Project Association:**
- Load LINEAR_PROJECT from project-parameters.yaml
- Automatically add issues to the specified project
- Validate project exists before execution

**Example Comment Format:**
```markdown
## 🤖 Execution Complete - [Timestamp]

**Status:** ✅ Successfully implemented
**Duration:** 3.2 minutes  
**Success Criteria:** 4/4 met (100%)

### Deliverables Created:
- Canvas GameObject with proper configuration
- 4 Button GameObjects with correct colors
- Grid Layout Group configured for 2x2 arrangement

### Technical Details:
- Unity Errors: 0
- Unity Warnings: 0
- MCP Operations: 5 successful

### Next Steps:
- Manual verification of visual boundaries recommended
- Ready for code review

🔗 Generated with Claude Code execute-linear command
```

## Configuration

### Project Parameters Integration
The command automatically loads project context from `project-parameters.yaml`:

```yaml
# Key parameters used by execute-linear:
LINEAR_TEAM: "AIGameDev"
LINEAR_PROJECT: "Number-Guessing-Game"  # Issues auto-added to this project
UNITY_VERSION: "6000"
UNITY_PROJECT_PATH: "/Users/diarmuidcurran/Unity Projects/Number-Guessing-Game"
```

### Global Settings
Create `~/.claude/execute-linear-config.json` for default settings:

```json
{
  "defaultTimeout": 10,
  "validationLevel": "basic",
  "autoNotifyUsers": ["diarmuidcurran01"],
  "unityValidation": true,
  "generateFallbackScripts": true,
  "verboseLogging": false,
  "unityStateManagement": {
    "forceExitPlayMode": true,
    "validateStateTransitions": true,
    "maxPlayModeWaitSeconds": 30
  },
  "linearIntegration": {
    "preserveDescription": true,
    "useCommentsForCompletion": true,
    "autoAddToProject": true
  }
}
```

### Project-Specific Settings
Create `.claude/execute-linear.json` in project root:

```json
{
  "unityVersion": "2023.3",
  "projectValidation": {
    "requireScriptsFolder": true,
    "requireScenesFolder": true,
    "validateAssetDatabase": true
  },
  "completionActions": {
    "createCodeReviewIssue": true,
    "runUnityTests": false,
    "generateBuildReport": false
  }
}
```

## Integration with Other Commands

### Workflow Integration
```bash
# Complete workflow example
generate-feature-tasks --feature 1.1.1
generate-ai-prompts --feature 1.1.1 --create-linear-issues --linear-project AIWorkflowTest1
execute-linear AIG-130,AIG-131,AIG-132,AIG-133
```

### Batch Operations
```bash
# Execute all issues for a feature
execute-linear $(linear-get-issues --feature 1.1.1 --status "Ready")

# Execute with dependency checking
execute-linear AIG-130 --wait-for-dependencies

# Execute in parallel (for independent tasks)
execute-linear AIG-130,AIG-131 --parallel
```

## Best Practices

### Execution Guidelines
1. **Run dry-run first** to validate execution plan
2. **Check Unity project state** before executing multiple issues
3. **Monitor execution progress** for long-running tasks
4. **Validate results** against success criteria
5. **Review Linear updates** for accuracy

### Error Prevention
- Use `--validate-unity-setup` for first-time project execution
- Set appropriate `--timeout` for complex tasks
- Use `--verbose` for debugging execution issues
- Keep Unity project clean before execution

### Team Collaboration
- Use `--notify-users` to alert team members of completion
- Create follow-up issues for code review or testing
- Document any manual steps required post-execution
- Share execution logs for transparency

This command provides a complete automation solution for executing Linear issues while maintaining transparency and control over the implementation process.