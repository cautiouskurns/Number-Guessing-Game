## 3. **CLASS DESIGN** (Implementation Level) **PROMPT**

# **AI PROMPT: CLASS DESIGN ARCHITECTURE GENERATOR**


You are an expert software architect specializing in game development class design and object-oriented architecture. Your task is to create Section 3 (Class Design) of a Technical Design Specification by analyzing the Game Design Document and previous technical sections to generate a comprehensive class architecture that supports the game's systems and design goals.

## 📋 INSTRUCTIONS:
1. **Analyze gameplay mechanics and systems** from GDD and previous sections to identify required classes
2. **Apply single responsibility principle** to create clear, focused class responsibilities
3. **Design inheritance hierarchies** that serve the game's architectural needs while favoring composition where appropriate
4. **Select design patterns** that support the game genre, development constraints, and system coordination needs
5. **Define interfaces** that create clear contracts between systems and support the architectural goals
6. **Establish dependency management** appropriate for the team size, timeline, and development approach

## 🎯 OUTPUT FORMAT:

### **3. CLASS DESIGN** *(Implementation Level)*

#### **3.1 Core Classes & Responsibilities**

**FIELD EXPLANATION:** Identify and define the core classes needed for your game by systematically analyzing the systems, gameplay mechanics, and technical requirements from previous sections. Each class should have a single, clear responsibility that maps directly to a specific system or gameplay need. Include class grouping by functional domain, dependency analysis, and comprehensive rationale connecting each class to design goals and architectural requirements.

**Class Design Philosophy:**
The class architecture for "[Game Title]" reflects the **[relevant design pillars]** requirements while maintaining **clear separation of concerns** appropriate for [development context]. Each class has a **single, discoverable responsibility** that directly maps to the [primary systems from previous sections], enabling straightforward task generation and iterative development.

**Core Class Identification & Responsibilities:**

| Class Name | Primary Responsibility | Key Functions | System Domain | Dependencies |
|------------|----------------------|---------------|---------------|--------------|
| **[CoreManagerClass]** | [Single clear responsibility from system analysis] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain from Section 1] | [Dependencies from Section 1] |
| **[GameplayClass1]** | [Single clear responsibility from gameplay mechanics] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |
| **[GameplayClass2]** | [Single clear responsibility from gameplay mechanics] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |
| **[SystemClass1]** | [Single clear responsibility from technical systems] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |
| **[SystemClass2]** | [Single clear responsibility from technical systems] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |
| **[InteractionClass]** | [Single clear responsibility from player interaction] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |
| **[DataClass]** | [Single clear responsibility from data management] | - [Function 1]<br>- [Function 2]<br>- [Function 3]<br>- [Function 4] | [System Domain] | [Dependencies] |

*Include 6-10 core classes based on system complexity from previous sections*

**Class Grouping by Functional Domain:**

**[Primary Domain Name]:**
- `[Class1]` - [Responsibility summary]
- `[Class2]` - [Responsibility summary]
- `[Class3]` - [Responsibility summary]

**[Secondary Domain Name]:**
- `[Class4]` - [Responsibility summary]
- `[Class5]` - [Responsibility summary]

**[Supporting Domain Name]:**
- `[Class6]` - [Responsibility summary]
- `[Class7]` - [Responsibility summary]

#### **3.2 Inheritance Hierarchies**

**FIELD EXPLANATION:** Design inheritance hierarchies that serve your architectural goals while favoring composition where appropriate. This includes creating base classes that provide shared functionality, organizing derived classes that specialize behavior, and defining composition patterns for complex behaviors. Focus on hierarchies that reduce code duplication while maintaining clear responsibilities and Unity integration compatibility.

**Inheritance Strategy Rationale:**
"[Game Title]" uses **[inheritance approach]** to support **[key architectural goals from previous sections]** while following **composition over inheritance** for [specific use cases]. The inheritance relationships serve **[primary architectural purpose]** and **[Unity integration needs]**.

**Primary Inheritance Hierarchies:**

**1. [Primary Hierarchy Name]:**

```

[BaseClass] (Abstract Base)
├── [DerivedClass1]
│   ├── [SpecializedClass1]
│   ├── [SpecializedClass2]
│   └── [SpecializedClass3]
├── [DerivedClass2]
│   ├── [SpecializedClass4]
│   ├── [SpecializedClass5]
│   └── [SpecializedClass6]
└── [DerivedClass3]
├── [SpecializedClass7]
├── [SpecializedClass8]
└── [SpecializedClass9]

```

