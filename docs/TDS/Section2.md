# Section 2: Gameplay Architecture

> **Technical Design Specification for Number Guessing Game**
> **Complexity Level:** Simple
> **Generated:** 2025-08-16

---

## **2. GAMEPLAY ARCHITECTURE** *(How the game actually works)*

### **2.1 Game Rules & Mechanics Structure**

**Purpose & Design Philosophy:**
The gameplay rules for "Number Guessing Game" reflect the **"Pure Logic"** and **"Immediate Clarity"** design pillars from the GDD. Unlike action games that emphasize reflexes and timing, this casual puzzle game prioritizes **deterministic rule application** and **transparent feedback systems**, driving rule systems that support **predictable logical interactions** and **instant comprehension**.

**Core Gameplay Loop Implementation:**

```csharp
public class NumberGuessingGameplayLoop : MonoBehaviour
{
    [Header("Core Loop Configuration")]
    public int minNumber = 1;                    // Range minimum for logical deduction
    public int maxNumber = 100;                  // Range maximum maintains manageable scope
    public int maxAttempts = 10;                 // Failure condition supports "Satisfying Progress" pillar
    
    [Header("Game State")]
    public bool gameActive = false;
    public int targetNumber;
    public int currentAttempts = 0;
    public List<int> guessHistory = new List<int>();

    // Core loop: Generate → Input → Validate → Feedback → Progress → Result
    public IEnumerator ExecuteGameplayLoop()
    {
        while (gameActive)
        {
            // 1. Wait for Player Input (supports deliberate thinking)
            yield return StartCoroutine(WaitForPlayerGuess());

            // 2. Validate Input (immediate rule enforcement)
            ValidatePlayerGuess();

            // 3. Process Guess Logic (deterministic feedback)
            ProcessGuessResult();

            // 4. Update Progress Tracking (satisfying progress visibility)
            UpdateProgressIndicators();

            // 5. Check Victory/Failure Conditions (clear end states)
            CheckGameEndConditions();
        }
    }
}
```

**Rule Categories & Implementation Strategy:**

| Rule Category | Rule Definition | Validation Method | Enforcement Point | Why This Rule |
| --- | --- | --- | --- | --- |
| **Input Validation** | Player guess must be integer 1-100 | Range check + integer parsing | InputManager.ValidateInput() | Supports "Pure Logic" by eliminating invalid inputs that would confuse feedback |
| **Attempt Tracking** | Each valid guess increments attempt counter | Counter increment after successful validation | GameLogic.ProcessGuess() | Enables "Satisfying Progress" through visible advancement toward goal |
| **Feedback Consistency** | Identical guesses always produce identical feedback | Deterministic comparison logic | GameLogic.CompareGuess() | Reinforces "Pure Logic" pillar through predictable, learnable system behavior |
| **Victory Conditions** | Exact match wins game, 10+ attempts triggers failure | Equality check + attempt threshold | GameLogic.CheckWinCondition() | Creates clear success/failure states supporting immediate clarity of outcomes |

**Game State Transitions:**

| From State | To State | Trigger Condition | Transition Duration | Actions Performed |
| --- | --- | --- | --- | --- |
| **MainMenu** | **Playing** | New Game button clicked | Immediate | Generate target number, reset counters, initialize UI |
| **Playing** | **Won** | Correct guess submitted | <200ms | Display victory screen, save best score, play celebration sound |
| **Playing** | **Lost** | 10th incorrect guess submitted | <200ms | Display game over screen, reveal target number, offer retry |
| **Won/Lost** | **Playing** | Play Again button clicked | <300ms | Reset all game state, generate new target, return to gameplay |

**Why These State Transitions:**
Transition timing prioritizes immediate feedback over elaborate animations, supporting the "Immediate Clarity" pillar. Quick state changes maintain gameplay momentum while allowing players to instantly understand their progress and options.

### **2.2 Player Interaction Architecture**

**Input System Design Philosophy:**
The **"Immediate Clarity"** design pillar drives a **simple, responsive input approach** that prioritizes **instant feedback** over complex input schemes. The system supports **keyboard and mouse primary input** while maintaining **touch compatibility** for future mobile deployment.

**Unity Input System Implementation:**

