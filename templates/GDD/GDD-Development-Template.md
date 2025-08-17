# GDD Development Prompt - Enhanced Template

***[Using the attached GDD template and game concept, please generate a complete Game Design Document. Follow the template structure exactly, fill out all sections with specific details, and use the guidance to create comprehensive responses.]***

You are an expert game designer specialising in solo development projects. Create a comprehensive Game Design Document using the Solo Developer GDD Template below.

**Make it an artifact.**

## 📋 INSTRUCTIONS:

1. **Load project parameters** from project-parameters.yaml (especially COMPLEXITY_LEVEL)
2. **Analyze the input** for core concept, genre, scope, and constraints
3. **Apply solo developer principles**: Achievable scope, clear technical requirements, practical planning
4. **Scale content based on complexity level** (see complexity instructions below)
5. **Fill out required sections** with specific, actionable content
6. **Maintain consistency** between sections
7. **Use clear formatting** with tables and bullets for readability
8. **Focus on implementation-ready details** for AI coding prompts
9. **Replace ALL example content with your game's specific details**
10. **Provide measurable targets** for all technical requirements

**IMPORTANT:** All examples marked as "EXAMPLE FORMAT" are for structure reference only. Do NOT copy the example content - create original content for your specific game following the same format.

## 🎯 COMPLEXITY-AWARE INSTRUCTIONS:

**BEFORE STARTING:** Check the COMPLEXITY_LEVEL in your project-parameters.yaml and follow the appropriate level:

### **SIMPLE** *(Prototypes, Learning Projects, Quick Concepts)*
- **Complete sections only:** 1.1, 1.2, 2.1, 2.2, 5.1, 6.1
- **Response style:** Concise (1-2 sentences per field, essential info only)
- **Focus:** Core gameplay, basic technical requirements, minimal scope
- **Target length:** 2-3 pages
- **Use case:** Weekend prototypes, game jams, learning exercises

### **INTERMEDIATE** *(Standard Indie Games, Commercial Projects)*
- **Complete sections:** All sections with standard detail level
- **Response style:** Balanced (2-3 sentences per field, necessary details)
- **Focus:** Complete game design with practical implementation details
- **Target length:** 5-7 pages  
- **Use case:** Solo indie games, small team projects, commercial releases

### **DETAILED** *(Comprehensive Projects, Advanced Games)*
- **Complete sections:** All sections with expanded detail and sub-examples
- **Response style:** Comprehensive (3+ sentences per field, thorough explanations)
- **Focus:** Advanced features, detailed technical specs, complex systems
- **Target length:** 10-15 pages
- **Use case:** Complex games, team projects, advanced technical implementations

**SECTION REQUIREMENTS BY COMPLEXITY:**

| Section | Simple | Intermediate | Detailed |
|---------|---------|-------------|----------|
| 1.1 Core Concept | ✅ Required | ✅ Required | ✅ Required |
| 1.2 Design Pillars | ✅ Required | ✅ Required | ✅ Required |
| 1.3 Influences & Aesthetics | ❌ Skip | ✅ Required | ✅ Required |
| 1.4 Scope | ❌ Skip | ✅ Required | ✅ Required |
| 2.1 Gameplay Mechanics | ✅ Required | ✅ Required | ✅ Required |
| 2.2 Systems & Features | ✅ Required | ✅ Required | ✅ Required |
| 2.3 Game Economy | ❌ Skip | ✅ If Applicable | ✅ Required |
| 3.1 Gameplay Loops | ❌ Skip | ✅ Required | ✅ Required |
| 3.2 Player Interaction | ❌ Skip | ✅ Required | ✅ Required |
| 3.3 Challenge & Learning | ❌ Skip | ✅ Required | ✅ Required |
| 4.1 Narrative Structure | ❌ Skip | ✅ If Applicable | ✅ Required |
| 4.2 Content Categories | ❌ Skip | ✅ Required | ✅ Required |
| 4.3 Content Scope | ❌ Skip | ✅ Required | ✅ Required |
| 5.1 Platform & Performance | ✅ Required | ✅ Required | ✅ Required |
| 5.2 Technology Stack | ❌ Skip | ✅ Required | ✅ Required |
| 6.1 Scope Management | ✅ Required | ✅ Required | ✅ Required |
| 6.2 Validation Approach | ❌ Skip | ✅ Required | ✅ Required |

## 🎯 SOLO DEVELOPER GDD TEMPLATE:

### **1. GAME IDENTITY** *(What is this game?)*

**PURPOSE:** Define game identity to prevent scope creep and maintain focus during development. Clear identity boundaries help solo developers avoid feature bloat and stay on track.

### **1.1 Core Concept**

**GUIDANCE:** Keep the game overview to a single sentence that captures the essence. The unique value proposition should differentiate from similar games in the market. Be specific about platform choices and their impact on design.

**FIELD EXPLANATIONS:**
- **Game Overview**: A single, clear sentence that explains what the player does in your game. Should be specific enough that someone can visualize the core gameplay.
- **Genre & Platform**: Primary genre defines core mechanics, secondary genres add flavor. Platform choice affects input methods, UI design, and performance targets.
- **Unique Value Proposition**: What makes your game different from competitors. Should solve a specific player problem or offer a novel experience.

**EXAMPLE FORMAT (Do not copy content - use structure only):**
- Game Overview: "[Game Name] is a [genre] where players [core verb] to [objective] by [unique mechanic]."
- Genre: Primary genre + secondary influences (e.g., "Puzzle-Strategy with Roguelike elements")
- Platform: List primary first, then secondary with specific versions (e.g., "PC (Steam), Mobile (iOS 14+, Android 10+)")