**[BaseClass] Base Class Responsibilities:**
- **[Shared Responsibility 1]** - [Why this is shared across derived classes]
- **[Shared Responsibility 2]** - [Common behavior rationale]
- **[Shared Responsibility 3]** - [Unity integration or system coordination need]
- **[Shared Responsibility 4]** - [Data management or state coordination]
- **[Shared Responsibility 5]** - [Lifecycle management or event coordination]

**2. [Secondary Hierarchy Name]:**

```

[ManagerBase] (Abstract Base)
├── [SpecificManager1]
├── [SpecificManager2]
├── [SpecificManager3]
└── [SpecificManager4]

```

**[ManagerBase] Base Responsibilities:**
- **[Manager Responsibility 1]** - [System coordination rationale]
- **[Manager Responsibility 2]** - [Initialization and lifecycle management]
- **[Manager Responsibility 3]** - [Cross-system communication handling]
- **[Manager Responsibility 4]** - [State management and persistence]

**3. [Supporting Hierarchy Name]:**

```

[HandlerBase] (Abstract Base)
├── [HandlerType1]
├── [HandlerType2]
├── [HandlerType3]
└── [HandlerType4]

```

**[HandlerBase] Base Responsibilities:**
- **[Handler Responsibility 1]** - [Common processing pattern]
- **[Handler Responsibility 2]** - [Validation and error handling]
- **[Handler Responsibility 3]** - [Event coordination and response]
- **[Handler Responsibility 4]** - [State management and feedback]

**Composition Over Inheritance Examples:**

**Complex Behavioral Composition:**
- `[ComplexClass1]` **composes** `[Component1]` + `[Component2]` + `[Component3]`
- `[ComplexClass2]` **uses** `[System1]` + `[System2]` + `[Handler1]`
- `[ComplexClass3]` **contains** `[Coordinator1]` + `[Validator1]` + `[Trigger1]`

**Why Composition for Complex Behaviors:**
- **[Composition Benefit 1]:** [Specific architectural advantage]
- **[Composition Benefit 2]:** [AI development or maintenance advantage]
- **[Composition Benefit 3]:** [Unity integration or flexibility advantage]

#### **3.3 Design Patterns Used**

**FIELD EXPLANATION:** Select and implement design patterns that support your game's architectural goals, system coordination needs, and development constraints. This includes choosing appropriate patterns for different scenarios, providing concrete implementations, establishing pattern selection criteria, and ensuring patterns work effectively with Unity's architecture. Focus on patterns that solve specific architectural problems rather than generic pattern application.

**Pattern Selection Strategy:**
Design patterns are chosen specifically to support **[key architectural goals from Sections 0-2]** while maintaining **[development approach constraints]**. Each pattern serves the **[primary system goals]** while maintaining **clear architectural boundaries**.

**Core Architectural Patterns:**

**1. Singleton Pattern Applications:**
- **[SingletonClass1]** - [Specific coordination responsibility and why singleton is needed]
- **[SingletonClass2]** - [Centralized management responsibility and rationale]
- **[SingletonClass3]** - [Global state coordination need and justification]

**Singleton Usage Rationale:**
- **[Singleton Rationale 1]** - [Why global access/state is needed for this system]
- **[Singleton Rationale 2]** - [Coordination requirement that demands single instance]
- **[Singleton Rationale 3]** - [Performance or consistency requirement]

**2. Observer Pattern Applications:**
- **[ObserverSystem1]** - [Event coordination responsibility and participant systems]
- **[ObserverSystem2]** - [State change notification system and rationale]
- **[ObserverSystem3]** - [Cross-system communication need and implementation approach]

**Observer Pattern Responsibilities:**
- **[Observer Responsibility 1]:** [Event type] events trigger [coordinated response type]
- **[Observer Responsibility 2]:** [State change type] propagate to [affected systems]
- **[Observer Responsibility 3]:** [System integration type] updates [dependent systems] for [continuity goal]

**3. State Machine Pattern Applications:**
- **[StateMachine1]** - [State progression description and rationale]
- **[StateMachine2]** - [State management need and transition logic]
- **[StateMachine3]** - [Complex state coordination requirement]

**State Machine Usage Rationale:**
- **[State Machine Rationale 1]:** [System behavior] follows [clear pattern] stages
- **[State Machine Rationale 2]:** [Complex transitions] require [structured management approach]
- **[State Machine Rationale 3]:** [Coordination need] needs [sequencing approach]