```csharp
public class NumberGuessingInputManager : BaseGameManager
{
    [Header("Unity Input System Configuration")]
    public InputActionAsset inputActionAsset;
    public float inputResponseTime = 0.1f;       // Visual feedback delay for clarity
    
    [Header("Cross-Platform Support")]
    public bool enableTouchInput = true;         // Mobile compatibility
    public bool enableKeyboardShortcuts = true; // PC accessibility
    public bool enableEnterSubmission = true;   // Quick submission option

    [Header("Accessibility Features")]
    public bool enableInputConfirmation = false; // Visual input feedback
    public bool enableNumberPadSupport = true;   // Alternative number input
    public float inputValidationDelay = 0.2f;   // Input validation timing

    private InputActionMap gameplayActionMap;
    private InputAction numberInputAction;
    private InputAction submitAction;
    private InputAction newGameAction;
    private InputAction hintAction;
    
    // Cross-platform input actions
    private InputAction touchSubmitAction;
    private InputAction keyboardShortcutAction;

    protected override bool OnInitialize()
    {
        if (inputActionAsset == null) return false;
        
        gameplayActionMap = inputActionAsset.FindActionMap("NumberGuessingGameplay");
        if (gameplayActionMap == null) return false;

        // Initialize primary actions
        numberInputAction = gameplayActionMap.FindAction("NumberInput");
        submitAction = gameplayActionMap.FindAction("SubmitGuess");
        newGameAction = gameplayActionMap.FindAction("NewGame");
        hintAction = gameplayActionMap.FindAction("RequestHint");
        
        // Initialize platform-specific actions
        touchSubmitAction = gameplayActionMap.FindAction("TouchSubmit");
        keyboardShortcutAction = gameplayActionMap.FindAction("KeyboardShortcut");

        // Configure input processing
        ConfigureInputProcessors();
        EnableInputMaps();
        
        return true;
    }

    // Simplified input processing for casual puzzle game
    public int GetPlayerGuess()
    {
        // Direct input field reading - no complex processing needed
        if (InputField.text.Length > 0)
        {
            if (int.TryParse(InputField.text, out int guess))
            {
                return ValidateGuessRange(guess);
            }
        }
        return -1; // Invalid input indicator
    }

    // Cross-platform submission detection
    public bool GetSubmitInput()
    {
        bool submitDetected = false;

        // Primary submission methods
        submitDetected |= submitAction.WasPressedThisFrame();
        
        // Keyboard Enter key
        if (enableEnterSubmission)
            submitDetected |= Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
            
        // Touch submission for mobile
        if (enableTouchInput)
            submitDetected |= touchSubmitAction.WasPressedThisFrame();

        if (submitDetected)
        {
            // Visual feedback for accessibility
            if (enableInputConfirmation)
                ShowInputConfirmation();
                
            return ValidateSubmissionConditions();
        }

        return false;
    }

    // Simple validation appropriate for puzzle game
    private int ValidateGuessRange(int guess)
    {
        if (guess >= 1 && guess <= 100)
        {
            ShowValidInput();
            return guess;
        }
        else
        {
            ShowInvalidInput();
            return -1;
        }
    }

    private bool ValidateSubmissionConditions()
    {
        // Only submit if game is active and input is valid
        return gameActive && GetPlayerGuess() != -1;
    }

    // Accessibility support methods
    private void ShowInputConfirmation() { /* Visual confirmation of input received */ }
    private void ShowValidInput() { /* Green highlight for valid input */ }
    private void ShowInvalidInput() { /* Red highlight for invalid input */ }
}
```

**Input Processing Pipeline:**

| Stage | Purpose | Performance Target | Platform Differences | Accessibility Features |
| --- | --- | --- | --- | --- |
| **Input Capture** | Capture number input from text field or touch | <50ms response time | Keyboard (PC), Touch keyboard (mobile) | Large touch targets, clear input feedback |
| **Input Validation** | Check number range and format | <10ms validation | Integer parsing (all platforms) | Visual validation feedback, error messages |
| **Submission Detection** | Detect submit intent from multiple sources | <50ms detection | Button click, Enter key, Touch tap | Multiple submission methods, visual confirmation |
| **Feedback Display** | Provide immediate visual/audio response | <100ms feedback | Platform-appropriate UI updates | Color coding, sound cues, text feedback |

**Cross-Platform & Accessibility Support:**

- **Simplified Input Model:** Text field input works consistently across PC, mobile, and web platforms
- **Multiple Submission Methods:** Button click, Enter key, and touch tap support different user preferences
- **Visual Feedback:** Immediate input validation prevents user confusion and supports accessibility
- **Error Prevention:** Range validation prevents invalid submissions rather than complex error handling

### **2.3 Experience-to-Implementation Translation**

**Systematic Experience-to-Technical Translation Methodology:**

