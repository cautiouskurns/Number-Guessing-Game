# Update Commands

Synchronize commands between local project and global Claude Code commands directory.

## Usage
```bash
# Push local changes to global commands
update-commands push

# Pull global changes to local commands  
update-commands pull

# Show differences between local and global
update-commands diff

# Interactive sync (choose which files to sync)
update-commands sync
```

## What it does
- **push**: Copy modified commands from templates/Commands/ back to global ~/.claude/commands/
- **pull**: Update templates/Commands/ with changes from global directory
- **diff**: Show differences between templates/Commands/ and global command files
- **sync**: Interactive mode to selectively sync specific commands

## Implementation
```bash
#!/bin/bash

GLOBAL_COMMANDS_DIR="$HOME/.claude/commands"
LOCAL_COMMANDS_DIR="templates/Commands"

# Function to show usage
show_usage() {
    echo "Usage: update-commands [push|pull|diff|sync]"
    echo ""
    echo "Commands:"
    echo "  push  - Copy local commands to global directory"
    echo "  pull  - Copy global commands to local directory"
    echo "  diff  - Show differences between local and global"
    echo "  sync  - Interactive synchronization"
    exit 1
}

# Function to check directories exist
check_directories() {
    if [ ! -d "$GLOBAL_COMMANDS_DIR" ]; then
        echo "Error: Global commands directory not found at $GLOBAL_COMMANDS_DIR"
        exit 1
    fi
    
    if [ ! -d "$LOCAL_COMMANDS_DIR" ]; then
        echo "Error: Local commands directory not found at $LOCAL_COMMANDS_DIR"
        echo "Run 'copy-commands' first to initialize commands in templates folder"
        exit 1
    fi
}

# Function to push local to global
push_commands() {
    echo "🔄 Pushing local commands to global directory..."
    
    # Create backup of global commands
    backup_dir="${GLOBAL_COMMANDS_DIR}_backup_$(date +%Y%m%d_%H%M%S)"
    echo "Creating backup of global commands at $backup_dir"
    cp -r "$GLOBAL_COMMANDS_DIR" "$backup_dir"
    
    # Copy local to global
    cp -r "$LOCAL_COMMANDS_DIR"/* "$GLOBAL_COMMANDS_DIR/"
    
    echo "✅ Local commands pushed to global directory"
}

# Function to pull global to local
pull_commands() {
    echo "🔄 Pulling global commands to local directory..."
    
    # Create backup of local commands
    backup_dir="${LOCAL_COMMANDS_DIR}_backup_$(date +%Y%m%d_%H%M%S)"
    echo "Creating backup of local commands at $backup_dir"
    cp -r "$LOCAL_COMMANDS_DIR" "$backup_dir"
    
    # Copy global to local
    cp -r "$GLOBAL_COMMANDS_DIR"/* "$LOCAL_COMMANDS_DIR/"
    
    echo "✅ Global commands pulled to local directory"
}

# Function to show differences
show_diff() {
    echo "🔍 Comparing local and global commands..."
    echo ""
    
    # Find all .md files in both directories
    local_files=$(find "$LOCAL_COMMANDS_DIR" -name "*.md" -type f | sed "s|$LOCAL_COMMANDS_DIR/||" | sort)
    global_files=$(find "$GLOBAL_COMMANDS_DIR" -name "*.md" -type f | sed "s|$GLOBAL_COMMANDS_DIR/||" | sort)
    
    # Show files only in local
    local_only=$(comm -23 <(echo "$local_files") <(echo "$global_files"))
    if [ ! -z "$local_only" ]; then
        echo "📁 Files only in local:"
        echo "$local_only" | sed 's/^/  /'
        echo ""
    fi
    
    # Show files only in global
    global_only=$(comm -13 <(echo "$local_files") <(echo "$global_files"))
    if [ ! -z "$global_only" ]; then
        echo "🌍 Files only in global:"
        echo "$global_only" | sed 's/^/  /'
        echo ""
    fi
    
    # Show differences in common files
    common_files=$(comm -12 <(echo "$local_files") <(echo "$global_files"))
    echo "🔄 Comparing common files:"
    
    for file in $common_files; do
        if ! diff -q "$LOCAL_COMMANDS_DIR/$file" "$GLOBAL_COMMANDS_DIR/$file" > /dev/null 2>&1; then
            echo "  📝 $file - DIFFERENT"
        else
            echo "  ✅ $file - identical"
        fi
    done
}

# Function for interactive sync
interactive_sync() {
    echo "🔄 Interactive command synchronization"
    echo ""
    
    # Find all unique files
    all_files=$(find "$LOCAL_COMMANDS_DIR" "$GLOBAL_COMMANDS_DIR" -name "*.md" -type f | sed -e "s|$LOCAL_COMMANDS_DIR/||" -e "s|$GLOBAL_COMMANDS_DIR/||" | sort | uniq)
    
    for file in $all_files; do
        local_file="$LOCAL_COMMANDS_DIR/$file"
        global_file="$GLOBAL_COMMANDS_DIR/$file"
        
        echo "Processing: $file"
        
        if [ ! -f "$local_file" ]; then
            echo "  Only exists in global. Copy to local? (y/n)"
            read -r response
            if [ "$response" = "y" ]; then
                mkdir -p "$(dirname "$local_file")"
                cp "$global_file" "$local_file"
                echo "  ✅ Copied to local"
            fi
        elif [ ! -f "$global_file" ]; then
            echo "  Only exists in local. Copy to global? (y/n)"
            read -r response
            if [ "$response" = "y" ]; then
                mkdir -p "$(dirname "$global_file")"
                cp "$local_file" "$global_file"
                echo "  ✅ Copied to global"
            fi
        elif ! diff -q "$local_file" "$global_file" > /dev/null 2>&1; then
            echo "  Files differ. Which version to keep?"
            echo "    1) Keep local version"
            echo "    2) Keep global version"
            echo "    3) Skip this file"
            read -r choice
            case $choice in
                1) cp "$local_file" "$global_file"; echo "  ✅ Global updated with local version" ;;
                2) cp "$global_file" "$local_file"; echo "  ✅ Local updated with global version" ;;
                3) echo "  ⏭️  Skipped" ;;
                *) echo "  ❌ Invalid choice, skipping" ;;
            esac
        else
            echo "  ✅ Files identical"
        fi
        echo ""
    done
}

# Main script logic
case "${1:-}" in
    push)
        check_directories
        push_commands
        ;;
    pull)
        check_directories
        pull_commands
        ;;
    diff)
        check_directories
        show_diff
        ;;
    sync)
        check_directories
        interactive_sync
        ;;
    *)
        show_usage
        ;;
esac
```