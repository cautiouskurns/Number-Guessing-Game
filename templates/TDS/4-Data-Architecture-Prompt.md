## 4. **DATA ARCHITECTURE** (Information Design) **PROMPT**

# **AI PROMPT: DATA ARCHITECTURE GENERATOR**

You are an expert data architect specializing in game development data design and information systems. Your task is to create Section 4 (Data Architecture) of a Technical Design Specification by analyzing the Game Design Document and previous technical sections to generate a comprehensive data architecture that supports the game's information needs, state management, and performance requirements.

## 📋 INSTRUCTIONS:
1. **Analyze game mechanics and systems** from GDD and previous sections to identify data storage and management needs
2. **Design data structures** appropriate for the game's information complexity, performance targets, and platform constraints
3. **Create state management systems** that support the gameplay patterns, save/load requirements, and player experience goals
4. **Establish serialization strategies** for persistent data, save systems, and cross-session continuity
5. **Design configuration architecture** for settings, preferences, accessibility, and runtime adaptation
6. **Implement memory management** appropriate for platform constraints, performance targets, and development complexity

## 🎯 OUTPUT FORMAT:

### **4. DATA ARCHITECTURE** *(Information Design)*

#### **4.1 Data Structures**

**FIELD EXPLANATION:** Design data structures that efficiently represent your game's information needs while considering performance constraints, serialization requirements, and memory usage. This includes selecting appropriate data types (struct vs class), designing collections for access patterns, implementing validation systems, and ensuring data consistency across the game's lifecycle. Focus on structures that support both runtime performance and development productivity.

**Data Structure Design Philosophy:**
The data architecture for "[Game Title]" prioritizes **[primary data priority from design goals]** and **[secondary data priority]** over [deprioritized approach]. Unlike [contrasting game type] requiring [different data approach], this [game genre] emphasizes **[key data requirement 1]** and **[key data requirement 2]**, driving data structures that maintain **[data consistency goal]** and **[data accessibility goal]**.

**Core [Game-Specific] Data Types:**

```csharp
// [Primary Data Category] Tracking
[System.Serializable]
public struct [PrimaryDataType] : IEquatable<[PrimaryDataType]>
{
    public string [primaryId];
    public [EnumType] [primaryType];
    public [PositionType] [spatialData];
    public float [timeData];
    public [ContextType] [contextData];
    public [RelevanceType] [significanceData];

    // [Data type] operations
    public bool [SignificanceCheck]() => [significanceData] != [RelevanceType].None;
    public float [TimeCalculation]() => Time.time - [timeData];
    public bool [ContextCheck]([ContextType] context) => [contextData].Equals(context);

    // Collection support for [data purpose]
    public bool Equals([PrimaryDataType] other) => [primaryId].Equals(other.[primaryId]);
    public override int GetHashCode() => [primaryId].GetHashCode();
}

// [Secondary Data Category] Configuration
[System.Serializable]
public struct [SecondaryDataType]
{
    public [StateType] [currentState];
    public [ParametersType] [configParameters1];
    public [ParametersType] [configParameters2];
    public [ParametersType] [configParameters3];
    public [TimingType] [timingSettings];

    // [Data type] validation and constraints
    public bool IsValidConfiguration()
    {
        return [configParameters1].IsValid() &&
               [configParameters2].IsValid() &&
               [timingSettings].[duration] > 0.0f;
    }

    public [SecondaryDataType] BlendWith([SecondaryDataType] target, float blendFactor)
    {
        return new [SecondaryDataType]
        {
            [currentState] = blendFactor > 0.5f ? target.[currentState] : [currentState],
            [configParameters1] = [ParametersType].Lerp([configParameters1], target.[configParameters1], blendFactor),
            [configParameters2] = [ParametersType].Blend([configParameters2], target.[configParameters2], blendFactor),
            [configParameters3] = [ParametersType].Interpolate([configParameters3], target.[configParameters3], blendFactor),
            [timingSettings] = [TimingType].Combine([timingSettings], target.[timingSettings])
        };
    }
}

// [Complex Data Category] Data
[System.Serializable]
public class [ComplexDataType]
{
    public readonly string [complexId];
    public readonly [TypeEnum] [complexType];
    public readonly [PositionType] [worldPosition];
    public readonly float [durationData];

    private List<[StepType]> [historyData];
    private Dictionary<string, object> [contextualData];

    public [ComplexDataType](string id, [TypeEnum] type, [PositionType] position)
    {
        [complexId] = id;
        [complexType] = type;
        [worldPosition] = position;
        [durationData] = 0.0f;
        [historyData] = new List<[StepType]>();
        [contextualData] = new Dictionary<string, object>();
    }

    // Immutable [data purpose] recording
    public [ComplexDataType] Record[Operation]([StepType] step)
    {
        var newData = DeepCopy();
        newData.[historyData].Add(step);
        return newData;
    }

    // Contextual data management
    public void SetContextualData<T>(string key, T value) => [contextualData][key] = value;
    public T GetContextualData<T>(string key) => [contextualData].ContainsKey(key) ? (T)[contextualData][key] : default(T);
}

```

**[Game-Specific] Enumeration Types:**

```csharp
public enum [PrimaryStateEnum]
{
    [State1],          // [Description of state and its purpose]
    [State2],          // [Description of state and its purpose]
    [State3],          // [Description of state and its purpose]
    [State4],          // [Description of state and its purpose]
    [State5]           // [Description of state and its purpose]
}

public enum [SecondaryTypeEnum]
{
    [Type1],          // [Description and game context]
    [Type2],          // [Description and game context]
    [Type3],          // [Description and game context]
    [Type4]           // [Description and game context]
}

public enum [InteractionEnum]
{
    [Interaction1],           // [Description of interaction type]
    [Interaction2],           // [Description of interaction type]
    [Interaction3],           // [Description of interaction type]
    [Interaction4],           // [Description of interaction type]
    [Interaction5]            // [Description of interaction type]
}

```

**Unity-Specific Data Architecture Patterns:**

**ScriptableObject Data Design:**

```csharp
// Game Configuration Data - Designer-Friendly ScriptableObjects
[CreateAssetMenu(fileName = "GameData", menuName = "Game/Core Data")]
public abstract class BaseGameData : ScriptableObject
{
    [Header("Data Identity")]
    public string dataId = "";
    public string displayName = "";
    [TextArea(3, 5)]
    public string description = "";
    
    [Header("Unity Editor Integration")]
    public bool showInInspector = true;
    public Color inspectorColor = Color.white;
    
    protected virtual void OnValidate()
    {
        if (string.IsNullOrEmpty(dataId))
        {
            dataId = name.ToLower().Replace(" ", "_");
        }
        
        ValidateData();
    }
    
    protected virtual void ValidateData()
    {
        // Override in derived classes for specific validation
    }
    
    public abstract string GetDataSummary();
}

// Specific Game Data Types
[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : BaseGameData
{
    [Header("Level Configuration")]
    public Vector2 levelSize = new Vector2(10, 10);
    public float difficulty = 1.0f;
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    
    [Header("Level Resources")]
    public List<GameObjectReference> levelPrefabs = new List<GameObjectReference>();
    public AudioClip backgroundMusic;
    public Texture2D levelThumbnail;
    
    [System.Serializable]
    public class SpawnPoint
    {
        public Vector3 position;
        public string spawnType;
        public float spawnProbability = 1.0f;
        
        [HideInInspector]
        public bool isValid = true;
    }
    
    protected override void ValidateData()
    {
        base.ValidateData();
        
        if (levelSize.x <= 0 || levelSize.y <= 0)
        {
            Debug.LogError($"Invalid level size in {name}: {levelSize}");
        }
        
        foreach (var spawn in spawnPoints)
        {
            spawn.isValid = spawn.spawnProbability > 0 && 
                           !string.IsNullOrEmpty(spawn.spawnType);
        }
    }
    
    public override string GetDataSummary()
    {
        return $"Level: {levelSize} | Difficulty: {difficulty} | Spawns: {spawnPoints.Count}";
    }
}

// Data Collection Management
[CreateAssetMenu(fileName = "GameDataCollection", menuName = "Game/Data Collection")]
public class GameDataCollection : ScriptableObject
{
    [Header("Data Collections")]
    public List<LevelData> levels = new List<LevelData>();
    public List<CharacterData> characters = new List<CharacterData>();
    public List<ItemData> items = new List<ItemData>();
    
    [Header("Collection Settings")]
    public bool autoValidateOnLoad = true;
    public bool enableRuntimeLookups = true;
    
    private Dictionary<string, BaseGameData> dataLookup;
    
    public void Initialize()
    {
        if (enableRuntimeLookups)
        {
            BuildDataLookup();
        }
        
        if (autoValidateOnLoad)
        {
            ValidateAllData();
        }
    }
    
    private void BuildDataLookup()
    {
        dataLookup = new Dictionary<string, BaseGameData>();
        
        foreach (var level in levels)
        {
            if (level != null)
                dataLookup[level.dataId] = level;
        }
        
        foreach (var character in characters)
        {
            if (character != null)
                dataLookup[character.dataId] = character;
        }
        
        foreach (var item in items)
        {
            if (item != null)
                dataLookup[item.dataId] = item;
        }
    }
    
    public T GetData<T>(string dataId) where T : BaseGameData
    {
        if (dataLookup != null && dataLookup.TryGetValue(dataId, out BaseGameData data))
        {
            return data as T;
        }
        return null;
    }
    
    private void ValidateAllData()
    {
        int validationErrors = 0;
        
        foreach (var data in dataLookup.Values)
        {
            if (data == null)
            {
                validationErrors++;
                continue;
            }
            
            // Trigger validation through reflection
            var method = data.GetType().GetMethod("ValidateData", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method?.Invoke(data, null);
        }
        
        if (validationErrors > 0)
        {
            Debug.LogWarning($"GameDataCollection validation found {validationErrors} issues");
        }
    }
}
```

**Unity Serialization Optimization:**

