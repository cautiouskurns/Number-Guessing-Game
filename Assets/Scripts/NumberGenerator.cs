using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Core random number generation system for the Number Guessing Game.
/// Implements singleton pattern for global access and provides random target numbers
/// within the 1-100 range for gameplay interactions.
/// Includes debug mode infrastructure for deterministic testing.
/// </summary>
public class NumberGenerator : MonoBehaviour
{
    #region Singleton Pattern
    
    /// <summary>
    /// Singleton instance for global access to the NumberGenerator
    /// </summary>
    public static NumberGenerator Instance { get; private set; }
    
    #endregion
    
    #region Inspector Configuration
    
    [Header("Random Generation Configuration")]
    [SerializeField, Tooltip("Minimum value for random generation (inclusive)")]
    private int minValue = 1;
    
    [SerializeField, Tooltip("Maximum value for random generation (inclusive)")]
    private int maxValue = 100;
    
    [Header("Current State")]
    [SerializeField, Tooltip("Currently generated target number (read-only)")]
    private int currentTarget;
    
    [Header("Debug Information")]
    [SerializeField, Tooltip("Enable debug logging for generation events")]
    private bool enableDebugLogging = false;
    
    [Header("Event Integration")]
    [SerializeField, Tooltip("Enable event-driven integration with GameStateManager")]
    private bool enableEventIntegration = true;
    
    [SerializeField, Tooltip("Enable debug logging for event coordination")]
    private bool enableEventLogging = false;
    
    #if UNITY_EDITOR
    [Header("Debug Mode Configuration")]
    [SerializeField, Tooltip("Enable debug mode for deterministic testing")]
    private bool isDebugMode = false;
    
    [SerializeField, Tooltip("Seed value for deterministic generation in debug mode")]
    private int debugSeed = 12345;
    
    [SerializeField, Tooltip("Show detailed debug information in console")]
    private bool enableDetailedDebugLogging = false;
    
    [SerializeField, Tooltip("Track generation sequence for validation (read-only)")]
    private int generationCount = 0;
    #endif
    
    #endregion
    
    #region Public Properties
    
    /// <summary>
    /// Gets the current target number that players need to guess
    /// </summary>
    public int CurrentTarget { get; private set; }
    
    /// <summary>
    /// Gets the minimum value for random generation
    /// </summary>
    public int MinValue => minValue;
    
    /// <summary>
    /// Gets the maximum value for random generation
    /// </summary>
    public int MaxValue => maxValue;
    
    /// <summary>
    /// Gets whether a target number has been generated
    /// </summary>
    public bool HasTarget => CurrentTarget > 0;
    
    #if UNITY_EDITOR
    /// <summary>
    /// Gets whether debug mode is currently enabled (Editor only)
    /// </summary>
    public bool IsDebugMode => isDebugMode;
    
    /// <summary>
    /// Gets the current debug seed value (Editor only)
    /// </summary>
    public int DebugSeed => debugSeed;
    
    /// <summary>
    /// Gets the number of generations since debug mode was enabled (Editor only)
    /// </summary>
    public int GenerationCount => generationCount;
    #endif
    
    #endregion
    
    #region Unity Lifecycle
    
    private void Awake()
    {
        InitializeSingleton();
        ValidateConfiguration();
        #if UNITY_EDITOR
        InitializeDebugMode();
        #endif
    }
    
    private void Start()
    {
        // Generate initial target number
        GenerateNewTarget();
    }
    
    private void OnEnable()
    {
        if (enableEventIntegration)
        {
            SubscribeToGameStateEvents();
        }
    }
    
    private void OnDisable()
    {
        if (enableEventIntegration)
        {
            UnsubscribeFromGameStateEvents();
        }
    }
    
    private void OnDestroy()
    {
        // Clean up singleton reference if this instance is being destroyed
        if (Instance == this)
        {
            Instance = null;
        }
        
        // Ensure event cleanup
        if (enableEventIntegration)
        {
            UnsubscribeFromGameStateEvents();
        }
    }
    
    #endregion
    
