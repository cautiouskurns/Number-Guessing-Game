# **AI TASK IMPLEMENTATION PROMPT**

You are an expert Unity developer working on a Unity project via MCP agents.

Implement **Debug Mode & Deterministic Testing Infrastructure** for the Number-Guessing-Game Unity2D.

## 📚 Project Knowledge Base

**Before implementing, familiarize yourself with the project context:**

### **Core Documentation:**
- **Game Design Document**: `docs/Number-Guessing-Game-GDD.md` - Game mechanics, player experience, core vision
- **Technical Design Spec**: `docs/TDS/` - System architecture and technical requirements  
- **Development Roadmap**: `docs/Number-Guessing-Game-Roadmap.md` - Project phases and milestones

### **Current Epic Context:**
- **Epic Specification**: `docs/epics/Epic-1.1-Specification.md` - Current epic scope and acceptance criteria
- **Feature Breakdown**: `docs/tasks/Feature-1.1.1-Tasks.md` - All related tasks and dependencies

### **Implementation Resources:**
- **Unity Project**: `/Assets/Scripts/` - Existing codebase and component structure
- **Project Parameters**: `project-parameters.yaml` - Team settings, Linear integration, Unity configuration
- **MCP Guidelines**: Unity MCP tools are available for component management and testing

**📖 Read these documents to understand the full context before implementing this specific task.**

## 🎯 Task Overview
**Task ID:** 1.1.1.2 | **Priority:** High | **Duration:** 3 hours  
**Feature:** 1.1.1 - Random Number Generation System | **Epic:** 1.1 - Core Game Logic System | **Category:** 7.3 Debug Systems

## 🎮 Game Context

This task builds upon the core NumberGenerator to add debug infrastructure that enables deterministic testing scenarios through seed control. This supports development quality assurance ensuring the "Pure Logic" pillar functions correctly by enabling thorough testing of gameplay scenarios without randomness interference. The debug system provides Unity Editor integration for easy access during development and comprehensive quality assurance validation.

**📖 Project Context References:**
- **Game Design Document**: `/docs/Number-Guessing-Game-GDD.md` - Core game vision and mechanics
- **Epic Specification**: `/docs/epics/Epic-1.1-Specification.md` - Technical requirements and scope
- **Feature Tasks**: `/docs/tasks/Feature-1.1.1-Tasks.md` - Complete task breakdown and dependencies
- **Development Roadmap**: `/docs/Number-Guessing-Game-Roadmap.md` - Project timeline and milestones
- **Project Parameters**: `project-parameters.yaml` - Configuration and team settings

## 📋 Task Requirements

- Debug mode toggle functionality with conditional compilation for Editor-only features
- Seed setting capability for deterministic generation in testing scenarios
- Unity Editor menu items providing easy debug access for development team
- Validation ensuring debug mode produces identical sequences with same seed
- Performance impact assessment ensuring debug features don't affect release builds
- Debug logging provides clear information about current seed and generation state

## 🎯 Expected Outcome

After implementation, developers should see:
- **Visual Outcome**: Debug mode controls in Unity Inspector and Editor menu items for easy access
- **Functional Outcome**: Deterministic number generation when debug mode enabled with fixed seeds
- **Integration Outcome**: Debug infrastructure seamlessly integrated with existing NumberGenerator singleton
- **Performance Outcome**: Zero performance impact in release builds through conditional compilation

**Verification**: Enable debug mode with seed 12345, generate 10 numbers, restart Unity, generate 10 more numbers with same seed and verify identical sequences

## 🔧 Implementation Steps

1. **Add Debug Mode Fields**: Extend NumberGenerator with debug mode toggle and seed configuration fields
2. **Implement Conditional Compilation**: Use #if UNITY_EDITOR directives to ensure debug features only exist in Editor builds
3. **Create Seed Management**: Add methods for setting custom seeds and switching between random/deterministic modes
4. **Add Editor Menu Integration**: Create MenuItem attributes for Unity Editor menu access to debug controls
5. **Implement Debug Logging**: Add configurable debug logging showing current mode, seed values, and generation state
6. **Add Validation Methods**: Create methods to verify deterministic behavior and seed consistency