**GDD Experience Goal: "Pure strategy-based deduction without time pressure, focusing on logical thinking"**

**Technical Implementation Framework:**

| Experience Component | Success Metric | Technical System | Implementation Details | Performance Target | Validation Method |
| --- | --- | --- | --- | --- | --- |
| **No Time Pressure** | Zero time-based failure conditions | No timer systems, turn-based processing | Synchronous input processing, no countdown UI | Indefinite thinking time | Player survey on stress levels |
| **Logical Deduction Support** | 90%+ consistent feedback for identical inputs | Deterministic comparison algorithms | Pure mathematical comparison without randomness | 100% consistency | Automated testing of all input/output pairs |
| **Strategic Information** | Complete guess history visible | Persistent UI display of all previous guesses | ScrollRect with guess history, organized chronologically | <100ms history updates | UI responsiveness testing |
| **Clear Feedback Systems** | <200ms feedback display after submission | Immediate UI text updates | Direct text component updates, no complex animations | <200ms response time | Input latency measurement |

**GDD Experience Goal: "Each attempt brings visible progress toward the solution with meaningful accomplishment"**

**Technical Implementation Framework:**

```csharp
public class ProgressTrackingSystem : MonoBehaviour
{
    [Header("Progress Visualization")]
    public float progressUpdateSpeed = 0.2f;     // Smooth progress bar animation
    public bool showRemainingRange = true;       // Visual range narrowing display
    public bool highlightOptimalGuesses = true; // Binary search education

    [Header("Achievement Recognition")]
    public bool enableEfficiencyRating = true;   // Rate guess efficiency
    public float celebrationDelay = 0.5f;        // Victory celebration timing
    public int perfectGameThreshold = 7;         // Attempts for "perfect" rating

    // Progress visualization that supports "Satisfying Progress" pillar
    public void UpdateProgressDisplay(int guess, string feedback, int attemptNumber)
    {
        // 1. Update attempt counter with visual emphasis
        StartCoroutine(AnimateAttemptCounter(attemptNumber));

        // 2. Show guess in history with feedback color coding
        AddGuessToHistory(guess, feedback);

        // 3. Update remaining number range visualization
        if (showRemainingRange)
            UpdateRangeVisualization(guess, feedback);

        // 4. Calculate and display efficiency rating
        if (enableEfficiencyRating)
            UpdateEfficiencyRating(attemptNumber);

        // 5. Provide strategic guidance for learning
        if (highlightOptimalGuesses)
            ShowOptimalNextGuess();
    }
}
```

**Common Experience-to-Technical Translations:**

| Abstract Experience Goal | Concrete Technical Requirements | Measurable Success Criteria |
| --- | --- | --- |
| **"Feels responsive and immediate"** | Input processing <100ms, UI updates <200ms, no loading delays | 95% of interactions meet timing targets |
| **"Logical and predictable"** | Deterministic algorithms, consistent rule application, clear cause-effect | 100% consistency in identical input scenarios |
| **"Progressively satisfying"** | Visible progress indicators, achievement recognition, improvement tracking | Average session length >5 minutes, replay rate >60% |
| **"Accessible and clear"** | Multiple input methods, visual feedback, error prevention | <30 seconds to understand core mechanics |

### **2.4 AI & Behavior Architecture**

**AI Pattern Selection Framework:**

Based on the **casual puzzle game** requirements and **solo developer** constraints, "Number Guessing Game" uses **minimal AI systems** rather than complex behavioral AI, reflecting the **"Pure Logic"** design pillar. The focus is on **deterministic systems** and **hint generation** while maintaining **simple rule-based architecture** appropriate for the team and timeline.

**Simple Rule-Based AI for Hint System:**

