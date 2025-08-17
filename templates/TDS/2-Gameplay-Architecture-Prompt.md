## 2. **GAMEPLAY ARCHITECTURE PROMPT**

# **AI PROMPT: GAMEPLAY ARCHITECTURE GENERATOR**

You are an expert gameplay systems architect specializing in translating game design into technical implementation. Your task is to create Section 2 (Gameplay Architecture) of a Technical Design Specification by analyzing the Game Design Document and previous technical sections to generate comprehensive gameplay systems that serve the game's design goals.

## 📋 INSTRUCTIONS:
1. **Analyze GDD gameplay mechanics** and extract core interaction patterns, rules, and player experience goals
2. **Build on previous technical decisions** from Sections 0-1 to create consistent gameplay architecture
3. **Design gameplay rule systems** that enforce the intended player experience through technical implementation
4. **Create input architecture** appropriate for the game genre, platform constraints, and accessibility needs
5. **Translate abstract experience goals** into specific technical systems with measurable targets
6. **Design AI/behavior systems** that serve the gameplay and narrative goals identified in the GDD

## 🎯 OUTPUT FORMAT:

### **2. GAMEPLAY ARCHITECTURE** *(How the game actually works)*

#### **2.1 Game Rules & Mechanics Structure**

**FIELD EXPLANATION:** Define the technical implementation of your game's core rules and mechanics by translating GDD gameplay systems into code structures, validation methods, and state management. This includes the gameplay loop implementation, rule validation systems, and state transition management that enforce your design goals through technical architecture. Focus on creating measurable, enforceable rules that maintain game balance and serve the intended player experience.

**Purpose & Design Philosophy:**
The gameplay rules for "[Game Title]" reflect the **"[Design Pillar 1]"** and **"[Design Pillar 2]"** design pillars from the GDD. Unlike [contrasting genre] that emphasize [different priorities], this [game genre] prioritizes **[key gameplay driver 1]** and **[key gameplay driver 2]**, driving rule systems that support **[core experience goal]** and **[secondary experience goal]**.

**Core Gameplay Loop Implementation:**

```csharp
public class GameplayLoop : MonoBehaviour
{
    [Header("Core Loop Configuration")]
    public float [gameSpecificSetting1] = [value];  // [Rationale for setting]
    public bool [gameSpecificSetting2] = [value];   // [Design goal served]
    public bool [gameSpecificSetting3] = [value];   // [Player experience support]

    // Core loop: [Step1] → [Step2] → [Step3] → [Step4] → [Step5]
    public IEnumerator ExecuteGameplayLoop()
    {
        while (gameActive)
        {
            // 1. [Loop Phase 1] ([purpose and rationale])
            yield return StartCoroutine([Phase1Method]());

            // 2. [Loop Phase 2] ([purpose and rationale])
            yield return StartCoroutine([Phase2Method]());

            // 3. [Loop Phase 3] ([purpose and rationale])
            [Phase3Method]();

            // 4. [Loop Phase 4] ([purpose and rationale])
            [Phase4Method]();

            // 5. [Loop Phase 5] ([purpose and rationale])
            [Phase5Method]();
        }
    }
}

```

**Rule Categories & Implementation Strategy:**

| Rule Category | Rule Definition | Validation Method | Enforcement Point | Why This Rule |
| --- | --- | --- | --- | --- |
| **[Rule Category 1]** | [Specific rule based on GDD mechanics] | [Technical validation approach] | [Where in code this is checked] | [Design goal this rule serves] |
| **[Rule Category 2]** | [Specific rule based on GDD mechanics] | [Technical validation approach] | [Where in code this is checked] | [Player experience this enables] |
| **[Rule Category 3]** | [Specific rule based on GDD mechanics] | [Technical validation approach] | [Where in code this is checked] | [Design pillar this supports] |
| **[Rule Category 4]** | [Specific rule based on GDD mechanics] | [Technical validation approach] | [Where in code this is checked] | [Constraint this addresses] |

**Game State Transitions:**