## 🏗️ Technical Specification

### **Class Structure:**
```csharp
public class NumberGenerator : MonoBehaviour
{
    // Existing singleton and generation code...
    
    [Header("Debug Configuration")]
    #if UNITY_EDITOR
    [SerializeField] private bool isDebugMode = false;
    [SerializeField] private int debugSeed = 12345;
    [SerializeField] private bool enableDebugLogging = true;
    #endif
    
    #if UNITY_EDITOR
    public bool IsDebugMode => isDebugMode;
    public int DebugSeed => debugSeed;
    
    [MenuItem("NumberGuessingGame/Debug/Toggle Debug Mode")]
    public static void ToggleDebugMode() { /* Implementation */ }
    
    [MenuItem("NumberGuessingGame/Debug/Set Debug Seed")]
    public static void SetDebugSeedDialog() { /* Implementation */ }
    #endif
}
```

### **Core Logic:**
Debug infrastructure enabling deterministic testing through seed control, with conditional compilation ensuring Editor-only availability and zero impact on release builds.

### **Dependencies:**
Task 1.1.1.1 (Core NumberGenerator) must be complete, Unity Editor scripting APIs, conditional compilation understanding.

**📋 Task Dependencies:**
- **Prerequisites**: Task 1.1.1.1 (Core NumberGenerator) must provide base singleton functionality
- **Blocks**: Task 1.1.1.3 (Statistical Validation) needs debug mode for deterministic testing
- **Related Systems**: QA testing workflows, development debugging processes

**🔗 Implementation Context:**
- **Existing Codebase**: Extend existing NumberGenerator class without breaking existing functionality
- **Unity Project Setup**: Ensure conditional compilation works correctly across different build configurations
- **MCP Integration**: Use Unity MCP tools for Editor script management and validation

### **Performance Constraints:**
Zero performance impact in release builds, minimal overhead in Editor for debug features, efficient seed management without memory allocation.

### **Architecture Guidelines:**
- Follow Single Responsibility Principle - debug features enhance but don't complicate core generation
- Keep debug code cleanly separated through conditional compilation
- Only implement debug functionality explicitly required by testing scenarios
- Avoid debug feature creep that complicates core logic
- Align with TDS testing philosophy emphasizing reliable, debuggable systems

## 🔧 Unity Integration

**GameObject Setup:** No additional GameObjects required - debug features integrated into existing NumberGenerator component
**Scene Hierarchy:** Debug functionality integrates with existing NumberGenerator in _GameSystems hierarchy
**Inspector Config:** Debug fields visible in Inspector with proper headers, only available in Unity Editor
**System Connections:** Debug logging integration with Unity Console, Editor menu integration for development workflow

## ✅ Success Criteria

- [ ] Debug mode produces identical number sequences when using the same seed
- [ ] Unity Editor menu items provide intuitive debug control access
- [ ] Debug features only available in Unity Editor builds, excluded from player builds
- [ ] Debug mode can be toggled on/off without affecting core functionality
- [ ] Seed values can be set programmatically and through Inspector interface
- [ ] Debug logging provides clear information about current seed and generation state
- [ ] No compilation errors
- [ ] Follows Unity best practices and Single Responsibility Principle
- [ ] Aligns with TDS architectural patterns
- [ ] Meets GDD player experience requirements
- [ ] Satisfies epic-level acceptance criteria

## 🛠️ Unity MCP Implementation

**📖 Reference Documentation:**
- Unity MCP Implementation Guidelines: Follow established patterns for component creation and testing
- Project Parameters: Use `project-parameters.yaml` for Linear integration and Unity paths
- Execute Linear Command: Use updated workflow with comment-based completion tracking

**🔧 Implementation Approach:**
Follow **Editor Extension** pattern: Extend existing NumberGenerator with debug functionality using conditional compilation, Editor menu integration, and Inspector enhancements.

