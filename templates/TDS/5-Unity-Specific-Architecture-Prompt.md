## 5. **UNITY-SPECIFIC ARCHITECTURE PROMPT**

# **AI PROMPT: UNITY-SPECIFIC ARCHITECTURE GENERATOR**

You are an expert Unity architect specializing in Unity-specific implementation patterns and optimization strategies. Your task is to create Section 5 (Unity-Specific Architecture) of a Technical Design Specification by analyzing the Game Design Document and previous technical sections to generate comprehensive Unity implementation architecture that leverages Unity's strengths while serving the game's design goals and development constraints.

IMPORTANT: The patterns and code examples below are guidelines to inspire your implementation. Adapt these patterns to your specific game requirements rather than implementing exactly as shown. Focus on the architectural principles and modify the complexity and features to match your game's actual needs.

## 📋 INSTRUCTIONS:
1. **Analyze game systems and mechanics** from GDD and previous sections to identify Unity-specific implementation needs
2. **Design scene organization** that supports the game's content structure, performance targets, and player experience flow
3. **Create prefab architecture** that enables efficient content creation while maintaining design consistency and performance
4. **Establish component composition** patterns that leverage Unity's strengths while supporting the game's system architecture
5. **Design ScriptableObject usage** for configuration, events, and tools that support the development workflow and design goals
6. **Implement resource management** appropriate for platform targets, performance requirements, and content complexity

## 🎯 OUTPUT FORMAT:

### **5. UNITY-SPECIFIC ARCHITECTURE** *(Unity Implementation Details)*

#### **5.1 Scene Organization**

**FIELD EXPLANATION:** Design the Unity scene structure that optimally supports your game's content organization, loading strategies, and performance requirements. This includes defining scene types, additive loading patterns, transition strategies, and cross-scene communication. The architecture should balance content modularity with loading efficiency while maintaining smooth player experience during transitions.

**Scene Architecture Philosophy:**
The scene organization for "[Game Title]" reflects the **[relevant design pillars from GDD]** and **[key gameplay characteristics]** design pillars. Unlike [contrasting game type] requiring [different scene approach], this [game genre] emphasizes **[key scene requirement 1]** and **[key scene requirement 2]**, driving a scene architecture that supports **[scene goal 1]** and **[scene goal 2]**.

**[Game-Specific] Scene Structure:**

| Scene Type | Purpose | Loading Strategy | Content Composition | Why This Approach |
|------------|---------|------------------|---------------------|-------------------|
| **[SceneType1]** | [Scene purpose from game needs] | [Loading approach and timing] | [What content goes in this scene type] | [Rationale connecting to design goals] |
| **[SceneType2]** | [Scene purpose from game needs] | [Loading approach and timing] | [What content goes in this scene type] | [Rationale connecting to design goals] |
| **[SceneType3]** | [Scene purpose from game needs] | [Loading approach and timing] | [What content goes in this scene type] | [Rationale connecting to design goals] |

**Additive Scene Management:**
Design additive loading patterns that support your game's content streaming and memory management needs:
- **Layer-based Loading:** Core scene + content layers + detail overlays
- **Proximity-based Streaming:** Load/unload based on player position and movement
- **State Persistence:** Maintain game state across scene transitions
- **Memory Management:** Intelligent unloading based on distance and importance

**Scene Transition Architecture:**
Create smooth transitions that serve your game's experience goals:
- **Preloading Phase:** Background loading of next scene during gameplay
- **Transition Phase:** Player feedback and continuity maintenance
- **Activation Phase:** Scene switching with state transfer
- **Cleanup Phase:** Previous scene unloading and memory management

**Cross-Scene Communication Patterns:**

**Design Approach:** Implement systems for maintaining data and communication across scene transitions using Unity's DontDestroyOnLoad and singleton patterns.

