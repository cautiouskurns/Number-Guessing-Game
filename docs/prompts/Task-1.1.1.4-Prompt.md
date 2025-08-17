# **AI TASK IMPLEMENTATION PROMPT**

You are an expert Unity developer working on a Unity project via MCP agents.

Implement **Game State Integration & Event-Driven Architecture** for the Number-Guessing-Game Unity2D.

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
**Task ID:** 1.1.1.4 | **Priority:** Low | **Duration:** 2 hours  
**Feature:** 1.1.1 - Random Number Generation System | **Epic:** 1.1 - Core Game Logic System | **Category:** 1.2 Event Systems

## 🎮 Game Context

This task implements event-driven integration enabling automatic number generation triggered by game state transitions, with proper event subscription lifecycle management and thread-safe operation coordination. It supports "Immediate Clarity" by automatically generating new numbers when needed without manual intervention and enables seamless gameplay flow supporting the "Satisfying Progress" design pillar. The integration follows TDS event-driven communication architecture for decoupled system coordination.

**📖 Project Context References:**
- **Game Design Document**: `/docs/Number-Guessing-Game-GDD.md` - Core game vision and mechanics
- **Epic Specification**: `/docs/epics/Epic-1.1-Specification.md` - Technical requirements and scope
- **Feature Tasks**: `/docs/tasks/Feature-1.1.1-Tasks.md` - Complete task breakdown and dependencies
- **Development Roadmap**: `/docs/Number-Guessing-Game-Roadmap.md` - Project timeline and milestones
- **Project Parameters**: `project-parameters.yaml` - Configuration and team settings

## 📋 Task Requirements

- Event subscription to GameStateManager state change events (OnGameStart, OnGameReset)
- Automatic number generation triggers responding to appropriate state transitions
- Proper event cleanup and memory leak prevention through unsubscription management
- Thread-safe operation coordination if called from multiple systems
- Integration with existing singleton pattern without architectural conflicts
- Error handling for edge cases like rapid state transitions or invalid states

## 🎯 Expected Outcome

After implementation, developers should see:
- **Visual Outcome**: NumberGenerator automatically responds to game state changes without manual intervention
- **Functional Outcome**: New target numbers generated automatically when games start or reset
- **Integration Outcome**: Seamless coordination between NumberGenerator and GameStateManager through events
- **Performance Outcome**: Efficient event handling without memory leaks or performance impact

**Verification**: Start new game and verify new target number generated automatically, reset game and confirm fresh number generation, check for proper event cleanup in extended play sessions

## 🔧 Implementation Steps

1. **Add Event System Integration**: Extend NumberGenerator with event subscription capabilities using Unity's event system
2. **Implement State Event Handlers**: Create methods to handle OnGameStart and OnGameReset events with automatic generation
3. **Add Lifecycle Management**: Implement proper event subscription in OnEnable and unsubscription in OnDisable
4. **Create Error Handling**: Add defensive programming for edge cases like rapid state transitions and null references
5. **Add Debug Logging**: Include configurable logging for event coordination tracking and troubleshooting
6. **Implement Thread Safety**: Ensure event handlers are thread-safe with proper coordination mechanisms

## 🏗️ Technical Specification

### **Class Structure:**
```csharp
public class NumberGenerator : MonoBehaviour
{
    // Existing singleton and generation code...
    
    [Header("Event Integration")]
    [SerializeField] private bool enableEventLogging = false;
    
    private void OnEnable()
    {
        SubscribeToGameStateEvents();
    }
    
    private void OnDisable()
    {
        UnsubscribeFromGameStateEvents();
    }
    
    private void SubscribeToGameStateEvents()
    {
        // Event subscription implementation
        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.OnGameStart += HandleGameStart;
            GameStateManager.Instance.OnGameReset += HandleGameReset;
        }
    }
    
    private void UnsubscribeFromGameStateEvents()
    {
        // Event cleanup implementation
    }
    
    private void HandleGameStart()
    {
        GenerateNewTarget();
        if (enableEventLogging)
            Debug.Log($"NumberGenerator: New target generated for game start: {CurrentTarget}");
    }
    
    private void HandleGameReset()
    {
        GenerateNewTarget();
        if (enableEventLogging)
            Debug.Log($"NumberGenerator: New target generated for game reset: {CurrentTarget}");
    }
}
```

### **Core Logic:**
Event-driven integration enabling automatic number generation triggered by game state transitions, with proper event subscription lifecycle management and thread-safe operation coordination.

### **Dependencies:**
Task 1.1.1.1 (Core NumberGenerator) must provide base functionality, GameStateManager understanding from Feature 1.1.3 for event interface design, Unity event system knowledge.

**📋 Task Dependencies:**
- **Prerequisites**: Task 1.1.1.1 (Core NumberGenerator) must provide singleton and generation functionality
- **Blocks**: None - this is the final task in Feature 1.1.1
- **Related Systems**: Future GameStateManager from Feature 1.1.3, event-driven architecture coordination

**🔗 Implementation Context:**
- **Existing Codebase**: Integrate event handling with existing NumberGenerator singleton without breaking functionality
- **Unity Project Setup**: Ensure event system integration works with Unity lifecycle and coroutine systems
- **MCP Integration**: Use Unity MCP tools for event system validation and lifecycle testing

### **Performance Constraints:**
Minimal event handling overhead, efficient event subscription/unsubscription without memory allocation, thread-safe coordination without blocking operations.