**4. Command Pattern Applications:**
- **[CommandSystem1]** - [Action encapsulation need and undo/redo capability]
- **[CommandSystem2]** - [Complex operation coordination and rollback support]
- **[CommandSystem3]** - [Action queuing or sequencing requirement]

**Command Pattern Benefits:**
- **[Command Benefit 1]:** [Specific interaction or operation support need]
- **[Command Benefit 2]:** [Coordination or rollback capability]
- **[Command Benefit 3]:** [Flexibility or experimentation support]

**5. Unity-Specific Patterns:**

**ScriptableObject Configuration Pattern:**
- **[ConfigurationAsset1]** - [Configuration domain and designer workflow support]
- **[ConfigurationAsset2]** - [Settings management and runtime flexibility]
- **[ConfigurationAsset3]** - [Data organization and system coordination]

**MonoBehaviour Lifecycle Pattern:**
- **[LifecycleManager1]** - [System initialization and coordination responsibility]
- **[LifecycleManager2]** - [Component management and Unity integration]
- **[LifecycleManager3]** - [Cleanup and resource management coordination]

**ScriptableObject Event Pattern:**
- **[EventChannel1]** - [Event coordination domain and designer configuration]
- **[EventChannel2]** - [System communication and loose coupling]
- **[EventChannel3]** - [State coordination and notification management]

**Interface Design with Concrete Examples:**

**Core System Interfaces:**

```csharp
// System Lifecycle Interface - for consistent initialization and cleanup
public interface ISystemLifecycle
{
    bool IsInitialized { get; }
    int InitializationOrder { get; }
    bool Initialize();
    void Shutdown();
    void OnUpdate(float deltaTime);
}

// Game Entity Interface - for objects that participate in gameplay
public interface IGameEntity
{
    string EntityId { get; }
    bool IsActive { get; set; }
    Transform Transform { get; }
    void OnEntityCreated();
    void OnEntityDestroyed();
}

// Gameplay Interaction Interface - for player-interactable objects
public interface IInteractable
{
    bool CanInteract { get; }
    string InteractionPrompt { get; }
    bool TryInteract(IPlayer player);
    void OnInteractionStart(IPlayer player);
    void OnInteractionEnd(IPlayer player);
}

// State Management Interface - for objects with complex state
public interface IStateful<TState> where TState : System.Enum
{
    TState CurrentState { get; }
    bool CanTransitionTo(TState newState);
    bool TryTransitionTo(TState newState);
    event System.Action<TState, TState> OnStateChanged;
}

// Unity Component Integration Interface - for custom Unity components
public interface IUnityIntegrated
{
    GameObject GameObject { get; }
    bool IsUnityObjectValid { get; }
    void RegisterUnityCallbacks();
    void UnregisterUnityCallbacks();
}

// Performance Monitoring Interface - for objects that need performance tracking
public interface IPerformanceMonitored
{
    string PerformanceId { get; }
    float LastUpdateTime { get; }
    void BeginPerformanceTracking();
    void EndPerformanceTracking();
}
```

**Base Class Examples with Unity Integration:**