**Key Components:**
- **Persistent Data Manager:** Singleton-based system for cross-scene data storage
- **Scene Message Queues:** Asynchronous messaging between scenes with type-safe data transfer
- **Shared State System:** Centralized game state management with JSON serialization support
- **Transition Data Passing:** Safe parameter passing during scene changes with automatic cleanup

**Implementation Pattern:**
```csharp
// Example: Simple cross-scene data manager
public class CrossSceneDataManager : MonoBehaviour
{
    private static CrossSceneDataManager instance;
    private Dictionary<string, object> persistentData = new Dictionary<string, object>();
    
    public static void SetPersistentData<T>(string key, T value) { /* Implement singleton-based storage */ }
    public static T GetPersistentData<T>(string key, T defaultValue = default) { /* Implement retrieval with type safety */ }
    public static void SendMessageToScene(string targetScene, string messageType, object data) { /* Implement message queuing */ }
    public static List<SceneMessage> GetMessagesForCurrentScene() { /* Implement message consumption */ }
}
```

### **5.2 Prefab Architecture**

**FIELD EXPLANATION:** Create a comprehensive prefab system that supports efficient content creation, maintains design consistency, and enables flexible variations. This includes prefab hierarchies, variant systems, nesting strategies, pooling implementations, and validation frameworks. The architecture should empower designers while maintaining performance and ensuring consistent game feel.

**Prefab Design Philosophy:**
The prefab architecture prioritizes **[prefab priority 1]** and **[prefab priority 2]** over [deprioritized approach]. The system supports **[design coherence goal]** across different [context variations] while enabling **[development efficiency goal]** for [development context].

**Prefab Organization Strategy:**

| Prefab Category | Design Purpose | Variant Management | Override Strategy | Development Benefit |
| --- | --- | --- | --- | --- |
| **[PrefabCategory1]** | [Category purpose] | [Variant approach] | [Override strategy] | [Development benefit] |
| **[PrefabCategory2]** | [Category purpose] | [Variant approach] | [Override strategy] | [Development benefit] |
| **[PrefabCategory3]** | [Category purpose] | [Variant approach] | [Override strategy] | [Development benefit] |

**Prefab Base Architecture Pattern:**
```csharp
// Example: Base prefab with common functionality
public abstract class [GameSpecific]PrefabBase : MonoBehaviour
{
    [Header("[System] Integration")]
    public [CategoryType] gameCategory;
    public [InfluenceType] systemRole;
    
    protected virtual void Awake() { RegisterWithSystems(); }
    protected abstract void RegisterWithSystems();
    public abstract void IntegrateWith[SystemContext]([ContextType] context);
}
```

**Prefab Variant System:**
- **ScriptableObject-based Configuration:** Data-driven prefab variations
- **Override Hierarchy:** Base prefab → Category variants → Specific instances
- **Designer-Friendly Tools:** Visual variant management in Unity Editor
- **Runtime Optimization:** Efficient instantiation and variant switching

**Prefab Pooling Strategy:**
Design object pooling appropriate for your game's spawning patterns:
- **Category-based Pools:** Separate pools for different prefab types
- **Warm-up System:** Pre-instantiate commonly used prefabs
- **Smart Cleanup:** Return objects based on game state and distance
- **State Preservation:** Maintain or reset object state as appropriate

**Testing and Validation Framework:**

**Validation Approach:** Implement extensible prefab validation to catch issues early:
- **Rule-based System:** Configurable validation rules for different prefab types
- **Performance Analysis:** Vertex count, texture memory, component count monitoring
- **Reference Validation:** Missing component and reference detection
- **Naming Conventions:** Automated naming standard enforcement
- **Editor Integration:** Batch validation tools accessible from Unity Editor

**Validation Pattern:**
```csharp
// Example: Extensible validation system
public class PrefabValidationSystem
{
    public static List<ValidationResult> ValidatePrefab(GameObject prefab) { /* Implement rule-based validation */ }
    public static void RegisterRule(string name, ValidationSeverity severity, Func<GameObject, ValidationResult> validator) { /* Add custom rules */ }
}
```