```csharp
// Custom serialization for complex data types Unity can't handle
[System.Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();
    
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    
    public Dictionary<TKey, TValue> Dictionary => dictionary;
    
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        
        foreach (var pair in dictionary)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
    
    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        
        int count = Mathf.Min(keys.Count, values.Count);
        for (int i = 0; i < count; i++)
        {
            if (keys[i] != null)
            {
                dictionary[keys[i]] = values[i];
            }
        }
    }
    
    // Dictionary interface methods
    public void Add(TKey key, TValue value) => dictionary.Add(key, value);
    public bool Remove(TKey key) => dictionary.Remove(key);
    public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);
    public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);
    public void Clear() => dictionary.Clear();
    public int Count => dictionary.Count;
}

// Performance-optimized data containers
[System.Serializable]
public struct CompactGameObjectReference
{
    [SerializeField] private int instanceId;
    [SerializeField] private string prefabPath;
    
    private GameObject cachedObject;
    
    public GameObject GameObject
    {
        get
        {
            if (cachedObject == null)
            {
                if (instanceId != 0)
                {
                    cachedObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
                }
                
                if (cachedObject == null && !string.IsNullOrEmpty(prefabPath))
                {
                    cachedObject = Resources.Load<GameObject>(prefabPath);
                }
            }
            
            return cachedObject;
        }
        set
        {
            cachedObject = value;
            instanceId = value != null ? value.GetInstanceID() : 0;
            
            #if UNITY_EDITOR
            if (value != null)
            {
                string assetPath = UnityEditor.AssetDatabase.GetAssetPath(value);
                if (!string.IsNullOrEmpty(assetPath))
                {
                    prefabPath = assetPath;
                }
            }
            #endif
        }
    }
}

// Binary serialization for performance-critical data
public static class BinaryDataSerializer
{
    public static byte[] SerializeGameState(GameState gameState)
    {
        using (var stream = new MemoryStream())
        using (var writer = new BinaryWriter(stream))
        {
            // Write version header
            writer.Write("GAMESTATE");
            writer.Write(1); // Version number
            
            // Write game state data efficiently
            writer.Write(gameState.currentLevel);
            writer.Write(gameState.playerScore);
            writer.Write(gameState.gameTime);
            
            // Write collections efficiently
            writer.Write(gameState.collectedItems.Count);
            foreach (var item in gameState.collectedItems)
            {
                writer.Write(item.itemId);
                writer.Write(item.quantity);
            }
            
            return stream.ToArray();
        }
    }
    
    public static GameState DeserializeGameState(byte[] data)
    {
        using (var stream = new MemoryStream(data))
        using (var reader = new BinaryReader(stream))
        {
            // Validate header
            string header = reader.ReadString();
            if (header != "GAMESTATE")
            {
                throw new InvalidDataException("Invalid save data format");
            }
            
            int version = reader.ReadInt32();
            if (version != 1)
            {
                throw new NotSupportedException($"Save data version {version} not supported");
            }
            
            var gameState = new GameState
            {
                currentLevel = reader.ReadInt32(),
                playerScore = reader.ReadInt64(),
                gameTime = reader.ReadSingle()
            };
            
            int itemCount = reader.ReadInt32();
            gameState.collectedItems = new List<CollectedItem>(itemCount);
            
            for (int i = 0; i < itemCount; i++)
            {
                gameState.collectedItems.Add(new CollectedItem
                {
                    itemId = reader.ReadString(),
                    quantity = reader.ReadInt32()
                });
            }
            
            return gameState;
        }
    }
}
```

**Data Structure Selection Rationale:**

| Data Type | Purpose | Why This Type | Performance Trade-off | Alternative Rejected |
| --- | --- | --- | --- | --- |
| **Struct ([PrimaryDataType])** | [Data purpose and behavior needs] | [Rationale for value vs reference semantics] | [Acceptable trade-off for game goals] | [Alternative] ([reason for rejection]) |
| **Class ([ComplexDataType])** | [Complex data purpose and behavior] | [Rationale for reference semantics] | [Trade-off acceptability for gameplay] | [Alternative] ([reason for rejection]) |
| **List<T> ([CollectionUsage])** | [Sequential data purpose] | [Dynamic growth and order preservation needs] | [Memory vs functionality trade-off] | [Alternative] ([inadequacy reason]) |
| **Dictionary<string, object> ([FlexibleUsage])** | [Runtime flexibility purpose] | [Type flexibility vs safety trade-off] | [Flexibility vs type safety decision] | [Alternative] ([inflexibility reason]) |

**Immutability vs Mutability Strategy:**

**Immutable Data (Value Types):**

- **[ImmutableType1]** - [Reason why this data should be immutable]
- **[ImmutableType2]** - [Historical/snapshot rationale]
- **[ImmutableType3]** - [State consistency rationale]

**Mutable Data (Reference Types):**

- **[MutableType1]** - [Reason why this data needs mutability]
- **[MutableType2]** - [Continuous update rationale]
- **[MutableType3]** - [Runtime modification rationale]

**Data Validation and Constraint Enforcement:**

```csharp
public static class [GameSpecific]DataValidator
{
    public static ValidationResult Validate[DataType]([DataType] [dataInstance])
    {
        var result = new ValidationResult();

        // [Validation category 1]
        if ([validation condition 1])
            result.AddError("[Error message 1]");

        // [Validation category 2]
        if ([validation condition 2])
            result.AddError("[Error message 2]");

        // [Validation category 3]
        if ([validation condition 3])
            result.AddError("[Error message 3]");

        // [Game-specific validation]
        if ([game-specific condition])
            result.AddError("[Game-specific error message]");

        return result;
    }

    public static bool Validate[RelationshipType]([DataType1] from, [DataType2] to)
    {
        // [Relationship validation logic]
        return [ValidationRule].IsValid[Relationship](from.[property], to.[property]) &&
               [TimingRule].IsReasonable(from.[timingProperty], to.[timingProperty]);
    }
}

```

### **4.2 State Management**

**FIELD EXPLANATION:** Create comprehensive state management systems that handle game state persistence, session continuity, and state transitions while supporting undo/redo functionality and data integrity. This includes designing state snapshots, managing state history, implementing persistence strategies, and ensuring state consistency across different game systems. Focus on systems that balance functionality with performance and memory usage.

**State Management Philosophy:**
"[Game Title]" implements **[state management approach]** supporting both **[immediate state need]** and **[persistent state need]**. The approach prioritizes **[state priority 1]** and **[state priority 2]** over [deprioritized state aspect], reflecting the [relevant design pillar] design pillar.

**[Game-Specific] State Architecture:**

```csharp
public class [GameSpecific]StateManager : MonoBehaviour
{
    [Header("State Tracking Configuration")]
    public int max[StateType]HistoryDepth = [number];           // [Purpose of state history]
    public float [stateType]SnapshotInterval = [number]f;       // [Automatic snapshot rationale]
    public bool enable[StateFeature] = true;                    // [State feature purpose]

    [Header("Persistence Configuration")]
    public bool enable[PersistenceType1] = true;                // [Persistence need 1]
    public bool enable[PersistenceType2] = true;                // [Persistence need 2]
    public bool enable[PersistenceType3] = false;               // [Why this doesn't persist]

    // Layered state management
    private Stack<[StateSnapshot]> stateHistory;
    private [GameStateType] current[StateType];
    private Dictionary<string, [PersistentDataType]> persistent[DataCategory];
    private [ProgressionDataType] [progressionData];

    // State management operations
    public void RecordStateSnapshot([SnapshotReason] reason);
    public bool RestoreToSnapshot(int stepsBack = 1);
    public void CommitStateToPersistence();
    public [GameStateType] GetCurrentState();
    public bool ValidateStateConsistency();
}

```

**[Game-Specific] State Snapshot Structure:**

| State Component | Snapshot Strategy | Restoration Approach | Persistence Level | Rationale |
| --- | --- | --- | --- | --- |
| **[StateComponent1]** | [When snapshots are taken] | [How restoration works] | [Persistence duration] | [Why this approach serves game goals] |
| **[StateComponent2]** | [Snapshot timing/trigger] | [Restoration method] | [Persistence level] | [Design goal this serves] |
| **[StateComponent3]** | [Snapshot conditions] | [Restoration approach] | [Persistence duration] | [Player experience rationale] |
| **[StateComponent4]** | [Snapshot strategy] | [Restoration method] | [Persistence level] | [Technical or design rationale] |
| **[StateComponent5]** | [Snapshot approach] | [Restoration strategy] | [Persistence duration] | [Gameplay support rationale] |

**[State Management Feature] System:**

```csharp
public class [GameSpecific][StateFeature]System : MonoBehaviour
{
    [Header("[State Feature] Configuration")]
    public float [stateFeature]TimeWindow = [number]f;        // [Time-based constraint rationale]
    public int max[StateFeature]Operations = [number];        // [Limitation rationale]
    public bool require[StateFeature]Confirmation = true;     // [Confirmation requirement rationale]

    private Queue<[StateAction]> [actionHistory];
    private Dictionary<string, object> [actionContextData];

    public struct [StateAction]
    {
        public string [actionId];
        public [ActionType] [actionType];
        public float [actionTimestamp];
        public [StateSnapshot] [stateBefore];
        public object [actionData];
        public bool [canRevert];

        public bool IsWithin[StateFeature]Window(float currentTime) =>
            (currentTime - [actionTimestamp]) <= [timeWindow];
    }

    // [State feature] operations
    public bool Can[StateFeature]LastAction();
    public [StateFeature]Result [StateFeature]LastAction();
    public void Record[StateAction]([ActionType] type, object actionData);
    public void Clear[StateFeature]History(); // Called at [specific game events]
}

```

**State Persistence Strategy:**

**[Primary Data Category] Persistence:**

- **[PersistenceType1]:** [What persists and why]
- **[PersistenceType2]:** [Persistence rationale and scope]
- **[PersistenceType3]:** [Persistence approach and duration]

**[Secondary Data Category] Persistence:**

- **[PersistenceApproach1]:** [Persistence strategy and rationale]
- **[PersistenceApproach2]:** [What persists across sessions and why]

**Session State Management:**

