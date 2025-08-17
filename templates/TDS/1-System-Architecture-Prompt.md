## 1. **SYSTEM ARCHITECTURE PROMPT**


You are an expert Unity game architect specializing in system design and technical implementation. Your task is to create Section 1 (System Architecture) of a Technical Design Specification by analyzing the Game Design Document and Section 0 (Design Translation Framework) to generate a comprehensive system architecture that supports the game's design goals.

## 📋 INSTRUCTIONS:
1. **Analyze the GDD and Section 0** to understand design pillars, technical requirements, and constraints
2. **Identify required systems** based on gameplay mechanics and technical needs from Section 0
3. **Create system dependency mapping** showing initialization order and critical paths
4. **Design Unity scene hierarchy** that supports the game's architectural needs
5. **Define manager patterns** appropriate for the team size and complexity constraints
6. **Establish communication architecture** that serves the game's interaction patterns

## 🎯 OUTPUT FORMAT:

### **1. SYSTEM ARCHITECTURE** *(High-Level Overview)*

#### **1.1 System Dependency Map**

**FIELD EXPLANATION:** Create a comprehensive analysis of how your game's major systems interact, initialize, and depend on each other. This includes a visual dependency graph, critical path analysis showing startup sequence, and detailed rationale connecting each architectural decision to design goals. This mapping prevents circular dependencies, ensures proper initialization order, and helps AI understand implementation sequence for task generation.

**Purpose & Design Rationale:**
The system architecture for "[Game Title]" reflects the **"[Design Pillar 1]"** and **"[Design Pillar 2]"** design pillars from the GDD. Unlike [contrasting genre] that prioritize [different priority], this [game genre] emphasizes **[key architectural driver 1]** and **[key architectural driver 2]**, driving an architecture that supports **[key experience goal]** and **[secondary experience goal]**.

**System Dependencies - Detailed Analysis:**

```
mermaid
graph TD
    A[System1] --> B[System2]
    A --> C[System3]
    [Continue mapping all major systems and their dependencies]

```

**Critical Path Analysis:**

1. **[Core Manager]** initializes first ([rationale for why this system is foundational])
2. **[Infrastructure System]** establishes [key framework] ([why this system is needed early])
3. **[Input/Interaction System]** enables [player capability] ([how this serves design goals])
4. **[Core Gameplay System]** depends on [other systems] for [functionality]
5. **[Supporting Systems]** are consumers that [respond to/support core systems]

**Why This Architecture for [Game Genre]:**

- **[Key Architectural Decision 1]:** [System] [action/responsibility] because [design rationale]
- **[Key Architectural Decision 2]:** [System] drives [experience] rather than [alternative approach]
- **[Key Architectural Decision 3]:** Multiple systems [coordination pattern] to create [intended experience]
- **[Performance/Pacing Consideration]:** [Performance priority decision based on game type]