**⚠️ Fallback Approach:**
If MCP unavailable, manually extend NumberGenerator.cs with debug functionality, add Editor menu items through [MenuItem] attributes, and verify conditional compilation manually.

**🎯 MCP Integration Requirements:**
- **Unity State Management**: Ensure Unity exits play mode after any tests or validation
- **Component Integration**: Use `manage_script` to extend existing NumberGenerator component
- **Script Management**: Use conditional compilation validation through `read_console` error checking
- **Error Handling**: Check Unity console via `read_console` for compilation and conditional compilation issues
- **Linear Integration**: Implementation will be tracked via Linear comments (preserves task descriptions)

### **MCP Priority Implementation:**

**Primary (Use When Available):**
- Use `manage_script` to update NumberGenerator.cs with debug functionality
- Use `read_console` to validate conditional compilation works correctly
- Use `manage_editor` to verify Editor menu items appear correctly
- Validate debug functionality through Unity Editor testing

**Secondary (Fallback):**
- Manual NumberGenerator.cs modification with debug features
- Manual verification of conditional compilation through build testing
- Traditional Unity Editor workflow for menu item validation

## 📁 Deliverables

- Extended `Assets/Scripts/NumberGenerator.cs` with debug mode functionality and conditional compilation
- Unity Editor menu items under "NumberGuessingGame/Debug/" for debug control access
- Inspector integration with debug fields visible only in Unity Editor
- Debug logging system with configurable verbosity levels

## 🧪 Validation

**Functional Validation:**
Enable debug mode with specific seed, generate number sequence, restart Unity, repeat with same seed and verify identical sequences produced.

**Integration Validation:**  
Verify debug features integrate seamlessly with existing NumberGenerator functionality, confirm Editor menu items work correctly, test conditional compilation exclusion in builds.

**Performance Validation:**
Confirm zero performance impact in release builds through build testing, measure debug overhead in Editor to ensure minimal impact on development workflow.

**Epic Alignment Validation:**
Ensure debug infrastructure supports Epic 1.1 testing requirements and quality assurance processes for random number generation validation.

**GDD Compliance Validation:**
Confirm debug features support "Pure Logic" design pillar through deterministic testing capabilities, ensure development quality without affecting player experience.

## 🔄 Response Contract

**Required Output Format:**
1. **Implementation Plan** (4-6 bullets covering debug integration approach, conditional compilation strategy, Editor menu implementation, and validation methods)
2. **Code Files** (Extended NumberGenerator.cs with debug functionality, conditional compilation, and Editor integration)  
3. **Unity Setup Method** (MCP commands for script updates and Editor feature validation, with manual verification fallback)
4. **Integration Notes** (brief explanation of how debug features integrate with core generation and enable Task 1.1.1.3 statistical validation)

**File Structure:** Enhanced Assets/Scripts/NumberGenerator.cs with conditional compilation sections
**Code Standards:** Unity C# naming conventions, proper conditional compilation usage, clear debug logging format

## 🚨 Resilience Flags

**StubMissingDeps:** Create minimal debug interface if advanced Editor features unavailable
**ValidationLevel:** Basic - essential debug functionality with conditional compilation validation  
**Reusability:** Reusable - debug pattern applicable to other game systems requiring deterministic testing

## 🔍 Dependency Handling

**Missing Dependencies:**
- **If Unity Editor APIs change:** Adapt to available Editor scripting interfaces while maintaining core functionality
- **If conditional compilation fails:** Provide fallback debug implementation with manual enable/disable
- **If MenuItem attributes don't work:** Create alternative debug access through Inspector buttons or static methods

**Fallback Behaviors:**
- Default to debug mode disabled if configuration fails
- Log informative warnings for debug initialization issues
- Gracefully handle seed setting errors with validation and user feedback
- Align with TDS resilience patterns for robust debug system operation

**Risk Mitigation:**
Comprehensive testing of conditional compilation across build configurations, proper error handling for invalid seed values, defensive programming for debug mode state management.

Execute this implementation now.