### **5.3 Component Composition**

**FIELD EXPLANATION:** Design component composition patterns that leverage Unity's component-based architecture while maintaining clear responsibilities and efficient communication. This includes MonoBehaviour organization, update management, component communication patterns, and performance optimization strategies. The system should balance modularity with performance while supporting your game's specific interaction patterns.

**Component Architecture Philosophy:**
The component composition prioritizes **[component priority 1]** and **[component priority 2]** over [deprioritized optimization approach]. The system supports **[system integration goal]** and **[state management goal]** while maintaining **[responsibility clarity goal]** appropriate for [development context].

**Component Organization Strategy:**

| Component Category | Update Strategy | Communication Pattern | Performance Characteristics | Integration Role |
| --- | --- | --- | --- | --- |
| **[ComponentCategory1]** | [Update approach] | [Communication pattern] | [Performance characteristics] | [Integration role and purpose] |
| **[ComponentCategory2]** | [Update approach] | [Communication pattern] | [Performance characteristics] | [Integration role and purpose] |
| **[ComponentCategory3]** | [Update approach] | [Communication pattern] | [Performance characteristics] | [Integration role and purpose] |

**Base Component Pattern:**
```csharp
// Example: Base component with system integration
public abstract class [GameSpecific]Component : MonoBehaviour, I[SystemIntegration]
{
    [Header("[System] Integration")]
    public [SystemPriorityType] updatePriority = [StandardPriority];
    public bool participatesInSystemUpdates = true;
    
    protected virtual void Awake() { InitializeSystemIntegration(); }
    public abstract void IntegrateWithSystems();
    public abstract void UpdateSystemState();
}
```

**Component Communication Patterns:**
- **Event-based Communication:** ScriptableObject events for loose coupling
- **Interface-based Integration:** Clear contracts between components
- **Manager Coordination:** Centralized coordination for complex interactions
- **Performance Optimization:** Update frequency management and batching

**Performance Management:**
Design update strategies appropriate for your game type:
- **Update Categories:** Different update frequencies for different component types
- **Conditional Updates:** State-based update enabling/disabling
- **Batched Operations:** Group similar operations for efficiency
- **Adaptive Performance:** Dynamic adjustment based on performance metrics

### **5.4 ScriptableObject Usage**

**FIELD EXPLANATION:** Design ScriptableObject systems that separate data from behavior, enable designer-friendly configuration, and support modular game architecture. This includes configuration assets, event channels, runtime sets, and editor tool integration. The system should empower non-programmers to modify game behavior while maintaining type safety and performance.

**ScriptableObject Architecture Philosophy:**
The ScriptableObject architecture supports **[designer workflow goal]** and **[system flexibility goal]** essential for [development context]. The system prioritizes **[content modularity goal]** and **[system coordination goal]** while enabling **[rapid iteration goal]** and **[consistent integration goal]**.

**Configuration Asset Strategy:**
- **Hierarchical Configuration:** Base configs → Platform overrides → User preferences
- **Type Safety:** Generic configuration system with compile-time validation
- **Designer Accessibility:** User-friendly interfaces with helpful tooltips and validation
- **Runtime Adaptation:** Hot-reloading support for development iteration

**Event Channel Architecture:**
```csharp
// Example: ScriptableObject event system
[CreateAssetMenu(fileName = "[GameSpecific]EventChannel", menuName = "[GameCategory]/Event Channel")]
public class [GameSpecific]EventChannel : ScriptableObject
{
    public void RaiseEvent([EventDataType] eventData) { /* Implement event broadcasting */ }
    public void Subscribe(System.Action<[EventDataType]> handler) { /* Implement subscription */ }
    public void Unsubscribe(System.Action<[EventDataType]> handler) { /* Implement unsubscription */ }
}
```