| Aspect | Description | EXAMPLE FORMAT (Replace with your content) |
| --- | --- | --- |
| **Game Overview** | [Single sentence description] | "Nexus Nodes is a strategic puzzle game where players connect energy nodes to power a city by optimizing limited resources." |
| **Genre & Platform** | [Classification and target platforms] | Primary: Puzzle-Strategy<br>Secondary: Resource Management<br>Platforms: PC (Steam/itch.io), Mobile (iOS/Android 2024) |
| **Unique Value Proposition** | [What makes this different] | Unlike static puzzles, the city dynamically responds to your network, creating emergent challenges as districts grow based on power distribution |

### **1.2 Design Pillars** *(Maximum 3)*

**GUIDANCE:** Design pillars are core principles that guide all design decisions. They should be memorable phrases that help you decide what features belong in the game. Limit to 3 to maintain focus - more pillars dilute decision-making power. Each pillar should directly influence multiple game systems.

**FIELD EXPLANATIONS:**
- **Pillar Name**: A memorable 2-3 word phrase that captures the core principle. Should be quotable and easy to remember.
- **Description**: Explains what this pillar means for your game in 2-3 sentences. Should be specific to your game's vision.
- **Implementation**: Lists specific features, mechanics, or systems that embody this pillar. Proves the pillar isn't just abstract.
- **Decision Filter**: A simple question to ask when evaluating new features. Helps maintain focus during development.

**EXAMPLE FORMAT (Do not copy content - create your own pillars):**

1. **"[Your Pillar 1]"** 
   - Description: [What this means for your game specifically]
   - Implementation: [Specific features that embody this pillar]
   - Decision Filter: "[Question to ask when evaluating features]"

2. **"[Your Pillar 2]"** 
   - Description: [What this means for your game specifically]
   - Implementation: [Specific features that embody this pillar]
   - Decision Filter: "[Question to ask when evaluating features]"

3. **"[Your Pillar 3]"** 
   - Description: [What this means for your game specifically]
   - Implementation: [Specific features that embody this pillar]
   - Decision Filter: "[Question to ask when evaluating features]"

### **1.3 Influences & Aesthetics**

**GUIDANCE:** Choose 1-2 key reference games that capture your gameplay vision. Visual and audio direction should be achievable with available skills/resources. Avoid overly complex references that would require large teams. Be specific about what you're taking from each influence.

**FIELD EXPLANATIONS:**
- **Visual Style**: Define your art direction with specific details - color palette (hex codes), geometric style, rendering approach. Must be achievable with your skill level and resources.
- **Audio Direction**: Specify music genre, tempo range, and how audio responds to gameplay. Include sound design strategy and reference examples.
- **Gameplay Influences**: List 2-3 reference games with specific mechanics you're adapting. Explain what to take and what to avoid from each reference.

**FORMAT REQUIREMENTS:**
- Include specific color codes and technical achievability notes
- Reference existing games with specific elements you're adopting
- Balance inspiration with originality - don't copy wholesale

