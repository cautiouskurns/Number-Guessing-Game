# Section 3: Class Design

> **Technical Design Specification for Number Guessing Game**
> **Complexity Level:** Simple
> **Generated:** 2025-08-16

---

## **3. CLASS DESIGN** *(Implementation Level)*

### **3.1 Core Classes & Responsibilities**

**Class Design Philosophy:**
The class architecture for "Number Guessing Game" reflects the **"Pure Logic"** and **"Immediate Clarity"** requirements while maintaining **clear separation of concerns** appropriate for solo development. Each class has a **single, discoverable responsibility** that directly maps to the core systems from previous sections, enabling straightforward task generation and iterative development.

**Core Class Identification & Responsibilities:**

| Class Name | Primary Responsibility | Key Functions | System Domain | Dependencies |
|------------|----------------------|---------------|---------------|--------------|
| **GameManager** | Coordinate overall game state and system initialization | - Initialize all systems<br>- Manage game state transitions<br>- Coordinate scene management<br>- Handle application lifecycle | System Management | Unity MonoBehaviour, All other managers |
| **NumberGuessingLogic** | Implement core number guessing game rules and validation | - Generate random target numbers<br>- Validate player guesses<br>- Calculate feedback responses<br>- Track game progress | Gameplay Logic | None (pure logic class) |
| **InputManager** | Handle all player input and validation for number guessing | - Capture number input from UI<br>- Validate input range and format<br>- Process submission commands<br>- Handle keyboard shortcuts | Player Interaction | Unity Input System, UI components |
| **UIManager** | Manage all user interface updates and state synchronization | - Update feedback displays<br>- Show/hide game screens<br>- Animate UI transitions<br>- Synchronize UI with game state | User Interface | Canvas components, TextMeshPro |
| **ScoreManager** | Track and persist player statistics and achievements | - Calculate attempt efficiency<br>- Track best scores<br>- Save/load persistent data<br>- Generate performance statistics | Data Management | SaveManager, PlayerPrefs |
| **AudioManager** | Handle all sound effects and audio feedback | - Play input confirmation sounds<br>- Trigger victory/failure audio<br>- Manage volume settings<br>- Control audio mixing | Audio System | AudioSource components |
| **SaveManager** | Manage persistent data storage and retrieval | - Save/load game settings<br>- Persist best scores<br>- Handle data validation<br>- Manage save file integrity | Data Persistence | PlayerPrefs, JSON serialization |

**Class Grouping by Functional Domain:**

**Core Game Logic:**
- `NumberGuessingLogic` - Pure game rules implementation
- `GameManager` - Overall coordination and state management

**Player Interaction:**
- `InputManager` - Input capture and validation
- `UIManager` - Visual feedback and interface management

**Data & Persistence:**
- `ScoreManager` - Statistics and progress tracking
- `SaveManager` - Persistent storage operations

**Supporting Systems:**
- `AudioManager` - Sound effects and audio feedback

### **3.2 Inheritance Hierarchies**

**Inheritance Strategy Rationale:**
"Number Guessing Game" uses **minimal inheritance** to support **simple system coordination** while following **composition over inheritance** for complex behaviors. The inheritance relationships serve **Unity MonoBehaviour integration** and **system manager consistency**.

**Primary Inheritance Hierarchies:**

**1. Manager Base Hierarchy:**

```
BaseManager (Abstract Base)
├── GameManager
├── InputManager
├── UIManager
├── ScoreManager
├── AudioManager
└── SaveManager
```

**BaseManager Base Class Responsibilities:**
- **System Lifecycle Management** - Standardized initialization, update, and shutdown patterns across all managers
- **Unity Integration** - Consistent MonoBehaviour lifecycle handling and Inspector configuration
- **Event Registration** - Common event subscription and unsubscription patterns for system communication
- **Debug Logging** - Centralized logging and debugging capabilities with system identification
- **Performance Monitoring** - Basic performance tracking and bottleneck identification for optimization

**2. Game Data Hierarchy:**

```
BaseGameData (Abstract Base)
├── GameSession
├── GameSettings
├── PlayerStatistics
└── SaveData
```

**BaseGameData Base Responsibilities:**
- **Serialization Support** - Common JSON serialization/deserialization patterns for save/load operations
- **Validation Framework** - Data integrity checks and corruption detection for reliable persistence
- **Version Management** - Save data versioning and migration support for future updates
- **Default Values** - Consistent default value assignment and reset functionality

**Composition Over Inheritance Examples:**

**Complex Behavioral Composition:**
- `GameManager` **composes** `NumberGuessingLogic` + `GameStateHandler` + `SystemInitializer`
- `UIManager` **uses** `FeedbackDisplayer` + `ScreenTransitioner` + `ProgressTracker`
- `InputManager` **contains** `InputValidator` + `KeyboardHandler` + `TouchHandler`