- **[SessionAspect1]:** [How session state is managed and why]
- **[SessionAspect2]:** [Session reset strategy and rationale]
- **[SessionAspect3]:** [Session continuity approach]

## 🔄 **DATA ACCESS PATTERNS & PERFORMANCE**

### **Repository Pattern Implementation:**

```csharp
// Generic repository interface for data access abstraction
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(System.Func<T, bool> predicate);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
    Task<int> CountAsync();
    Task<bool> ExistsAsync(string id);
}

// Game-specific data repository with caching
public class GameDataRepository<T> : MonoBehaviour, IRepository<T> where T : BaseGameData
{
    [Header("Repository Configuration")]
    public bool enableCaching = true;
    public int maxCacheSize = 100;
    public float cacheTimeoutSeconds = 300f;
    
    [Header("Data Sources")]
    public GameDataCollection dataCollection;
    public bool enablePersistentStorage = true;
    public string persistentDataPath = "";
    
    // Caching infrastructure
    private LRUCache<string, T> dataCache;
    private Dictionary<string, float> cacheTimestamps;
    private HashSet<string> dirtyEntries;
    
    protected virtual void Awake()
    {
        if (enableCaching)
        {
            dataCache = new LRUCache<string, T>(maxCacheSize);
            cacheTimestamps = new Dictionary<string, float>();
            dirtyEntries = new HashSet<string>();
        }
        
        if (dataCollection != null)
        {
            dataCollection.Initialize();
        }
    }
    
    public async Task<T> GetByIdAsync(string id)
    {
        // Check cache first
        if (enableCaching && dataCache.TryGetValue(id, out T cachedItem))
        {
            if (IsCacheEntryValid(id))
            {
                return cachedItem;
            }
            
            // Cache expired, remove
            dataCache.Remove(id);
            cacheTimestamps.Remove(id);
        }
        
        // Load from data collection
        T item = dataCollection?.GetData<T>(id);
        
        // If not in collection, try persistent storage
        if (item == null && enablePersistentStorage)
        {
            item = await LoadFromPersistentStorageAsync(id);
        }
        
        // Cache the result
        if (item != null && enableCaching)
        {
            dataCache.Add(id, item);
            cacheTimestamps[id] = Time.time;
        }
        
        return item;
    }
    
    public async Task<IEnumerable<T>> FindAsync(System.Func<T, bool> predicate)
    {
        var results = new List<T>();
        
        // Search cached items first
        if (enableCaching)
        {
            foreach (var cachedItem in dataCache.Values)
            {
                if (predicate(cachedItem))
                {
                    results.Add(cachedItem);
                }
            }
        }
        
        // Search data collection
        if (dataCollection != null)
        {
            var collectionResults = await SearchDataCollectionAsync(predicate);
            
            // Avoid duplicates from cache
            foreach (var item in collectionResults)
            {
                if (!results.Any(r => r.dataId == item.dataId))
                {
                    results.Add(item);
                }
            }
        }
        
        return results;
    }
    
    public async Task<bool> UpdateAsync(T entity)
    {
        if (entity == null || string.IsNullOrEmpty(entity.dataId))
            return false;
        
        // Mark as dirty for batched persistence
        if (enableCaching)
        {
            dataCache.Add(entity.dataId, entity);
            cacheTimestamps[entity.dataId] = Time.time;
            dirtyEntries.Add(entity.dataId);
        }
        
        // Immediate update to data collection
        bool success = UpdateInDataCollection(entity);
        
        // Schedule persistent storage update
        if (success && enablePersistentStorage)
        {
            await UpdatePersistentStorageAsync(entity);
        }
        
        return success;
    }
    
    private bool IsCacheEntryValid(string id)
    {
        if (!cacheTimestamps.TryGetValue(id, out float timestamp))
            return false;
            
        return (Time.time - timestamp) < cacheTimeoutSeconds;
    }
    
    private async Task<T> LoadFromPersistentStorageAsync(string id)
    {
        // Implement persistent storage loading
        // This could be file system, PlayerPrefs, or database
        return await Task.FromResult<T>(null);
    }
    
    private async Task<IEnumerable<T>> SearchDataCollectionAsync(System.Func<T, bool> predicate)
    {
        // Async search through data collection to avoid blocking
        return await Task.Run(() => {
            return dataCollection.GetAllData<T>().Where(predicate);
        });
    }
    
    // Batch persistence for performance
    public async Task FlushDirtyDataAsync()
    {
        if (dirtyEntries.Count == 0) return;
        
        var entriesToFlush = new List<string>(dirtyEntries);
        dirtyEntries.Clear();
        
        foreach (string id in entriesToFlush)
        {
            if (dataCache.TryGetValue(id, out T item))
            {
                await UpdatePersistentStorageAsync(item);
            }
        }
    }
}

// Efficient caching implementation
public class LRUCache<TKey, TValue>
{
    private readonly int capacity;
    private readonly Dictionary<TKey, LinkedListNode<CacheItem>> cache;
    private readonly LinkedList<CacheItem> accessOrder;
    
    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<TKey, LinkedListNode<CacheItem>>(capacity);
        accessOrder = new LinkedList<CacheItem>();
    }
    
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> node))
        {
            // Move to front (most recently used)
            accessOrder.Remove(node);
            accessOrder.AddFirst(node);
            
            value = node.Value.Value;
            return true;
        }
        
        value = default(TValue);
        return false;
    }
    
    public void Add(TKey key, TValue value)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> existingNode))
        {
            // Update existing item
            existingNode.Value.Value = value;
            accessOrder.Remove(existingNode);
            accessOrder.AddFirst(existingNode);
            return;
        }
        
        // Add new item
        if (cache.Count >= capacity)
        {
            // Remove least recently used item
            var lastNode = accessOrder.Last;
            accessOrder.RemoveLast();
            cache.Remove(lastNode.Value.Key);
        }
        
        var newNode = accessOrder.AddFirst(new CacheItem { Key = key, Value = value });
        cache[key] = newNode;
    }
    
    public bool Remove(TKey key)
    {
        if (cache.TryGetValue(key, out LinkedListNode<CacheItem> node))
        {
            accessOrder.Remove(node);
            cache.Remove(key);
            return true;
        }
        return false;
    }
    
    public IEnumerable<TValue> Values => accessOrder.Select(item => item.Value);
    public int Count => cache.Count;
    
    private class CacheItem
    {
        public TKey Key;
        public TValue Value;
    }
}
```

### **Data Service Layer Pattern:**

```csharp
// Service layer for complex data operations
public abstract class BaseDataService<T> : MonoBehaviour where T : BaseGameData
{
    [Header("Service Configuration")]
    public bool enableAutomaticCaching = true;
    public bool enablePreloading = false;
    public bool enableBackgroundUpdates = false;
    
    protected IRepository<T> repository;
    protected HashSet<string> preloadedIds;
    protected Queue<DataOperation> operationQueue;
    
    protected virtual void Awake()
    {
        repository = GetComponent<IRepository<T>>();
        preloadedIds = new HashSet<string>();
        operationQueue = new Queue<DataOperation>();
        
        if (enablePreloading)
        {
            StartCoroutine(PreloadCriticalDataCoroutine());
        }
        
        if (enableBackgroundUpdates)
        {
            StartCoroutine(ProcessOperationQueueCoroutine());
        }
    }
    
    // High-level service methods
    public async Task<ServiceResult<T>> GetDataAsync(string id, bool forceRefresh = false)
    {
        try
        {
            T data = await repository.GetByIdAsync(id);
            
            if (data != null)
            {
                return ServiceResult<T>.Success(data);
            }
            
            return ServiceResult<T>.NotFound($"Data with id '{id}' not found");
        }
        catch (System.Exception ex)
        {
            return ServiceResult<T>.Error($"Failed to get data: {ex.Message}");
        }
    }
    
    public async Task<ServiceResult<IEnumerable<T>>> SearchDataAsync(DataQuery<T> query)
    {
        try
        {
            var results = await repository.FindAsync(query.Predicate);
            
            if (query.SortOrder != null)
            {
                results = query.SortOrder(results);
            }
            
            if (query.PageSize > 0)
            {
                results = results.Skip(query.PageIndex * query.PageSize).Take(query.PageSize);
            }
            
            return ServiceResult<IEnumerable<T>>.Success(results);
        }
        catch (System.Exception ex)
        {
            return ServiceResult<IEnumerable<T>>.Error($"Search failed: {ex.Message}");
        }
    }
    
    public async Task<ServiceResult<bool>> UpdateDataAsync(T data, bool immediate = false)
    {
        if (immediate)
        {
            return await ExecuteUpdateImmediatelyAsync(data);
        }
        else
        {
            QueueOperation(new DataOperation
            {
                Type = DataOperationType.Update,
                Data = data,
                Id = data.dataId
            });
            
            return ServiceResult<bool>.Success(true);
        }
    }
    
    // Background processing
    private IEnumerator ProcessOperationQueueCoroutine()
    {
        while (enabled)
        {
            if (operationQueue.Count > 0)
            {
                var operation = operationQueue.Dequeue();
                yield return StartCoroutine(ProcessOperationCoroutine(operation));
            }
            
            yield return new WaitForSeconds(0.1f); // Process queue every 100ms
        }
    }
    
    private IEnumerator ProcessOperationCoroutine(DataOperation operation)
    {
        switch (operation.Type)
        {
            case DataOperationType.Update:
                var updateTask = repository.UpdateAsync(operation.Data);
                yield return new WaitUntil(() => updateTask.IsCompleted);
                break;
                
            case DataOperationType.Delete:
                var deleteTask = repository.DeleteAsync(operation.Id);
                yield return new WaitUntil(() => deleteTask.IsCompleted);
                break;
        }
    }
    
    private void QueueOperation(DataOperation operation)
    {
        operationQueue.Enqueue(operation);
        
        // Prevent queue from growing too large
        if (operationQueue.Count > 1000)
        {
            Debug.LogWarning("Data operation queue is getting large. Consider increasing processing frequency.");
        }
    }
}

// Query builder for complex data searches
public class DataQuery<T>
{
    public System.Func<T, bool> Predicate { get; private set; }
    public System.Func<IEnumerable<T>, IOrderedEnumerable<T>> SortOrder { get; private set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    
    private DataQuery() { }
    
    public static DataQuery<T> Create()
    {
        return new DataQuery<T>
        {
            Predicate = _ => true, // Default: select all
            PageIndex = 0,
            PageSize = 0 // 0 means no pagination
        };
    }
    
    public DataQuery<T> Where(System.Func<T, bool> predicate)
    {
        Predicate = predicate;
        return this;
    }
    
    public DataQuery<T> OrderBy<TKey>(System.Func<T, TKey> keySelector)
    {
        SortOrder = items => items.OrderBy(keySelector);
        return this;
    }
    
    public DataQuery<T> OrderByDescending<TKey>(System.Func<T, TKey> keySelector)
    {
        SortOrder = items => items.OrderByDescending(keySelector);
        return this;
    }
    
    public DataQuery<T> Page(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        return this;
    }
}

// Service result wrapper for error handling
public class ServiceResult<T>
{
    public bool IsSuccess { get; private set; }
    public T Data { get; private set; }
    public string ErrorMessage { get; private set; }
    public ServiceResultType ResultType { get; private set; }
    
    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T>
        {
            IsSuccess = true,
            Data = data,
            ResultType = ServiceResultType.Success
        };
    }
    
    public static ServiceResult<T> NotFound(string message)
    {
        return new ServiceResult<T>
        {
            IsSuccess = false,
            ErrorMessage = message,
            ResultType = ServiceResultType.NotFound
        };
    }
    
    public static ServiceResult<T> Error(string message)
    {
        return new ServiceResult<T>
        {
            IsSuccess = false,
            ErrorMessage = message,
            ResultType = ServiceResultType.Error
        };
    }
}

public enum ServiceResultType
{
    Success,
    NotFound,
    Error,
    ValidationFailed,
    PermissionDenied
}
```

