# Task 1.1.2.2: Core Input Validation Logic

You are an expert Unity developer implementing this task for a Unity2D project.

## 📚 Context

Read these for full context:
- `docs/Number-Guessing-Game-GDD.md` - Game mechanics and player experience  
- `docs/epics/Epic-1.1-Specification.md` - Epic requirements
- `docs/tasks/Feature-1.1.2-Tasks.md` - Task breakdown and dependencies

## 🎯 Task Overview
**ID:** 1.1.2.2 | **Priority:** Foundation Critical | **Duration:** 3 hours  
**Feature:** 1.1.2 - Complete Input & Validation System | **Epic:** 1.1 - Core Game Logic System

## 🎮 Game Context

Implement comprehensive validation algorithms that process player input for the number guessing game. This system ensures accurate number parsing, range validation (1-100), duplicate detection, and user-friendly error messaging that supports the "Immediate Clarity" design pillar through clear, actionable feedback.

## 📋 Requirements

- Static InputValidator class with comprehensive validation methods
- Safe number parsing using int.TryParse() with error handling
- Range validation enforcing 1-100 bounds consistently
- Duplicate guess detection across game sessions
- User-friendly error messages for all validation scenarios
- Performance target of <10ms validation time
- Static utility methods for easy testing and integration

## 🎯 Expected Outcome

After implementation:
- **Visual**: Clean validation API ready for InputManager integration
- **Functional**: Reliable input validation covering all error scenarios
- **Integration**: Foundation ready for real-time input feedback systems

## 🔧 Implementation Steps

1. **Create InputValidator Script**: Use MCP to create InputValidator.cs in Assets/Scripts/
2. **Implement Number Parsing**: Add IsValidNumber method with int.TryParse() and edge case handling
3. **Add Range Validation**: Create IsInRange method for 1-100 boundary checking
4. **Build Duplicate Detection**: Implement IsUniqueGuess with previous guesses list checking
5. **Create Error Messaging**: Add GetValidationMessage with comprehensive error dictionary
6. **Integrate Main Validator**: Build ValidateGuess method combining all validation checks

## 🏗️ Technical Specification

```csharp
namespace NumberGuessingGame.InputSystem
{
    public static class InputValidator
    {
        public static bool IsValidNumber(string input, out int result);
        public static bool IsInRange(int value, int min, int max);
        public static bool IsUniqueGuess(int value, List<int> previousGuesses);
        public static string GetValidationMessage(ValidationError errorType);
        public static InputValidation ValidateGuess(string input, List<int> previousGuesses);
        
        public const int MIN_GUESS_VALUE = 1;
        public const int MAX_GUESS_VALUE = 100;
    }
}
```

**Core Logic:** Safe parsing with comprehensive error handling, efficient range checking, duplicate detection with List.Contains().

**Dependencies:** Task 1.1.2.1 InputValidation structures, System.Collections.Generic for List handling.

## ✅ Success Criteria

- [ ] Number parsing handles invalid formats gracefully (letters, decimals, empty)
- [ ] Range validation correctly identifies values outside 1-100 bounds
- [ ] Duplicate detection prevents re-guessing same numbers within session
- [ ] Validation messages are clear and actionable for players
- [ ] Edge cases handled: leading/trailing spaces, negative numbers, zero
- [ ] All validation operations complete in under 10ms
- [ ] Static methods enable easy unit testing
- [ ] Comprehensive error message dictionary for localization support
- [ ] No compilation errors
- [ ] Follows Unity best practices
- [ ] Meets GDD requirements

## 🛠️ Unity MCP Implementation

**🚨 VERIFICATION MANDATORY**: After every MCP operation, verify success using Read, LS, read_console tools

**Primary Approach:**
- Use `manage_script` to create InputValidator.cs script
- Use `read_console` to check for compilation errors

**Fallback Approach:**
If MCP unavailable: Create script manually in Assets/Scripts/ with Write tool

**Verification Steps:**
```bash
# After manage_script
Read file_path="Assets/Scripts/InputValidator.cs"  # Verify file exists
read_console action="get" types=["error", "warning"]  # Check compilation
```

## 📁 Deliverables

- `Assets/Scripts/InputValidator.cs` - Complete validation class with static utility methods
- Error message dictionary for user-friendly feedback
- XML documentation for all public methods

## 🧪 Validation

**Functional:** Test all validation scenarios including valid inputs, invalid formats, out-of-range values, and duplicates
**Integration:** Verify clean integration with InputValidation structures from Task 1.1.2.1
**Performance:** Confirm <10ms validation time using Unity Profiler

Execute this implementation now.