```csharp
// Abstract Base Manager with Unity Integration
public abstract class BaseManager : MonoBehaviour, ISystemLifecycle, IPerformanceMonitored
{
    [Header("System Configuration")]
    [SerializeField] private bool autoInitialize = true;
    [SerializeField] private int initializationOrder = 100;
    
    public bool IsInitialized { get; private set; }
    public abstract int InitializationOrder { get; }
    public string PerformanceId => GetType().Name;
    public float LastUpdateTime { get; private set; }
    
    // Unity Lifecycle Integration
    protected virtual void Awake()
    {
        if (autoInitialize)
        {
            RegisterToSystemManager();
        }
    }
    
    protected virtual void Start()
    {
        if (autoInitialize && !IsInitialized)
        {
            Initialize();
        }
    }
    
    protected virtual void Update()
    {
        if (IsInitialized)
        {
            BeginPerformanceTracking();
            OnUpdate(Time.deltaTime);
            EndPerformanceTracking();
        }
    }
    
    protected virtual void OnDestroy()
    {
        if (IsInitialized)
        {
            Shutdown();
        }
    }
    
    // ISystemLifecycle Implementation
    public bool Initialize()
    {
        if (IsInitialized) return true;
        
        bool success = OnInitialize();
        if (success)
        {
            IsInitialized = true;
            OnSystemInitialized();
        }
        
        return success;
    }
    
    public void Shutdown()
    {
        if (!IsInitialized) return;
        
        OnShutdown();
        IsInitialized = false;
    }
    
    public abstract void OnUpdate(float deltaTime);
    protected abstract bool OnInitialize();
    protected virtual void OnShutdown() { }
    protected virtual void OnSystemInitialized() { }
    
    // Performance Monitoring
    public void BeginPerformanceTracking()
    {
        LastUpdateTime = Time.realtimeSinceStartup;
    }
    
    public void EndPerformanceTracking()
    {
        float duration = Time.realtimeSinceStartup - LastUpdateTime;
        if (duration > 0.016f) // More than 16ms (60fps budget)
        {
            Debug.LogWarning($"{PerformanceId} took {duration * 1000:F2}ms");
        }
    }
    
    private void RegisterToSystemManager()
    {
        // Register with central system manager for initialization ordering
        SystemManager.Instance?.RegisterSystem(this);
    }
}

// Abstract Game Entity Base Class
public abstract class BaseGameEntity : MonoBehaviour, IGameEntity, IStateful<EntityState>
{
    [Header("Entity Configuration")]
    [SerializeField] private string entityId;
    [SerializeField] private bool startActive = true;
    
    public string EntityId => string.IsNullOrEmpty(entityId) ? name : entityId;
    public bool IsActive { get; set; }
    public Transform Transform => transform;
    public EntityState CurrentState { get; private set; }
    
    public event System.Action<EntityState, EntityState> OnStateChanged;
    
    protected virtual void Awake()
    {
        IsActive = startActive;
        CurrentState = EntityState.Created;
        OnEntityCreated();
    }
    
    protected virtual void Start()
    {
        if (IsActive)
        {
            TryTransitionTo(EntityState.Active);
        }
    }
    
    public virtual void OnEntityCreated()
    {
        // Register with entity management system
        EntityManager.Instance?.RegisterEntity(this);
    }
    
    public virtual void OnEntityDestroyed()
    {
        // Unregister from entity management system
        EntityManager.Instance?.UnregisterEntity(this);
    }
    
    public virtual bool CanTransitionTo(EntityState newState)
    {
        // Define valid state transitions
        return newState switch
        {
            EntityState.Active => CurrentState == EntityState.Created || CurrentState == EntityState.Inactive,
            EntityState.Inactive => CurrentState == EntityState.Active,
            EntityState.Destroyed => CurrentState != EntityState.Destroyed,
            _ => false
        };
    }
    
    public bool TryTransitionTo(EntityState newState)
    {
        if (!CanTransitionTo(newState)) return false;
        
        EntityState oldState = CurrentState;
        CurrentState = newState;
        
        OnStateTransition(oldState, newState);
        OnStateChanged?.Invoke(oldState, newState);
        
        return true;
    }
    
    protected virtual void OnStateTransition(EntityState from, EntityState to)
    {
        // Override in derived classes for state-specific behavior
    }
}

public enum EntityState
{
    Created,
    Active,
    Inactive,
    Destroyed
}
```

**Interface Usage Strategy with Examples:**
- **System Contracts:** `ISystemLifecycle` ensures consistent initialization across all manager classes
- **Behavior Contracts:** `IInteractable` defines player interaction capabilities for any game object
- **Integration Contracts:** `IUnityIntegrated` provides standard Unity component lifecycle management
- **Testing Contracts:** Interfaces enable dependency injection and mock object creation for automated testing

**Dependency Injection Approach:**

**[Dependency Management Approach] Dependency Management:**
- **Constructor Injection** for [dependency type and rationale]
- **Property Injection** for [dependency type and rationale]
- **Service Locator Pattern** for [dependency type and rationale]
- **Inspector Reference Assignment** for [dependency type and rationale]

**[Game-Specific] Dependency Strategy:**
- **[System Category 1]:** [Dependency approach] for [reliability/performance goal]
- **[System Category 2]:** [Dependency approach] for [flexibility goal]
- **[System Category 3]:** [Dependency approach] for [simplicity goal]
- **[System Category 4]:** [Dependency approach] for [designer control goal]

**Pattern Selection Decision Framework:**

**When to Use Each Pattern - Decision Matrix:**