### **4.3 Serialization Requirements**

**FIELD EXPLANATION:** Establish robust serialization systems for save/load functionality, configuration management, and data persistence across game sessions. This includes designing save data formats, implementing versioning and migration strategies, handling data integrity and corruption, and ensuring backward compatibility. Focus on systems that balance data fidelity with performance and maintainability.

**Serialization Strategy Philosophy:**
The serialization architecture supports **[primary serialization goal]** and **[secondary serialization goal]** while maintaining **[data integrity goal]** across updates. The approach prioritizes **[serialization priority 1]** and **[serialization priority 2]** over [deprioritized aspect].

**[Game-Specific] Save Data Structure:**

```csharp
[System.Serializable]
public class [GameSpecific]SaveData
{
    [Header("Save Data Metadata")]
    public string saveDataVersion = "1.0.0";
    public string gameVersion = "1.0.0";
    public DateTime lastSaveTime;
    public float totalPlayTime;
    public SaveDataIntegrity integrityHash;

    [Header("[Primary Data Category]")]
    public [PrimaryProgressionType] [primaryProgression];
    public List<[CompletedEventType]> [eventHistory];
    public Dictionary<string, bool> [flagData];

    [Header("[Secondary Data Category]")]
    public Dictionary<string, [SecondaryDataType]> [secondaryData];
    public Dictionary<string, [ResponseDataType]> [responseMemory];
    public List<[RelationshipType]> [discoveredRelationships];

    [Header("Player Data")]
    public [PlayerProgressionType] [playerProgression];
    public Dictionary<string, float> [playerSettings];
    public [PlayerPreferencesType] [playerPreferences];

    // Save data validation and integrity
    public bool ValidateSaveDataIntegrity();
    public void UpdateIntegrityHash();
    public SaveDataMigrationResult MigrateToCurrentVersion();
}

```

**Data Format and Versioning Strategy:**

| Data Category | Format | Versioning Approach | Migration Strategy | Rationale |
| --- | --- | --- | --- | --- |
| **[DataCategory1]** | [Format choice] | [Versioning strategy] | [Migration approach] | [Why this approach serves the data needs] |
| **[DataCategory2]** | [Format choice] | [Versioning strategy] | [Migration approach] | [Data preservation rationale] |
| **[DataCategory3]** | [Format choice] | [Versioning strategy] | [Migration approach] | [Performance vs compatibility trade-off] |
| **[DataCategory4]** | [Format choice] | [Versioning strategy] | [Migration approach] | [Data regeneration capability rationale] |

**Save/Load System Architecture:**

```csharp
public class [GameSpecific]SaveSystem : MonoBehaviour
{
    [Header("Save System Configuration")]
    public SaveDataFormat primaryFormat = SaveDataFormat.[Format];
    public bool enableSaveDataCompression = [boolean];
    public bool enableIntegrityValidation = [boolean];
    public int maxSaveSlots = [number];

    [Header("Serialization Settings")]
    public float autosaveInterval = [number]f;        // [Autosave rationale]
    public bool enable[AutosaveType1] = true;          // [Autosave trigger 1]
    public bool enable[AutosaveType2] = true;          // [Autosave trigger 2]

    // Save/Load operations
    public async Task<SaveResult> Save[GameSpecific]Data([SaveDataType] saveData, int saveSlot);
    public async Task<LoadResult> Load[GameSpecific]Data(int saveSlot);
    public bool ValidateSaveDataIntegrity([SaveDataType] saveData);
    public SaveDataMigrationResult MigrateSaveData([SaveDataType] saveData, string targetVersion);

    // Data migration and versioning
    private Dictionary<string, ISaveDataMigrator> versionMigrators;
    private SaveDataVersionValidator versionValidator;
}

```

**Backward Compatibility and Migration:**

**Version Migration Strategy:**

- **[MigrationAspect1]:** [What is preserved and how]
- **[MigrationAspect2]:** [Data protection approach]
- **[MigrationAspect3]:** [Setting migration strategy]
- **[MigrationAspect4]:** [Data regeneration approach when needed]

**Data Migration Pipeline:**

1. **[MigrationStep1]:** [Validation or integrity step]
2. **[MigrationStep2]:** [Version detection step]
3. **[MigrationStep3]:** [Critical data preservation step]
4. **[MigrationStep4]:** [Settings and preferences migration]
5. **[MigrationStep5]:** [Derived data reconstruction]
6. **[MigrationStep6]:** [Final validation step]

## 🛡️ **ERROR HANDLING & RECOVERY SYSTEMS**

### **Data Corruption Detection and Recovery:**