| From State | To State | Trigger Condition | Transition Duration | Actions Performed |
| --- | --- | --- | --- | --- |
| **[GameState1]** | **[GameState2]** | [Trigger from GDD mechanics] | [Duration appropriate to game feel] | [Technical actions supporting design goals] |
| **[GameState2]** | **[GameState3]** | [Trigger from GDD mechanics] | [Duration appropriate to game feel] | [Technical actions supporting design goals] |
| **[GameState3]** | **[GameState4]** | [Trigger from GDD mechanics] | [Duration appropriate to game feel] | [Technical actions supporting design goals] |

**Why These State Transitions:**
[Explanation of how transition timing and actions serve the design pillars and intended player experience from the GDD]

### **2.2 Player Interaction Architecture**

**FIELD EXPLANATION:** Design the complete input system that translates player intentions into game actions, considering genre requirements, platform constraints, and accessibility needs. This includes input processing pipeline, validation systems, cross-platform mapping, alternative input methods, and performance optimization. The architecture should support responsive gameplay while accommodating different player needs and platform capabilities.

**Input System Design Philosophy:**
The **"[relevant design pillar]"** design pillar drives a **[input approach description]** that prioritizes **[input priority 1]** over [deprioritized aspect]. The system supports **[accessibility/platform considerations]** while maintaining the [intended experience quality] across all platforms.

**Unity Input System Implementation:**

```csharp
public class [GameSpecific]InputManager : BaseManager
{
    [Header("Unity Input System Configuration")]
    public InputActionAsset inputActionAsset;    // Main input action asset
    public float inputSensitivity = 1.0f;       // [Rationale for sensitivity]
    public float deadZone = 0.1f;              // [Controller deadzone rationale]
    public bool invertYAxis = false;            // [Player preference support]

    [Header("Cross-Platform Support")]
    public bool enableTouchInput = true;        // Mobile/tablet support
    public bool enableKeyboardShortcuts = true; // PC accessibility
    public bool enableControllerSupport = true; // Console/PC controller support
    public bool enableMouseSupport = true;      // PC precision input

    [Header("Accessibility Features")]
    public bool enableInputRemapping = true;    // Custom key bindings
    public bool enableHoldToToggle = false;    // Alternative interaction methods
    public float inputBufferTime = 0.2f;       // Input timing assistance
    public bool enableVisualInputFeedback = false; // Input confirmation display

    private InputActionMap [gameplayActionMap];
    private InputAction [primaryAction];
    private InputAction [secondaryAction];
    private InputAction [specialAction];        // [Game-specific action]
    
    // Cross-platform input actions
    private InputAction [touchAction];          // Mobile touch input
    private InputAction [pointerAction];        // Mouse/stylus input
    private InputAction [gampadAction];         // Controller input

    protected override bool OnInitialize()
    {
        if (inputActionAsset == null) return false;
        
        [gameplayActionMap] = inputActionAsset.FindActionMap("[GameplayActionMapName]");
        if ([gameplayActionMap] == null) return false;

        // Initialize primary actions
        [primaryAction] = [gameplayActionMap].FindAction("[PrimaryActionName]");
        [secondaryAction] = [gameplayActionMap].FindAction("[SecondaryActionName]");
        [specialAction] = [gameplayActionMap].FindAction("[SpecialActionName]");
        
        // Initialize platform-specific actions
        [touchAction] = [gameplayActionMap].FindAction("[TouchActionName]");
        [pointerAction] = [gameplayActionMap].FindAction("[PointerActionName]");
        [gampadAction] = [gameplayActionMap].FindAction("[GamepadActionName]");

        // Configure input processing
        ConfigureInputProcessors();
        EnableInputMaps();
        
        return true;
    }

    private void ConfigureInputProcessors()
    {
        // Apply deadzone to analog inputs
        if ([primaryAction].activeControl != null && [primaryAction].activeControl.device is Gamepad)
        {
            [primaryAction].ApplyBindingOverride(new InputBinding { 
                processors = $"stickDeadzone(min={deadZone})" 
            });
        }

        // Configure sensitivity scaling
        [primaryAction].ApplyBindingOverride(new InputBinding { 
            processors = $"scale(factor={inputSensitivity})" 
        });
    }

    // Cross-platform input processing
    public [InputType] Get[PrimaryInput]()
    {
        [InputType] input = Vector2.zero;

        // Process based on active device
        if ([primaryAction].activeControl?.device is Gamepad)
        {
            input = [primaryAction].ReadValue<[InputType]>();
            // Apply controller-specific processing
            input = ProcessControllerInput(input);
        }
        else if ([primaryAction].activeControl?.device is Keyboard)
        {
            input = [primaryAction].ReadValue<[InputType]>();
            // Apply keyboard-specific processing
            input = ProcessKeyboardInput(input);
        }
        else if (enableTouchInput && [touchAction].IsPressed())
        {
            input = [touchAction].ReadValue<[InputType]>();
            // Apply touch-specific processing
            input = ProcessTouchInput(input);
        }

        // Apply universal processing (buffering, validation, etc.)
        return ProcessUniversalInput(input);
    }

    // Accessibility-enhanced interaction detection
    public bool Get[InteractionInput]()
    {
        bool inputDetected = false;

        // Check multiple input sources
        inputDetected |= [secondaryAction].WasPressedThisFrame();
        
        // Touch/mobile support
        if (enableTouchInput)
            inputDetected |= [touchAction].WasPressedThisFrame();
            
        // Alternative controller inputs
        if (enableControllerSupport)
            inputDetected |= [gampadAction].WasPressedThisFrame();

        // Input buffering for accessibility
        if (!inputDetected && inputBufferTime > 0)
        {
            inputDetected = CheckBufferedInput();
        }

        // Hold-to-toggle accessibility option
        if (enableHoldToToggle && [secondaryAction].IsPressed())
        {
            inputDetected = CheckHoldToToggle();
        }

        if (inputDetected && [conditionalCheck])
        {
            // Visual feedback for accessibility
            if (enableVisualInputFeedback)
                ShowInputFeedback();
                
            return ValidateInput();
        }

        return inputDetected;
    }

    // Platform-specific input processing methods
    private [InputType] ProcessControllerInput([InputType] input) { /* Controller-specific logic */ }
    private [InputType] ProcessKeyboardInput([InputType] input) { /* Keyboard-specific logic */ }
    private [InputType] ProcessTouchInput([InputType] input) { /* Touch-specific logic */ }
    private [InputType] ProcessUniversalInput([InputType] input) { /* Universal validation/filtering */ }
    
    // Accessibility support methods
    private bool CheckBufferedInput() { /* Input timing assistance */ }
    private bool CheckHoldToToggle() { /* Alternative interaction method */ }
    private void ShowInputFeedback() { /* Visual input confirmation */ }
    private bool ValidateInput() { /* Input validation logic */ }
}

```

