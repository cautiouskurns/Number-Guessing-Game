# Copy Global Commands

Copy all global Claude Code commands to the project templates folder for version control tracking.

## Usage
```bash
# Copy all global commands to project templates
copy-commands
```

## What it does
- Copies all commands from global ~/.claude/commands/ to local templates/Commands/
- Preserves original file structure and content
- Allows tracking command changes in project git repository
- Creates backup of existing local commands if they exist

## Implementation
```bash
#!/bin/bash

# Global commands directory
GLOBAL_COMMANDS_DIR="$HOME/.claude/commands"
LOCAL_COMMANDS_DIR="/Users/diarmuidcurran/Unity Projects/Number-Guessing-Game/templates/Commands"

# Check if global commands directory exists
if [ ! -d "$GLOBAL_COMMANDS_DIR" ]; then
    echo "Error: Global commands directory not found at $GLOBAL_COMMANDS_DIR"
    exit 1
fi

# Create local commands directory if it doesn't exist
mkdir -p "$LOCAL_COMMANDS_DIR"

# Create backup of existing local commands if they exist
if [ "$(ls -A $LOCAL_COMMANDS_DIR 2>/dev/null)" ]; then
    backup_dir="${LOCAL_COMMANDS_DIR}_backup_$(date +%Y%m%d_%H%M%S)"
    echo "Creating backup of existing local commands at $backup_dir"
    cp -r "$LOCAL_COMMANDS_DIR" "$backup_dir"
fi

# Copy all global commands to local directory
echo "Copying global commands from $GLOBAL_COMMANDS_DIR to $LOCAL_COMMANDS_DIR"
cp -r "$GLOBAL_COMMANDS_DIR"/* "$LOCAL_COMMANDS_DIR/"

# List copied files
echo ""
echo "Copied commands:"
find "$LOCAL_COMMANDS_DIR" -name "*.md" -type f | sort

echo ""
echo "✅ Global commands successfully copied to templates/Commands/"
echo "💡 You can now track command changes in git and customize them locally"
echo "💡 Use 'update-commands' to sync changes back to global commands"
```