```csharp
// Comprehensive data integrity and recovery system
public class DataIntegrityManager : MonoBehaviour
{
    [Header("Integrity Configuration")]
    public bool enableDataValidation = true;
    public bool enableAutomaticBackups = true;
    public int maxBackupCount = 5;
    public float backupIntervalHours = 24f;
    
    [Header("Recovery Configuration")]
    public bool enableAutomaticRecovery = true;
    public bool enableCorruptionDetection = true;
    public bool enableDataRegenerationFallback = false;
    
    private Dictionary<string, DataIntegrityInfo> dataIntegrityMap;
    private Queue<BackupInfo> backupHistory;
    private HashSet<string> corruptedDataIds;
    
    public struct DataIntegrityInfo
    {
        public string dataId;
        public string checksum;
        public DateTime lastValidated;
        public int corruptionCount;
        public bool isValid;
    }
    
    public struct BackupInfo
    {
        public string backupPath;
        public DateTime createdTime;
        public string dataVersion;
        public long fileSizeBytes;
    }
    
    private void Awake()
    {
        dataIntegrityMap = new Dictionary<string, DataIntegrityInfo>();
        backupHistory = new Queue<BackupInfo>();
        corruptedDataIds = new HashSet<string>();
        
        if (enableAutomaticBackups)
        {
            InvokeRepeating(nameof(CreateAutomaticBackup), backupIntervalHours * 3600f, backupIntervalHours * 3600f);
        }
    }
    
    public DataRecoveryResult ValidateAndRepairData<T>(T data) where T : class
    {
        if (data == null)
        {
            return DataRecoveryResult.Failed("Data is null");
        }
        
        string dataId = GetDataId(data);
        
        // Step 1: Basic validation
        if (!ValidateDataStructure(data))
        {
            return AttemptDataRecovery<T>(dataId, "Structure validation failed");
        }
        
        // Step 2: Checksum validation
        if (enableDataValidation && !ValidateDataChecksum(data, dataId))
        {
            return AttemptDataRecovery<T>(dataId, "Checksum validation failed");
        }
        
        // Step 3: Business logic validation
        if (!ValidateBusinessLogic(data))
        {
            return AttemptDataRecovery<T>(dataId, "Business logic validation failed");
        }
        
        // Update integrity info for valid data
        UpdateIntegrityInfo(dataId, data);
        
        return DataRecoveryResult.Success("Data validation passed");
    }
    
    private DataRecoveryResult AttemptDataRecovery<T>(string dataId, string reason) where T : class
    {
        Debug.LogWarning($"Data corruption detected for {dataId}: {reason}");
        corruptedDataIds.Add(dataId);
        
        if (!enableAutomaticRecovery)
        {
            return DataRecoveryResult.Failed($"Automatic recovery disabled. {reason}");
        }
        
        // Recovery Strategy 1: Load from most recent backup
        var backupResult = TryLoadFromBackup<T>(dataId);
        if (backupResult.IsSuccess)
        {
            Debug.Log($"Successfully recovered {dataId} from backup");
            return backupResult;
        }
        
        // Recovery Strategy 2: Regenerate from default/template
        if (enableDataRegenerationFallback)
        {
            var regenResult = TryRegenerateData<T>(dataId);
            if (regenResult.IsSuccess)
            {
                Debug.Log($"Successfully regenerated {dataId} from defaults");
                return regenResult;
            }
        }
        
        // Recovery Strategy 3: Partial recovery (salvage what's usable)
        var partialResult = TryPartialRecovery<T>(dataId);
        if (partialResult.IsSuccess)
        {
            Debug.LogWarning($"Partial recovery successful for {dataId}");
            return partialResult;
        }
        
        // All recovery strategies failed
        return DataRecoveryResult.Failed($"All recovery strategies failed for {dataId}");
    }
    
    private DataRecoveryResult TryLoadFromBackup<T>(string dataId) where T : class
    {
        // Search backups from newest to oldest
        var sortedBackups = backupHistory.OrderByDescending(b => b.createdTime);
        
        foreach (var backup in sortedBackups)
        {
            try
            {
                T recoveredData = LoadDataFromBackup<T>(backup.backupPath, dataId);
                if (recoveredData != null && ValidateDataStructure(recoveredData))
                {
                    return DataRecoveryResult.Success("Recovered from backup", recoveredData);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to load from backup {backup.backupPath}: {ex.Message}");
            }
        }
        
        return DataRecoveryResult.Failed("No valid backup found");
    }
    
    private DataRecoveryResult TryRegenerateData<T>(string dataId) where T : class
    {
        try
        {
            // Use factory pattern or default constructors to regenerate data
            T regeneratedData = CreateDefaultData<T>(dataId);
            if (regeneratedData != null)
            {
                return DataRecoveryResult.Success("Regenerated from defaults", regeneratedData);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to regenerate data for {dataId}: {ex.Message}");
        }
        
        return DataRecoveryResult.Failed("Data regeneration failed");
    }
    
    private DataRecoveryResult TryPartialRecovery<T>(string dataId) where T : class
    {
        // Attempt to salvage partial data by reconstructing valid portions
        try
        {
            T partialData = PartialDataReconstruction<T>(dataId);
            if (partialData != null)
            {
                return DataRecoveryResult.Success("Partial recovery completed", partialData);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Partial recovery failed for {dataId}: {ex.Message}");
        }
        
        return DataRecoveryResult.Failed("Partial recovery failed");
    }
    
    // Backup management
    public void CreateManualBackup(string reason = "Manual backup")
    {
        try
        {
            string backupPath = GenerateBackupPath();
            CreateBackupFile(backupPath);
            
            var backupInfo = new BackupInfo
            {
                backupPath = backupPath,
                createdTime = DateTime.Now,
                dataVersion = Application.version,
                fileSizeBytes = new FileInfo(backupPath).Length
            };
            
            backupHistory.Enqueue(backupInfo);
            
            // Maintain backup count limit
            while (backupHistory.Count > maxBackupCount)
            {
                var oldBackup = backupHistory.Dequeue();
                if (File.Exists(oldBackup.backupPath))
                {
                    File.Delete(oldBackup.backupPath);
                }
            }
            
            Debug.Log($"Backup created: {backupPath} ({reason})");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Backup creation failed: {ex.Message}");
        }
    }
    
    private void CreateAutomaticBackup()
    {
        CreateManualBackup("Automatic scheduled backup");
    }
    
    // Helper methods
    private bool ValidateDataStructure<T>(T data)
    {
        // Implement structure validation logic
        return data != null;
    }
    
    private bool ValidateDataChecksum<T>(T data, string dataId)
    {
        string currentChecksum = CalculateChecksum(data);
        
        if (dataIntegrityMap.TryGetValue(dataId, out DataIntegrityInfo info))
        {
            return info.checksum == currentChecksum;
        }
        
        return true; // No previous checksum to compare
    }
    
    private bool ValidateBusinessLogic<T>(T data)
    {
        // Implement game-specific business logic validation
        return true;
    }
    
    private string CalculateChecksum<T>(T data)
    {
        // Implement checksum calculation (MD5, SHA256, etc.)
        return data.GetHashCode().ToString();
    }
}

// Recovery result wrapper
public class DataRecoveryResult
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public object RecoveredData { get; private set; }
    public DataRecoveryType RecoveryType { get; private set; }
    
    public static DataRecoveryResult Success(string message, object recoveredData = null)
    {
        return new DataRecoveryResult
        {
            IsSuccess = true,
            Message = message,
            RecoveredData = recoveredData,
            RecoveryType = DataRecoveryType.Success
        };
    }
    
    public static DataRecoveryResult Failed(string message)
    {
        return new DataRecoveryResult
        {
            IsSuccess = false,
            Message = message,
            RecoveryType = DataRecoveryType.Failed
        };
    }
}

public enum DataRecoveryType
{
    Success,
    Failed,
    PartialRecovery,
    BackupRecovery,
    RegeneratedData
}
```

### **Save File Error Handling:**

```csharp
// Robust save/load system with error handling
public class SafeSaveSystem : MonoBehaviour
{
    [Header("Save System Configuration")]
    public int maxSaveRetries = 3;
    public float saveRetryDelaySeconds = 1f;
    public bool createBackupBeforeSave = true;
    public bool verifyAfterSave = true;
    
    [Header("Error Recovery")]
    public bool enableSaveRecovery = true;
    public bool enableCorruptionRepair = true;
    public string emergencyBackupPath = "";
    
    public async Task<SaveOperationResult> SafeSaveDataAsync<T>(T data, string filePath) where T : class
    {
        if (data == null || string.IsNullOrEmpty(filePath))
        {
            return SaveOperationResult.Failed("Invalid save parameters");
        }
        
        // Create backup before saving if enabled
        string backupPath = null;
        if (createBackupBeforeSave && File.Exists(filePath))
        {
            backupPath = CreateBackupCopy(filePath);
        }
        
        // Attempt save with retries
        for (int attempt = 0; attempt < maxSaveRetries; attempt++)
        {
            try
            {
                // Attempt the save operation
                await WriteSaveDataAsync(data, filePath);
                
                // Verify the saved data if enabled
                if (verifyAfterSave)
                {
                    var verificationResult = await VerifySaveDataAsync<T>(filePath);
                    if (!verificationResult.IsSuccess)
                    {
                        Debug.LogWarning($"Save verification failed on attempt {attempt + 1}: {verificationResult.ErrorMessage}");
                        
                        if (attempt < maxSaveRetries - 1)
                        {
                            await Task.Delay((int)(saveRetryDelaySeconds * 1000));
                            continue;
                        }
                    }
                }
                
                // Save successful, clean up backup
                if (backupPath != null && File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }
                
                return SaveOperationResult.Success("Save completed successfully");
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.LogError($"Save attempt {attempt + 1} failed - Access denied: {ex.Message}");
                
                if (attempt == maxSaveRetries - 1)
                {
                    return HandleSaveFailure(backupPath, $"Access denied: {ex.Message}");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Debug.LogError($"Save attempt {attempt + 1} failed - Directory not found: {ex.Message}");
                
                // Try to create the directory
                try
                {
                    string directory = Path.GetDirectoryName(filePath);
                    Directory.CreateDirectory(directory);
                }
                catch
                {
                    return HandleSaveFailure(backupPath, $"Cannot create directory: {ex.Message}");
                }
                
                if (attempt == maxSaveRetries - 1)
                {
                    return HandleSaveFailure(backupPath, $"Directory creation failed: {ex.Message}");
                }
            }
            catch (IOException ex)
            {
                Debug.LogError($"Save attempt {attempt + 1} failed - IO Error: {ex.Message}");
                
                if (attempt < maxSaveRetries - 1)
                {
                    await Task.Delay((int)(saveRetryDelaySeconds * 1000));
                }
                else
                {
                    return HandleSaveFailure(backupPath, $"IO Error: {ex.Message}");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Save attempt {attempt + 1} failed - Unexpected error: {ex.Message}");
                
                if (attempt == maxSaveRetries - 1)
                {
                    return HandleSaveFailure(backupPath, $"Unexpected error: {ex.Message}");
                }
            }
        }
        
        return HandleSaveFailure(backupPath, "All save attempts failed");
    }
    
    public async Task<LoadOperationResult<T>> SafeLoadDataAsync<T>(string filePath) where T : class
    {
        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        {
            return LoadOperationResult<T>.Failed("File does not exist");
        }
        
        try
        {
            // Attempt to load the file
            T data = await ReadSaveDataAsync<T>(filePath);
            
            if (data == null)
            {
                return await AttemptLoadRecovery<T>(filePath, "Data deserialization returned null");
            }
            
            // Validate loaded data
            if (!ValidateLoadedData(data))
            {
                return await AttemptLoadRecovery<T>(filePath, "Data validation failed");
            }
            
            return LoadOperationResult<T>.Success(data, "Load completed successfully");
        }
        catch (FileNotFoundException ex)
        {
            return LoadOperationResult<T>.Failed($"File not found: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            return LoadOperationResult<T>.Failed($"Access denied: {ex.Message}");
        }
        catch (JsonException ex)
        {
            return await AttemptLoadRecovery<T>(filePath, $"JSON parsing error: {ex.Message}");
        }
        catch (System.Exception ex)
        {
            return await AttemptLoadRecovery<T>(filePath, $"Load error: {ex.Message}");
        }
    }
    
    private async Task<LoadOperationResult<T>> AttemptLoadRecovery<T>(string filePath, string errorReason) where T : class
    {
        Debug.LogWarning($"Load failed for {filePath}: {errorReason}. Attempting recovery.");
        
        if (!enableSaveRecovery)
        {
            return LoadOperationResult<T>.Failed($"Recovery disabled. {errorReason}");
        }
        
        // Recovery Strategy 1: Try backup files
        var backupResult = await TryLoadFromBackupFiles<T>(filePath);
        if (backupResult.IsSuccess)
        {
            return backupResult;
        }
        
        // Recovery Strategy 2: Try emergency backup location
        if (!string.IsNullOrEmpty(emergencyBackupPath))
        {
            var emergencyResult = await TryLoadFromEmergencyBackup<T>(filePath);
            if (emergencyResult.IsSuccess)
            {
                return emergencyResult;
            }
        }
        
        // Recovery Strategy 3: Attempt corruption repair
        if (enableCorruptionRepair)
        {
            var repairResult = await TryRepairCorruptedFile<T>(filePath);
            if (repairResult.IsSuccess)
            {
                return repairResult;
            }
        }
        
        return LoadOperationResult<T>.Failed($"All recovery attempts failed. {errorReason}");
    }
    
    private SaveOperationResult HandleSaveFailure(string backupPath, string errorMessage)
    {
        // Restore backup if it exists
        if (backupPath != null && File.Exists(backupPath))
        {
            try
            {
                string originalPath = backupPath.Replace(".backup", "");
                File.Copy(backupPath, originalPath, true);
                File.Delete(backupPath);
                
                Debug.Log($"Restored backup after save failure: {originalPath}");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to restore backup: {ex.Message}");
            }
        }
        
        return SaveOperationResult.Failed(errorMessage);
    }
}

// Operation result wrappers
public class SaveOperationResult
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    
    public static SaveOperationResult Success(string message) =>
        new SaveOperationResult { IsSuccess = true, Message = message };
        
    public static SaveOperationResult Failed(string message) =>
        new SaveOperationResult { IsSuccess = false, Message = message };
}

public class LoadOperationResult<T>
{
    public bool IsSuccess { get; private set; }
    public T Data { get; private set; }
    public string Message { get; private set; }
    
    public static LoadOperationResult<T> Success(T data, string message) =>
        new LoadOperationResult<T> { IsSuccess = true, Data = data, Message = message };
        
    public static LoadOperationResult<T> Failed(string message) =>
        new LoadOperationResult<T> { IsSuccess = false, Message = message };
}
```