**System Lifecycle Management:**
[Description of how systems start up, run, and shut down, considering the game's session patterns and technical constraints]

### **1.2 Component Hierarchy**

**FIELD EXPLANATION:** Design the Unity scene organization and GameObject hierarchy that best supports your game's systems and performance requirements. This includes the complete scene structure with specific GameObject organization, component placement rationale, and performance considerations. The hierarchy should reflect your design priorities and enable efficient system communication and management.

**Unity Scene Architecture - Design Reasoning:**
The scene hierarchy reflects the **"[relevant design pillar]"** design pillar while supporting the **"[technical requirement]"** requirement. The organization prioritizes **[organizational priority 1]** and **[organizational priority 2]** over [deprioritized approach].

**Recommended Scene Organization with Detailed Rationale:**

```
[GameName] (Scene Root)
├── _GameSystems (Empty GameObject - [Organization purpose])
│   ├── [CoreManager] ([Components] + [Additional responsibilities])
│   ├── [SystemManager] ([Technical details])
│   └── [SupportManager] ([Capabilities])
├── [GameplaySection] (Empty GameObject - [Section purpose])
│   ├── [GameplayContainer] (Empty GameObject - [Container purpose])
│   │   ├── [GameplayElement1] ([Technical implementation])
│   │   ├── [GameplayElement2] ([Technical implementation])
│   │   └── [GameplayElement3] ([Technical implementation])
│   └── [AdditionalContainer] ([Purpose and contents])
├── [PlayerSection] (Empty GameObject - [Player system organization])
│   ├── [PlayerObject] ([Components] + [Colliders/Physics])
│   └── [PlayerSupport] ([Support systems like camera, UI])
└── [UISection] ([UI approach based on design pillars])
    ├── [UICategory1] ([UI elements and purpose])
    └── [UICategory2] ([UI elements and purpose])

```

**Design Decisions & Rationale:**

**[Primary Focus Area]:**

- **[Organizational Decision 1]:** [Technical implementation] because [design goal served]
- **[Organizational Decision 2]:** [System organization] for [technical benefit]
- **[Organizational Decision 3]:** [Architecture choice] enables [gameplay goal]

**[Secondary Focus Area]:**

- **[Decision 1]:** [Implementation] rather than [alternative] to [design rationale]
- **[Decision 2]:** [Organization] appear [when/how] to [design goal]

**Performance Considerations:**

- **[Performance Decision 1]:** [Organization] enables [technical benefit]
- **[Performance Decision 2]:** [Caching/reference strategy] for [performance goal]
- **[Performance Decision 3]:** [Architecture choice] prevents [performance problem]

### **1.3 Manager Pattern Structure**

**FIELD EXPLANATION:** Define the manager pattern implementation that coordinates your game's systems while respecting team size and complexity constraints. This includes the base manager class design, specific manager implementations, initialization order management, and communication patterns. Choose patterns that balance system coordination needs with architectural simplicity appropriate for your team and timeline.

**Manager Architecture Philosophy:**
The manager pattern for "[Game Title]" reflects the **[team constraint]** constraint while supporting the **[key design requirements]** requirements. The architecture prioritizes **[priority 1]** over [deprioritized approach], since [game type] [reason for priority choice].

**Core Manager Design Pattern:**

```csharp
public abstract class [BaseManagerName] : MonoBehaviour
{
    public abstract string SystemName { get; }
    public abstract int InitializationOrder { get; }
    public bool IsInitialized { get; private set; }

    [Header("[Game-Specific Integration]")]
    public bool [gameSpecificFlag1] = true;
    public bool [gameSpecificFlag2] = false;

    public virtual bool Initialize()
    {
        bool success = OnInitialize();
        if (success)
        {
            IsInitialized = true;
            Register[GameSpecific]Handlers();
        }
        return success;
    }

    protected abstract bool OnInitialize();
    protected virtual void Register[GameSpecific]Handlers() { }
    public abstract void On[GameSpecificEvent]([EventType] [parameter]);
}

```

**Manager Implementation Strategy:**

| Manager Type | Pattern Used | Justification | Key Responsibilities |
| --- | --- | --- | --- |
| **[CoreManager]** | [Pattern choice] | [Reason for pattern] | [List of responsibilities] |
| **[SystemManager]** | [Pattern choice] | [Reason for pattern] | [List of responsibilities] |
| **[GameplayManager]** | [Pattern choice] | [Reason for pattern] | [List of responsibilities] |
| **[SupportManager]** | [Pattern choice] | [Reason for pattern] | [List of responsibilities] |

**Why These Patterns for [Game Genre]:**

- **[Pattern Decision 1]:** [Manager] [responsibility] because [architectural need]
- **[Pattern Decision 2]:** [Pattern choice] allows [benefit] for [game-specific need]
- **[Pattern Decision 3]:** [Coupling decision] enables [design goal]

**Initialization Order Management:**

```csharp
public enum ManagerInitOrder
{
    [Manager1] = 1,        // [Initialization rationale]
    [Manager2] = 2,        // [Dependency reasoning]
    [Manager3] = 3,        // [Order justification]
    [Manager4] = 4,        // [Dependency explanation]
    [Manager5] = 5,        // [Support system rationale]
    [Manager6] = 6,        // [Final system justification]
}

```

**Manager Communication Philosophy:**
The [design focus] drives a **[communication pattern description]** where [trigger events] trigger [response pattern] through [system coordination approach].

### **1.4 Event/Communication Architecture**

**FIELD EXPLANATION:** Design the communication system that enables your game's systems to coordinate effectively without tight coupling. This includes event system design, communication pattern selection (direct calls vs events vs message passing), performance considerations, and specific implementation code. The architecture should support your game's interaction patterns while maintaining system independence and performance targets.

**Communication Strategy Rationale:**
The **"[design pillar]"** design pillar drives a **[communication approach]**: [interaction types] trigger [response patterns] across [system types] to create [intended experience outcome].

**Event System Design:**

```csharp
public static class [GameSpecific]Events
{
    // [Event category 1] ([event purpose and coordination])
    public static event System.Action<[EventType1]> On[Event1];
    public static event System.Action<[EventType2]> On[Event2];
    public static event System.Action<[EventType3]> On[Event3];

    // [Event category 2] ([event purpose and integration])
    public static event System.Action<[EventType4]> On[Event4];
    public static event System.Action<[EventType5]> On[Event5];
    public static event System.Action<[EventType6]> On[Event6];

    // [Event category 3] ([coordination purpose])
    public static event System.Action<[EventType7]> On[Event7];
    public static event System.Action<[EventType8]> On[Event8];

    // Event raising with [game-specific] context
    public static void Raise[Event1]([EventType1] [parameter])
    {
        On[Event1]?.Invoke([parameter]);
        // [Immediate coordination action]
        [CoordinationMethod]([parameter]);
    }

    public static void Raise[Event4]([EventType4] [parameter])
    {
        On[Event4]?.Invoke([parameter]);
        // [System integration action]
        [SystemManager].Instance?.[ResponseMethod]([parameter]);
    }
}

```

**Communication Pattern Decisions:**

| Communication Type | Usage Scenario | Performance Impact | Justification |
| --- | --- | --- | --- |
| **Direct Method Calls** | [Scenario 1] | [Performance metric] | [Rationale for direct calls] |
| **[Event Type 1]** | [Scenario 2] | [Performance metric] | [Rationale for event system] |
| **[Event Type 2]** | [Scenario 3] | [Performance metric] | [Rationale for choice] |

**Why This [Communication Approach]:**

- **[Communication Decision 1]:** [Events/calls] ensure [coordination benefit] for [design goal]
- **[Communication Decision 2]:** [System coordination] can [independence benefit] without [coupling problem]
- **[Communication Decision 3]:** [Performance consideration] allows for [experience quality trade-off]
- **[Communication Decision 4]:** [Events] can trigger [coordination pattern] simultaneously

**Event Processing Philosophy:**
[Explanation of how the communication architecture serves the game's specific needs, performance requirements, and design goals]

## 🔧 SYSTEM IDENTIFICATION METHODOLOGY:

### **Required Systems Analysis:**

- **From GDD Mechanics:** [gameplay features] → [required systems]
- **From Section 0 Technical Requirements:** [technical needs] → [infrastructure systems]
- **From Platform Constraints:** [platform needs] → [platform-specific systems]
- **From Team/Timeline Constraints:** [complexity level] → [architecture simplicity decisions]

### **Dependency Analysis:**

- **Initialization Dependencies:** Which systems must start before others?
- **Runtime Dependencies:** Which systems require data/services from others?
- **Communication Dependencies:** Which systems need to coordinate with others?

### **Manager Pattern Selection:**

- **Singleton:** Use when [criteria for singleton usage]
- **Component-based:** Use when [criteria for component usage]
- **Event-driven:** Use when [criteria for event-driven usage]
- **Static Utility:** Use when [criteria for static usage]

## 📝 INPUT REQUIREMENTS:

- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**

## ⚡ KEY REQUIREMENTS:

- **Extract system needs** from GDD gameplay mechanics and Section 0 technical requirements
- **Create visual dependency mapping** using mermaid chart syntax
- **Provide detailed Unity scene organization** with specific GameObject structure
- **Include comprehensive rationale** for all architectural decisions
- **Ensure architecture serves** the design pillars and constraints identified in Section 0
- **Make decisions actionable** for subsequent section prompts and AI task generation
- **Consider the specific game genre** and its architectural patterns
- **Account for team size and timeline** constraints in complexity decisions

## 🎮 INPUT:

**Complete GDD:**
[PASTE GAME DESIGN DOCUMENT HERE]

**Section 0 Output:**
[PASTE DESIGN TRANSLATION FRAMEWORK OUTPUT HERE]

Generate Section 1 following this exact structure with detailed rationale for all architectural decisions.