**Why Composition for Complex Behaviors:**
- **Single Responsibility Maintenance** - Each composed component handles one specific concern, maintaining clear boundaries
- **Testing Isolation** - Components can be unit tested independently and mocked for integration testing
- **Unity Component Flexibility** - Composition works naturally with Unity's component-based architecture and inspector workflow

### **3.3 Design Patterns Used**

**Pattern Selection Strategy:**
Design patterns are chosen specifically to support **immediate feedback and persistent progress** while maintaining **solo developer simplicity**. Each pattern serves the **core game loop efficiency** while maintaining **clear architectural boundaries**.

**Core Architectural Patterns:**

**1. Singleton Pattern Applications:**
- **GameManager** - Central coordination point for all system communication and state management
- **UIManager** - Single UI update coordination point to prevent conflicting interface changes
- **AudioManager** - Global audio control and mixing coordination for consistent sound experience

**Singleton Usage Rationale:**
- **Global State Coordination** - Game state must be consistently accessible across all systems without complex dependency injection
- **Unity Inspector Integration** - Singleton managers provide clear Inspector references while maintaining architectural simplicity
- **Performance Optimization** - Single instances eliminate reference lookup overhead in performance-critical update loops

**2. Observer Pattern Applications:**
- **Game State Events** - GameManager broadcasts state changes to all interested systems for coordinated responses
- **Score Updates** - ScoreManager notifies UI and audio systems when statistics change for immediate feedback
- **Input Validation** - InputManager publishes validation results to UI for instant visual confirmation

**Observer Pattern Responsibilities:**
- **Immediate Feedback Events:** Input submission events trigger instant UI updates and audio confirmation
- **Progress Tracking Events:** Score improvements propagate to UI displays and achievement checking systems
- **System Coordination Events:** Game state changes enable/disable appropriate input methods and UI screens

**3. State Machine Pattern Applications:**
- **Game State Management** - Clear transitions between Menu, Playing, Won, and Lost states with defined behaviors
- **Input State Handling** - Manages valid input states based on current game phase and UI focus
- **UI Screen Management** - Controls screen visibility and transitions based on game progression

**State Machine Usage Rationale:**
- **Clear Game Flow** - Predictable state transitions support "Immediate Clarity" pillar through obvious progression
- **Input Validation Context** - State machines ensure input is only processed when appropriate, preventing confusion
- **UI Synchronization** - Screen states automatically coordinate with game states for consistent user experience

**4. Unity-Specific Patterns:**

**ScriptableObject Configuration Pattern:**
- **GameSettings** - Designer-configurable difficulty settings and balance parameters
- **AudioClipData** - Organized audio assets with volume and pitch configurations
- **UIThemeData** - Color schemes and UI styling for consistent visual design

**MonoBehaviour Lifecycle Pattern:**
- **SystemInitializer** - Manages initialization order and dependency resolution across managers
- **UpdateCoordinator** - Centralizes Update calls to minimize performance overhead
- **ResourceManager** - Handles asset loading and memory management with Unity lifecycle integration

**Interface Design with Concrete Examples:**

**Core System Interfaces:**

```csharp
// System Lifecycle Interface - for consistent manager behavior
public interface IGameSystem
{
    bool IsInitialized { get; }
    bool Initialize();
    void Shutdown();
    void OnGameStateChanged(GameState newState);
}

// Game Logic Interface - for core gameplay validation
public interface IGameLogic
{
    int GenerateTargetNumber();
    GuessResult ProcessGuess(int guess);
    bool IsGameComplete();
    void ResetGame();
}

// Player Input Interface - for input handling abstraction
public interface IPlayerInput
{
    int GetPlayerGuess();
    bool IsSubmitPressed();
    bool IsNewGamePressed();
    void EnableInput(bool enabled);
}

// Data Persistence Interface - for save/load operations
public interface IDataPersistence
{
    void SaveData<T>(string key, T data);
    T LoadData<T>(string key, T defaultValue = default);
    bool HasData(string key);
    void ClearData(string key);
}

// Audio System Interface - for sound effect management
public interface IAudioSystem
{
    void PlaySound(AudioClipType clipType);
    void SetVolume(float volume);
    void SetMuted(bool muted);
}
```

**Base Class Examples with Unity Integration:**

