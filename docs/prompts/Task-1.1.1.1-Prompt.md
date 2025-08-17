# **AI TASK IMPLEMENTATION PROMPT**

You are an expert Unity developer working on a Unity project via MCP agents.

Implement **Core NumberGenerator MonoBehaviour Implementation** for the Number-Guessing-Game Unity2D.

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
**Task ID:** 1.1.1.1 | **Priority:** Critical | **Duration:** 6 hours  
**Feature:** 1.1.1 - Random Number Generation System | **Epic:** 1.1 - Core Game Logic System | **Category:** 1.4 Component Architecture

## 🎮 Game Context

This task implements the foundational random number generation system that enables the "Pure Logic" design pillar by ensuring each game feels fresh and unpredictable without bias toward certain numbers. This core component provides the target numbers that players must deduce through strategic thinking, forming the foundation for all gameplay interactions. The NumberGenerator serves as the central data source for input validation, UI feedback systems, and statistical tracking across all game systems.

**📖 Project Context References:**
- **Game Design Document**: `/docs/Number-Guessing-Game-GDD.md` - Core game vision and mechanics
- **Epic Specification**: `/docs/epics/Epic-1.1-Specification.md` - Technical requirements and scope
- **Feature Tasks**: `/docs/tasks/Feature-1.1.1-Tasks.md` - Complete task breakdown and dependencies
- **Development Roadmap**: `/docs/Number-Guessing-Game-Roadmap.md` - Project timeline and milestones
- **Project Parameters**: `project-parameters.yaml` - Configuration and team settings

## 📋 Task Requirements

- Unity MonoBehaviour singleton pattern with proper initialization and lifecycle management
- Random.Range(1, 101) implementation for inclusive 1-100 range generation
- Performance target of <1ms generation time for responsive gameplay
- Clean public API supporting min/max range configuration for future extensibility
- Thread-safe operations with proper encapsulation of random state
- Proper Unity lifecycle integration with Start/Awake methods
- Memory usage remains stable across multiple generations

## 🎯 Expected Outcome

After implementation, developers should see:
- **Visual Outcome**: NumberGenerator component visible in Unity Inspector with configurable min/max range fields
- **Functional Outcome**: Reliable random number generation between 1-100 with singleton access pattern
- **Integration Outcome**: Clean API ready for input validation and game state management integration
- **Performance Outcome**: Generation time consistently <1ms with stable memory usage

**Verification**: Generate 100 numbers and verify all are within 1-100 range, confirm singleton instance creation, validate performance through Unity Profiler

## 🔧 Implementation Steps

1. **Create Core MonoBehaviour Class**: Create NumberGenerator.cs inheriting from MonoBehaviour with singleton pattern implementation
2. **Implement Singleton Pattern**: Add static Instance property with lazy initialization and proper null checking
3. **Add Random Generation Logic**: Implement GenerateTarget() method using Unity's Random.Range(1, 101) for inclusive range
4. **Configure Inspector Interface**: Add SerializeField attributes for min/max values with proper headers and tooltips
5. **Add Performance Optimization**: Ensure generation method is lightweight with minimal allocations
6. **Implement Public API**: Create clean interface methods for external system integration

## 🏗️ Technical Specification

### **Class Structure:**
```csharp
public class NumberGenerator : MonoBehaviour
{
    public static NumberGenerator Instance { get; private set; }
    
    [Header("Random Generation Configuration")]
    [SerializeField] private int minValue = 1;
    [SerializeField] private int maxValue = 100;
    
    [Header("Current State")]
    [SerializeField, ReadOnly] private int currentTarget;
    
    public int CurrentTarget { get; private set; }
    public int MinValue => minValue;
    public int MaxValue => maxValue;
    
    // Singleton lifecycle management
    // Random number generation methods
    // Public API for external access
}
```

### **Core Logic:**
Random number generation using Unity's Random.Range with inclusive 1-100 range, singleton pattern for global access, performance-optimized generation with <1ms target time.

### **Dependencies:**
Unity MonoBehaviour lifecycle, Unity Random system, proper singleton pattern implementation with null checking and instance management.

**📋 Task Dependencies:**
- **Prerequisites**: Unity project setup, understanding of MonoBehaviour lifecycle and singleton patterns
- **Blocks**: Task 1.1.1.2 (Debug Mode), Task 1.1.1.3 (Statistical Validation), Task 1.1.1.4 (Event Integration)
- **Related Systems**: Future integration with GameStateManager, InputManager, and UI systems

**🔗 Implementation Context:**
- **Existing Codebase**: Check `/Assets/Scripts/` for related components and existing architecture patterns
- **Unity Project Setup**: Verify project configuration matches TDS requirements for manager patterns
- **MCP Integration**: Use Unity MCP tools for component and GameObject management

### **Performance Constraints:**
Generation time <1ms for responsive gameplay, minimal memory allocation during generation, stable performance across repeated generations.

### **Architecture Guidelines:**
- Follow Single Responsibility Principle - NumberGenerator handles only random number generation
- Keep class focused and manageable - avoid feature creep beyond core generation functionality
- Only implement fields and methods explicitly required by the specification
- Avoid unnecessary "nice to have" functionality not in requirements
- Align with TDS singleton MonoBehaviour pattern and BaseGameManager architecture

## 🔧 Unity Integration