| Scenario | Singleton | Observer | State Machine | Command | Factory | Strategy |
|----------|-----------|----------|---------------|---------|---------|----------|
| **Global system coordination** | ✅ Ideal | ❌ Too loose | ❌ Not applicable | ❌ Too heavy | ❌ Not needed | ❌ Wrong fit |
| **Event-driven communication** | ❌ Too rigid | ✅ Perfect | ❌ Not flexible | ⚠️ Possible | ❌ Not applicable | ❌ Wrong approach |
| **Complex state transitions** | ❌ Not applicable | ⚠️ Can help | ✅ Designed for this | ❌ Too simple | ❌ Not needed | ❌ Different purpose |
| **Undo/redo functionality** | ❌ Not applicable | ❌ Wrong approach | ❌ Not suitable | ✅ Perfect fit | ❌ Not needed | ❌ Wrong pattern |
| **Object creation complexity** | ⚠️ Sometimes | ❌ Not applicable | ❌ Wrong use | ❌ Not suitable | ✅ Ideal | ❌ Different purpose |
| **Algorithm selection** | ❌ Too rigid | ❌ Not applicable | ⚠️ Can work | ❌ Too heavy | ❌ Wrong fit | ✅ Perfect |

**Pattern Implementation Examples:**

```csharp
// Singleton Pattern - Unity-Optimized Implementation
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

// Observer Pattern - Unity Event-Driven Implementation
public static class GameEvents
{
    public static event System.Action<int> OnScoreChanged;
    public static event System.Action<GameState> OnGameStateChanged;
    public static event System.Action<IPlayer> OnPlayerDied;
    
    public static void RaiseScoreChanged(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }
    
    public static void RaiseGameStateChanged(GameState newState)
    {
        OnGameStateChanged?.Invoke(newState);
    }
}

// Command Pattern - Game Action System
public interface IGameCommand
{
    bool Execute();
    bool Undo();
    string Description { get; }
}

public class MoveCommand : IGameCommand
{
    private readonly IMoveable target;
    private readonly Vector3 direction;
    private readonly float distance;
    private Vector3 originalPosition;
    
    public string Description => $"Move {target} {direction * distance}";
    
    public MoveCommand(IMoveable target, Vector3 direction, float distance)
    {
        this.target = target;
        this.direction = direction;
        this.distance = distance;
    }
    
    public bool Execute()
    {
        if (target == null) return false;
        
        originalPosition = target.Position;
        target.MoveTo(originalPosition + direction * distance);
        return true;
    }
    
    public bool Undo()
    {
        if (target == null) return false;
        
        target.MoveTo(originalPosition);
        return true;
    }
}

public class CommandManager : MonoBehaviour
{
    private readonly Stack<IGameCommand> commandHistory = new Stack<IGameCommand>();
    private readonly Stack<IGameCommand> redoStack = new Stack<IGameCommand>();
    
    public bool ExecuteCommand(IGameCommand command)
    {
        if (command.Execute())
        {
            commandHistory.Push(command);
            redoStack.Clear(); // Clear redo stack when new command is executed
            return true;
        }
        return false;
    }
    
    public bool UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            var command = commandHistory.Pop();
            if (command.Undo())
            {
                redoStack.Push(command);
                return true;
            }
        }
        return false;
    }
}

// Strategy Pattern - AI Behavior Selection
public interface IAIBehavior
{
    void Execute(AIContext context);
    bool CanExecute(AIContext context);
    float GetPriority(AIContext context);
}

public class AggressiveBehavior : IAIBehavior
{
    public void Execute(AIContext context)
    {
        // Aggressive AI behavior implementation
        context.MoveTowards(context.Target);
        context.Attack();
    }
    
    public bool CanExecute(AIContext context)
    {
        return context.HasTarget && context.CanSeeTarget;
    }
    
    public float GetPriority(AIContext context)
    {
        return context.HasTarget ? 0.8f : 0.0f;
    }
}

public class DefensiveBehavior : IAIBehavior
{
    public void Execute(AIContext context)
    {
        // Defensive AI behavior implementation
        context.MoveAwayFrom(context.Target);
        context.Guard();
    }
    
    public bool CanExecute(AIContext context)
    {
        return context.HealthPercentage < 0.3f;
    }
    
    public float GetPriority(AIContext context)
    {
        return 1.0f - context.HealthPercentage;
    }
}

public class AIBehaviorController : MonoBehaviour
{
    [SerializeField] private List<IAIBehavior> availableBehaviors;
    private AIContext context;
    
    private void Update()
    {
        IAIBehavior bestBehavior = SelectBestBehavior();
        bestBehavior?.Execute(context);
    }
    
    private IAIBehavior SelectBestBehavior()
    {
        IAIBehavior best = null;
        float bestPriority = 0f;
        
        foreach (var behavior in availableBehaviors)
        {
            if (behavior.CanExecute(context))
            {
                float priority = behavior.GetPriority(context);
                if (priority > bestPriority)
                {
                    bestPriority = priority;
                    best = behavior;
                }
            }
        }
        
        return best;
    }
}
```

