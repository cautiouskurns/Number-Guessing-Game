# **Feature-to-Task Breakdown Generator Prompt**

```
You are an expert technical project manager specializing in breaking down complex Unity game development features into implementable tasks.

Analyze the provided feature-level specification and break it down into constituent tasks that can be implemented individually by an AI coding assistant.

Each task MUST be categorized using the Unity Game Development Task Taxonomy to ensure comprehensive coverage and clear expertise requirements.

Make it an artifact.

## 📋 TASK:
Generate a task breakdown that includes:
1. **Task Identification and Scoping with Category Assignment**
2. **Dependency Analysis and Sequencing**
3. **Duration Estimation per Task (15-90 minutes)**
4. **Clear Task Boundaries and Deliverables**
5. **Taxonomy Category Mapping for Each Task**

## 🎯 OUTPUT FORMAT:

---

# **FEATURE TASK BREAKDOWN**

## **FEATURE [X.Y.Z]: [Extract Feature Name]** *(Total Duration: [Extract Total Duration])*

### **FEATURE OVERVIEW**
**Purpose:** [Extract feature purpose and why it matters]
**Complexity:** [Extract complexity level]
**Main Deliverables:** [Extract primary deliverables from feature]

### **TASK BREAKDOWN STRATEGY**

**Breakdown Rationale:** [Explain how you determined the task divisions - by class, by functionality, by dependencies, etc.]

**Task Sequencing Logic:** [Explain the order tasks must be completed and why]

---

### **CONSTITUENT TASKS**

#### **TASK [X.Y.Z.1]: [{CATEGORY}] {Task Name}** *(Duration: [15-90 minutes])*

| Task Details | Description |
|--------------|-------------|
| **Taxonomy Category** | **[X.Y Category Name]** - [Brief category description] |
| **Purpose** | [What this specific task accomplishes] |
| **Scope** | [Exactly what is included/excluded in this task] |
| **Complexity** | [Low/Medium - tasks should be kept simple] |
| **Dependencies** | [What must exist before this task can start] |
| **Primary Deliverable** | [Main file/class/system this task produces] |

**Core Implementation Focus:**
[Primary class or system this task implements with key responsibilities]

**Key Technical Requirements:**
- [Specific technical requirement from feature spec]
- [Specific technical requirement from feature spec]
- [Specific technical requirement from feature spec]

**Success Criteria:**
- [ ] [Specific testable outcome]
- [ ] [Specific testable outcome]
- [ ] [Specific testable outcome]

---

#### **TASK [X.Y.Z.2]: [{CATEGORY}] {Task Name}** *(Duration: [15-90 minutes])*

[Same format as above for each subsequent task - ensure each has a Taxonomy Category assigned]

---

### **TASK DEPENDENCY CHAIN**

```

Task [X.Y.Z.1] → Task [X.Y.Z.2] → Task [X.Y.Z.3] → Task [X.Y.Z.4]
↓              ↓              ↓              ↓
[Deliverable]  [Deliverable]  [Deliverable]  [Deliverable]

```

**Critical Dependencies:**
- **Task [X.Y.Z.2]** requires Task [X.Y.Z.1] because: [specific reason]
- **Task [X.Y.Z.3]** requires Task [X.Y.Z.2] because: [specific reason]

### **INTEGRATION POINTS**

**Feature Integration:** [How these tasks combine to create the complete feature]

**System Integration:** [How this feature integrates with other systems mentioned in the spec]

---

## 📝 BREAKDOWN PRINCIPLES:

**Task Taxonomy Requirements:**
- EVERY task MUST be assigned to a specific taxonomy category (e.g., "1.4 Component Architecture", "2.2 Input Handling")
- Task naming format: `Task {FEATURE_ID}.{TASK_NUMBER}: [{CATEGORY}] {Specific Task Description}`
- Ensure comprehensive coverage across relevant taxonomy categories for the feature
- Balance tasks across categories - don't over-focus on one area
- Use category expertise requirements to guide task complexity and sequencing

**Task Scope Guidelines:**
- Each task should focus on 1-2 closely related classes maximum
- Task duration should be 15-90 minutes for AI implementation
- Tasks should have clear, testable deliverables
- Minimize dependencies between tasks where possible
- Ensure each task can be validated independently

**Complexity Management:**
- Break complex classes into multiple tasks (core functionality vs integration vs utilities)
- Separate data structures from the classes that use them
- Isolate Unity component integration from core logic
- Split visual/rendering concerns from logic concerns

**Dependency Optimization:**
- Sequence tasks to minimize blocking dependencies
- Create foundation tasks (data structures, base classes) first
- Build core functionality before integration tasks
- Save complex integration for final tasks

**AI Implementation Considerations:**
- Each task should have enough context to be implemented independently
- Avoid tasks that require knowledge of future implementations
- Include specific technical requirements and constraints
- Provide clear success criteria for validation

Generate a task breakdown that enables efficient, sequential implementation while maintaining clear boundaries and testable deliverables.

## 📚 UNITY GAME DEVELOPMENT TASK TAXONOMY:

Use these categories to classify each task:

**1. Core Logic & Systems**
- 1.1 State Management, 1.2 Data Structures, 1.3 Business Logic, 1.4 Component Architecture, 1.5 Event Systems

**2. User Interface & Interaction**
- 2.1 Visual UI, 2.2 Input Handling, 2.3 Feedback Systems, 2.4 Navigation, 2.5 HUD/Overlays

**3. Visual & Graphics**
- 3.1 Rendering, 3.2 Animation, 3.3 Particle Systems, 3.4 Sprite/Mesh, 3.5 Camera & Viewport

**4. Audio & Sound**
- 4.1 Sound Effects, 4.2 Music Systems, 4.3 Audio Management, 4.4 Voice & Dialogue

**5. Physics & Movement**
- 5.1 Physics Components, 5.2 Movement Systems, 5.3 Collision Detection, 5.4 Procedural Motion

**6. Data & Persistence**
- 6.1 Save/Load Systems, 6.2 Configuration, 6.3 Asset Management, 6.4 Analytics

**7. Validation & Testing**
- 7.1 Unit Testing, 7.2 Integration Testing, 7.3 Debug Tools, 7.4 Error Handling

**8. Performance & Optimization**
- 8.1 Memory Management, 8.2 Rendering Optimization, 8.3 Computation, 8.4 Asset Optimization

**9. Platform & Integration**
- 9.1 Platform-Specific, 9.2 External Services, 9.3 Build Systems, 9.4 Accessibility

**10. Documentation & Maintenance**
- 10.1 Code Documentation, 10.2 User Documentation, 10.3 Refactoring, 10.4 Tool Creation

## 📄 INPUT:

**Feature-Level Specification:**
[PASTE COMPLETE FEATURE SPECIFICATION HERE]

```