**Enhanced Input Processing Pipeline:**

| Stage | Purpose | Performance Target | Platform Differences | Accessibility Features |
| --- | --- | --- | --- | --- |
| **Device Detection** | Identify active input device and configure processing | <1ms device switching | Touch (mobile), Keyboard/Mouse (PC), Gamepad (console) | Auto-detection, manual override options |
| **Raw Input Capture** | Capture device-specific input data with appropriate processors | <16ms input latency | Touch: gesture recognition, KB/M: precision, Gamepad: analog processing | Input buffering, hold-to-toggle support |
| **Input Validation** | Apply deadzones, sensitivity, and game-specific filtering | <1ms validation time | Platform-specific deadzones and sensitivity curves | Configurable timing windows, alternative input methods |
| **Action Translation** | Convert processed input to game actions with context awareness | <1ms translation | Platform-appropriate action mapping and feedback | Remappable bindings, visual feedback options |
| **Gameplay Integration** | Execute validated actions in game systems with proper timing | Immediate execution | Platform-specific performance optimization | Input confirmation, error recovery |

**Enhanced Cross-Platform & Accessibility Support:**

- **Universal Input System:** Unity's new Input System provides consistent input handling across all platforms while supporting device-specific optimization
- **Accessibility First:** Input buffering, hold-to-toggle, visual feedback, and remappable controls ensure inclusive design from the start
- **Performance Optimization:** Device-specific processing paths maintain responsive gameplay across mobile, PC, and console platforms
- **Graceful Degradation:** System automatically adapts to available input methods without breaking core gameplay functionality