### **4.4 Performance Measurement Integration**

**FIELD EXPLANATION:** Implement comprehensive performance monitoring and analysis systems that integrate with Unity's profiler and provide custom metrics for data operations. This includes profiler integration, custom metric collection, performance threshold monitoring, benchmarking tools, and analytics integration. The system should help identify bottlenecks and optimize data architecture performance while maintaining low overhead.

**Unity Profiler Integration & Custom Metrics:**

```csharp
using Unity.Profiling;
using UnityEngine;

public class DataPerformanceMonitor : MonoBehaviour
{
    [Header("Performance Tracking")]
    public bool enableProfiling = false;
    public float samplingInterval = 1.0f;
    public int maxSampleHistory = 100;
    
    // Unity Profiler markers for data operations
    private static readonly ProfilerMarker s_DataLoadMarker = new ProfilerMarker("Data.Load");
    private static readonly ProfilerMarker s_DataSaveMarker = new ProfilerMarker("Data.Save");
    private static readonly ProfilerMarker s_CacheAccessMarker = new ProfilerMarker("Data.CacheAccess");
    private static readonly ProfilerMarker s_ValidationMarker = new ProfilerMarker("Data.Validation");
    
    // Performance metrics collection
    private Queue<DataOperationMetric> operationHistory = new Queue<DataOperationMetric>();
    private Dictionary<string, PerformanceStats> operationStats = new Dictionary<string, PerformanceStats>();
    
    [System.Serializable]
    public class DataOperationMetric
    {
        public string operationType;
        public float duration;
        public int dataSize;
        public bool wasSuccessful;
        public DateTime timestamp;
        public string additionalInfo;
    }
    
    [System.Serializable]
    public class PerformanceStats
    {
        public float averageDuration;
        public float maxDuration;
        public float minDuration;
        public int totalOperations;
        public int failedOperations;
        public float successRate;
        
        public void UpdateStats(DataOperationMetric metric)
        {
            totalOperations++;
            if (!metric.wasSuccessful) failedOperations++;
            
            if (totalOperations == 1)
            {
                averageDuration = maxDuration = minDuration = metric.duration;
            }
            else
            {
                averageDuration = ((averageDuration * (totalOperations - 1)) + metric.duration) / totalOperations;
                maxDuration = Mathf.Max(maxDuration, metric.duration);
                minDuration = Mathf.Min(minDuration, metric.duration);
            }
            
            successRate = ((float)(totalOperations - failedOperations)) / totalOperations;
        }
    }
    
    public static void BeginDataOperation(string operationType)
    {
        if (!Instance.enableProfiling) return;
        
        switch (operationType)
        {
            case "Load": s_DataLoadMarker.Begin(); break;
            case "Save": s_DataSaveMarker.Begin(); break;
            case "Cache": s_CacheAccessMarker.Begin(); break;
            case "Validation": s_ValidationMarker.Begin(); break;
        }
    }
    
    public static void EndDataOperation(string operationType, bool success, int dataSize = 0, string info = "")
    {
        if (!Instance.enableProfiling) return;
        
        // End profiler marker
        switch (operationType)
        {
            case "Load": s_DataLoadMarker.End(); break;
            case "Save": s_DataSaveMarker.End(); break;
            case "Cache": s_CacheAccessMarker.End(); break;
            case "Validation": s_ValidationMarker.End(); break;
        }
        
        // Record custom metrics for analysis
        var metric = new DataOperationMetric
        {
            operationType = operationType,
            duration = Time.realtimeSinceStartup, // This should be calculated properly
            dataSize = dataSize,
            wasSuccessful = success,
            timestamp = DateTime.Now,
            additionalInfo = info
        };
        
        Instance.RecordMetric(metric);
    }
    
    private void RecordMetric(DataOperationMetric metric)
    {
        // Maintain rolling history
        operationHistory.Enqueue(metric);
        if (operationHistory.Count > maxSampleHistory)
            operationHistory.Dequeue();
        
        // Update running statistics
        if (!operationStats.ContainsKey(metric.operationType))
            operationStats[metric.operationType] = new PerformanceStats();
        
        operationStats[metric.operationType].UpdateStats(metric);
        
        // Check for performance issues
        CheckPerformanceThresholds(metric);
    }
    
    private void CheckPerformanceThresholds(DataOperationMetric metric)
    {
        // Define performance thresholds based on operation type
        var thresholds = new Dictionary<string, float>
        {
            ["Load"] = 0.1f,      // 100ms for data loading
            ["Save"] = 0.2f,      // 200ms for data saving
            ["Cache"] = 0.01f,    // 10ms for cache access
            ["Validation"] = 0.05f // 50ms for validation
        };
        
        if (thresholds.ContainsKey(metric.operationType) && 
            metric.duration > thresholds[metric.operationType])
        {
            Debug.LogWarning($"Data operation '{metric.operationType}' exceeded performance threshold: " +
                           $"{metric.duration:F3}s > {thresholds[metric.operationType]:F3}s");
        }
    }
    
    // Performance benchmarking for different data scenarios
    [System.Serializable]
    public class DataBenchmark
    {
        public string benchmarkName;
        public int testIterations = 100;
        public System.Action testAction;
        
        public BenchmarkResult RunBenchmark()
        {
            var results = new List<float>();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            for (int i = 0; i < testIterations; i++)
            {
                var startTime = stopwatch.ElapsedMilliseconds;
                testAction?.Invoke();
                var duration = stopwatch.ElapsedMilliseconds - startTime;
                results.Add(duration);
            }
            
            return new BenchmarkResult
            {
                benchmarkName = this.benchmarkName,
                iterations = testIterations,
                averageTime = results.Average(),
                minTime = results.Min(),
                maxTime = results.Max(),
                totalTime = results.Sum()
            };
        }
    }
    
    [System.Serializable]
    public class BenchmarkResult
    {
        public string benchmarkName;
        public int iterations;
        public float averageTime;
        public float minTime;
        public float maxTime;
        public float totalTime;
        
        public void LogResults()
        {
            Debug.Log($"Benchmark '{benchmarkName}' Results:\n" +
                     $"  Iterations: {iterations}\n" +
                     $"  Average: {averageTime:F2}ms\n" +
                     $"  Min: {minTime:F2}ms\n" +
                     $"  Max: {maxTime:F2}ms\n" +
                     $"  Total: {totalTime:F2}ms");
        }
    }
    
    // Editor tooling for performance analysis
    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Game/Data/Run Performance Benchmark")]
    public static void RunDataPerformanceBenchmark()
    {
        var benchmarks = new List<DataBenchmark>
        {
            new DataBenchmark 
            { 
                benchmarkName = "Cache Access", 
                testAction = () => DataCache.Instance.Get<object>("test_key") 
            },
            new DataBenchmark 
            { 
                benchmarkName = "ScriptableObject Load", 
                testAction = () => Resources.Load<ScriptableObject>("TestData") 
            }
        };
        
        foreach (var benchmark in benchmarks)
        {
            var result = benchmark.RunBenchmark();
            result.LogResults();
        }
    }
    #endif
    
    // Real-time performance display for development
    private void OnGUI()
    {
        if (!enableProfiling || !debugMode) return;
        
        GUILayout.BeginArea(new Rect(10, 10, 300, 200));
        GUILayout.Label("Data Performance Monitor", EditorStyles.boldLabel);
        
        foreach (var statsPair in operationStats)
        {
            GUILayout.Label($"{statsPair.Key}: {statsPair.Value.averageDuration:F3}s avg " +
                          $"({statsPair.Value.successRate:P0} success)");
        }
        
        GUILayout.EndArea();
    }
    
    // Singleton pattern for easy access
    private static DataPerformanceMonitor _instance;
    public static DataPerformanceMonitor Instance => _instance ??= FindObjectOfType<DataPerformanceMonitor>();
}

// Extension methods for easy profiling integration
public static class DataProfilingExtensions
{
    public static T ProfileDataOperation<T>(this object source, string operationType, System.Func<T> operation)
    {
        DataPerformanceMonitor.BeginDataOperation(operationType);
        try
        {
            T result = operation();
            DataPerformanceMonitor.EndDataOperation(operationType, true);
            return result;
        }
        catch (System.Exception ex)
        {
            DataPerformanceMonitor.EndDataOperation(operationType, false, 0, ex.Message);
            throw;
        }
    }
    
    public static void ProfileDataOperation(this object source, string operationType, System.Action operation)
    {
        DataPerformanceMonitor.BeginDataOperation(operationType);
        try
        {
            operation();
            DataPerformanceMonitor.EndDataOperation(operationType, true);
        }
        catch (System.Exception ex)
        {
            DataPerformanceMonitor.EndDataOperation(operationType, false, 0, ex.Message);
            throw;
        }
    }
}

```

**Performance Integration Benefits:**
- **Unity Profiler Integration:** Seamless integration with Unity's built-in profiling tools
- **Custom Metrics:** Track game-specific data operation performance
- **Automated Threshold Monitoring:** Alerts when operations exceed performance targets
- **Benchmarking Tools:** Built-in performance testing for different scenarios
- **Analytics Integration:** Performance data can be sent to analytics platforms