**GameObject Setup:** Create NumberGenerator GameObject in _GameSystems hierarchy container for persistent managers
**Scene Hierarchy:** Position under _GameSystems/NumberGenerator following TDS scene organization patterns
**Inspector Config:** SerializeField attributes for min/max values with proper headers, tooltips, and read-only current target display
**System Connections:** Prepare clean API for future integration with GameStateManager events and InputManager validation

## ✅ Success Criteria

- [ ] Numbers generated consistently in 1-100 range (inclusive) across all test scenarios
- [ ] Different random numbers across multiple game sessions without discernible patterns
- [ ] Generation time consistently under 1ms for responsive gameplay experience
- [ ] Singleton pattern provides global access without multiple instances
- [ ] Clean API ready for integration with game state management and UI systems
- [ ] Proper Unity lifecycle integration with Start/Awake methods
- [ ] Memory usage remains stable across multiple generations
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
Follow **MonoBehaviour Singleton** pattern: Create singleton MonoBehaviour component with proper lifecycle management, lazy initialization, and global access through static Instance property.

**⚠️ Fallback Approach:**
If MCP unavailable, create NumberGenerator script manually in Assets/Scripts/ directory, add to NumberGenerator GameObject in scene hierarchy, and configure Inspector fields manually.

**🎯 MCP Integration Requirements:**
- **Unity State Management**: Ensure Unity exits play mode after any tests or validation
- **Component Integration**: Use `manage_gameobject` to create NumberGenerator GameObject with component attachment
- **Script Management**: Use `manage_script` for clean code creation with proper namespaces and Unity conventions
- **Error Handling**: Check Unity console via `read_console` for compilation and runtime issues
- **Linear Integration**: Implementation will be tracked via Linear comments (preserves task descriptions)

### **MCP Priority Implementation:**

**Primary (Use When Available):**
- Use `manage_gameobject` to create NumberGenerator GameObject in _GameSystems hierarchy
- Use `manage_script` to create NumberGenerator.cs script with proper namespace and structure
- Use `manage_scene` to verify proper scene hierarchy organization
- Validate setup with `read_console` for compilation error checking

**Secondary (Fallback):**
- Create Editor setup script for team distribution and consistent GameObject creation
- Manual Unity Editor setup with detailed step-by-step instructions
- Traditional Unity workflow with validation steps and Inspector configuration

## 📁 Deliverables

- `Assets/Scripts/NumberGenerator.cs` - Core MonoBehaviour class with singleton pattern and random generation
- NumberGenerator GameObject in scene hierarchy under _GameSystems container
- Inspector configuration with properly exposed min/max values and current target display
- Basic documentation comments for public methods and properties

## 🧪 Validation

**Functional Validation:**
Generate 100 random numbers and verify all fall within 1-100 inclusive range, confirm singleton behavior prevents multiple instances, validate performance using Unity Profiler.

**Integration Validation:**  
Verify clean API is ready for future GameStateManager integration, confirm GameObject hierarchy follows TDS patterns, test Inspector configuration and field exposure.

**Performance Validation:**
Measure generation time using Unity Profiler to confirm <1ms target, monitor memory allocation during repeated generations, validate performance stability over extended use.

**Epic Alignment Validation:**
Confirm component supports Epic 1.1 random number generation requirements, verify foundation readiness for Features 1.1.2 and 1.1.3 integration.

**GDD Compliance Validation:**
Ensure random generation supports "Pure Logic" design pillar through unbiased number generation, verify "Immediate Clarity" through clean, predictable API.

## 🔄 Response Contract

**Required Output Format:**
1. **Implementation Plan** (4-6 bullets covering singleton pattern, random generation approach, Unity integration, and performance considerations)
2. **Code Files** (NumberGenerator.cs with complete implementation including singleton pattern, random generation, and Inspector integration)  
3. **Unity Setup Method** (MCP commands for GameObject creation and component attachment, with Editor script fallback)
4. **Integration Notes** (brief explanation of how NumberGenerator integrates with future GameStateManager and provides foundation for Epic 1.1)

**File Structure:** Assets/Scripts/NumberGenerator.cs following Unity naming conventions
**Code Standards:** Unity C# naming conventions, XML documentation for public methods, SerializeField attributes for Inspector integration

## 🚨 Resilience Flags

**StubMissingDeps:** Create basic interface stubs for future GameStateManager integration if needed
**ValidationLevel:** Basic - essential error checking for singleton pattern and range validation  
**Reusability:** Reusable - design for potential future use with different ranges or game modes

## 🔍 Dependency Handling

**Missing Dependencies:**
- **If BaseGameManager pattern is missing:** Create standalone MonoBehaviour singleton following Unity best practices
- **If _GameSystems hierarchy is missing:** Create GameObject hierarchy following TDS scene organization
- **If project structure differs:** Adapt to existing project organization while maintaining functionality

**Fallback Behaviors:**
- Return safe default values (50) if generation fails unexpectedly
- Log informative warnings for configuration issues like invalid min/max ranges
- Gracefully handle singleton initialization edge cases and multiple instance attempts
- Align with TDS resilience patterns for robust system operation

**Risk Mitigation:**
Comprehensive null checking for singleton access, proper exception handling for Random.Range edge cases, defensive programming for min/max range validation.

Execute this implementation now.