using System;
using UnityEngine;

/// <summary>
/// Interface stub for GameStateManager event integration.
/// This provides the contract for event-driven coordination between
/// NumberGenerator and future GameStateManager implementation.
/// </summary>
public interface IGameStateManager
{
    /// <summary>
    /// Event triggered when a new game starts
    /// </summary>
    event Action OnGameStart;
    
    /// <summary>
    /// Event triggered when the game is reset
    /// </summary>
    event Action OnGameReset;
    
    /// <summary>
    /// Event triggered when game state changes
    /// </summary>
    event Action<GameState> OnGameStateChanged;
}

/// <summary>
/// Basic game state enumeration for event-driven architecture.
/// This stub will be replaced by the full implementation in Feature 1.1.3.
/// </summary>
public enum GameState
{
    Menu,
    Playing,
    Won,
    Lost,
    Paused
}

/// <summary>
/// Stub implementation of GameStateManager for event integration testing.
/// This allows NumberGenerator to implement event handling before
/// the full GameStateManager is available in Feature 1.1.3.
/// </summary>
public class GameStateManagerStub : MonoBehaviour, IGameStateManager
{
    public static GameStateManagerStub Instance { get; private set; }
    
    [Header("Event Testing (Stub Implementation)")]
    [SerializeField, Tooltip("Enable debug logging for event triggers")]
    private bool enableEventLogging = true;
    
    public event Action OnGameStart;
    public event Action OnGameReset;
    public event Action<GameState> OnGameStateChanged;
    
    [Header("Manual Event Testing")]
    [SerializeField, Tooltip("Current game state for testing")]
    private GameState currentState = GameState.Menu;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (enableEventLogging)
                Debug.Log("GameStateManagerStub initialized for event testing");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    #if UNITY_EDITOR
    /// <summary>
    /// Manual trigger for testing game start events
    /// </summary>
    [UnityEditor.MenuItem("NumberGuessingGame/Debug/Trigger Game Start Event")]
    public static void TriggerGameStartEvent()
    {
        if (Instance != null)
        {
            Instance.TriggerGameStart();
        }
        else
        {
            Debug.LogWarning("GameStateManagerStub instance not found. Create a GameObject with GameStateManagerStub component.");
        }
    }
    
    /// <summary>
    /// Manual trigger for testing game reset events
    /// </summary>
    [UnityEditor.MenuItem("NumberGuessingGame/Debug/Trigger Game Reset Event")]
    public static void TriggerGameResetEvent()
    {
        if (Instance != null)
        {
            Instance.TriggerGameReset();
        }
        else
        {
            Debug.LogWarning("GameStateManagerStub instance not found.");
        }
    }
    #endif
    
    /// <summary>
    /// Triggers a game start event for testing
    /// </summary>
    public void TriggerGameStart()
    {
        currentState = GameState.Playing;
        
        if (enableEventLogging)
            Debug.Log("GameStateManagerStub: Triggering OnGameStart event");
        
        OnGameStart?.Invoke();
        OnGameStateChanged?.Invoke(currentState);
    }
    
    /// <summary>
    /// Triggers a game reset event for testing
    /// </summary>
    public void TriggerGameReset()
    {
        currentState = GameState.Menu;
        
        if (enableEventLogging)
            Debug.Log("GameStateManagerStub: Triggering OnGameReset event");
        
        OnGameReset?.Invoke();
        OnGameStateChanged?.Invoke(currentState);
    }
}