**Input Architecture Decision Framework:**

| Game Genre | Recommended Input Approach | Platform Priority | Accessibility Emphasis |
| --- | --- | --- | --- |
| **Action/Arcade** | Low-latency, precise input with minimal buffering | Console/PC gamepad support | Input timing assistance, alternative action triggers |
| **Puzzle/Strategy** | Deliberate input with confirmation options | Touch-first design with PC/console adaptation | Extended input timing, visual confirmations |
| **RPG/Adventure** | Context-sensitive input with extensive remapping | Equal cross-platform support | Comprehensive remapping, multiple interaction methods |
| **Mobile-First** | Touch-optimized with optional controller support | Mobile primary, PC secondary | Large touch targets, gesture alternatives |

### **2.3 Experience-to-Implementation Translation**

**FIELD EXPLANATION:** Systematically translate abstract experience goals from the GDD into specific, measurable technical systems with objective performance targets. This includes identifying experience components, selecting appropriate technical implementations, defining measurable success metrics, and creating validation approaches. The goal is to ensure technical systems actually deliver the intended player experience through measurable, observable outcomes.

**Systematic Experience-to-Technical Translation Methodology:**

**Step 1: Experience Goal Decomposition**
Break abstract experience goals into measurable components with specific success criteria.

**Experience Translation Framework:**

| Experience Type | Measurement Approach | Technical Implementation | Validation Method |
| --- | --- | --- | --- |
| **Responsiveness** | Input-to-visual feedback delay | <100ms input processing, immediate visual response | Input latency profiling, user reaction testing |
| **Flow State** | Uninterrupted gameplay duration | Seamless state transitions, predictable timing | Session length analytics, interruption tracking |
| **Challenge/Mastery** | Success rate progression | Adaptive difficulty, skill-based matching | Win/loss ratio analysis, learning curve metrics |
| **Immersion** | Attention retention duration | Consistent aesthetics, minimal UI interruption | Attention tracking, external distraction resistance |
| **Satisfaction** | Action-reward feedback loops | <200ms reward acknowledgment, clear progress indicators | Dopamine response proxies, engagement metrics |

**Step 2: Technical System Mapping**

**GDD Experience Goal: "[Direct quote from GDD experience goal]"**

**Systematic Translation Process:**

1. **Identify Experience Components:** Break the experience goal into 3-5 specific, observable aspects
2. **Define Success Metrics:** Create measurable criteria for each component (time, accuracy, frequency)
3. **Select Technical Systems:** Choose Unity systems that can deliver and measure the required outcomes
4. **Implement Validation:** Create automated testing to verify technical systems achieve experience goals

**Enhanced Implementation Strategy:**

| Experience Component | Success Metric | Technical System | Implementation Details | Performance Target | Validation Method |
| --- | --- | --- | --- | --- | --- |
| **[Experience aspect 1]** | [Specific measurable outcome] | [Unity system/component] | [Detailed implementation approach] | [Specific performance target] | [Automated testing approach] |
| **[Experience aspect 2]** | [Specific measurable outcome] | [Unity system/component] | [Detailed implementation approach] | [Specific performance target] | [Automated testing approach] |
| **[Experience aspect 3]** | [Specific measurable outcome] | [Unity system/component] | [Detailed implementation approach] | [Specific performance target] | [Automated testing approach] |
| **[Experience aspect 4]** | [Specific measurable outcome] | [Unity system/component] | [Detailed implementation approach] | [Specific performance target] | [Automated testing approach] |

**Step 3: Implementation Validation Framework**

**Common Experience-to-Technical Translations:**

| Abstract Experience Goal | Concrete Technical Requirements | Measurable Success Criteria |
| --- | --- | --- |
| **"Feels responsive and immediate"** | Input latency <100ms, visual feedback <50ms, audio feedback <30ms | 95% of inputs processed within timing targets |
| **"Challenging but fair"** | 60-70% success rate, gradual difficulty curve, clear failure feedback | Win rate within target range, difficulty progression validated |
| **"Smooth and polished"** | 60fps minimum, seamless transitions, consistent visual quality | Frame rate stability, transition timing consistency |
| **"Engaging and compelling"** | Session length >15min, return rate >70%, progression clarity | Analytics data meeting engagement targets |
| **"Intuitive and accessible"** | <30s learning time, <3 failed attempts to understand, multiple input methods | Usability testing metrics, accessibility compliance |

