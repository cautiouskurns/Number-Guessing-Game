# Simple Technical Design Specification Template

> **Optimized for --complexity="simple" projects**  
> **Sections:** 0-3 (Core sections only)  
> **Target:** Fast TDS generation for simple games

This template provides a streamlined TDS generation process for simple projects, focusing on core technical requirements without unnecessary complexity.

---

## **0. DESIGN TRANSLATION FRAMEWORK** *(Core Design → Tech Mapping)*

### **0.1 Design Pillars → Technical Requirements**

**For [Game Title] [Genre]:**

| Design Decision | Technical Implementation | Why This Matters |
| --- | --- | --- |
| **"[Core gameplay pillar]"** | [Essential Unity systems] | [How this serves the core experience] |
| **"[Visual style goal]"** | [Basic rendering approach] | [Why this choice fits the style] |
| **"[Player experience goal]"** | [Key systems needed] | [How this creates the intended feel] |

### **0.2 Platform Constraints** 

**Target Platform:** [Unity2D/Unity3D]
- **Performance Target:** [Basic target - e.g., 60fps 1080p]
- **Platform Specific:** [Essential platform considerations]
- **Key Limitations:** [Major constraints affecting design]

---

## **1. SYSTEM ARCHITECTURE** *(High-Level Structure)*

### **1.1 Core Systems**

**Essential Systems for [Game Title]:**

```
[Game Manager] → [Core Gameplay] → [Player Controller] → [UI Manager]
```

**System Responsibilities:**
- **[Game Manager]**: [Core state management]
- **[Gameplay System]**: [Main game logic]
- **[Player System]**: [Player interactions]
- **[UI System]**: [Interface management]

### **1.2 Unity Scene Structure**

**Scene Organization:**
- **MainMenu**: [Menu functionality]
- **GameplayScene**: [Core game]
- **[Additional scenes if needed]**

---

## **2. GAMEPLAY ARCHITECTURE** *(Game Logic)*

### **2.1 Core Game Loop**

**Primary Loop:**
1. **[Initialization]**: [What happens on start]
2. **[Player Input]**: [How player interacts]
3. **[Game Logic]**: [Core gameplay mechanics]
4. **[Feedback]**: [Visual/audio response]
5. **[State Update]**: [Game state changes]

### **2.2 Player Interaction Model**

**Input → Response Pattern:**
- **[Primary Input]**: [Main player action] → [System response]
- **[Secondary Input]**: [Additional actions] → [System response]
- **[Game Events]**: [Automatic game events] → [System response]

---

## **3. CLASS DESIGN** *(Implementation Level)*

### **3.1 Core Classes**

**Essential Classes:**

| Class Name | Responsibility | Key Methods |
|------------|----------------|-------------|
| **[GameManager]** | [Game state control] | `StartGame()`, `EndGame()`, `PauseGame()` |
| **[Player]** | [Player entity] | `Move()`, `[PrimaryAction]()`, `[SecondaryAction]()` |
| **[GameplayController]** | [Game logic] | `ProcessInput()`, `UpdateGame()`, `CheckWinCondition()` |
| **[UIManager]** | [Interface control] | `UpdateUI()`, `ShowMenu()`, `HideMenu()` |

### **3.2 Inheritance Structure**

**Class Hierarchy (Keep Simple):**
```
MonoBehaviour
├── GameManager
├── Player
├── GameplayController
└── UIManager
```

**Design Pattern:** **Component-based** (Unity's natural pattern)
- Each class inherits from MonoBehaviour
- Clear separation of responsibilities
- Minimal inheritance hierarchy

---

## **📋 GENERATION GUIDELINES**

### **For Simple Complexity:**
- **Focus on:** Core functionality only
- **Avoid:** Complex patterns, advanced optimizations
- **Keep:** Clear, straightforward implementations
- **Target:** 3-5 core systems maximum
- **Classes:** 4-8 essential classes
- **Patterns:** Use Unity's component pattern primarily

### **Template Usage:**
1. Replace `[placeholders]` with game-specific content
2. Focus on the essential systems for your game
3. Keep technical depth appropriate for simple projects
4. Ensure all sections connect to actual gameplay needs

### **Time Target:**
- **Generation Time:** 5-10 minutes per section
- **Total TDS Time:** 20-40 minutes (vs 2+ hours for full TDS)
- **Implementation Readiness:** Direct path to coding tasks

---

*This template prioritizes speed and clarity over comprehensive technical depth, perfect for simple games that need quick technical planning.*