```csharp
// Abstract Base Manager with Unity Integration
public abstract class BaseManager : MonoBehaviour, IGameSystem
{
    [Header("System Configuration")]
    [SerializeField] protected bool autoInitialize = true;
    [SerializeField] protected bool enableDebugLogging = true;
    
    public bool IsInitialized { get; private set; }
    
    protected virtual void Awake()
    {
        if (autoInitialize)
        {
            SystemBootstrapper.RegisterSystem(this);
        }
    }
    
    protected virtual void Start()
    {
        if (autoInitialize && !IsInitialized)
        {
            Initialize();
        }
    }
    
    public bool Initialize()
    {
        if (IsInitialized) return true;
        
        if (enableDebugLogging)
            Debug.Log($"Initializing {GetType().Name}...");
        
        bool success = OnInitialize();
        if (success)
        {
            IsInitialized = true;
            OnSystemReady();
        }
        
        return success;
    }
    
    public void Shutdown()
    {
        if (!IsInitialized) return;
        
        OnShutdown();
        IsInitialized = false;
        
        if (enableDebugLogging)
            Debug.Log($"Shutdown {GetType().Name}");
    }
    
    public virtual void OnGameStateChanged(GameState newState)
    {
        if (enableDebugLogging)
            Debug.Log($"{GetType().Name} responding to state: {newState}");
    }
    
    protected abstract bool OnInitialize();
    protected virtual void OnShutdown() { }
    protected virtual void OnSystemReady() { }
}

// Simple Game Data Base Class
[System.Serializable]
public abstract class BaseGameData
{
    public virtual void SetDefaults()
    {
        // Override in derived classes for default value assignment
    }
    
    public virtual bool IsValid()
    {
        // Override in derived classes for validation logic
        return true;
    }
    
    public string ToJson()
    {
        return JsonUtility.ToJson(this, true);
    }
    
    public static T FromJson<T>(string json) where T : BaseGameData, new()
    {
        try
        {
            T data = JsonUtility.FromJson<T>(json);
            if (data == null)
            {
                data = new T();
                data.SetDefaults();
            }
            return data;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to deserialize {typeof(T).Name}: {ex.Message}");
            T defaultData = new T();
            defaultData.SetDefaults();
            return defaultData;
        }
    }
}
```

**Concrete Implementation Examples:**