**GDD Experience Goal: "[Second direct quote from GDD experience goal]"**

**Technical Implementation Framework:**

```csharp
public class [ExperienceSpecific]System : MonoBehaviour
{
    [Header("[Experience Category] Settings")]
    public float [experienceSetting1] = [value];  // [Experience goal served]
    public float [experienceSetting2] = [value];  // [Player experience rationale]
    public float [experienceSetting3] = [value];    // [Design pillar support]

    [Header("[Implementation Category]")]
    public bool [implementationFlag1] = true;        // [Technical approach rationale]
    public float [implementationSetting1] = [value];           // [Performance consideration]
    public int [implementationSetting2] = [value];     // [Design constraint consideration]

    // [Experience approach] management
    public void Process[ExperienceElement]([ElementType] element)
    {
        // 1. [Implementation step 1] ([rationale])
        yield return new WaitForSeconds([experienceSetting2]);

        // 2. [Implementation step 2] ([rationale])
        [TechnicalMethod](element);

        // 3. [Implementation step 3] ([rationale])
        [EvaluationMethod](element);

        // 4. [Implementation step 4] ([rationale])
        yield return new WaitForSeconds([experienceSetting3]);

        // 5. [Implementation step 5] ([rationale])
        [EnablementMethod]();
    }
}

```

**[Progression/Mastery] → System Design:**

**GDD Player Journey: "[Direct quote about player progression/learning from GDD]"**

**Technical System Design Strategy:**

| Learning Phase | Duration | System Adaptations | Technical Implementation |
| --- | --- | --- | --- |
| **[Phase 1 Name]** ([time range]) | [duration] | [System adaptation approach] | [Specific technical implementation] |
| **[Phase 2 Name]** ([time range]) | [duration] | [System adaptation approach] | [Specific technical implementation] |
| **[Phase 3 Name]** ([time range]) | [duration] | [System adaptation approach] | [Specific technical implementation] |
| **[Phase 4 Name]** ([time range]) | [duration] | [System adaptation approach] | [Specific technical implementation] |

**Why This [Progression Type] Implementation:**
[Explanation of how the technical systems serve the specific learning/progression goals identified in the GDD]

### **2.4 AI & Behavior Architecture**

**FIELD EXPLANATION:** Design AI and behavior systems that serve your game's specific gameplay and narrative goals rather than generic AI requirements. This includes selecting appropriate AI patterns (FSM, Behavior Trees, Utility AI), implementing coordination systems, defining AI scope appropriate for team/timeline constraints, and ensuring AI behavior supports the intended player experience. Focus on AI that enhances gameplay rather than showcasing technical complexity.

**AI Pattern Selection Framework:**

**Decision Matrix for AI Architecture:**

| Game Requirements | Finite State Machine (FSM) | Behavior Trees | Utility AI | Neural Networks | Hybrid Approach |
| --- | --- | --- | --- | --- | --- |
| **Simple, predictable AI** | ✅ Ideal | ❌ Overkill | ❌ Overkill | ❌ Excessive | ❌ Unnecessary |
| **Complex decision-making** | ❌ Limited | ✅ Excellent | ✅ Excellent | ⚠️ Requires expertise | ✅ Flexible |
| **Dynamic, adaptive behavior** | ❌ Rigid | ⚠️ Possible | ✅ Ideal | ✅ Advanced | ✅ Best of both |
| **Multi-criteria decisions** | ❌ Binary only | ⚠️ Complex setup | ✅ Natural fit | ✅ Advanced | ✅ Comprehensive |
| **Performance-critical** | ✅ Fast | ✅ Moderate | ⚠️ CPU intensive | ❌ GPU required | ⚠️ Depends on mix |
| **Team has AI experience** | ✅ Easy | ✅ Moderate | ⚠️ Advanced | ❌ Expert-level | ⚠️ Varies |
| **Limited development time** | ✅ Quick | ⚠️ Medium | ❌ Time-intensive | ❌ Very slow | ❌ Complex |