### **Architecture Guidelines:**
- Follow Single Responsibility Principle - event integration enhances but doesn't complicate core generation
- Keep event handling code cleanly separated and focused on coordination only
- Only implement event responses explicitly required by game state transitions
- Avoid event handling complexity beyond basic state transition responses
- Align with TDS event-driven communication architecture for decoupled system coordination

## 🔧 Unity Integration

**GameObject Setup:** No additional GameObjects required - event integration added to existing NumberGenerator component
**Scene Hierarchy:** Event functionality integrates with existing NumberGenerator in _GameSystems hierarchy
**Inspector Config:** Optional event logging toggle for debugging and development workflow support
**System Connections:** Event-based coordination with future GameStateManager, integration with Unity's event and lifecycle systems

## ✅ Success Criteria

- [ ] Automatic number generation when game state transitions to Playing
- [ ] New number generation when game reset events are triggered
- [ ] Proper event cleanup prevents memory leaks during repeated game sessions
- [ ] Integration works seamlessly with GameStateManager state transition system
- [ ] Thread-safe operation when events triggered from different execution contexts
- [ ] Error handling for edge cases like rapid state transitions or invalid states
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
Follow **Event-Driven Integration** pattern: Extend existing NumberGenerator with event subscription capabilities, automatic state response, and proper lifecycle management.

**⚠️ Fallback Approach:**
If MCP unavailable, manually extend NumberGenerator.cs with event handling, implement state event responses through Unity's event system, and validate lifecycle management manually.

**🎯 MCP Integration Requirements:**
- **Unity State Management**: Ensure Unity exits play mode after any tests or validation
- **Component Integration**: Use `manage_script` to extend NumberGenerator with event handling capabilities
- **Script Management**: Use event system validation through `read_console` error checking
- **Error Handling**: Check Unity console via `read_console` for event subscription and lifecycle issues
- **Linear Integration**: Implementation will be tracked via Linear comments (preserves task descriptions)

### **MCP Priority Implementation:**

**Primary (Use When Available):**
- Use `manage_script` to update NumberGenerator.cs with event integration functionality
- Use `read_console` to validate event subscription and lifecycle management
- Use Unity MCP validation to ensure proper event handling and memory management
- Validate event coordination through state transition testing

**Secondary (Fallback):**
- Manual NumberGenerator.cs extension with event handling implementation
- Manual validation of event subscription and unsubscription through Unity lifecycle testing
- Traditional Unity workflow for event system integration and validation

## 📁 Deliverables

- Extended `Assets/Scripts/NumberGenerator.cs` with event integration and automatic state response
- Event subscription lifecycle management with proper OnEnable/OnDisable integration
- Debug logging system for event coordination tracking and troubleshooting
- Thread-safe event handling with error management for edge cases

## 🧪 Validation

**Functional Validation:**
Trigger game state changes and verify automatic number generation, test rapid state transitions for proper event handling, confirm event cleanup through extended play sessions.

**Integration Validation:**  
Verify seamless integration with existing NumberGenerator functionality, test event system coordination with Unity lifecycle, confirm no conflicts with singleton pattern.

**Performance Validation:**
Measure event handling performance impact to ensure minimal overhead, monitor memory usage during extended event subscription/unsubscription cycles.

**Epic Alignment Validation:**
Ensure event integration supports Epic 1.1 automatic coordination requirements and seamless game state management.

**GDD Compliance Validation:**
Confirm event integration supports "Immediate Clarity" through automatic number generation and "Satisfying Progress" through seamless gameplay flow.

## 🔄 Response Contract

**Required Output Format:**
1. **Implementation Plan** (4-6 bullets covering event integration approach, lifecycle management strategy, error handling implementation, and GameStateManager coordination)
2. **Code Files** (Extended NumberGenerator.cs with event integration, lifecycle management, and automatic state response)  
3. **Unity Setup Method** (MCP commands for event system validation and lifecycle testing, with manual verification fallback)
4. **Integration Notes** (brief explanation of how event integration completes Feature 1.1.1 and prepares for GameStateManager coordination in Feature 1.1.3)

**File Structure:** Enhanced Assets/Scripts/NumberGenerator.cs with event handling sections and lifecycle management
**Code Standards:** Unity C# naming conventions, proper event subscription patterns, clear event handling organization

## 🚨 Resilience Flags

**StubMissingDeps:** Create mock GameStateManager interface for event integration if full implementation unavailable
**ValidationLevel:** Basic - essential event handling with proper lifecycle management  
**Reusability:** Reusable - event integration pattern applicable to other systems requiring state coordination

## 🔍 Dependency Handling

**Missing Dependencies:**
- **If GameStateManager not yet implemented:** Create interface stub for event subscription with proper method signatures
- **If Unity event system differs:** Adapt to available event mechanisms while maintaining functionality
- **If threading issues arise:** Implement event queuing or main thread coordination as needed

**Fallback Behaviors:**
- Default to manual generation triggers if event system unavailable
- Log informative warnings for event subscription failures or missing dependencies
- Gracefully handle event handling errors with proper error recovery and state management
- Align with TDS resilience patterns for robust event system operation

**Risk Mitigation:**
Comprehensive null checking for event subscription targets, proper exception handling for event coordination edge cases, defensive programming for rapid state transition scenarios.

Execute this implementation now.