| Element | Direction | EXAMPLE FORMAT (Replace with your aesthetic choices) |
| --- | --- | --- |
| **Visual Style** | [Your art direction with specific technical details] | **Minimalist Neon:**<br>- Color Palette: Cyan (#00D4FF), Magenta (#FF00AA), Dark Blue (#1A1A2E)<br>- Geometry: Low-poly with emissive materials<br>- Reference: Mini Metro's clarity + Tron's glow effects<br>- Achievable with: Basic 3D modeling + shader effects |
| **Audio Direction** | [Your music and sound strategy with specifics] | **Ambient Electronic:**<br>- Music: 60-80 BPM ambient synth (like C418)<br>- Dynamic: Layers add with complexity<br>- SFX: Synthesized UI sounds, electrical hums<br>- Reference: Mini Metro's responsive audio |
| **Gameplay Influences** | [Your 2-3 reference games with specific takeaways] | **Primary:** Mini Metro (flow management, visual language)<br>**Secondary:** SpaceChem (puzzle complexity from simple rules)<br>**What to take:** Mini Metro's elegance, SpaceChem's depth<br>**What to avoid:** SpaceChem's difficulty cliff, Mini Metro's time pressure |

### **1.4 Scope**

**GUIDANCE:** Success definition should be specific and measurable. Boundaries are equally important - explicitly state what you will NOT include to prevent scope creep. Development scope should reflect realistic timeline and resource constraints. Include concrete numbers wherever possible.

**FIELD EXPLANATIONS:**
- **Success Definition**: Specific, measurable criteria for when the game is complete and launched successfully. Include both technical completion metrics and commercial success targets.
- **Boundaries**: Explicit list of features you will NOT include. This prevents scope creep during development. Be specific about what's cut and why.
- **Development Scope**: Realistic timeline, budget constraints, team size, and technical limitations. Include work schedule and resource availability.

**FORMAT REQUIREMENTS:**
- All success metrics must be quantifiable (numbers, percentages, measurable outcomes)
- Boundaries should list specific cut features with reasoning
- Timeline should account for 20% overrun buffer and be realistic for your availability
- Include budget breakdown and technical constraints

| Scope Category | Definition | EXAMPLE FORMAT (Replace with your specific scope) |
| --- | --- | --- |
| **Success Definition** | [Your specific, measurable completion and launch criteria] | **MVP Complete When:**<br>- 25 unique levels shipped<br>- 3-hour campaign playable<br>- 90% bug-free in 100 playtests<br>- Steam page live with 500 wishlists<br>**Launch Success:**<br>- 100 sales in first month<br>- 70% positive reviews<br>- 1 streamer coverage |
| **Boundaries** | [Your explicit list of features NOT included] | **NOT Including:**<br>- Multiplayer of any kind<br>- Level editor (future DLC)<br>- Procedural generation<br>- Voice acting or cutscenes<br>- Multiple save slots<br>- Achievements (post-launch)<br>- Localization (English only) |
| **Development Scope** | [Your realistic timeline, resources, and constraints] | **Timeline:** 6 months (4 months dev + 2 months polish)<br>**Budget:** $5,000 (assets, tools, marketing)<br>**Team:** Solo developer + contract artist (20 hours)<br>**Work Schedule:** 20 hours/week (part-time)<br>**Tech Constraints:** Must run on 5-year-old hardware |

### **2. GAMEPLAY & SYSTEMS** *(What can the game do?)*

**PURPOSE:** Define all interactive elements and technical systems the game requires. This section directly feeds into technical implementation planning and AI coding task creation.

### **2.1 Gameplay Mechanics**

**GUIDANCE:** Primary mechanics are the core actions players perform most frequently. Secondary mechanics support the primary loop. Victory/failure conditions should be clear and testable to prevent endless polishing. Include control schemes and feedback for each mechanic.

**MECHANIC TYPE EXPLANATIONS:**
- **Primary Mechanics**: The main actions players perform most frequently (every few seconds). These define your game's core experience. Include specific inputs, validation rules, and player feedback.
- **Secondary Mechanics**: Supporting actions that enhance or modify primary mechanics. Camera controls, UI interactions, utility functions.
- **Victory/Failure Conditions**: Clear, testable conditions for winning and losing. Must be specific enough to implement and balance.

**FORMAT REQUIREMENTS:**
- List mechanics in order of implementation priority
- Include specific inputs and expected outputs for each mechanic
- Define edge cases, validation rules, and failure states
- Specify timing (how often players use each mechanic)

| Mechanic Type | Actions | EXAMPLE FORMAT (Replace with your mechanics) |
| --- | --- | --- |
| **Primary Mechanics** | [Main actions players perform frequently] | **1. Node Connection (Every 5-10 seconds)**<br>- Input: Click source → drag → release on target<br>- Validation: Distance check, budget check, crossing check<br>- Feedback: Line preview with cost display<br>- Constraints: Max 4 connections per node<br><br>**2. Resource Management (Constant)**<br>- Monitor: Energy budget (100-500 units)<br>- Spend: Connection costs (10-50 per link)<br>- Gain: Efficiency bonuses (+5 per optimization) |
| **Secondary Mechanics** | [Supporting actions that enhance primary mechanics] | **1. Camera Control**<br>- Pan: WASD or edge scrolling<br>- Zoom: Mouse wheel (3 levels)<br>- Reset: Spacebar (returns to default)<br><br>**2. Planning Mode**<br>- Toggle: Tab key<br>- Function: Preview connections without spending<br>- Visual: Ghost lines at 50% opacity |
| **Victory/Failure Conditions** | [Clear, testable win/lose states] | **Victory Conditions:**<br>- All zones powered (100% coverage)<br>- Efficiency target met (varies 60-85%)<br>- Under budget (specified per level)<br><br>**Failure States:**<br>- Budget exhausted with zones unpowered<br>- Cascade failure (>50% network down)<br>- Time limit exceeded (timed levels only) |

### **2.2 Systems & Features**

**GUIDANCE:** Systems are technical implementations (physics, AI, save system). Features are player-facing capabilities (inventory, skill trees, multiplayer). This distinction helps prioritize technical work vs user experience work. Be specific about technical requirements and dependencies.

**CATEGORY EXPLANATIONS:**
- **Core Systems**: Backend technical implementations that make the game function. Include algorithms, data structures, update rates, and technical specifications. Not directly visible to players but essential for functionality.
- **Core Features**: Player-facing capabilities and interfaces. These are what players directly interact with and see. Should be described from the player's perspective.

**FORMAT REQUIREMENTS:**
- Separate backend systems from frontend features for clear development priorities
- Note system interdependencies to plan implementation order
- Include specific technical requirements (algorithms, data structures, performance targets)
- Specify user-facing feature details (UI layout, user flows, visual feedback)

| System Category | Components | EXAMPLE FORMAT (Replace with your systems/features) |
| --- | --- | --- |
| **Core Systems** | [Essential backend technical implementations] | **Power Flow System**<br>- Algorithm: Dijkstra's for path finding<br>- Update rate: 10Hz (every 100ms)<br>- Data: Graph structure with weighted edges<br><br>**Save System**<br>- Format: JSON for debugging, binary for release<br>- Autosave: Every level completion<br>- Data tracked: Level states, best scores, unlocks<br><br>**Level Loading System**<br>- Format: ScriptableObjects for level data<br>- Async loading with progress bar<br>- Memory pool for node objects |
| **Core Features** | [Player-facing capabilities and interfaces] | **Level Selection**<br>- Grid-based chapter/level layout<br>- Visual progress tracking (stars, completion %)<br>- Lock/unlock system with prerequisites<br><br>**Statistics Tracking**<br>- Per-level: Time, efficiency, attempts<br>- Global: Total nodes, perfect clears, hours played<br>- Display: Post-level and summary screens<br><br>**Settings Menu**<br>- Graphics: Resolution, quality (3 presets)<br>- Audio: Master, Music, SFX sliders<br>- Gameplay: Colorblind mode, hint toggles |

### **2.3 Game Economy** *(If Applicable)*

**GUIDANCE:** Economy includes any resources players collect, spend, or manage - not just money. Include time, energy, materials, progression points, etc. Define clear sources and sinks to prevent resource inflation or starvation. Include balancing formulas where applicable.

**FIELD EXPLANATIONS:**
- **Resource Type**: Name and primary function of each resource in your game. Include currencies, materials, energy, time, progression points, etc.
- **Purpose**: What role this resource plays in gameplay. Is it a constraint, reward, progression gate, or player choice enabler?
- **Acquisition**: All the ways players can gain this resource. Be specific about amounts and frequencies.
- **Spending**: All the ways players use/lose this resource. Include costs and what players get in return.
- **Balance Formula**: Mathematical relationship that prevents inflation or starvation. Include target ratios and buffers.

**FORMAT REQUIREMENTS:**
- Show clear resource flow with input → output
- Include specific numbers for acquisition and spending rates
- Define min/max caps and regeneration/decay rates where applicable
- Provide balancing formulas to maintain healthy economy

| Resource Type | Purpose | Acquisition | Spending | EXAMPLE FORMAT (Replace with your resources) |
| --- | --- | --- | --- | --- |
| **[Your Resource 1]** | [Primary constraint/reward/etc.] | **Sources:**<br>- [Source 1]: [Amount/frequency]<br>- [Source 2]: [Amount/frequency]<br>- [Source 3]: [Amount/frequency] | **Sinks:**<br>- [Use 1]: [Cost and benefit]<br>- [Use 2]: [Cost and benefit]<br>- [Use 3]: [Cost and benefit] | Balance: [Your balancing formula]<br>([Reasoning for balance]) |
| **[Your Resource 2]** | [Unlock gates/progression/etc.] | **Earning:**<br>- [Condition 1]: [Reward]<br>- [Condition 2]: [Reward]<br>- [Condition 3]: [Reward] | **Spending:**<br>- [Purchase 1]: [Cost]<br>- [Purchase 2]: [Cost]<br>- [Purchase 3]: [Cost] | Progression: [Target percentage unlocks everything]<br>([Design philosophy]) |

### **3. PLAYER EXPERIENCE** *(How do players interact?)*

**PURPOSE:** Define the rhythm, pacing, and interaction patterns that create the intended player experience. This guides UI/UX design and technical responsiveness requirements.

### **3.1 Gameplay Loops**

**GUIDANCE:** Core loop (30-60 seconds) is the basic action cycle. Session loop (5-15 minutes) provides short-term goals. Progression loop provides long-term motivation. Each loop should offer meaningful completion and clear next steps. Include specific timing and player actions.

**FIELD EXPLANATIONS:**
- **Loop Type**: The three essential gameplay loops that drive player engagement at different time scales.
- **Duration**: How long each complete cycle takes. Core loops are seconds, session loops are minutes, progression loops are longer periods.
- **Activities**: Step-by-step breakdown of what the player does in each loop. Use action verbs and include timing for each step.
- **Emotional Arc**: The emotional journey players experience through each loop. This drives engagement and retention.

**FORMAT REQUIREMENTS:**
- Use verb-based descriptions for activities (Analyze, Plan, Execute, etc.)
- Include specific timing for each step within the loop
- Map emotional progression from start to finish of each loop
- Show how loops connect and reinforce each other

| Loop Type | Duration | Activities | EXAMPLE FORMAT (Replace with your loops) |
| --- | --- | --- | --- |
| **Core Loop** | [30-60 seconds] | **1. [Action]** ([time]): [What player does]<br>**2. [Action]** ([time]): [What player does]<br>**3. [Action]** ([time]): [What player does]<br>**4. [Action]** ([time]): [What player does]<br>**5. [Action]** ([time]): [What player does]<br>**Repeat [X] times per level** | [Emotion] → [Emotion] → [Emotion] → [Emotion] → [Emotion] → [Emotion] |
| **Session Loop** | [5-15 minutes] | **1. [Action]** ([time]): [What player does]<br>**2. [Action]** ([time]): [Multiple core loops]<br>**3. [Action]** ([time]): [What player does]<br>**4. [Action]** ([time]): [What player does]<br>**5. [Action]** ([time]): [What player does]<br>**Typical session: [X] levels** | [Emotion] → [Emotion] → [Emotion] → [Emotion] → [Emotion] |
| **Progression Loop** | [30+ minutes] | **1. [Action]** ([time]): [What player does]<br>**2. [Action]** ([time]): [What player does]<br>**3. [Action]** ([time]): [What player does]<br>**4. [Action]** ([time]): [What player does]<br>**5. [Action]** ([time]): [What player does]<br>**[X] chapters total = [Y] hours content** | [Emotion] → [Emotion] → [Emotion] → [Emotion] → [Emotion] |

### **3.2 Player Interaction**

**GUIDANCE:** Input methods should match platform capabilities and player expectations. Core feedback should be immediate and clear. Player choices should feel meaningful and impact gameplay in observable ways. Include response times and feedback layers.

**INTERACTION TYPE EXPLANATIONS:**
- **Input Methods**: Define exactly how players control your game on each platform. Include primary controls, alternative options, and accessibility features. Must specify response time requirements.
- **Core Feedback**: Describe how the game responds to player actions in layers - immediate (instant), short-term (quick response), and long-term (lasting effects). This creates satisfying interaction loops.
- **Player Choices**: List meaningful decisions available to players that affect gameplay. These should have observable consequences and multiple valid approaches.

**FORMAT REQUIREMENTS:**
- Specify input latency requirements (target <50ms for responsive feel)
- Layer feedback by timing (immediate/short-term/long-term)
- Include accessibility considerations for wider audience
- Define choice categories (strategic/tactical/expression)

| Interaction Type | Implementation | EXAMPLE FORMAT (Replace with your content) |
| --- | --- | --- |
| **Input Methods** | [Define how players control your game on each platform] | **PC Controls:**<br>- Mouse: Primary interaction (click, drag)<br>- Keyboard: Shortcuts (Tab=planning, R=restart, Space=center)<br>- Response time: <50ms input latency<br><br>**Mobile Controls:**<br>- Touch: Tap and drag for connections<br>- Pinch: Zoom in/out (0.5x to 2x)<br>- Two-finger: Pan camera<br>- Long press: Delete connection<br><br>**Accessibility:**<br>- One-handed mode available<br>- Colorblind safe palette<br>- Button remapping supported |
| **Core Feedback** | [How your game responds to player actions in layers] | **Immediate (0-100ms):**<br>- Hover: Node highlights, tooltip appears<br>- Click: Sound effect, visual pulse<br>- Drag: Line preview with live cost<br><br>**Short-term (100ms-1s):**<br>- Connection made: Particle burst<br>- Power flows: Animated current<br>- Buildings activate: Light up sequence<br><br>**Long-term (1s+):**<br>- Efficiency updates: Meter animation<br>- City growth: Buildings emerge<br>- Network stress: Warning indicators |
| **Player Choices** | [Meaningful decisions with observable consequences] | **Strategic Choices:**<br>- Efficiency vs Coverage (quality vs quantity)<br>- Direct vs Distributed (centralized vs mesh)<br>- Risk vs Reward (cheap unstable vs expensive reliable)<br><br>**Tactical Choices:**<br>- Connection order (affects remaining options)<br>- Node prioritization (residential vs industrial)<br>- Resource allocation (save for later vs spend now)<br><br>**Expression Choices:**<br>- Solution elegance (multiple valid approaches)<br>- Visual patterns (player signature styles)<br>- Speed vs Perfection (personal goals) |

### **3.3 Challenge & Learning**

**GUIDANCE:** Difficulty should ramp gradually, introducing one new concept at a time. Learning should happen through play, not tutorials. Failure should teach rather than frustrate, with clear feedback on how to improve. Include specific learning gates and skill requirements.

**FIELD EXPLANATIONS:**
- **Difficulty Progression**: How challenge increases over time. Map specific skills to level ranges and define scaling factors (complexity, constraints, time pressure, etc.).
- **Learning Approach**: How players discover and master game systems without explicit tutorials. Include teaching methods and indicators of player mastery.
- **Failure Handling**: How the game responds when players fail. Include recovery mechanisms and constructive feedback to turn failure into learning.

**FORMAT REQUIREMENTS:**
- Map specific skills to level ranges with clear progression
- Define mastery indicators that show player understanding
- Include hint/assist systems that don't undermine challenge
- Provide specific examples of failure feedback

| Aspect | Approach | EXAMPLE FORMAT (Replace with your learning design) |
| --- | --- | --- |
| **Difficulty Progression** | [How your game's challenge scales over time] | **Skill Introduction Curve:**<br>Level [X-Y]: [Skill focus] ([learning goal])<br>Level [X-Y]: [Skill focus] ([learning goal])<br>Level [X-Y]: [Skill focus] ([learning goal])<br>Level [X-Y]: [Skill focus] ([learning goal])<br>Level [X-Y]: [Skill focus] ([learning goal])<br>Level [X-Y]: [Skill focus] ([proving mastery])<br><br>**Scaling Factors:**<br>- [Factor 1]: [Start value]→[End value] ([progression type])<br>- [Factor 2]: [Start value]→[End value] ([progression type])<br>- [Factor 3]: [Start value]→[End value] ([progression type]) |
| **Learning Approach** | [How players discover your game systems] | **Teaching Methods:**<br>- **[Method 1]:** [How it works]<br>- **[Method 2]:** [How it works]<br>- **[Method 3]:** [How it works]<br>- **[Method 4]:** [How it works]<br><br>**Learning Indicators:**<br>- [Indicator 1] ([what it shows])<br>- [Indicator 2] ([what it shows])<br>- [Indicator 3] ([what it shows])<br>- [Indicator 4] ([what it shows]) |
| **Failure Handling** | [How your game handles player failure] | **Failure Mitigation:**<br>- **[Method 1]:** [How it helps]<br>- **[Method 2]:** [How it helps]<br>- **[Method 3]:** [How it helps]<br>- **[Method 4]:** [How it helps]<br><br>**Failure Feedback:**<br>- Specific: "[Example specific feedback]"<br>- Constructive: "[Example helpful suggestion]"<br>- Visual: [How problems are highlighted]<br>- Encouraging: "[Example positive message]" |

### **4. STORY & CONTENT** *(What exists in the game?)*

**PURPOSE:** Define all content that needs to be created, from story elements to level design. Helps scope the content creation pipeline and identify what can be procedural vs hand-crafted.

### **4.1 Narrative Structure**

**GUIDANCE:** Choose a narrative approach that matches your writing skills and time constraints. Simple premises often work better than complex plots for solo development. Consider how story integrates with gameplay rather than interrupting it. Include delivery methods and production requirements.

**FIELD EXPLANATIONS:**
- **Core Story**: Your game's main plot, setting, and premise. Include the central conflict, story arc from beginning to end, and key themes. Keep it simple and focused.
- **Character Roles**: Key characters and their functions in your story. Define their role in gameplay, personality, and how they deliver information to the player.
- **Narrative Delivery**: How story information reaches the player. Focus on methods that integrate with gameplay rather than interrupt it.

**FORMAT REQUIREMENTS:**
- Keep individual story beats under 100 words each
- Integrate story with gameplay mechanics (no separate cutscenes)
- Use environmental storytelling where possible
- Define production requirements (writing workload, asset needs)

| Element | Implementation | EXAMPLE FORMAT (Replace with your story) |
| --- | --- | --- |
| **Core Story** | [Your main plot, setting, and premise] | **Premise:** [Your game's setting and central conflict]<br><br>**Setup:** [Who the player is and their initial situation]<br><br>**Arc:** [Beginning] → [Middle] → [End progression]<br><br>**Themes:** [2-3 central themes that connect to gameplay] |
| **Character Roles** | [Your key characters and their narrative functions] | **[Character 1] ([Role]):** [Their function]<br><br>**[Character 2] ([Role]):** [Their function and details]<br>- Delivery: [How they communicate]<br>- Personality: [Key traits]<br>- Purpose: [Gameplay/story function]<br><br>**[Character 3]:** [Environmental/background characters]<br>- Show through: [How they're represented]<br>- No direct interaction |
| **Narrative Delivery** | [How your story reaches the player] | **Methods:**<br>- **[Method 1]:** [How it works and examples]<br>- **[Method 2]:** [How it works and examples]<br>- **[Method 3]:** [How it works and examples]<br>- **[Method 4]:** [How it works and examples]<br>- **[Method 5]:** [How it works and examples]<br><br>**Production Constraints:** [What you won't include] |

### **4.2 Content Categories**

**GUIDANCE:** Identify all content types that need creation. Consider which can be procedurally generated vs hand-crafted. Hand-crafted content is higher quality but takes more time. Balance based on what's most important for your game experience. Include specific quantities and variations.

**FIELD EXPLANATIONS:**
- **Gameplay Content**: Levels, challenges, encounters, and interactive elements. Define the core playable content and how much you need to create.
- **Story Content**: Dialogue, text, story beats, and narrative elements. Quantify writing requirements and production workload.
- **World Content**: Environments, art assets, visual effects, and world-building elements. List all visual and audio assets needed.

**FORMAT REQUIREMENTS:**
- List exact quantities needed for each content type
- Note reusability potential and modular design opportunities
- Identify production bottlenecks and time-intensive content
- Balance hand-crafted quality vs. procedural efficiency

| Content Type | Specifications | EXAMPLE FORMAT (Replace with your content needs) |
| --- | --- | --- |
| **Gameplay Content** | [Your levels, challenges, interactive elements] | **[Content Category 1]:** [X] hand-crafted<br>- [Subcategory]: [X] pieces ([purpose])<br>- [Subcategory]: [X] pieces ([purpose])<br>- [Subcategory]: [X] pieces ([purpose])<br><br>**[Content Category 2]:** [X] variations<br>- [Type 1]: [X] pieces ([specific focus])<br>- [Type 2]: [X] pieces ([specific focus])<br><br>**[Supporting Elements]:**<br>- [Element type]: [X] unique variations<br>- [Element type]: [X] types ([list specific types])<br>- [Element type]: [X] themes ([list themes]) |
| **Story Content** | [Your narrative and text requirements] | **Text Content:**<br>- [Content type]: [X] × [Y] words = [Total] words<br>- [Content type]: [X] unique pieces<br>- [Content type]: [X] words<br>- Total writing: ~[X] words<br><br>**Story Beats:**<br>- [Beat type]: [X] ([when they occur])<br>- [Beat type]: [X] × [Y] words<br>- [Beat type]: [X] visual scenes |
| **World Content** | [Your visual and environmental assets] | **[Asset Category 1]:**<br>- [Asset type]: [X] models ([list specific types])<br>- [Asset type]: [X] variations ([organization method])<br>- [Asset type]: [X] sprites/models ([purpose])<br>- [Asset type]: [X] pieces ([variation method])<br><br>**[Asset Category 2]:**<br>- [Effect type]: [X] effects ([list specific effects])<br>- [Technical type]: [X] ([list types])<br>- [Processing type]: [X] profiles ([list profiles]) |

### **4.3 Content Scope**

**GUIDANCE:** Be realistic about asset creation time. Each piece of content (level, character, environment) takes longer than expected. Plan for 20-30% fewer assets than you initially think you can create. Include production time estimates.

**FIELD EXPLANATIONS:**
- **World Scale**: Define the size and boundaries of your game world. Include technical constraints and scope limits that keep development manageable.
- **Content Boundaries**: Explicit list of content you will NOT create. This prevents scope creep and manages expectations during development.

**FORMAT REQUIREMENTS:**
- Include realistic time estimates per asset type (add 20% buffer)
- Account for iteration and polish time in estimates
- Define minimum viable content vs. ideal content
- List specific technical and creative limitations

| Scope Element | Definition | EXAMPLE FORMAT (Replace with your scope limits) |
| --- | --- | --- |
| **World Scale** | [Your game world size, boundaries, and constraints] | **Playable Space:**<br>- [Dimension/size]: [Specific measurements/limits]<br>- [View options]: [X] levels ([describe each])<br>- Total unique [units]: [X] ([organization method])<br><br>**Scope Limits:**<br>- No [limitation 1]<br>- No [limitation 2]<br>- [Fixed constraint]<br><br>**Production Time:**<br>- Per [asset type]: [X] hours<br>- Per [asset type]: [X] hours<br>- Per [asset type]: [X] hours<br>- Total: [X] hours for all [content] |
| **Content Boundaries** | [Your explicit list of content NOT included] | **NOT Creating:**<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([reason/alternative])<br>- [Content type] ([timing/scope reason])<br>- [Content type] ([alternative approach]) |

### **5. TECHNICAL REQUIREMENTS** *(How do we build this?)*

**PURPOSE:** Define all technical specifications needed for development. This section directly informs tool choices, AI coding prompts, and technical task planning.

### **5.1 Platform & Performance**

**GUIDANCE:** Choose platforms based on target audience and technical capabilities. Performance targets should be achievable with your technical skills. Consider platform-specific constraints (mobile battery, web file size limits, etc.). Include specific hardware targets and optimization strategies.

**FIELD EXPLANATIONS:**
- **Target Platforms**: Primary and secondary platforms with specific technical requirements. Include distribution channels, minimum specs, and input requirements.
- **Performance Targets**: Measurable performance goals for frame rate, loading times, and build sizes. Must be achievable on minimum specifications.
- **Platform Constraints**: Specific limitations and optimization strategies for each platform. Include memory limits, battery life, cross-platform considerations.

**FORMAT REQUIREMENTS:**
- List specific device models and minimum specifications
- Include measurable performance metrics (FPS, loading times, file sizes)
- Define acceptable quality settings and fallback options
- Plan for optimization strategies and technical constraints

| Platform | Requirements | EXAMPLE FORMAT (Replace with your platform targets) |
| --- | --- | --- |
| **Target Platforms** | [Your primary and secondary platforms with technical specs] | **Primary: [Platform] ([OS versions])**<br>- Distribution: [Channels]<br>- Min spec: [CPU], [RAM], [GPU]<br>- Recommended: [CPU], [RAM], [GPU]<br>- Input: [Required input methods]<br><br>**Secondary: [Platform] ([OS versions])**<br>- [Platform]: [Device requirements]<br>- [Platform]: [Memory requirements]<br>- Screen: [Size range] supported<br>- Input: [Touch/controller optimizations] |
| **Performance Targets** | [Your measurable performance goals] | **Frame Rate Targets:**<br>- [Platform]: [Target FPS] (minimum [FPS])<br>- [Platform]: [Target FPS] ([stability requirement])<br>- [Platform]: [Target FPS] ([fallback options])<br><br>**Loading Times:**<br>- [Load type]: <[X] seconds<br>- [Load type]: <[X] seconds<br>- [Load type]: <[X] seconds<br><br>**Build Size:**<br>- [Platform]: <[X]MB installed<br>- [Platform]: <[X]MB download<br>- [Platform]: <[X]MB initial load |
| **Platform Constraints** | [Your specific limitations and optimization strategies] | **Memory Limits:**<br>- [Platform]: [X]MB max RAM usage<br>- [Resource type]: [X]MB budget<br>- [Resource type]: [X]MB budget<br><br>**[Platform] Optimization:**<br>- [Optimization 1]: [Target/strategy]<br>- [Optimization 2]: [Target/strategy]<br>- [Optimization 3]: [Target/strategy]<br><br>**Cross-Platform Features:**<br>- [Feature]: [Implementation method]<br>- [Feature]: [Format/compatibility]<br>- [Feature]: [Backwards compatibility plan] |

### **5.2 Technology Stack**

**GUIDANCE:** Choose tools you know or can learn quickly. Avoid changing engines mid-project. External libraries should solve specific problems and be well-documented. Data storage format affects save/load complexity. Include version numbers and licensing considerations.

**FIELD EXPLANATIONS:**
- **Engine & Tools**: Core development engine, IDE, version control, and production tools. Include specific versions and licensing costs.
- **External Libraries**: Third-party code libraries, asset store purchases, and external services. List specific solutions for specific problems.
- **Data Storage**: Save system format, file organization, and data migration strategies. Consider debugging vs. release requirements.

**FORMAT REQUIREMENTS:**
- Specify exact versions for reproducible builds
- Note all licensing costs and budget impact
- Include backup alternatives for critical tools
- Plan for version migration and compatibility

| Category | Tools & Libraries | EXAMPLE FORMAT (Replace with your technology choices) |
| --- | --- | --- |
| **Engine & Tools** | [Your core development stack] | **Engine: [Engine Name] [Version]**<br>- Version: [Specific version] ([stability reason])<br>- Render: [Rendering pipeline]<br>- License: [License type] ([cost/limitation])<br><br>**Development Tools:**<br>- IDE: [Name] ([cost])<br>- Version Control: [System] + [Service] ([cost])<br>- Task Tracking: [Tool] ([tier/cost])<br>- Art: [Tool] ([cost]) + [Tool] ([cost])<br>- Audio: [Tool] ([cost]) |
| **External Libraries** | [Your third-party solutions and their costs] | **Code Libraries:**<br>- [Library]: [Purpose] ([cost])<br>- [Library]: [Purpose] ([included/free])<br>- [Library]: [Purpose] ([cost])<br><br>**Asset Store:**<br>- [Asset]: [Cost]<br>- [Asset]: [Cost]<br>- [Asset]: [Cost]<br><br>**Services:**<br>- [Service]: [Purpose] ([cost/tier])<br>- [Service]: [Purpose] ([cost])<br>- [Service]: [Purpose] ([optional cost]) |
| **Data Storage** | [Your save system design and organization] | **Save System:**<br>- Format: [Format] ([debug]) → [Format] ([release])<br>- Location: [Storage location/method]<br>- Structure: [Organization strategy]<br><br>**Data Organization:**<br>```<br>[Your file structure]<br>[Folder/]<br>├── [file1]<br>├── [file2]<br>├── [file3]<br>└── [file4]<br>```<br><br>**Version Migration:**<br>- [Migration strategy 1]<br>- [Migration strategy 2]<br>- [Fallback strategy] |

### **6. DEVELOPMENT PLANNING** *(How do we ship this?)*

**PURPOSE:** Transform the game vision into executable development plan. Provides roadmap for AI-assisted development and prevents endless polishing by defining clear completion criteria.

### **6.1 Scope Management**

**GUIDANCE:** Use MoSCoW prioritization (Must/Should/Could/Won't have). Must-haves create minimum viable product. Won't-haves prevent scope creep. Focus on shipping a complete experience rather than perfect features. Include specific feature lists with time estimates.

**PRIORITY LEVEL EXPLANATIONS:**
- **Must-Have**: Features absolutely required for the game to function and ship. Without these, the game is not playable or sellable. This is your Minimum Viable Product (MVP).
- **Should-Have**: Important features that significantly enhance the experience but aren't required for launch. Add these if time permits within scope.
- **Could-Have**: Nice-to-have features that would be good additions but don't affect core experience. Only add if ahead of schedule.
- **Won't-Have**: Features explicitly cut to prevent scope creep. Document these to avoid adding them back during development.

**FORMAT REQUIREMENTS:**
- Order by implementation dependency
- Include effort estimates (hours) - be realistic and add 20% buffer
- Mark technical prerequisites
- Group related features together

| Priority Level | Features | EXAMPLE FORMAT (Replace with your features) |
| --- | --- | --- |
| **Must-Have** | [Core features required to ship] | **Core Gameplay (140 hours)**<br>- Node connection system (40h)<br>- Power flow calculation (20h)<br>- 25 campaign levels (50h)<br>- Save/load system (10h)<br>- Basic UI/menus (20h)<br><br>**Polish (40 hours)**<br>- Sound effects (10h)<br>- Visual feedback (15h)<br>- Tutorial levels (10h)<br>- Bug fixing (5h) |
| **Should-Have** | [Important enhancements] | **Enhanced Experience (60 hours)**<br>- Level selection map (10h)<br>- Statistics tracking (10h)<br>- Settings menu (10h)<br>- 3-star rating system (10h)<br>- Particle effects (10h)<br>- Background music (10h) |
| **Could-Have** | [Nice additions if time allows] | **Nice Additions (40 hours)**<br>- Challenge levels (15h)<br>- Achievements (10h)<br>- Leaderboards (10h)<br>- Colorblind mode (5h)<br>- Additional themes (20h)<br>- Hint system (10h) |
| **Won't-Have** | [Explicitly excluded to prevent scope creep] | **Explicitly Excluded**<br>- Level editor (future DLC)<br>- Multiplayer (too complex)<br>- Procedural generation (design choice)<br>- Voice acting (budget)<br>- Cutscenes (scope)<br>- Multiple save slots (unnecessary)<br>- Steam Workshop (post-launch)<br>- Mobile launch (6 months later) |

### **6.2 Validation Approach**

**GUIDANCE:** Define specific, testable criteria for each milestone and overall success. This prevents endless polishing and provides clear gates for moving to the next phase. Include both technical validation (does it work?) and experience validation (is it fun?). Add specific test cases and metrics.

**FIELD EXPLANATIONS:**
- **Milestone Validation**: Specific criteria for Alpha, Beta, and Gold milestones. Include technical functionality, bug counts, performance targets, and user feedback requirements.
- **Success Criteria**: Overall success metrics for technical performance, gameplay engagement, and commercial viability. Must be measurable and achievable.

**FORMAT REQUIREMENTS:**
- Include quantifiable metrics for all validation criteria
- Define specific test procedures and acceptance thresholds
- Set achievable ranges based on realistic expectations
- Balance technical metrics with user experience indicators

| Validation Type | Method | EXAMPLE FORMAT (Replace with your validation criteria) |
| --- | --- | --- |
| **Milestone Validation** | [How you'll know each milestone is complete] | **[Milestone 1] ([Timeline]):**<br>- [Criteria 1]: [Specific measurable requirement]<br>- [Criteria 2]: [Specific measurable requirement]<br>- [Criteria 3]: [Specific measurable requirement]<br>- [User feedback]: "[Target feedback quality]"<br><br>**[Milestone 2] ([Timeline]):**<br>- [Criteria 1]: [Specific measurable requirement]<br>- [Criteria 2]: [Specific measurable requirement]<br>- [Criteria 3]: [Specific measurable requirement]<br>- [User feedback]: "[Target feedback quality]"<br><br>**[Final Milestone] ([Timeline]):**<br>- [Criteria 1]: [Zero tolerance requirement]<br>- [Criteria 2]: [Completion requirement]<br>- [Criteria 3]: [Quality requirement]<br>- [Market readiness]: [Launch readiness criteria] |
| **Success Criteria** | [What defines your working, shippable game] | **Technical Success:**<br>- [Metric 1]: <[X]% of [measurement]<br>- [Metric 2]: <[X] seconds<br>- [Metric 3]: [X]% [reliability target]<br>- [Metric 4]: [X]+ FPS on [specification]<br><br>**Gameplay Success:**<br>- [Engagement metric]: >[X]% of players<br>- [Retention metric]: >[X]% reach [milestone]<br>- [Session metric]: [X]+ minutes average<br>- [Behavior metric]: >[X]% [positive behavior]<br><br>**Commercial Success:**<br>- [Quality metric]: >[X]% positive<br>- [Business metric]: <[X]% [negative outcome]<br>- [Sales metric]: [X]+ units in [timeframe]<br>- [Financial metric]: Break even within [timeframe] |

## 📝 GDD COMPLETION CHECKLIST:

Before considering the GDD complete, verify:

**Content Completeness:**
- ✓ All sections have specific examples
- ✓ No placeholders or "TBD" entries
- ✓ Quantities specified for all content
- ✓ Technical specs include version numbers
- ✓ Time estimates provided for all features

**Implementation Readiness:**
- ✓ AI can code features from descriptions
- ✓ Artists can create assets from specifications
- ✓ Testers can validate against criteria
- ✓ Scope is realistic for timeline
- ✓ Dependencies are clearly mapped

**Quality Checks:**
- ✓ Design pillars reflected throughout
- ✓ No feature contradictions
- ✓ Platform constraints respected
- ✓ Performance targets achievable
- ✓ Won't-have list is comprehensive

## 🎮 INPUT GAME IDEA:

[PASTE YOUR GAME IDEA HERE]

**Additional Context (Optional):**
- Development Timeline: [X months]
- Budget Constraints: [$X]
- Team Size: [Solo/Small team]
- Target Audience: [Casual/Core/Specific]
- Platform Priority: [PC/Mobile/Console]

Generate a complete GDD with all sections filled using tables, specific examples, and clear formatting as shown above.