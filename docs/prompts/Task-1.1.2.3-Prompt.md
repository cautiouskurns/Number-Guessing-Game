# Task 1.1.2.3: Unity Input System Integration

You are an expert Unity developer implementing this task for a Unity2D project.

## 📚 Context

Read these for full context:
- `docs/Number-Guessing-Game-GDD.md` - Game mechanics and player experience  
- `docs/epics/Epic-1.1-Specification.md` - Epic requirements
- `docs/tasks/Feature-1.1.2-Tasks.md` - Task breakdown and dependencies

## 🎯 Task Overview
**ID:** 1.1.2.3 | **Priority:** Core Functionality | **Duration:** 4 hours  
**Feature:** 1.1.2 - Complete Input & Validation System | **Epic:** 1.1 - Core Game Logic System

## 🎮 Game Context

Create the InputManager MonoBehaviour that bridges Unity's UI system with the validation logic, providing real-time input handling and visual feedback. This system supports the "Immediate Clarity" design pillar through instant validation feedback and seamless player interaction with the number guessing interface.

## 📋 Requirements

- InputManager MonoBehaviour with Unity UI integration
- TMP_InputField configuration with numeric input restrictions
- Real-time validation feedback as user types
- Submit button enable/disable based on validation state
- Enter key submission alongside button clicking
- Previous guesses tracking throughout game session
- Integration with NumberGenerator for target comparison
- Proper Unity lifecycle management (Awake, Start, OnEnable, OnDisable)

## 🎯 Expected Outcome

After implementation:
- **Visual**: Input field responds with real-time color feedback, submit button states update dynamically
- **Functional**: Complete input handling with validation integration and guess tracking
- **Integration**: Ready for GuessProcessor and UI feedback system integration

## 🔧 Implementation Steps

1. **Create InputManager Script**: Use MCP to create InputManager.cs MonoBehaviour in Assets/Scripts/
2. **Setup Component References**: Add SerializeField attributes for TMP_InputField, Button, and NumberGenerator
3. **Configure Input Field**: Set up numeric content type, character limits, and event handlers
4. **Implement Real-time Validation**: Add OnValueChanged handler with InputValidator integration
5. **Handle Submission Events**: Create OnSubmit handlers for both button clicks and Enter key
6. **Add Guess Tracking**: Implement previous guesses list and attempt counter management

## 🏗️ Technical Specification

```csharp
namespace NumberGuessingGame.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        [Header("Input Configuration")]
        public TMP_InputField numberInputField;
        public Button submitButton;
        public int maxAttempts = 10;
        
        [Header("Dependencies")]
        public NumberGenerator numberGenerator;
        
        private List<int> previousGuesses = new List<int>();
        private int currentAttempts = 0;
        private bool isInputEnabled = true;
    }
}
```

**Core Logic:** Event-driven input handling with real-time validation, MonoBehaviour lifecycle management, Unity UI component integration.

**Dependencies:** Task 1.1.2.2 InputValidator, Feature 1.1.1 NumberGenerator, TextMeshPro UI components.

## ✅ Success Criteria

- [ ] TMP_InputField configured with proper number input restrictions
- [ ] Submit button responds to both click and Enter key press
- [ ] Real-time validation feedback updates as user types
- [ ] Input field automatically focuses for immediate player interaction
- [ ] Previous guesses list maintained throughout game session
- [ ] Component references properly configured through Inspector
- [ ] Unity lifecycle methods properly implemented
- [ ] Integration with NumberGenerator for target access
- [ ] No compilation errors
- [ ] Follows Unity best practices
- [ ] Meets GDD requirements

## 🛠️ Unity MCP Implementation

**🚨 VERIFICATION MANDATORY**: After every MCP operation, verify success using Read, LS, read_console tools

**Primary Approach:**
- Use `manage_script` to create InputManager.cs script
- Use `manage_gameobject` to create InputManager GameObject in scene
- Use `read_console` to check for compilation errors

**Fallback Approach:**
If MCP unavailable: Create script manually with Write tool, set up GameObject manually in Unity Editor

**Verification Steps:**
```bash
# After manage_script
Read file_path="Assets/Scripts/InputManager.cs"  # Verify file exists
read_console action="get" types=["error", "warning"]  # Check compilation
# After manage_gameobject
manage_scene action="get_hierarchy"  # Verify GameObject creation
```

## 📁 Deliverables

- `Assets/Scripts/InputManager.cs` - Complete MonoBehaviour with input handling and validation integration
- InputManager GameObject in scene hierarchy with component references
- Inspector configuration for all UI component assignments

## 🧪 Validation

**Functional:** Test input field responses, button state changes, Enter key functionality, and guess tracking
**Integration:** Verify InputValidator integration and NumberGenerator connectivity
**Performance:** Confirm real-time validation feedback without frame drops

Execute this implementation now.