**Pattern Selection Criteria:**
- **Performance Impact:** Singleton (minimal), Observer (low), State Machine (moderate), Command (moderate), Factory (low), Strategy (low-moderate)
- **Unity Compatibility:** All patterns work well with Unity, but prefer ScriptableObject events over static events
- **Team Complexity:** Singleton/Observer (beginner), State Machine/Strategy (intermediate), Command/Factory (advanced)
- **Testability:** Avoid Singleton for testable code, prefer dependency injection

## 🚀 UNITY PERFORMANCE & OPTIMIZATION PATTERNS:

### **Memory-Conscious Class Design:**

```csharp
// Object Pool Pattern for frequently instantiated objects
public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;
    [SerializeField] private int initialPoolSize = 10;
    [SerializeField] private bool expandPool = true;
    
    private readonly Queue<T> pool = new Queue<T>();
    private readonly HashSet<T> activeObjects = new HashSet<T>();
    
    private void Start()
    {
        // Pre-populate pool to avoid runtime allocations
        for (int i = 0; i < initialPoolSize; i++)
        {
            T instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            pool.Enqueue(instance);
        }
    }
    
    public T GetFromPool()
    {
        T instance;
        
        if (pool.Count > 0)
        {
            instance = pool.Dequeue();
        }
        else if (expandPool)
        {
            instance = Instantiate(prefab);
        }
        else
        {
            return null;
        }
        
        instance.gameObject.SetActive(true);
        activeObjects.Add(instance);
        return instance;
    }
    
    public void ReturnToPool(T instance)
    {
        if (instance != null && activeObjects.Contains(instance))
        {
            instance.gameObject.SetActive(false);
            activeObjects.Remove(instance);
            pool.Enqueue(instance);
        }
    }
}

// Efficient Update Management - Avoid MonoBehaviour Update calls
public interface IUpdatable
{
    void OnUpdate(float deltaTime);
    bool IsActive { get; }
}

public class UpdateManager : MonoBehaviour
{
    private readonly List<IUpdatable> updatables = new List<IUpdatable>();
    private readonly List<IUpdatable> toRemove = new List<IUpdatable>();
    
    public void RegisterUpdatable(IUpdatable updatable)
    {
        if (!updatables.Contains(updatable))
        {
            updatables.Add(updatable);
        }
    }
    
    public void UnregisterUpdatable(IUpdatable updatable)
    {
        toRemove.Add(updatable);
    }
    
    private void Update()
    {
        float deltaTime = Time.deltaTime;
        
        // Remove inactive updatables
        foreach (var item in toRemove)
        {
            updatables.Remove(item);
        }
        toRemove.Clear();
        
        // Update all registered objects in a single loop
        for (int i = updatables.Count - 1; i >= 0; i--)
        {
            var updatable = updatables[i];
            if (updatable?.IsActive == true)
            {
                updatable.OnUpdate(deltaTime);
            }
            else
            {
                updatables.RemoveAt(i);
            }
        }
    }
}

// Data-Oriented Component Design for performance
[System.Serializable]
public struct TransformData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    
    public TransformData(Transform transform)
    {
        position = transform.position;
        rotation = transform.rotation;
        scale = transform.localScale;
    }
    
    public void ApplyTo(Transform transform)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }
}

// Efficient GameObject Component Management
public abstract class ComponentManager<T> : MonoBehaviour where T : Component
{
    [SerializeField] private int initialCapacity = 100;
    
    private readonly Dictionary<int, T> components = new Dictionary<int, T>();
    private readonly List<int> recycledIds = new List<int>();
    private int nextId = 0;
    
    protected virtual void Awake()
    {
        // Pre-allocate collections to avoid runtime allocations
        if (components.Count == 0 && initialCapacity > 0)
        {
            // Dictionary doesn't support capacity constructor, but we can optimize with reasonable sizing
        }
    }
    
    public int RegisterComponent(T component)
    {
        int id = GetNextId();
        components[id] = component;
        return id;
    }
    
    public void UnregisterComponent(int id)
    {
        if (components.Remove(id))
        {
            recycledIds.Add(id);
        }
    }
    
    public T GetComponent(int id)
    {
        components.TryGetValue(id, out T component);
        return component;
    }
    
    private int GetNextId()
    {
        if (recycledIds.Count > 0)
        {
            int id = recycledIds[recycledIds.Count - 1];
            recycledIds.RemoveAt(recycledIds.Count - 1);
            return id;
        }
        
        return nextId++;
    }
}
```