**AI Complexity Scaling Guide:**

| Project Scope | Recommended Approach | Implementation Details | Team Requirements |
| --- | --- | --- | --- |
| **Prototype/Simple** | Simple FSM (3-5 states) | Basic state transitions, minimal logic | 1 programmer, basic Unity knowledge |
| **Intermediate** | Enhanced FSM or Simple Behavior Trees | Hierarchical states or basic BT nodes | 1-2 programmers, moderate AI experience |
| **Complex/Detailed** | Advanced Behavior Trees or Utility AI | Complex decision trees, scoring systems | 2+ programmers, AI architecture experience |

**[AI Type] Design Philosophy:**
Based on the **[game genre]** requirements and **[team constraint]** constraints, "[Game Title]" uses **[selected AI approach]** rather than [alternative AI approach], reflecting the **[relevant design pillar]** design pillar. This choice supports **[AI purpose 1]** and **[AI purpose 2]** while maintaining **[scope constraint consideration]** appropriate for the team and timeline.

**[Selected AI Pattern] Implementation Example:**

```csharp
// Example: FSM Implementation for Simple Game AI
public class [GameSpecific]FSMAIController : MonoBehaviour
{
    [Header("AI Configuration")]
    public float detectionRange = 5.0f;
    public float attackRange = 2.0f;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 4.0f;
    
    [Header("State Management")]
    public AIState currentState = AIState.Patrol;
    public Transform[] patrolPoints;
    public Transform player;
    
    // Simple FSM for enemy AI
    public enum AIState
    {
        Patrol,     // Move between patrol points
        Chase,      // Pursue detected player
        Attack,     // Engage player in combat
        Return      // Return to patrol after losing player
    }
    
    public void Update()
    {
        switch (currentState)
        {
            case AIState.Patrol:
                HandlePatrolState();
                break;
            case AIState.Chase:
                HandleChaseState();
                break;
            case AIState.Attack:
                HandleAttackState();
                break;
            case AIState.Return:
                HandleReturnState();
                break;
        }
    }
    
    private void HandlePatrolState()
    {
        // Patrol behavior implementation
        if (PlayerInRange(detectionRange))
            TransitionToState(AIState.Chase);
    }
    
    private void TransitionToState(AIState newState)
    {
        // State transition with proper cleanup
        ExitCurrentState();
        currentState = newState;
        EnterNewState();
    }
}

// Example: Behavior Tree Implementation for Complex AI
[System.Serializable]
public class BehaviorTreeNode
{
    public enum NodeType { Selector, Sequence, Action, Condition }
    public NodeType nodeType;
    public string actionName;
    public BehaviorTreeNode[] children;
    
    public bool Execute(GameObject agent)
    {
        switch (nodeType)
        {
            case NodeType.Selector:
                // OR logic - succeed if any child succeeds
                foreach (var child in children)
                {
                    if (child.Execute(agent))
                        return true;
                }
                return false;
                
            case NodeType.Sequence:
                // AND logic - fail if any child fails
                foreach (var child in children)
                {
                    if (!child.Execute(agent))
                        return false;
                }
                return true;
                
            case NodeType.Action:
                // Execute specific action
                return ExecuteAction(actionName, agent);
                
            case NodeType.Condition:
                // Evaluate condition
                return EvaluateCondition(actionName, agent);
        }
        
        return false;
    }
}

// Example: Utility AI Implementation for Dynamic Decision-Making
public class UtilityAIController : MonoBehaviour
{
    [System.Serializable]
    public class AIAction
    {
        public string actionName;
        public float baseScore = 1.0f;
        public UtilityConsideration[] considerations;
        
        public float CalculateUtility(GameObject agent)
        {
            float finalScore = baseScore;
            
            foreach (var consideration in considerations)
            {
                finalScore *= consideration.Evaluate(agent);
            }
            
            return finalScore;
        }
    }
    
    [System.Serializable]
    public class UtilityConsideration
    {
        public string considerationName;
        public AnimationCurve responseCurve = AnimationCurve.Linear(0, 0, 1, 1);
        
        public float Evaluate(GameObject agent)
        {
            float inputValue = GetInputValue(considerationName, agent);
            return responseCurve.Evaluate(inputValue);
        }
    }
    
    public AIAction[] availableActions;
    
    public void ExecuteBestAction()
    {
        AIAction bestAction = null;
        float bestScore = 0f;
        
        foreach (var action in availableActions)
        {
            float score = action.CalculateUtility(gameObject);
            if (score > bestScore)
            {
                bestScore = score;
                bestAction = action;
            }
        }
        
        if (bestAction != null)
        {
            ExecuteAction(bestAction.actionName);
        }
    }
}

```