### **4.5 Configuration Architecture**

**FIELD EXPLANATION:** Design flexible configuration systems that support player preferences, accessibility options, developer settings, and runtime adaptation while maintaining game design integrity. This includes creating configuration hierarchies, implementing validation systems, supporting runtime updates, and managing configuration persistence. Focus on systems that empower players while preserving intended game experience.

**Configuration Management Philosophy:**
The configuration system prioritizes **[configuration priority 1]** and **[configuration priority 2]** while maintaining **[design integrity aspect]** for [game-specific system]. The architecture supports **[runtime adaptation capability]** for [player needs] without compromising **[design integrity constraint]**.

**[Game-Specific] Configuration Hierarchy:**

```csharp
[CreateAssetMenu(fileName = "[GameSpecific]Configuration", menuName = "[GameCategory]/Game Configuration")]
public class [GameSpecific]Configuration : ScriptableObject
{
    [Header("[Primary System] Settings")]
    public [PrimarySystemConfiguration] [primarySettings];
    public [InteractionConfiguration] [interactionSettings];
    public [AccessibilityConfiguration] [accessibilitySettings];

    [Header("[Secondary System] Settings")]
    public [SecondaryConfiguration] [secondarySettings];
    public [FeatureConfiguration] [featureSettings];
    public [SystemConfiguration] [systemSettings];

    [Header("Technical Configuration")]
    public [PerformanceConfiguration] [performanceSettings];
    public [PlatformConfiguration] [platformSettings];
    public [MemoryConfiguration] [memorySettings];

    // Configuration validation and runtime updates
    public bool ValidateConfiguration();
    public void ApplyRuntimeConfiguration();
    public ConfigurationChangeResult UpdateSetting(string settingPath, object newValue);
    
    private static GameConfiguration CreateDefaultConfiguration()
    {
        var config = CreateInstance<GameConfiguration>();
        // Set default values
        return config;
    }
}

// Advanced configuration system with hierarchical overrides
public class ConfigurationManager : MonoBehaviour
{
    [Header("Configuration Hierarchy")]
    public GameConfiguration baseConfiguration;
    public GameConfiguration platformConfiguration;
    public GameConfiguration userConfiguration;
    
    [Header("Runtime Settings")]
    public bool allowRuntimeChanges = true;
    public bool autoSaveUserPrefs = true;
    public float configSaveDelay = 2.0f;
    
    private GameConfiguration _resolvedConfiguration;
    private Dictionary<string, object> _runtimeOverrides = new Dictionary<string, object>();
    private Coroutine _saveCoroutine;
    
    public GameConfiguration ResolvedConfiguration
    {
        get
        {
            if (_resolvedConfiguration == null)
                RefreshConfiguration();
            return _resolvedConfiguration;
        }
    }
    
    private void Start()
    {
        LoadConfigurationHierarchy();
        RefreshConfiguration();
    }
    
    private void LoadConfigurationHierarchy()
    {
        // Load base configuration (always present)
        baseConfiguration = Resources.Load<GameConfiguration>("Configurations/base");
        
        // Load platform-specific configuration
        string platformPath = $"Configurations/platform_{Application.platform.ToString().ToLower()}";
        platformConfiguration = Resources.Load<GameConfiguration>(platformPath);
        
        // Load user configuration (may not exist initially)
        LoadUserConfiguration();
    }
    
    private void LoadUserConfiguration()
    {
        string userConfigPath = Path.Combine(Application.persistentDataPath, "user_config.json");
        
        if (File.Exists(userConfigPath))
        {
            try
            {
                string json = File.ReadAllText(userConfigPath);
                var userSettings = JsonUtility.FromJson<UserConfigurationData>(json);
                
                // Convert to ScriptableObject if needed
                userConfiguration = ScriptableObject.CreateInstance<GameConfiguration>();
                ApplyUserSettings(userConfiguration, userSettings);
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning($"Failed to load user configuration: {ex.Message}");
                userConfiguration = null;
            }
        }
    }
    
    public void RefreshConfiguration()
    {
        _resolvedConfiguration = ScriptableObject.CreateInstance<GameConfiguration>();
        
        // Apply configurations in hierarchy order: base -> platform -> user -> runtime
        ApplyConfiguration(_resolvedConfiguration, baseConfiguration);
        
        if (platformConfiguration != null)
            ApplyConfiguration(_resolvedConfiguration, platformConfiguration);
        
        if (userConfiguration != null)
            ApplyConfiguration(_resolvedConfiguration, userConfiguration);
        
        // Apply runtime overrides
        ApplyRuntimeOverrides();
        
        // Notify systems of configuration changes
        OnConfigurationChanged?.Invoke(_resolvedConfiguration);
    }
    
    // Configuration change system
    public static event System.Action<GameConfiguration> OnConfigurationChanged;
    
    public void SetRuntimeOverride(string fieldName, object value)
    {
        if (!allowRuntimeChanges) return;
        
        _runtimeOverrides[fieldName] = value;
        RefreshConfiguration();
        
        // Schedule delayed save to user configuration
        if (autoSaveUserPrefs)
            ScheduleSaveUserConfiguration();
    }
    
    public T GetConfigValue<T>(string fieldName)
    {
        var field = ResolvedConfiguration.GetType().GetField(fieldName, 
            BindingFlags.Public | BindingFlags.Instance);
        return field != null ? (T)field.GetValue(ResolvedConfiguration) : default(T);
    }
    
    // Configuration validation system
    public bool ValidateConfiguration(GameConfiguration config)
    {
        var validationResults = new List<string>();
        
        // Validate performance settings
        if (config.targetFrameRate <= 0 || config.targetFrameRate > 300)
            validationResults.Add("Target frame rate must be between 1 and 300");
        
        // Validate data management settings
        if (config.cacheSize <= 0)
            validationResults.Add("Cache size must be positive");
        
        if (config.autoSaveInterval <= 0)
            validationResults.Add("Auto-save interval must be positive");
        
        // Log validation issues
        if (validationResults.Count > 0)
        {
            Debug.LogWarning($"Configuration validation issues:\n{string.Join("\n", validationResults)}");
            return false;
        }
        
        return true;
    }
    
    // Configuration profiles for different scenarios
    public void LoadConfigurationProfile(string profileName)
    {
        var profileConfig = Resources.Load<GameConfiguration>($"Configurations/profiles/{profileName}");
        if (profileConfig != null)
        {
            ApplyConfiguration(_resolvedConfiguration, profileConfig);
            RefreshConfiguration();
            Debug.Log($"Loaded configuration profile: {profileName}");
        }
        else
        {
            Debug.LogWarning($"Configuration profile '{profileName}' not found");
        }
    }
    
    // Development/debugging features
    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Game/Configuration/Reload All Configurations")]
    public static void ReloadAllConfigurations()
    {
        var manager = FindObjectOfType<ConfigurationManager>();
        if (manager != null)
        {
            manager.LoadConfigurationHierarchy();
            manager.RefreshConfiguration();
            Debug.Log("All configurations reloaded");
        }
    }
    
    [UnityEditor.MenuItem("Game/Configuration/Reset User Configuration")]
    public static void ResetUserConfiguration()
    {
        string userConfigPath = Path.Combine(Application.persistentDataPath, "user_config.json");
        if (File.Exists(userConfigPath))
        {
            File.Delete(userConfigPath);
            Debug.Log("User configuration reset");
        }
    }
    #endif
    
    // Helper methods and classes
    private void ApplyConfiguration(GameConfiguration target, GameConfiguration source) { /* Implementation */ }
    private void ApplyRuntimeOverrides() { /* Implementation */ }
    private void ScheduleSaveUserConfiguration() { /* Implementation */ }
    private void SaveUserConfiguration() { /* Implementation */ }
    private void ApplyUserSettings(GameConfiguration target, UserConfigurationData userData) { /* Implementation */ }
    
    [System.Serializable]
    public class UserConfigurationData
    {
        public Dictionary<string, object> userPreferences = new Dictionary<string, object>();
        public Dictionary<string, object> runtimeOverrides = new Dictionary<string, object>();
    }
}

```

**Advanced Configuration Features:**
- **Hierarchical Configuration:** Base -> Platform -> User -> Runtime override system
- **Hot Reloading:** Configuration changes without restart
- **Validation System:** Automatic validation of configuration values
- **Profile System:** Different configuration profiles for various scenarios
- **Persistent User Settings:** User preferences automatically saved and loaded
- **Editor Tools:** Development tools for configuration management

**Player Preference Management:**

```csharp
public class [GameSpecific]PreferencesManager : MonoBehaviour
{
    [Header("[Primary Preference Category]")]
    public float [preference1] = [default];     // [Preference purpose and impact]
    public float [preference2] = [default];     // [Preference rationale]
    public bool [preference3] = [default];      // [Preference function]
    public bool [preference4] = [default];      // [Preference effect]

    [Header("[Accessibility Category]")]
    public bool [accessibilityOption1] = false;       // [Accessibility function]
    public bool [accessibilityOption2] = false;       // [Accessibility purpose]
    public float [accessibilityOption3] = 0.0f;       // [Accessibility feature]
    public bool [accessibilityOption4] = false;       // [Accessibility support]

    [Header("[Feature Category]")]
    public float [featurePreference1] = 1.0f;     // [Feature customization purpose]
    public bool [featurePreference2] = true;      // [Feature toggle rationale]
    public bool [featurePreference3] = true;      // [Feature option purpose]

    // Preference management operations
    public void ApplyPreferences();
    public bool ValidatePreferenceChange(string preferenceName, object newValue);
    public void ResetToDefaults(PreferenceCategory category);
    public PreferenceProfile CreateCustomProfile();
}

```

**Runtime Configuration Adaptation:**