### **Unity-Specific Performance Best Practices:**

**MonoBehaviour Optimization Patterns:**

| Pattern | Use Case | Performance Benefit | Implementation |
|---------|----------|-------------------|----------------|
| **Cached Component References** | Frequently accessed components | Eliminates GetComponent calls | Cache in Awake/Start, null-check before use |
| **Coroutine Pooling** | Frequent coroutine usage | Reduces allocation overhead | Pool coroutine objects, reuse WaitForSeconds |
| **Update Manager** | Many objects needing updates | Single Update loop vs hundreds | Central update dispatcher with registration |
| **Object Pooling** | Frequently spawned/destroyed objects | Eliminates instantiation overhead | Pre-allocate pool, activate/deactivate instead of create/destroy |
| **String Interning** | Repeated string operations | Reduces string allocation | Use string constants, StringBuilder for concatenation |

### **Garbage Collection Minimization:**

```csharp
// String allocation avoidance
public class PerformantTextManager : MonoBehaviour
{
    private readonly StringBuilder stringBuilder = new StringBuilder(256);
    private readonly Dictionary<string, string> cachedStrings = new Dictionary<string, string>();
    
    public string FormatScore(int score)
    {
        string key = $"score_{score}";
        
        if (!cachedStrings.TryGetValue(key, out string result))
        {
            stringBuilder.Clear();
            stringBuilder.Append("Score: ");
            stringBuilder.Append(score);
            result = stringBuilder.ToString();
            
            // Cache commonly used strings
            if (cachedStrings.Count < 100)
            {
                cachedStrings[key] = result;
            }
        }
        
        return result;
    }
}

// Collection allocation avoidance
public class EfficientCollectionManager<T>
{
    private readonly List<T> workingList = new List<T>();
    private readonly HashSet<T> workingSet = new HashSet<T>();
    
    public void ProcessItems(IEnumerable<T> items, System.Func<T, bool> predicate)
    {
        // Reuse collections instead of creating new ones
        workingList.Clear();
        workingSet.Clear();
        
        foreach (T item in items)
        {
            if (predicate(item))
            {
                workingList.Add(item);
                workingSet.Add(item);
            }
        }
        
        // Process using working collections
        ProcessWorkingCollections();
    }
    
    private void ProcessWorkingCollections()
    {
        // Implementation using the working collections
        // Collections will be reused in next call
    }
}
```

## 🧪 TESTING & VALIDATION INTEGRATION:

### **Testable Class Design Patterns:**

```csharp
// Dependency Injection for Testing
public interface IGameDataService
{
    void SaveData(GameData data);
    GameData LoadData();
    bool HasSaveData();
}

public class GameLogicManager : MonoBehaviour
{
    private IGameDataService dataService;
    
    // Constructor injection for testing
    public void Initialize(IGameDataService dataService = null)
    {
        this.dataService = dataService ?? new DefaultGameDataService();
    }
    
    public void SaveGame()
    {
        GameData data = CollectGameData();
        dataService.SaveData(data);
    }
    
    private GameData CollectGameData()
    {
        // Game data collection logic
        return new GameData();
    }
}

// Mock service for testing
public class MockGameDataService : IGameDataService
{
    public GameData LastSavedData { get; private set; }
    public int SaveCallCount { get; private set; }
    
    public void SaveData(GameData data)
    {
        LastSavedData = data;
        SaveCallCount++;
    }
    
    public GameData LoadData()
    {
        return new GameData(); // Return test data
    }
    
    public bool HasSaveData()
    {
        return true; // Or false, depending on test scenario
    }
}

// Validation Attributes for Inspector Fields
public class ValidatedMonoBehaviour : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private Transform target;
    
    protected virtual void OnValidate()
    {
        ValidateFields();
    }
    
    private void ValidateFields()
    {
        if (health <= 0)
        {
            Debug.LogError($"{name}: Health must be greater than 0", this);
            health = 1f;
        }
        
        if (target == null)
        {
            Debug.LogWarning($"{name}: Target reference is missing", this);
        }
    }
    
    // Runtime validation
    public bool ValidateState()
    {
        bool isValid = true;
        
        if (health <= 0)
        {
            Debug.LogError($"{name}: Invalid health state: {health}");
            isValid = false;
        }
        
        if (target == null)
        {
            Debug.LogError($"{name}: Missing required target reference");
            isValid = false;
        }
        
        return isValid;
    }
}
```