```csharp
// Core Game Logic Implementation
public class NumberGuessingLogic : IGameLogic
{
    private int targetNumber;
    private int attemptCount;
    private List<int> guessHistory;
    private const int MIN_NUMBER = 1;
    private const int MAX_NUMBER = 100;
    private const int MAX_ATTEMPTS = 10;
    
    public NumberGuessingLogic()
    {
        guessHistory = new List<int>();
        ResetGame();
    }
    
    public int GenerateTargetNumber()
    {
        targetNumber = UnityEngine.Random.Range(MIN_NUMBER, MAX_NUMBER + 1);
        return targetNumber;
    }
    
    public GuessResult ProcessGuess(int guess)
    {
        if (guess < MIN_NUMBER || guess > MAX_NUMBER)
        {
            return new GuessResult
            {
                IsValid = false,
                FeedbackText = $"Please enter a number between {MIN_NUMBER} and {MAX_NUMBER}",
                GameState = GameState.Playing
            };
        }
        
        attemptCount++;
        guessHistory.Add(guess);
        
        if (guess == targetNumber)
        {
            return new GuessResult
            {
                IsValid = true,
                FeedbackText = $"Correct! You guessed it in {attemptCount} attempts!",
                GameState = GameState.Won,
                AttemptsUsed = attemptCount
            };
        }
        else if (attemptCount >= MAX_ATTEMPTS)
        {
            return new GuessResult
            {
                IsValid = true,
                FeedbackText = $"Game Over! The number was {targetNumber}",
                GameState = GameState.Lost,
                AttemptsUsed = attemptCount
            };
        }
        else
        {
            string feedback = guess < targetNumber ? "Too low! Try higher." : "Too high! Try lower.";
            return new GuessResult
            {
                IsValid = true,
                FeedbackText = feedback,
                GameState = GameState.Playing,
                AttemptsUsed = attemptCount
            };
        }
    }
    
    public bool IsGameComplete()
    {
        return attemptCount >= MAX_ATTEMPTS || guessHistory.Contains(targetNumber);
    }
    
    public void ResetGame()
    {
        attemptCount = 0;
        guessHistory.Clear();
        GenerateTargetNumber();
    }
}

// Input Manager Implementation
public class InputManager : BaseManager, IPlayerInput
{
    [Header("Input Configuration")]
    [SerializeField] private TMP_InputField numberInputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button newGameButton;
    
    private bool inputEnabled = true;
    
    protected override bool OnInitialize()
    {
        if (numberInputField == null || submitButton == null || newGameButton == null)
        {
            Debug.LogError("InputManager: Missing required UI references");
            return false;
        }
        
        // Configure input field validation
        numberInputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        numberInputField.characterLimit = 3;
        
        return true;
    }
    
    public int GetPlayerGuess()
    {
        if (!inputEnabled || string.IsNullOrEmpty(numberInputField.text))
            return -1;
        
        if (int.TryParse(numberInputField.text, out int guess))
        {
            return guess;
        }
        
        return -1;
    }
    
    public bool IsSubmitPressed()
    {
        return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
    }
    
    public bool IsNewGamePressed()
    {
        return Input.GetKeyDown(KeyCode.N);
    }
    
    public void EnableInput(bool enabled)
    {
        inputEnabled = enabled;
        numberInputField.interactable = enabled;
        submitButton.interactable = enabled;
    }
    
    public override void OnGameStateChanged(GameState newState)
    {
        base.OnGameStateChanged(newState);
        
        switch (newState)
        {
            case GameState.Playing:
                EnableInput(true);
                numberInputField.text = "";
                numberInputField.Select();
                break;
            case GameState.Won:
            case GameState.Lost:
                EnableInput(false);
                break;
        }
    }
}

// Game Data Structures
[System.Serializable]
public class GameSession : BaseGameData
{
    public int targetNumber;
    public int attemptCount;
    public List<int> guessHistory;
    public GameState currentState;
    public System.DateTime sessionStartTime;
    
    public override void SetDefaults()
    {
        targetNumber = 50;
        attemptCount = 0;
        guessHistory = new List<int>();
        currentState = GameState.Menu;
        sessionStartTime = System.DateTime.Now;
    }
    
    public override bool IsValid()
    {
        return targetNumber >= 1 && targetNumber <= 100 &&
               attemptCount >= 0 && attemptCount <= 10 &&
               guessHistory != null;
    }
}

[System.Serializable]
public class PlayerStatistics : BaseGameData
{
    public int gamesPlayed;
    public int gamesWon;
    public int bestScore;
    public float averageAttempts;
    public System.DateTime lastPlayTime;
    
    public override void SetDefaults()
    {
        gamesPlayed = 0;
        gamesWon = 0;
        bestScore = 10;
        averageAttempts = 0f;
        lastPlayTime = System.DateTime.Now;
    }
    
    public float WinRate => gamesPlayed > 0 ? (float)gamesWon / gamesPlayed : 0f;
    
    public void RecordGame(bool won, int attempts)
    {
        gamesPlayed++;
        if (won)
        {
            gamesWon++;
            if (attempts < bestScore)
                bestScore = attempts;
        }
        
        // Calculate new average
        averageAttempts = ((averageAttempts * (gamesPlayed - 1)) + attempts) / gamesPlayed;
        lastPlayTime = System.DateTime.Now;
    }
}

// Result Data Structures
[System.Serializable]
public struct GuessResult
{
    public bool IsValid;
    public string FeedbackText;
    public GameState GameState;
    public int AttemptsUsed;
}

public enum GameState
{
    Menu,
    Playing,
    Won,
    Lost
}

public enum AudioClipType
{
    ButtonClick,
    CorrectGuess,
    IncorrectGuess,
    GameWon,
    GameLost
}
```

**Pattern Selection Decision Framework:**

| Scenario | Singleton | Observer | State Machine | Composition | Factory |
|----------|-----------|----------|---------------|-------------|---------|
| **System coordination** | ✅ Ideal | ❌ Too loose | ❌ Not applicable | ❌ Too complex | ❌ Not needed |
| **UI updates** | ❌ Too rigid | ✅ Perfect | ❌ Not flexible | ✅ Good | ❌ Not applicable |
| **Game state flow** | ❌ Not applicable | ⚠️ Can help | ✅ Designed for this | ❌ Too simple | ❌ Not needed |
| **Complex behaviors** | ❌ Not applicable | ❌ Wrong approach | ❌ Not suitable | ✅ Perfect fit | ❌ Not needed |
| **Data management** | ⚠️ Sometimes | ❌ Not applicable | ❌ Wrong use | ✅ Good | ⚠️ Possible |

**Pattern Implementation Benefits:**
- **Singleton**: Eliminates reference management complexity for core managers
- **Observer**: Enables immediate UI feedback supporting "Immediate Clarity" pillar
- **State Machine**: Provides predictable game flow supporting "Pure Logic" pillar
- **Composition**: Maintains single responsibility while enabling complex behaviors
- **Unity Integration**: Leverages Unity patterns for designer workflow and performance

---

**Next Section:** This completes the simple complexity TDS. For intermediate/detailed complexity, Sections 4-7 would cover Data Architecture, Unity Specific Architecture, Platform Technical Architecture, and Asset Specification.