    #region Singleton Management
    
    /// <summary>
    /// Initializes the singleton instance with proper error handling
    /// </summary>
    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (enableDebugLogging)
                Debug.Log($"NumberGenerator singleton initialized successfully");
        }
        else if (Instance != this)
        {
            if (enableDebugLogging)
                Debug.LogWarning($"Duplicate NumberGenerator detected. Destroying {gameObject.name}");
            
            Destroy(gameObject);
        }
    }
    
    #endregion
    
    #region Configuration Validation
    
    /// <summary>
    /// Validates the min/max configuration and corrects invalid values
    /// </summary>
    private void ValidateConfiguration()
    {
        if (minValue >= maxValue)
        {
            Debug.LogError($"Invalid range configuration: minValue ({minValue}) must be less than maxValue ({maxValue}). Using defaults (1-100).");
            minValue = 1;
            maxValue = 100;
        }
        
        if (minValue < 1)
        {
            Debug.LogWarning($"MinValue ({minValue}) is less than 1. Adjusting to 1.");
            minValue = 1;
        }
        
        if (enableDebugLogging)
            Debug.Log($"NumberGenerator configured for range: {minValue} to {maxValue}");
    }
    
    #endregion
    
    #region Random Number Generation
    
    /// <summary>
    /// Generates a new random target number within the configured range.
    /// Performance target: <1ms generation time.
    /// </summary>
    /// <returns>The newly generated target number</returns>
    public int GenerateNewTarget()
    {
        #if UNITY_EDITOR
        if (isDebugMode)
        {
            return GenerateDebugTarget();
        }
        #endif
        
        // Use Unity's Random.Range with inclusive max value for proper 1-100 range
        CurrentTarget = Random.Range(minValue, maxValue + 1);
        
        // Update inspector field for debugging
        currentTarget = CurrentTarget;
        
        if (enableDebugLogging)
            Debug.Log($"NumberGenerator: New target generated: {CurrentTarget}");
        
        return CurrentTarget;
    }
    
    /// <summary>
    /// Generates a random number using a specific seed for testing purposes
    /// </summary>
    /// <param name="seed">The seed value for deterministic generation</param>
    /// <returns>The generated target number</returns>
    public int GenerateWithSeed(int seed)
    {
        var previousState = Random.state;
        Random.InitState(seed);
        
        int result = GenerateNewTarget();
        
        // Restore previous random state to avoid affecting other systems
        Random.state = previousState;
        
        if (enableDebugLogging)
            Debug.Log($"NumberGenerator: Generated with seed {seed}: {result}");
        
        return result;
    }
    
    /// <summary>
    /// Checks if the provided guess matches the current target
    /// </summary>
    /// <param name="guess">The player's guess</param>
    /// <returns>True if the guess matches the target, false otherwise</returns>
    public bool IsCorrectGuess(int guess)
    {
        return guess == CurrentTarget;
    }
    
    /// <summary>
    /// Gets the relationship between a guess and the target
    /// </summary>
    /// <param name="guess">The player's guess</param>
    /// <returns>1 if target is higher, -1 if target is lower, 0 if correct</returns>
    public int CompareToTarget(int guess)
    {
        if (guess < CurrentTarget) return 1;  // Target is higher
        if (guess > CurrentTarget) return -1; // Target is lower
        return 0; // Correct guess
    }
    
    #endregion
    
    #region Range Configuration
    
    /// <summary>
    /// Updates the generation range. Use carefully as this affects gameplay balance.
    /// </summary>
    /// <param name="newMin">New minimum value (inclusive)</param>
    /// <param name="newMax">New maximum value (inclusive)</param>
    public void SetRange(int newMin, int newMax)
    {
        if (newMin >= newMax)
        {
            Debug.LogError($"Invalid range: {newMin} to {newMax}. Min must be less than max.");
            return;
        }
        
        minValue = newMin;
        maxValue = newMax;
        
        ValidateConfiguration();
        
        if (enableDebugLogging)
            Debug.Log($"NumberGenerator range updated to: {minValue} to {maxValue}");
    }
    
    #endregion
    
    #region Debug and Validation
    
    /// <summary>
    /// Validates that the current target is within the expected range
    /// </summary>
    /// <returns>True if the target is valid, false otherwise</returns>
    public bool ValidateCurrentTarget()
    {
        bool isValid = CurrentTarget >= minValue && CurrentTarget <= maxValue;
        
        if (!isValid && enableDebugLogging)
            Debug.LogError($"Invalid target detected: {CurrentTarget} is outside range {minValue}-{maxValue}");
        
        return isValid;
    }
    
    /// <summary>
    /// Gets debug information about the current state
    /// </summary>
    /// <returns>Debug string with current state information</returns>
    public string GetDebugInfo()
    {
        #if UNITY_EDITOR
        if (isDebugMode)
        {
            return $"NumberGenerator - Target: {CurrentTarget}, Range: {minValue}-{maxValue}, HasTarget: {HasTarget}, DebugMode: ON, Seed: {debugSeed}, Generation: {generationCount}";
        }
        #endif
        
        return $"NumberGenerator - Target: {CurrentTarget}, Range: {minValue}-{maxValue}, HasTarget: {HasTarget}";
    }
    
    #endregion
    
    #if UNITY_EDITOR
    #region Debug Mode Implementation
    
    /// <summary>
    /// Initializes debug mode configuration and state
    /// </summary>
    private void InitializeDebugMode()
    {
        if (isDebugMode)
        {
            Random.InitState(debugSeed);
            generationCount = 0;
            
            if (enableDetailedDebugLogging)
                Debug.Log($"NumberGenerator Debug Mode initialized with seed: {debugSeed}");
        }
    }
    
    /// <summary>
    /// Generates a target number in debug mode using the configured seed
    /// </summary>
    /// <returns>The deterministically generated target number</returns>
    private int GenerateDebugTarget()
    {
        // Ensure we're using the debug seed for deterministic generation
        Random.InitState(debugSeed + generationCount);
        
        CurrentTarget = Random.Range(minValue, maxValue + 1);
        currentTarget = CurrentTarget;
        generationCount++;
        
        if (enableDetailedDebugLogging)
            Debug.Log($"NumberGenerator Debug: Generated {CurrentTarget} (seed: {debugSeed + generationCount - 1}, generation: {generationCount})");
        
        return CurrentTarget;
    }
    
    /// <summary>
    /// Enables debug mode with the specified seed
    /// </summary>
    /// <param name="seed">The seed to use for deterministic generation</param>
    public void EnableDebugMode(int seed)
    {
        debugSeed = seed;
        isDebugMode = true;
        generationCount = 0;
        Random.InitState(debugSeed);
        
        if (enableDebugLogging)
            Debug.Log($"Debug mode enabled with seed: {seed}");
    }
    
    /// <summary>
    /// Disables debug mode and returns to random generation
    /// </summary>
    public void DisableDebugMode()
    {
        isDebugMode = false;
        generationCount = 0;
        
        if (enableDebugLogging)
            Debug.Log("Debug mode disabled - returning to random generation");
    }
    
    /// <summary>
    /// Sets the debug seed while maintaining debug mode state
    /// </summary>
    /// <param name="seed">The new seed value</param>
    public void SetDebugSeed(int seed)
    {
        debugSeed = seed;
        if (isDebugMode)
        {
            generationCount = 0;
            Random.InitState(debugSeed);
            
            if (enableDebugLogging)
                Debug.Log($"Debug seed updated to: {seed}");
        }
    }
    
    /// <summary>
    /// Resets the debug generation count and re-initializes with current seed
    /// </summary>
    public void ResetDebugSequence()
    {
        if (isDebugMode)
        {
            generationCount = 0;
            Random.InitState(debugSeed);
            
            if (enableDebugLogging)
                Debug.Log($"Debug sequence reset with seed: {debugSeed}");
        }
    }
    
    /// <summary>
    /// Validates debug mode deterministic behavior by generating a sequence
    /// </summary>
    /// <param name="sequenceLength">Number of values to generate for validation</param>
    /// <returns>Array of generated values for sequence validation</returns>
    public int[] ValidateDebugSequence(int sequenceLength = 10)
    {
        if (!isDebugMode)
        {
            Debug.LogWarning("Cannot validate debug sequence when debug mode is disabled");
            return new int[0];
        }
        
        int[] sequence = new int[sequenceLength];
        int originalCount = generationCount;
        
        // Reset to beginning of sequence
        Random.InitState(debugSeed);
        
        for (int i = 0; i < sequenceLength; i++)
        {
            Random.InitState(debugSeed + i);
            sequence[i] = Random.Range(minValue, maxValue + 1);
        }
        
        // Restore original state
        generationCount = originalCount;
        Random.InitState(debugSeed + generationCount);
        
        if (enableDetailedDebugLogging)
        {
            string sequenceStr = string.Join(", ", sequence);
            Debug.Log($"Debug sequence validation (seed {debugSeed}): [{sequenceStr}]");
        }
        
        return sequence;
    }
    
    #endregion
    
    #region Unity Editor Menu Items
    
    [MenuItem("NumberGuessingGame/Debug/Toggle Debug Mode")]
    public static void ToggleDebugMode()
    {
        if (Instance == null)
        {
            Debug.LogWarning("NumberGenerator instance not found. Debug mode cannot be toggled.");
            return;
        }
        
        if (Instance.isDebugMode)
        {
            Instance.DisableDebugMode();
            Debug.Log("Debug mode disabled via menu");
        }
        else
        {
            Instance.EnableDebugMode(Instance.debugSeed);
            Debug.Log($"Debug mode enabled via menu with seed: {Instance.debugSeed}");
        }
    }
    
    [MenuItem("NumberGuessingGame/Debug/Set Debug Seed...")]
    public static void SetDebugSeedDialog()
    {
        if (Instance == null)
        {
            Debug.LogWarning("NumberGenerator instance not found. Debug seed cannot be set.");
            return;
        }
        
        // Simple seed input through console for now
        // In a full implementation, this would use EditorUtility.DisplayDialog
        int newSeed = Random.Range(1000, 99999);
        Instance.SetDebugSeed(newSeed);
        Debug.Log($"Debug seed randomly set to: {newSeed} (modify debugSeed field in Inspector for custom values)");
    }
    
    [MenuItem("NumberGuessingGame/Debug/Reset Debug Sequence")]
    public static void ResetDebugSequenceMenuItem()
    {
        if (Instance == null)
        {
            Debug.LogWarning("NumberGenerator instance not found. Debug sequence cannot be reset.");
            return;
        }
        
        Instance.ResetDebugSequence();
        Debug.Log("Debug sequence reset via menu");
    }
    
    [MenuItem("NumberGuessingGame/Debug/Validate Debug Sequence")]
    public static void ValidateDebugSequence()
    {
        if (Instance == null)
        {
            Debug.LogWarning("NumberGenerator instance not found. Debug sequence cannot be validated.");
            return;
        }
        
        if (!Instance.isDebugMode)
        {
            Debug.LogWarning("Debug mode is not enabled. Enable debug mode first to validate sequences.");
            return;
        }
        
        int[] sequence = Instance.ValidateDebugSequence(10);
        string sequenceStr = string.Join(", ", sequence);
        Debug.Log($"Debug validation complete. Sequence (10 values): [{sequenceStr}]");
    }
    
    [MenuItem("NumberGuessingGame/Debug/Show Debug Info")]
    public static void ShowDebugInfo()
    {
        if (Instance == null)
        {
            Debug.LogWarning("NumberGenerator instance not found.");
            return;
        }
        
        Debug.Log($"NumberGenerator Debug Info: {Instance.GetDebugInfo()}");
    }
    
    #endregion
    
    #endif
    
    #region Event System Integration
    
    /// <summary>
    /// Subscribes to GameStateManager events for automatic number generation
    /// </summary>
    private void SubscribeToGameStateEvents()
    {
        try
        {
            // Try to find the current GameStateManager implementation
            var gameStateManager = FindGameStateManager();
            
            if (gameStateManager != null)
            {
                gameStateManager.OnGameStart += HandleGameStart;
                gameStateManager.OnGameReset += HandleGameReset;
                gameStateManager.OnGameStateChanged += HandleGameStateChanged;
                
                if (enableEventLogging)
                    Debug.Log("NumberGenerator: Successfully subscribed to GameStateManager events");
            }
            else
            {
                if (enableEventLogging)
                    Debug.LogWarning("NumberGenerator: GameStateManager not found. Event integration disabled until GameStateManager is available.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"NumberGenerator: Failed to subscribe to GameStateManager events: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Unsubscribes from GameStateManager events to prevent memory leaks
    /// </summary>
    private void UnsubscribeFromGameStateEvents()
    {
        try
        {
            var gameStateManager = FindGameStateManager();
            
            if (gameStateManager != null)
            {
                gameStateManager.OnGameStart -= HandleGameStart;
                gameStateManager.OnGameReset -= HandleGameReset;
                gameStateManager.OnGameStateChanged -= HandleGameStateChanged;
                
                if (enableEventLogging)
                    Debug.Log("NumberGenerator: Successfully unsubscribed from GameStateManager events");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"NumberGenerator: Failed to unsubscribe from GameStateManager events: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Finds the appropriate GameStateManager implementation
    /// </summary>
    /// <returns>GameStateManager instance or null if not found</returns>
    private IGameStateManager FindGameStateManager()
    {
        // First try to find the real GameStateManager (will be implemented in Feature 1.1.3)
        var realGameStateManager = FindObjectOfType<MonoBehaviour>();
        if (realGameStateManager != null && realGameStateManager is IGameStateManager)
        {
            return realGameStateManager as IGameStateManager;
        }
        
        // Fallback to stub for testing
        var stubGameStateManager = FindObjectOfType<GameStateManagerStub>();
        if (stubGameStateManager != null)
        {
            if (enableEventLogging)
                Debug.Log("NumberGenerator: Using GameStateManagerStub for event integration testing");
            return stubGameStateManager;
        }
        
        return null;
    }
    
    /// <summary>
    /// Handles game start events by generating a new target number
    /// </summary>
    private void HandleGameStart()
    {
        try
        {
            if (enableEventLogging)
                Debug.Log("NumberGenerator: Handling OnGameStart event");
            
            GenerateNewTarget();
            
            if (enableEventLogging)
                Debug.Log($"NumberGenerator: New target generated for game start: {CurrentTarget}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"NumberGenerator: Error handling game start event: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Handles game reset events by generating a new target number
    /// </summary>
    private void HandleGameReset()
    {
        try
        {
            if (enableEventLogging)
                Debug.Log("NumberGenerator: Handling OnGameReset event");
            
            GenerateNewTarget();
            
            if (enableEventLogging)
                Debug.Log($"NumberGenerator: New target generated for game reset: {CurrentTarget}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"NumberGenerator: Error handling game reset event: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Handles game state change events for additional coordination
    /// </summary>
    /// <param name="newState">The new game state</param>
    private void HandleGameStateChanged(GameState newState)
    {
        try
        {
            if (enableEventLogging)
                Debug.Log($"NumberGenerator: Game state changed to: {newState}");
            
            // Additional state-specific logic can be added here
            // For now, we only respond to explicit OnGameStart/OnGameReset events
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"NumberGenerator: Error handling game state change event: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Manual method to test event integration
    /// </summary>
    public void TestEventIntegration()
    {
        if (!enableEventIntegration)
        {
            Debug.LogWarning("Event integration is disabled. Enable it in the Inspector to test.");
            return;
        }
        
        var gameStateManager = FindGameStateManager();
        if (gameStateManager == null)
        {
            Debug.LogWarning("No GameStateManager found for event integration testing.");
            return;
        }
        
        Debug.Log("NumberGenerator: Event integration test completed successfully");
    }
    
    #endregion
}