### **Class Design Quality Checklist:**

**Performance Validation:**
- [ ] Classes avoid allocations in Update/FixedUpdate loops
- [ ] String operations use StringBuilder or cached strings
- [ ] Collections are reused rather than recreated
- [ ] Component references are cached, not retrieved repeatedly
- [ ] Object pooling is used for frequently instantiated objects

**Architecture Validation:**
- [ ] Each class has single, clear responsibility
- [ ] Dependencies are injected, not hardcoded
- [ ] Interfaces define clear contracts between systems
- [ ] Inheritance serves architectural purpose, not just code reuse
- [ ] Composition is preferred over inheritance for complex behaviors

**Unity Integration Validation:**
- [ ] MonoBehaviour lifecycle is properly utilized
- [ ] Serialized fields are validated in OnValidate()
- [ ] References are null-checked before use
- [ ] Coroutines are properly managed and stopped
- [ ] Update methods are optimized or eliminated

**Testing & Debugging Validation:**
- [ ] Classes can be unit tested in isolation
- [ ] Dependencies can be mocked for testing
- [ ] State can be inspected and validated
- [ ] Error conditions are handled gracefully
- [ ] Debug information is available when needed

## 🔧 CLASS IDENTIFICATION METHODOLOGY:

### **System Analysis for Class Extraction:**
- **From Section 1 System Dependencies:** Manager classes for each major system with clear initialization order
- **From Section 2 Gameplay Mechanics:** Dedicated classes for each core gameplay mechanic with single responsibilities
- **From Section 2 Player Interaction:** Input handling and validation classes with performance optimization
- **From Section 2 AI/Behavior:** AI controller classes with appropriate pattern selection (FSM/Behavior Tree/Utility)
- **From GDD Content Requirements:** Data management classes with efficient serialization and caching

### **Performance-Conscious Responsibility Assignment:**
- **Single Responsibility + Performance:** Each class handles one domain efficiently without allocations in hot paths
- **System Boundary + Memory Management:** Classes respect boundaries while sharing pooled resources appropriately
- **Gameplay Mechanic + Optimization:** Core mechanics get optimized implementations with Update management
- **Unity Integration + Best Practices:** Leverage Unity patterns while avoiding common performance pitfalls

### **Pattern Selection with Performance Criteria:**
- **Coordination Needs + Performance:** Choose patterns based on system needs and runtime performance impact
- **State Management + Memory:** Select state patterns that minimize allocations and enable efficient transitions
- **Event Communication + GC:** Use events/delegates with consideration for garbage collection impact
- **Unity Integration + Optimization:** Prefer Unity-optimized patterns over generic implementations
- **Scope + Team + Performance:** Choose appropriate complexity level while maintaining performance standards

### **Testing-Friendly Interface Design:**
- **System Contracts + Testability:** Define interfaces that enable dependency injection and unit testing
- **Behavior Contracts + Validation:** Include validation methods and state inspection capabilities
- **Integration Contracts + Debugging:** Provide debugging and diagnostic capabilities for Unity integration
- **Performance Contracts + Monitoring:** Include performance monitoring and profiling integration points

## 📝 INPUT REQUIREMENTS:
- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**
- **Section 1: System Architecture output**
- **Section 2: Gameplay Architecture output**

## ⚡ KEY REQUIREMENTS:
- **Extract class needs systematically** from all previous sections and GDD mechanics
- **Apply single responsibility principle** consistently across all identified classes
- **Design inheritance hierarchies** that serve architectural goals, not just code reuse
- **Select design patterns** appropriate for the game genre, scope constraints, and development approach
- **Define clear interfaces** that support system integration and AI-assisted development
- **Include comprehensive rationale** connecting all architectural decisions to game design goals
- **Consider Unity integration** and leverage Unity patterns where beneficial
- **Ensure architecture supports** the development constraints and team size from Section 0
- **Make all class designs actionable** for AI-assisted implementation task generation

## 🎮 INPUT:
**Complete GDD:**
[PASTE GAME DESIGN DOCUMENT HERE]

**Section 0 Output:**
[PASTE DESIGN TRANSLATION FRAMEWORK OUTPUT HERE]

**Section 1 Output:**
[PASTE SYSTEM ARCHITECTURE OUTPUT HERE]

**Section 2 Output:**
[PASTE GAMEPLAY ARCHITECTURE OUTPUT HERE]

Generate Section 3 following this exact structure with comprehensive class identification, clear responsibility assignment, and detailed architectural rationale connecting all decisions to the game design goals and previous technical sections.

```