**Runtime Set Pattern:**
Implement ScriptableObject collections for managing game entities:
- **Dynamic Entity Tracking:** Automatic registration/deregistration of game objects
- **Query Interface:** Easy access to filtered entity lists
- **Event Notifications:** Automatic events when entities are added/removed
- **Performance Optimization:** Cached queries and efficient lookups

**Editor Tool Integration:**
Design ScriptableObject-based tools for content creators:
- **Visual Configuration:** Custom property drawers for complex data types
- **Validation Integration:** Real-time validation with helpful error messages
- **Preview Systems:** Live preview of configuration changes
- **Template Generation:** Automated creation of common configuration patterns

### **5.5 Resource Management**

**FIELD EXPLANATION:** Design comprehensive resource management systems that handle asset loading, memory optimization, and platform-specific requirements. This includes addressable systems, memory management, streaming strategies, and build optimization. The architecture should balance performance with flexibility while supporting your target platforms and content scope.

**Resource Management Philosophy:**
The resource management architecture prioritizes **[resource priority 1]** and **[resource priority 2]** over [aggressive optimization approach]. The system supports **[smooth transition goal]** and **[rich presentation goal]** while maintaining **[efficient organization goal]**.

**Asset Loading Strategy:**
Design loading patterns appropriate for your game's content and platform requirements:
- **Preloading Strategy:** Critical assets loaded at startup or level beginning
- **Streaming Strategy:** Dynamic loading based on player position and needs
- **Caching Strategy:** Intelligent caching with memory pressure management
- **Addressable Integration:** Unity Addressables for flexible asset management

**Platform Optimization:**
- **Texture Compression:** Platform-specific compression settings
- **Audio Optimization:** Format and quality settings per platform
- **Mesh Optimization:** LOD systems and geometry compression
- **Bundle Strategy:** Asset bundling optimized for target platforms

**Memory Management:**
```csharp
// Example: Memory management system
public class [GameSpecific]MemoryManager : MonoBehaviour
{
    public void OptimizeMemoryForPlatform() { /* Platform-specific optimization */ }
    public void MonitorMemoryUsage() { /* Track memory consumption */ }
    public void TriggerGarbageCollection() { /* Strategic GC timing */ }
    public MemoryReport GenerateMemoryReport() { /* Memory analysis */ }
}
```

**Addressable Asset System:**
- **Asset Groups:** Logical organization of related assets
- **Loading Policies:** Different strategies for different content types
- **Remote Content:** Support for downloadable content and updates
- **Analytics Integration:** Asset usage tracking for optimization

### **5.6 Build and Deployment Optimization**

**FIELD EXPLANATION:** Create comprehensive build pipeline and deployment strategies that optimize for target platforms, minimize build times, and ensure consistent quality across environments. This includes build settings optimization, asset bundling, platform-specific configurations, CI/CD integration, and post-processing automation.

**Build Pipeline Architecture:**
Design automated build systems appropriate for your development workflow:
- **Configuration Management:** Multiple build configurations for different purposes
- **Platform Optimization:** Automatic asset optimization per target platform
- **Quality Assurance:** Integrated testing and validation in build pipeline
- **Deployment Automation:** Automated distribution to target platforms

**Build Configuration Strategy:**
```csharp
// Example: Build configuration system
[System.Serializable]
public class BuildConfiguration
{
    public string configurationName;
    public BuildTarget buildTarget;
    public BuildOptions buildOptions;
    public bool enableAssetBundles;
    
    public void ExecuteBuild() { /* Implement build process */ }
    public void ApplyPlatformOptimizations() { /* Platform-specific settings */ }
}
```

**Asset Optimization:**
- **Texture Settings:** Automatic resolution and compression per platform
- **Audio Settings:** Format and quality optimization for target devices
- **Code Stripping:** Remove unused code for smaller builds
- **Asset Bundling:** Optimize bundle sizes and loading strategies