| Configuration Category | Runtime Modifiable | Validation Requirements | Persistence Level | Impact on Gameplay |
| --- | --- | --- | --- | --- |
| **[ConfigCategory1]** | [Yes/No/Limited] | [Validation requirements] | [Persistence level] | [Gameplay impact description] |
| **[ConfigCategory2]** | [Yes/No/Limited] | [Validation requirements] | [Persistence level] | [Player experience impact] |
| **[ConfigCategory3]** | [Yes/No/Limited] | [Validation requirements] | [Persistence level] | [System functionality impact] |
| **[ConfigCategory4]** | [Yes/No/Limited] | [Validation requirements] | [Persistence level] | [Design integrity impact] |
| **[ConfigCategory5]** | [Yes/No/Limited] | [Validation requirements] | [Persistence level] | [Technical performance impact] |

**Configuration Validation and Constraints:**

```csharp
public static class [GameSpecific]ConfigurationValidator
{
    public static ValidationResult Validate[ConfigCategory]([ConfigurationType] settings)
    {
        var result = new ValidationResult();

        // [Validation category 1]
        if ([validation condition 1])
            result.AddWarning("[Warning message with rationale]");

        if ([validation condition 2])
            result.AddError("[Error message with rationale]");

        // [Game-specific validation]
        if ([game-specific constraint])
            result.AddError("[Game-specific constraint rationale]");

        return result;
    }

    public static bool Validate[SpecificConfiguration]([ConfigurationType] config)
    {
        // [Validation logic ensuring design integrity]
        return [validation1] != null &&
               [validation2].IsValid() &&
               ![validation3]; // [Why this cannot be enabled]
    }
}

```

### **4.5 Memory Management**

**FIELD EXPLANATION:** Implement comprehensive memory management systems that optimize data-related memory usage, minimize garbage collection impact, and prevent memory leaks while supporting the game's performance targets. This includes object pooling strategies, cache management, garbage collection scheduling, and platform-specific optimizations. Focus on systems that maintain consistent performance across different platforms and play sessions.

**Memory Management Philosophy:**
"[Game Title]" implements **[memory management approach]** that prioritizes **[memory priority 1]** and **[memory priority 2]** over [deprioritized memory aspect]. The approach supports **[performance goal]** while maintaining **[efficiency goal]** for [platform constraint].

**[Game-Specific] Object Pooling Strategy:**

```csharp
public class [GameSpecific]ObjectPoolManager : MonoBehaviour
{
    [Header("[Pool Category] Configuration")]
    public int [poolType1]PoolSize = [number];     // [Pool purpose and sizing rationale]
    public int [poolType2]PoolSize = [number];     // [Pool usage pattern]
    public int [poolType3]PoolSize = [number];     // [Pool frequency rationale]
    public int [poolType4]PoolSize = [number];     // [Pool performance rationale]

    [Header("Pool Management Settings")]
    public float poolCleanupInterval = [number]f;           // [Cleanup timing rationale]
    public bool enableDynamicPoolGrowth = [boolean];        // [Growth policy rationale]
    public float maxPoolGrowthMultiplier = [number]f;       // [Growth limit rationale]

    private Dictionary<Type, Queue<GameObject>> objectPools;
    private Dictionary<Type, int> poolUsageTracking;

    // [Game-specific] object pooling operations
    public T GetPooledObject<T>() where T : MonoBehaviour;
    public void ReturnToPool<T>(T objectToReturn) where T : MonoBehaviour;
    public void WarmupPools();
    public void CleanupUnusedPoolObjects();
    public PoolingStatistics GetPoolingStatistics();
}

```

**Memory Allocation Strategy:**

| System Category | Allocation Approach | GC Impact | Optimization Strategy | Rationale |
| --- | --- | --- | --- | --- |
| **[SystemCategory1]** | [Allocation strategy] | [GC impact level] | [Optimization approach] | [Why this approach serves game goals] |
| **[SystemCategory2]** | [Allocation strategy] | [GC impact level] | [Optimization approach] | [Performance vs functionality trade-off] |
| **[SystemCategory3]** | [Allocation strategy] | [GC impact level] | [Optimization approach] | [Memory vs availability trade-off] |
| **[SystemCategory4]** | [Allocation strategy] | [GC impact level] | [Optimization approach] | [Frequency vs efficiency rationale] |
| **[SystemCategory5]** | [Allocation strategy] | [GC impact level] | [Optimization approach] | [Persistence vs performance rationale] |

**Garbage Collection Minimization:**

```csharp
public class [GameSpecific]MemoryManager : MonoBehaviour
{
    [Header("GC Minimization Configuration")]
    public float gcMonitoringInterval = [number]f;          // [Monitoring frequency rationale]
    public int maxAllowedGCPerMinute = [number];             // [Acceptable GC frequency for game type]
    public bool enableGCScheduling = [boolean];              // [GC scheduling rationale]

    [Header("Memory Optimization Settings")]
    public bool enable[OptimizationType1] = [boolean];          // [Optimization purpose]
    public bool enable[OptimizationType2] = [boolean];          // [Optimization rationale]
    public bool enable[OptimizationType3] = [boolean];          // [Optimization trade-off]

    // Memory optimization tracking
    private Dictionary<string, WeakReference> [cacheType1];
    private LRUCache<string, [AssetType]> [cacheType2];
    private [MonitorType] [gcMonitor];

    // Memory management operations
    public void ScheduleGarbageCollection([SchedulingContext] context);
    public string GetInterned[DataType](string original[DataType]);
    public void OptimizeMemoryFor[GameEvent]();
    public MemoryUsageReport GenerateMemoryReport();
    public bool IsMemoryUsageWithinLimits();
}

```

**Memory Optimization for [Game-Specific System]:**

**[Asset Category] Streaming:**

- **[AssetType1]:** [Loading strategy and rationale]
- **[AssetType2]:** [Caching approach and reason]
- **[AssetType3]:** [Persistence strategy and justification]
- **[AssetType4]:** [Loading approach and design rationale]

**Memory Leak Prevention:**

```csharp
public class [GameSpecific]MemoryMonitor : MonoBehaviour
{
    [Header("Memory Leak Detection")]
    public bool enableMemoryLeakDetection = [boolean];
    public float memoryLeakCheckInterval = [number]f;      // [Check frequency rationale]
    public float memoryGrowthThreshold = [number]f;       // [Growth threshold rationale]

    private MemoryUsageHistory memoryHistory;
    private Dictionary<Type, int> objectCountTracker;

    public struct MemoryUsageSnapshot
    {
        public float totalMemoryMB;
        public float [objectCategory1]Count;
        public float [objectCategory2]Count;
        public float [objectCategory3]Count;
        public DateTime snapshotTime;

        public bool IndicatesMemoryLeak(MemoryUsageSnapshot previous)
        {
            float memoryGrowth = totalMemoryMB - previous.totalMemoryMB;
            float timeElapsed = (float)(snapshotTime - previous.snapshotTime).TotalMinutes;

            // [Memory leak detection logic with game-specific rationale]
            return memoryGrowth > [threshold] &&
                   timeElapsed > [timeThreshold] &&
                   [objectCategory1]Count <= previous.[objectCategory1]Count;
        }
    }

    // Memory leak detection and prevention
    public void TakeMemorySnapshot();
    public bool DetectPotentialMemoryLeak();
    public void GenerateMemoryLeakReport();
    public void TriggerMemoryCleanup();
}

```

**Platform-Specific Memory Considerations:**

**[Platform1] Memory Management:**

- **[MemoryAspect1]:** [Platform-specific approach and rationale]
- **[MemoryAspect2]:** [Platform optimization strategy]
- **[MemoryAspect3]:** [Platform-specific memory scheduling]

**[Platform2] Memory Management:**

- **[MemoryAspect1]:** [Platform constraint and optimization response]
- **[MemoryAspect2]:** [Platform-specific cleanup strategy]
- **[MemoryAspect3]:** [Platform performance tuning approach]

**[Platform3] Memory Management:**

- **[MemoryAspect1]:** [Platform limitation and architectural response]
- **[MemoryAspect2]:** [Platform-specific pooling strategy]
- **[MemoryAspect3]:** [Platform memory growth prevention]

## 🔧 DATA ANALYSIS METHODOLOGY:

### **Data Requirements Extraction:**

- **From GDD Mechanics:** [What data each mechanic requires]
- **From Section 1 Systems:** [What data each system needs to manage]
- **From Section 2 Gameplay:** [What data gameplay interactions generate and consume]
- **From Section 3 Classes:** [What data each class needs to store and process]

### **State Management Analysis:**

- **Persistent State Needs:** [What must survive sessions and why]
- **Session State Needs:** [What resets each session and rationale]
- **Temporary State Needs:** [What exists only during specific interactions]
- **Historical State Needs:** [What needs undo/redo or replay capability]

### **Performance Data Considerations:**

- **From Section 0 Performance Targets:** [Memory and performance constraints]
- **Platform Memory Constraints:** [Platform-specific memory limitations]
- **Gameplay Performance Needs:** [Frame rate and responsiveness requirements]

### **Serialization Requirements Analysis:**

- **Save System Needs:** [What requires persistent storage]
- **Configuration Needs:** [What players need to customize]
- **Platform Considerations:** [Platform-specific serialization constraints]

## 📝 INPUT REQUIREMENTS:

- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**
- **Section 1: System Architecture output**
- **Section 2: Gameplay Architecture output**
- **Section 3: Class Design output**

## ⚡ KEY REQUIREMENTS:

- **Extract data needs systematically** from all previous sections and GDD mechanics
- **Design data structures** appropriate for game complexity, performance targets, and platform constraints
- **Create comprehensive state management** supporting gameplay patterns and player experience goals
- **Establish robust serialization** for save systems, settings, and cross-session continuity
- **Include platform-specific memory management** for performance targets and deployment constraints
- **Provide detailed rationale** connecting all data decisions to game design goals and technical requirements
- **Consider accessibility and configuration** needs for inclusive player experience
- **Ensure all data architecture supports** AI-assisted implementation and iterative development
- **Make memory management appropriate** for solo development complexity and platform targets

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

Generate Section 4 following this exact structure with comprehensive data architecture, detailed memory management strategies, and thorough rationale connecting all data decisions to the game's design goals and technical requirements.