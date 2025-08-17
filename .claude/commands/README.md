# Claude Commands Management

This directory contains commands to manage local copies of Claude Code commands in your project's `templates/Commands/` folder, allowing you to track command changes in git and customize them for project-specific needs.

## Quick Start

### Initial Setup
```bash
# Copy all global commands to templates/Commands/ folder (already done)
copy-commands
```

### Keeping Commands in Sync

```bash
# Show differences between local and global commands
update-commands diff

# Push local changes back to global commands
update-commands push

# Pull latest global changes to local
update-commands pull

# Interactive sync (choose which files to update)
update-commands sync
```

## Commands Available

The following commands are now available in `templates/Commands/`:

- `copy-commands` - Copy global commands to local project
- `update-commands` - Sync commands between local and global
- `execute-linear` - Execute Linear workflow tasks
- `generate-ai-prompts` - Generate AI prompts for development
- `generate-epic-details` - Create detailed epic specifications
- `generate-feature-tasks` - Break down features into tasks
- `generate-game-documents` - Generate game design documents
- `setup-game-project` - Set up new game projects
- `setup-project-structure` - Set up project folder structure
- `validate-development-order` - Validate development sequence
- `validate-project-structure` - Validate project organization

## Benefits

✅ **Version Control**: Track command changes in project git  
✅ **Customization**: Modify commands for project-specific needs  
✅ **Backup**: Local copies prevent loss of custom modifications  
✅ **Collaboration**: Share customized commands with team members  
✅ **Synchronization**: Easy sync between local and global versions  

## Workflow

1. **Daily Development**: Use local commands for consistency
2. **Customization**: Modify local commands for project needs
3. **Sync Changes**: Use `update-commands push` to share improvements
4. **Stay Updated**: Use `update-commands pull` to get latest global updates
5. **Resolve Conflicts**: Use `update-commands sync` for interactive merging

## Git Integration

These local commands are now part of your project repository:

```bash
# Add commands to git
git add templates/Commands/

# Commit command changes
git commit -m "Add/update local Claude commands"

# Track command evolution over time
git log --oneline templates/Commands/
```

This ensures your development workflow commands evolve with your project and remain consistent across development sessions.