**CI/CD Integration:**
- **Automated Testing:** Unit tests and integration tests in build pipeline
- **Build Validation:** Automated quality checks and performance regression detection
- **Notification Systems:** Build status notifications via email/Slack
- **Deployment Pipeline:** Automated deployment to development and production environments

**Editor Tool Integration:**

**Development Tools Philosophy:** Create Unity Editor extensions that streamline common development tasks and reduce manual errors.

**Key Editor Tools:**
- **Scene Management:** Batch scene operations, validation, and organization
- **Asset Organization:** Automated folder structure, naming validation, unused asset detection
- **Component Tools:** Custom inspector generation, property drawer templates
- **Build Tools:** Build pipeline management, platform switching, validation checks

**Tool Integration Pattern:**
```csharp
// Example: Editor tool framework
#if UNITY_EDITOR
public class [GameSpecific]EditorTool : EditorWindow
{
    [MenuItem("Tools/[Tool Name]")]
    public static void ShowWindow() { /* Tool interface */ }
    
    private void OnGUI() { /* Tool implementation */ }
    private void ExecuteToolFunction() { /* Tool functionality */ }
}
#endif
```

## 🔧 UNITY IMPLEMENTATION GUIDELINES:

### **Adaptation Principles:**
- **Scale to Game Scope:** Implement only the patterns your game actually needs
- **Performance First:** Choose simpler implementations for better performance when appropriate
- **Team Capability:** Match implementation complexity to team expertise
- **Platform Constraints:** Adapt patterns to target platform limitations

### **Implementation Priority:**
1. **Core Systems First:** Start with essential scene and prefab organization
2. **Communication Second:** Add cross-scene and component communication as needed
3. **Optimization Third:** Add performance and build optimizations
4. **Tools Last:** Create editor tools to support your specific workflow

### **Quality Guidelines:**
- **Code Standards:** Follow Unity's coding conventions and best practices
- **Documentation:** Comment complex systems and provide usage examples
- **Testing:** Implement validation for critical systems
- **Iteration:** Build incrementally and test frequently

## 📝 INPUT REQUIREMENTS:

- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**
- **Section 1: System Architecture output**
- **Section 2: Gameplay Architecture output**
- **Section 3: Class Design output**
- **Section 4: Data Architecture output**

## ⚡ KEY REQUIREMENTS:

- **Extract Unity-specific needs systematically** from all previous sections and GDD requirements
- **Design Unity architecture** that leverages Unity's strengths while serving game design goals
- **Create appropriate scene organization** supporting content structure and performance targets
- **Establish efficient prefab architecture** for content creation, variation, and consistency
- **Design component composition** that supports system architecture and performance goals
- **Implement ScriptableObject systems** for configuration, events, and development workflow
- **Create resource management** appropriate for platform targets and content complexity
- **Include detailed rationale** connecting all Unity decisions to game design goals and development constraints
- **Consider cross-platform deployment** and optimization for performance targets
- **Ensure all Unity architecture supports** AI-assisted implementation and development workflow
- **Scale implementation appropriately** for project scope, team size, and development constraints

## 🎮 INPUT:

**Complete GDD:**
[PASTE GAME DESIGN DOCUMENT HERE]

**Section 0 Output:**
[PASTE DESIGN TRANSLATION FRAMEWORK OUTPUT HERE]

**Section 1 Output:**
[PASTE SYSTEM ARCHITECTURE OUTPUT HERE]

**Section 2 Output:**
[PASTE GAMEPLAY ARCHITECTURE OUTPUT HERE]

**Section 3 Output:**
[PASTE CLASS DESIGN OUTPUT HERE]

**Section 4 Output:**
[PASTE DATA ARCHITECTURE OUTPUT HERE]

Generate Section 5 following this exact structure with comprehensive Unity-specific architecture, detailed implementation strategies, and thorough rationale connecting all Unity decisions to the game's design goals, technical requirements, and development constraints. Adapt the provided patterns to your specific game requirements rather than implementing exactly as shown.
```