```csharp
public class NumberGuessingHintSystem : MonoBehaviour
{
    [Header("Hint Configuration")]
    public int maxHintsPerGame = 3;              // Limit to maintain challenge
    public bool enableBinarySearchHints = true;  // Teach optimal strategy
    public bool enableRangeVisualization = true; // Show remaining possibilities
    
    [Header("Educational AI")]
    public bool teachOptimalStrategy = true;      // Educate about binary search
    public float hintDisplayDuration = 3.0f;     // How long hints remain visible

    private int hintsUsed = 0;
    private List<int> previousGuesses = new List<int>();
    private int currentMin = 1;
    private int currentMax = 100;

    // Simple rule-based hint generation - no complex AI needed
    public string GenerateHint(List<int> guessHistory, List<string> feedbackHistory)
    {
        if (hintsUsed >= maxHintsPerGame)
            return "No more hints available";

        hintsUsed++;

        // Rule 1: If no guesses yet, suggest binary search start
        if (guessHistory.Count == 0)
        {
            return enableBinarySearchHints ? 
                "Try starting with 50 - it eliminates half the possibilities!" :
                "Try a number in the middle of the range.";
        }

        // Rule 2: Update range based on previous feedback
        UpdateRangeFromFeedback(guessHistory, feedbackHistory);

        // Rule 3: Suggest optimal next guess (binary search)
        if (enableBinarySearchHints)
        {
            int optimalGuess = (currentMin + currentMax) / 2;
            int remainingNumbers = currentMax - currentMin + 1;
            
            return $"Try {optimalGuess}. This splits the remaining {remainingNumbers} possibilities in half.";
        }

        // Rule 4: Basic range guidance
        return $"The number is between {currentMin} and {currentMax}. Try something in the middle.";
    }

    // Educational hint system that teaches strategy
    public void ShowOptimalStrategyExplanation()
    {
        if (teachOptimalStrategy)
        {
            string explanation = "Binary search strategy: Always guess the middle number " +
                               "of the remaining range to eliminate the most possibilities.";
            
            // Display educational popup
            UIManager.Instance?.ShowEducationalHint(explanation, hintDisplayDuration);
        }
    }

    // Simple range tracking - no complex state management
    private void UpdateRangeFromFeedback(List<int> guesses, List<string> feedback)
    {
        for (int i = 0; i < guesses.Count; i++)
        {
            int guess = guesses[i];
            string result = feedback[i];

            if (result.Contains("Higher") || result.Contains("higher"))
            {
                currentMin = Mathf.Max(currentMin, guess + 1);
            }
            else if (result.Contains("Lower") || result.Contains("lower"))
            {
                currentMax = Mathf.Min(currentMax, guess - 1);
            }
        }
    }

    // Visualization support for learning
    public void UpdateRangeVisualization()
    {
        if (enableRangeVisualization)
        {
            float rangePercentage = (float)(currentMax - currentMin + 1) / 100f;
            UIManager.Instance?.UpdateRangeDisplay(currentMin, currentMax, rangePercentage);
        }
    }
}
```

**AI System Categories:**

| AI System | Purpose | Implementation Approach | Player Experience Impact |
| --- | --- | --- | --- |
| **Hint Generation** | Provide strategic guidance without solving | Rule-based optimal move calculation | Supports learning and reduces frustration |
| **Range Visualization** | Show remaining number possibilities | Simple min/max tracking with visual display | Helps players understand logical deduction |
| **Strategy Education** | Teach binary search principles | Context-sensitive educational hints | Improves player skill and satisfaction |
| **Difficulty Adaptation** | Optional easier/harder modes | Adjust number range or attempt limits | Accommodates different skill levels |

**Why Rule-Based Systems Over Complex AI:**

- **Deterministic Behavior:** Rule-based hints provide consistent, learnable guidance supporting "Pure Logic" pillar
- **Educational Value:** Simple algorithms teach strategy rather than confusing with unpredictable AI behavior  
- **Development Efficiency:** Minimal AI reduces development time while meeting all design goals
- **Debugging Simplicity:** Rule-based logic is easy to test and modify for solo development

**Hint System Communication:**

```csharp
public static class HintSystemEvents
{
    // Hint request and delivery events
    public static event System.Action<string> OnHintGenerated;
    public static event System.Action<int> OnHintsRemainingChanged;
    public static event System.Action<bool> OnOptimalGuessHighlighted;

    // Educational system integration
    public static event System.Action<string> OnStrategyExplanationRequested;

    // Coordinated hint delivery
    public static void RequestHint(List<int> guessHistory, List<string> feedbackHistory)
    {
        string hint = HintSystem.Instance.GenerateHint(guessHistory, feedbackHistory);
        OnHintGenerated?.Invoke(hint);
        
        // Update remaining hints display
        int hintsLeft = HintSystem.Instance.GetRemainingHints();
        OnHintsRemainingChanged?.Invoke(hintsLeft);
        
        // Play helpful sound effect
        AudioManager.PlaySound(SoundType.HintProvided);
    }
}
```

**AI System Communication:**
The hint system coordinates with UI and audio systems to provide helpful guidance while maintaining the focus on player logical thinking. The simple event-driven architecture ensures hints integrate smoothly with gameplay flow without disrupting the core puzzle-solving experience.

---

**Next Section:** Section 3 (Class Design) - Specific implementation of core game classes and data structures