**[AI System] Categories:**

| AI System | Purpose | Implementation Approach | Player Experience Impact |
| --- | --- | --- | --- |
| **[AI System 1]** | [Purpose from GDD needs] | [Technical implementation approach] | [How this serves player experience] |
| **[AI System 2]** | [Purpose from GDD needs] | [Technical implementation approach] | [How this serves player experience] |
| **[AI System 3]** | [Purpose from GDD needs] | [Technical implementation approach] | [How this serves player experience] |
| **[AI System 4]** | [Purpose from GDD needs] | [Technical implementation approach] | [How this serves player experience] |

**Why [AI Approach] Over [Alternative AI Approach]:**

- **[AI Decision 1]:** [Rationale based on design pillars]
- **[AI Decision 2]:** [Player experience consideration]
- **[AI Decision 3]:** [Technical/scope consideration]
- **[AI Decision 4]:** [Genre-specific rationale]

**AI Coordination Architecture:**

```csharp
public static class [GameSpecific]IntelligenceEvents
{
    // [AI coordination category] events
    public static event System.Action<[EventType1]> On[AIEvent1];
    public static event System.Action<[EventType2]> On[AIEvent2];
    public static event System.Action<[EventType3]> On[AIEvent3];

    // Coordinated [AI response type]
    public static void Coordinate[AIResponse]([ParameterType] [parameter])
    {
        // [AI coordination step 1]
        On[AIEvent1]?.Invoke([parameter]);

        // [AI coordination step 2]
        [EvaluationMethod]([parameter]);

        // [AI coordination step 3]
        [AISystem].Instance?.[ResponseMethod]([parameter]);
    }
}

```

**[AI System] Communication:**
[Explanation of how AI systems coordinate to serve the gameplay and design goals identified in the GDD]

## 🔧 GENRE-SPECIFIC GAMEPLAY ANALYSIS METHODOLOGY:

### **Core Mechanics Extraction by Genre:**

**Action/Arcade Games:**
- **Primary Actions:** Movement precision, timing-critical actions, reflex responses
- **Secondary Actions:** Power-ups, defensive maneuvers, environmental interactions
- **Victory Conditions:** Score-based, survival-based, or objective completion
- **Core Loop:** Challenge → Response → Feedback → Escalation (30-60 seconds)

**Puzzle Games:**
- **Primary Actions:** Logical manipulation, pattern recognition, rule application
- **Secondary Actions:** Hint systems, undo mechanisms, alternative solutions
- **Victory Conditions:** Problem solving, efficiency optimization, creative solutions
- **Core Loop:** Problem → Analysis → Solution → Validation (2-5 minutes)

**Strategy Games:**
- **Primary Actions:** Resource management, planning, tactical decisions
- **Secondary Actions:** Information gathering, optimization, adaptation
- **Victory Conditions:** Long-term objective achievement, resource dominance
- **Core Loop:** Planning → Execution → Evaluation → Adaptation (5-15 minutes)

**RPG/Adventure Games:**
- **Primary Actions:** Character progression, story choices, exploration
- **Secondary Actions:** Inventory management, character customization, relationship building
- **Victory Conditions:** Story completion, character achievement, world mastery
- **Core Loop:** Explore → Discover → Progress → Grow (10-30 minutes)

### **Genre-Specific Experience Goal Translation:**

**Action Games - "Intense and Responsive":**
- **Technical Requirements:** <50ms input latency, 60+ FPS, immediate visual feedback
- **Implementation Focus:** Input processing optimization, visual effects systems, audio feedback
- **Validation:** Reaction time testing, performance profiling, player stress response

**Puzzle Games - "Clear and Satisfying":**
- **Technical Requirements:** Visual clarity, logical consistency, progress feedback
- **Implementation Focus:** UI clarity systems, animation timing, solution validation
- **Validation:** Comprehension testing, solution path analysis, satisfaction metrics

**Strategy Games - "Deep and Strategic":**
- **Technical Requirements:** Complex state management, information presentation, decision support
- **Implementation Focus:** Data architecture, AI systems, visualization tools
- **Validation:** Decision quality metrics, information processing efficiency, strategic depth analysis

**RPG Games - "Immersive and Progressive":**
- **Technical Requirements:** Persistent state, narrative systems, character customization
- **Implementation Focus:** Save systems, story delivery, progression tracking
- **Validation:** Engagement metrics, retention analysis, progression satisfaction

### **Genre-Specific Input Architecture Patterns:**

| Genre | Input Priority | Architecture Pattern | Cross-Platform Considerations |
| --- | --- | --- | --- |
| **Action/Arcade** | Low latency, precision | Direct input mapping, minimal processing | Gamepad primary, touch adaptation required |
| **Puzzle/Logic** | Deliberate interaction, confirmation | Input validation, undo/redo support | Touch primary, mouse/gamepad secondary |
| **Strategy/Management** | Information density, multi-selection | Context-sensitive input, keyboard shortcuts | Mouse primary, touch adaptation with gestures |
| **RPG/Adventure** | Contextual interaction, accessibility | Adaptive input, extensive remapping | Equal platform support, full accessibility |

### **Genre-Specific AI System Recommendations:**

| Genre | AI Complexity | Recommended Pattern | Implementation Focus |
| --- | --- | --- | --- |
| **Action Games** | Simple-Medium | FSM or Simple Behavior Trees | Performance optimization, predictable responses |
| **Puzzle Games** | Simple | Rule-based systems, FSM | Logic validation, hint generation |
| **Strategy Games** | Medium-High | Utility AI, Complex Behavior Trees | Multi-criteria decisions, long-term planning |
| **RPG Games** | Medium-High | Behavior Trees, Dialogue Systems | Character personality, narrative integration |

### **Genre-Specific Performance Targets:**

| Genre | Frame Rate | Input Latency | Load Times | Memory Usage |
| --- | --- | --- | --- | --- |
| **Action/Arcade** | 60+ FPS | <50ms | <3 seconds | Optimized for performance |
| **Puzzle/Strategy** | 30+ FPS | <100ms | <5 seconds | Moderate, complexity-dependent |
| **RPG/Adventure** | 30+ FPS | <100ms | <10 seconds | Higher for content/assets |
| **Mobile Games** | 30+ FPS | <100ms | <2 seconds | Minimal, battery-conscious |

## 📝 INPUT REQUIREMENTS:

- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**
- **Section 1: System Architecture output**

## ⚡ KEY REQUIREMENTS:

- **Extract specific gameplay mechanics** from GDD and translate to technical rules systems
- **Design input architecture** appropriate for the game genre, platforms, and constraints
- **Create measurable technical targets** for abstract experience goals
- **Include comprehensive code examples** showing implementation approaches
- **Provide detailed rationale** connecting all technical decisions to design goals
- **Ensure AI systems serve** the gameplay and narrative goals, not just technical requirements
- **Consider scope constraints** from previous sections in complexity decisions
- **Make all systems actionable** for subsequent implementation task generation

## 🎮 INPUT:

**Complete GDD:**
[PASTE GAME DESIGN DOCUMENT HERE]

**Section 0 Output:**
[PASTE DESIGN TRANSLATION FRAMEWORK OUTPUT HERE]

**Section 1 Output:**
[PASTE SYSTEM ARCHITECTURE OUTPUT HERE]

Generate Section 2 following this exact structure with detailed technical implementation and comprehensive rationale connecting all decisions to the GDD design goals.