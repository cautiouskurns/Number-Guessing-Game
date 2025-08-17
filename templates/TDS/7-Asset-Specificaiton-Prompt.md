## 7. **ASSET SPECIFICATIONS PROMPT**

# **AI PROMPT: ASSET SPECIFICATIONS GENERATOR**

```
You are an expert technical artist and asset pipeline specialist with extensive experience in game development asset creation, optimization, and cross-platform deployment. Your task is to create Section 7 (Asset Specifications) of a Technical Design Specification by analyzing the Game Design Document and previous technical sections to generate comprehensive asset creation guidelines that serve the game's visual style, technical requirements, and platform deployment needs.

## 📋 INSTRUCTIONS:
1. **Analyze visual style and aesthetic requirements** from GDD art direction and aesthetic goals
2. **Extract technical asset requirements** from previous sections covering rendering, platform constraints, and performance targets
3. **Create comprehensive asset specifications** covering visual, audio, and UI assets with detailed technical requirements
4. **Design asset organization systems** that support efficient content creation workflows and cross-platform deployment
5. **Establish naming conventions and metadata systems** that facilitate asset management and automated processing
6. **Include cross-platform optimization strategies** for asset formats, compression, and memory management
7. **Integrate accessibility requirements** across all asset categories to support inclusive design goals

## 🎯 OUTPUT FORMAT:

### **7. ASSET SPECIFICATIONS** *(Content Creation Guidelines)*

#### **7.1 Visual Assets**

**Visual Asset Architecture Philosophy:**
The visual asset specifications for "[Game Title]" prioritize **[primary visual goal]** and **[secondary visual goal]** while supporting **[core experience goal]** and **[platform deployment goal]**. The specifications emphasize **[key visual emphasis 1]** and **[key visual emphasis 2]** over [deprioritized visual aspect], ensuring **[visual consistency goal]** across all visual content.

##### **7.1.1 2D Sprite Specifications**

**2D Asset Design Rationale:**
The [art style description] requires **[precise specification requirement]** that maintain **[visual clarity goal]** while supporting **[visual system goal]** and **[cross-platform compatibility goal]**. Sprite specifications must preserve **[art style authenticity requirement]** while enabling **[system flexibility goal]** and **[memory efficiency goal]** across diverse hardware capabilities.

**[Game-Specific] Sprite Categories and Specifications:**

| Sprite Category | Resolution Specifications | Atlas Organization | Naming Convention | [Game System] Purpose |
|-----------------|-------------------------|-------------------|------------------|----------------------|
| **[SpriteCategory1]** | [Resolution range and PPU] | [Atlas organization strategy] | [Naming convention pattern] | [How this serves game design goals] |
| **[SpriteCategory2]** | [Resolution range and PPU] | [Atlas organization strategy] | [Naming convention pattern] | [How this supports game systems] |
| **[SpriteCategory3]** | [Resolution range and PPU] | [Atlas organization strategy] | [Naming convention pattern] | [How this enhances player experience] |
| **[SpriteCategory4]** | [Resolution range and PPU] | [Atlas organization strategy] | [Naming convention pattern] | [How this serves technical requirements] |
| **[SpriteCategory5]** | [Resolution range and PPU] | [Atlas organization strategy] | [Naming convention pattern] | [How this supports accessibility goals] |

**[Game-Specific] Sprite Technical Specifications:**

**Design Rationale:**
[Game-specific content] requires **[consistent sprite presentation requirement]** that maintains **[visual clarity goal]** while supporting **[system variation requirement]** and **[cross-platform performance requirement]**. Technical specifications must balance **[visual quality goal]** with **[memory efficiency goal]** and **[system flexibility goal]**.

```csharp
public class [GameSpecific]SpriteSpecification
{
    [Header("[Game System] Sprite Technical Requirements")]
    public int pixelsPerUnit = [value];                          // [Scaling rationale]
    public FilterMode [gameSystem]SpriteFilterMode = FilterMode.[FilterType];  // [Filtering rationale]
    public TextureFormat [gameSystem]TextureFormat = TextureFormat.[Format]; // [Format rationale]
    public bool enable[GameSystem]Mipmaps = [boolean];        // [Mipmap decision rationale]

    [Header("[Game System] Atlas Configuration")]
    public int max[GameSystem]AtlasSize = [size];           // [Atlas size rationale]
    public int [gameSystem]AtlasPadding = [padding];              // [Padding rationale]
    public bool enable[GameSystem]AtlasCompression = [boolean]; // [Compression rationale]
    public AtlasPackingMode [gameSystem]PackingMode = AtlasPackingMode.[Mode]; // [Packing rationale]

    [Header("[Game System] Animation Specifications")]
    public int [gameSystem]AnimationFrameRate = [framerate];       // [Frame rate rationale]
    public bool enable[GameSystem]AnimationLooping = [boolean]; // [Looping rationale]
    public float [gameSystem]AnimationTransitionTime = [time]f; // [Transition rationale]

    public struct [GameSystem]SpriteMetadata
    {
        public string [gameSystem]SpriteName;
        public [SpriteCategory] category;
        public [IdentifierType] associated[GameContext];
        public [SystemType] associated[SystemContext];
        public bool supports[SystemVariation];
        public [InteractionType] interactionType;

        public bool Validate[GameSystem]SpriteCompliance();
        public [SpriteVariant][] Generate[SystemVariants]();
        public float Calculate[GameSystem]MemoryFootprint();
    }
}

```

**[Game-Specific] Sprite Atlas Organization Strategy:**

**Design Rationale:**
[Game-specific content] benefits from **[organized atlas structure requirement]** that supports **[efficient asset loading goal]**, **[system variation management goal]**, and **[cross-platform memory optimization goal]**. Atlas organization must facilitate **[content iteration workflow goal]** while maintaining **[runtime performance efficiency goal]**.

| Atlas Category | Atlas Size Target | Content Organization | Loading Strategy | Memory Management |
| --- | --- | --- | --- | --- |
| **[AtlasCategory1]** | [Size target and rationale] | [Content organization approach] | [Loading strategy and timing] | [Memory management approach] |
| **[AtlasCategory2]** | [Size target and rationale] | [Content organization approach] | [Loading strategy and timing] | [Memory management approach] |
| **[AtlasCategory3]** | [Size target and rationale] | [Content organization approach] | [Loading strategy and timing] | [Memory management approach] |
| **[AtlasCategory4]** | [Size target and rationale] | [Content organization approach] | [Loading strategy and timing] | [Memory management approach] |

**[Game-Specific] Sprite Naming Convention System:**

**Design Rationale:**
Consistent [game-specific] sprite naming enables **[efficient asset organization goal]**, **[automated content processing goal]**, and **[clear asset identification goal]** for [development context] workflow. Naming conventions must support **[system categorization goal]** and **[variation management goal]**.

```
[Game-Specific] Sprite Naming Pattern:
[PREFIX]_[CATEGORY]_[TYPE]_[STATE]_[CONTEXT]_[VARIANT]

Examples:
[PREFIX]_[CAT]_[Type]_[State]_[Context]_[Variant]     // [Example description and purpose]
[PREFIX]_[CAT]_[Type]_[State]_[Context]_[Variant]  // [Example description and purpose]
[PREFIX]_[CAT]_[Type]_[State]_[Context]_[Variant]       // [Example description and purpose]
[PREFIX]_[CAT]_[Type]_[State]_[Context]_[Variant]   // [Example description and purpose]
[PREFIX]_[CAT]_[Type]_[State]_[Context]_[Variant]   // [Example description and purpose]

```

### **7.1.2 3D Model Specifications** *(If Applicable)*

**3D Asset Design Rationale:**
[If 3D assets are used] While "[Game Title]" primarily uses [primary art approach], limited 3D assets may be used for **[3D asset purpose 1]**, **[3D asset purpose 2]**, and **[3D asset purpose 3]**. 3D specifications focus on **[3D approach description]** that supports **[game system goal]** without compromising **[art style integrity goal]**.

**Limited 3D [Game-Specific] Asset Specifications:**

| 3D Asset Category | Polycount Budget | LOD Requirements | Texture Specifications | [Game System] Application |
| --- | --- | --- | --- | --- |
| **[3DCategory1]** | [Polycount range] | [LOD approach] | [Texture specifications] | [Application purpose and rationale] |
| **[3DCategory2]** | [Polycount range] | [LOD approach] | [Texture specifications] | [Application purpose and rationale] |
| **[3DCategory3]** | [Polycount range] | [LOD approach] | [Texture specifications] | [Application purpose and rationale] |

### **7.2 Audio Assets**

**Audio Asset Architecture Philosophy:**
The audio asset specifications prioritize **[primary audio goal]** and **[secondary audio goal]** while supporting **[cross-platform audio deployment goal]** and **[accessible audio design goal]**. The specifications emphasize **[audio emphasis 1]** and **[audio emphasis 2]** over [deprioritized audio approach], ensuring **[audio consistency goal]** through consistent audio presentation.

### **7.2.1 [Game-Specific] Audio Format Specifications**

**Audio Format Design Rationale:**
[Game-specific audio requirements] require **[high-quality audio requirement]** that maintains **[audio quality goal]** while supporting **[efficient audio streaming goal]** and **[cross-platform compatibility goal]**. Audio format specifications must balance **[audio quality goal]** with **[memory efficiency goal]** and **[audio experience goal]** requirements.

**[Game-Specific] Audio Category Specifications:**

| Audio Category | Format Specification | Compression Settings | Quality Requirements | [Game System] Purpose |
| --- | --- | --- | --- | --- |
| **[AudioCategory1]** | [Format and technical specs] | [Compression approach and settings] | [Quality requirements and rationale] | [How this serves game design goals] |
| **[AudioCategory2]** | [Format and technical specs] | [Compression approach and settings] | [Quality requirements and rationale] | [How this supports game systems] |
| **[AudioCategory3]** | [Format and technical specs] | [Compression approach and settings] | [Quality requirements and rationale] | [How this enhances player experience] |
| **[AudioCategory4]** | [Format and technical specs] | [Compression approach and settings] | [Quality requirements and rationale] | [How this serves technical requirements] |
| **[AudioCategory5]** | [Format and technical specs] | [Compression approach and settings] | [Quality requirements and rationale] | [How this supports accessibility goals] |

**[Game-Specific] Audio Technical Specifications:**

```csharp
public class [GameSpecific]AudioSpecification
{
    [Header("[Game System] Audio Technical Requirements")]
    public int [gameSystem]AudioSampleRate = [samplerate];       // [Sample rate rationale]
    public int [gameSystem]AudioBitDepth = [bitdepth];            // [Bit depth rationale]
    public AudioCompressionFormat [gameSystem]CompressionFormat = AudioCompressionFormat.[Format]; // [Compression rationale]
    public float [gameSystem]AudioQuality = [quality]f;         // [Quality rationale]

    [Header("[Game System] Audio Performance")]
    public int max[GameSystem]AudioSources = [number];          // [Audio source limit rationale]
    public float [gameSystem]AudioCullingDistance = [distance]f; // [Culling rationale]
    public bool enable[GameSystem]AudioCompression = [boolean]; // [Compression rationale]
    public bool enable[GameSystem]AudioStreaming = [boolean];   // [Streaming rationale]

    [Header("[Game System] Audio Accessibility")]
    public bool enable[GameSystem]AudioSubtitles = [boolean];   // [Subtitle rationale]
    public bool enable[GameSystem]AudioVisualization = [boolean]; // [Visualization rationale]
    public float [gameSystem]AudioDynamicRangeCompression = [value]f; // [Dynamic range rationale]

    public struct [GameSystem]AudioMetadata
    {
        public string [gameSystem]AudioName;
        public [AudioCategory] category;
        public [IdentifierType] associated[GameContext];
        public [SystemType] associated[SystemContext];
        public bool supports[GameSystem]Spatialization;
        public [TriggerType] triggerType;

        public bool Validate[GameSystem]AudioCompliance();
        public [AudioVariant][] Generate[SystemVariants]();
        public float Calculate[GameSystem]AudioMemoryFootprint();
    }
}

```

### **7.2.2 [Game-Specific] Audio Organization and Spatial Setup**

**[Game-Specific] Audio Organization Rationale:**
[Game-specific audio requirements] require **[systematic audio organization requirement]** that supports **[audio progression goal]**, **[audio transitions goal]**, and **[efficient audio asset management goal]**. Organization must facilitate **[content iteration workflow goal]** while maintaining **[audio consistency goal]** and **[audio coherence goal]**.

**[Game-Specific] Audio File Organization Structure:**

```
Assets/Audio/[GameSpecific]/
├── [AudioCategory1]/
│   ├── [AudioSubcategory1]/
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   ├── [AudioSubcategory2]/
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   └── [AudioSubcategory3]/
│       ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│       └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
├── [AudioCategory2]/
│   ├── [AudioSubcategory4]/
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   │   └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│   └── [AudioSubcategory5]/
│       ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
│       └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
└── [AudioCategory3]/
    ├── [AudioSubcategory6]/
    │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
    │   ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
    │   └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
    └── [AudioSubcategory7]/
        ├── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav
        └── [PREFIX]_[CAT]_[Type]_[Context]_[Variant].wav

```

**[Game-Specific] Spatial Audio Configuration:**

**Design Rationale:**
[Game-specific audio requirements] benefit from **[spatial audio capability]** that enhances **[audio goal 1]**, **[audio goal 2]**, and **[audio goal 3]**. Spatial audio configuration must support **[gameplay goal]** while maintaining **[audio clarity goal]** and **[cross-platform compatibility goal]**.

```csharp
public class [GameSpecific]SpatialAudioConfiguration
{
    [Header("[Game System] Spatial Audio Settings")]
    public float [gameSystem]AudioSpatializationRange = [range]f;    // [Spatialization range rationale]
    public AnimationCurve [gameSystem]AudioFalloffCurve;          // [Falloff curve rationale]
    public bool enable[GameSystem]AudioOcclusion = [boolean];          // [Occlusion rationale]
    public bool enable[GameSystem]AudioReflection = [boolean];         // [Reflection rationale]

    [Header("[Game System] Audio Zones")]
    public [GameSystem]AudioZone[] [gameSystem]AudioZones;       // [Audio zone rationale]
    public float [gameSystem]ZoneTransitionTime = [time]f;           // [Zone transition rationale]
    public bool enable[GameSystem]ZoneBlending = [boolean];            // [Zone blending rationale]

    [Header("[Game System] Audio Accessibility")]
    public bool enable[GameSystem]AudioVisualization = [boolean];      // [Visualization rationale]
    public bool enable[GameSystem]AudioDescription = [boolean];        // [Description rationale]
    public float [gameSystem]AudioContrastEnhancement = [value]f;     // [Contrast rationale]

    public struct [GameSystem]AudioZone
    {
        public string [gameSystem]ZoneName;
        public [AcousticProperties] acousticProperties;
        public [ReverbConfiguration] reverbConfiguration;
        public Vector3 [gameSystem]ZoneBounds;
        public [SystemType] associated[SystemContext];

        public bool ContainsPosition(Vector3 position);
        public [AcousticProperties] GetAcousticPropertiesForPosition(Vector3 position);
        public float Calculate[GameSystem]ReverbIntensity(Vector3 listenerPosition, Vector3 sourcePosition);
    }
}

```

### **7.3 UI Assets**

**UI Asset Architecture Philosophy:**
The UI asset specifications prioritize **[ui goal 1]** and **[ui goal 2]** while supporting **[cross-platform accessibility goal]** and **[ui philosophy goal]**. The specifications emphasize **[ui emphasis 1]** that blend with **[ui integration goal]** rather than competing for visual attention, ensuring **[ui experience goal]** through subtle interface design.

### **7.3.1 [Game-Specific] UI Design Specifications**

**[Game-Specific] UI Design Rationale:**
The [ui approach description] requires **[ui assets requirement]** with **[ui presentation goal]** while providing **[essential ui information goal]** and **[accessibility compliance goal]**. UI specifications must support **[gameplay pacing goal]** while maintaining **[ui immersion goal]** and **[cross-platform usability goal]**.

**[Game-Specific] UI Category Specifications:**

| UI Category | Resolution Requirements | Design Constraints | [Game System] Integration | Accessibility Requirements |
| --- | --- | --- | --- | --- |
| **[UICategory1]** | [Resolution requirements and scaling] | [Design constraint rationale] | [How this integrates with game systems] | [Accessibility requirement and implementation] |
| **[UICategory2]** | [Resolution requirements and scaling] | [Design constraint rationale] | [How this integrates with game systems] | [Accessibility requirement and implementation] |
| **[UICategory3]** | [Resolution requirements and scaling] | [Design constraint rationale] | [How this integrates with game systems] | [Accessibility requirement and implementation] |
| **[UICategory4]** | [Resolution requirements and scaling] | [Design constraint rationale] | [How this integrates with game systems] | [Accessibility requirement and implementation] |

**[Game-Specific] UI Technical Specifications:**

```csharp
public class [GameSpecific]UISpecification
{
    [Header("[Game System] UI Technical Requirements")]
    public float [gameSystem]UIScaleFactor = [scale]f;              // [UI scaling rationale]
    public CanvasScaler.ScaleMode [gameSystem]UIScaleMode = CanvasScaler.ScaleMode.[ScaleMode]; // [Scale mode rationale]
    public Vector2 [gameSystem]UIReferenceResolution = new Vector2([width], [height]); // [Reference resolution rationale]
    public float [gameSystem]UIMatchWidthOrHeight = [value]f;       // [Match rationale]

    [Header("[Game System] UI Asset Format")]
    public bool useVector[GameSystem]UI = [boolean];                 // [Vector UI rationale]
    public float [gameSystem]UITextureImportScale = [scale]f;       // [Import scale rationale]
    public FilterMode [gameSystem]UIFilterMode = FilterMode.[FilterMode]; // [Filter mode rationale]
    public TextureFormat [gameSystem]UITextureFormat = TextureFormat.[Format]; // [Texture format rationale]

    [Header("[Game System] UI Accessibility")]
    public bool enable[GameSystem]UIContrastOptions = [boolean];     // [Contrast option rationale]
    public bool enable[GameSystem]UIScalingOptions = [boolean];      // [Scaling option rationale]
    public bool enable[GameSystem]UIColorBlindSupport = [boolean];   // [Color blind support rationale]
    public bool enable[GameSystem]UIAlternativeText = [boolean];     // [Alternative text rationale]

    public struct [GameSystem]UIElement
    {
        public string [gameSystem]UIElementName;
        public [UICategory] category;
        public Vector2 [gameSystem]UIMinSize;
        public Vector2 [gameSystem]UIMaxSize;
        public bool supports[GameSystem][SystemVariation];
        public [AccessibilityLevel] accessibilityLevel;

        public bool Validate[GameSystem]UICompliance();
        public [UIVariant][] Generate[SystemVariants]();
        public float Calculate[GameSystem]UIPerformanceImpact();
    }
}

```

### **7.3.2 Cross-Platform [Game-Specific] UI Considerations**

**Cross-Platform UI Design Rationale:**
[Game-specific ui requirements] require **[consistent ui presentation requirement]** across diverse platforms while adapting to **[platform-specific interaction patterns]** and **[platform accessibility requirements]**. Cross-platform specifications must maintain **[ui integrity goal]** while leveraging **[platform interaction strengths]**.

**Platform-Specific [Game-Specific] UI Adaptations:**

| Platform Category | [Game System] UI Adaptations | [Game System] Interaction Considerations | [Game System] Accessibility Integration | Performance Considerations |
| --- | --- | --- | --- | --- |
| **[Platform1] [Game System] UI** | [Platform adaptation approach] | [Interaction consideration rationale] | [Accessibility integration approach] | [Performance consideration rationale] |
| **[Platform2] [Game System] UI** | [Platform adaptation approach] | [Interaction consideration rationale] | [Accessibility integration approach] | [Performance consideration rationale] |
| **[Platform3] [Game System] UI** | [Platform adaptation approach] | [Interaction consideration rationale] | [Accessibility integration approach] | [Performance consideration rationale] |
| **[Platform4] [Game System] UI** | [Platform adaptation approach] | [Interaction consideration rationale] | [Accessibility integration approach] | [Performance consideration rationale] |

**[Game-Specific] UI Responsive Design Implementation:**

```csharp
public class [GameSpecific]UIResponsiveManager : MonoBehaviour
{
    [Header("[Game System] UI Platform Configuration")]
    public [GameSystem]UIPlatformSettings[] platformSettings;     // [Platform setting rationale]
    public bool enable[GameSystem]UIAdaptiveScaling = [boolean];       // [Adaptive scaling rationale]
    public bool enable[GameSystem]UIAccessibilityScaling = [boolean];  // [Accessibility scaling rationale]

    [Header("[Game System] UI Responsive Breakpoints")]
    public [GameSystem]UIBreakpoint[] [gameSystem]UIBreakpoints; // [Breakpoint rationale]
    public float [gameSystem]UITransitionDuration = [time]f;         // [Transition timing rationale]
    public bool enable[GameSystem]UIAnimatedTransitions = [boolean];   // [Animation rationale]

    [Header("[Game System] UI Accessibility")]
    public [GameSystem]UIAccessibilityProfile accessibilityProfile; // [Accessibility profile rationale]
    public bool enable[GameSystem]UIHighContrast = [boolean];         // [High contrast rationale]
    public float [gameSystem]UIAccessibilityScale = [scale]f;         // [Accessibility scale rationale]

    public struct [GameSystem]UIPlatformSettings
    {
        public RuntimePlatform targetPlatform;
        public Vector2 [gameSystem]UIMinScreenSize;
        public Vector2 [gameSystem]UIMaxScreenSize;
        public float [gameSystem]UIScaleFactor;
        public [UIInputMethod] primaryInputMethod;
        public [UIAccessibilityRequirements] accessibilityRequirements;

        public bool Validate[GameSystem]UIForPlatform();
        public [UIConfiguration] GetOptimal[GameSystem]UIConfiguration();
        public [UIPerformanceProfile] Get[GameSystem]UIPerformanceProfile();
    }

    public struct [GameSystem]UIBreakpoint
    {
        public Vector2 screenSizeThreshold;
        public [UILayoutConfiguration] layoutConfiguration;
        public [UIScalingConfiguration] scalingConfiguration;
        public [UIAccessibilityConfiguration] accessibilityConfiguration;

        public bool AppliesToScreenSize(Vector2 screenSize);
        public void Apply[GameSystem]UIConfiguration();
    }
}

```

**[Game-Specific] UI Asset Organization Structure:**

**Design Rationale:**
[Game-specific] UI organization must support **[ui integration goal]**, **[ui variation goal]**, and **[efficient ui asset management goal]** while facilitating **[content iteration workflow goal]** and **[cross-platform ui deployment goal]**.

```
Assets/UI/[GameSpecific]/
├── [UICategory1]/
│   ├── [UISubcategory1]/
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   └── [PREFIX]_UI_[Type]_[Function].svg
│   ├── [UISubcategory2]/
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   └── [PREFIX]_UI_[Type]_[Function].svg
│   └── [UISubcategory3]/
│       ├── [PREFIX]_UI_[Type]_[Function].svg
│       └── [PREFIX]_UI_[Type]_[Function].svg
├── [UICategory2]/
│   ├── [UISubcategory4]/
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   ├── [PREFIX]_UI_[Type]_[Function].svg
│   │   └── [PREFIX]_UI_[Type]_[Function].svg
│   └── [UISubcategory5]/
│       ├── [PREFIX]_UI_[Type]_[Function].svg
│       └── [PREFIX]_UI_[Type]_[Function].svg
├── [UISystemVariants]/
│   ├── [SystemContext1]/
│   │   ├── [PREFIX]_UI_[Context1]_[Variation].asset
│   │   └── [PREFIX]_UI_[Context1]_[Styling].asset
│   ├── [SystemContext2]/
│   │   ├── [PREFIX]_UI_[Context2]_[Variation].asset
│   │   └── [PREFIX]_UI_[Context2]_[Styling].asset
│   └── [SystemContext3]/
│       ├── [PREFIX]_UI_[Context3]_[Variation].asset
│       └── [PREFIX]_UI_[Context3]_[Styling].asset
└── [UIAccessibility]/
    ├── [AccessibilityCategory1]/
    │   ├── [PREFIX]_UI_[AccessibilityType1]_[Configuration].svg
    │   └── [PREFIX]_UI_[AccessibilityType1]_[Configuration].svg
    ├── [AccessibilityCategory2]/
    │   ├── [PREFIX]_UI_[AccessibilityType2]_[Configuration].asset
    │   └── [PREFIX]_UI_[AccessibilityType2]_[Configuration].asset
    └── [AccessibilityCategory3]/
        ├── [PREFIX]_UI_[AccessibilityType3]_[Configuration].asset
        ├── [PREFIX]_UI_[AccessibilityType3]_[Configuration].asset
        └── [PREFIX]_UI_[AccessibilityType3]_[Configuration].asset

```

**[Game-Specific] UI Performance and Memory Specifications:**

**Design Rationale:**
[Game-specific] UI must maintain **[performance efficiency goal]** while supporting **[ui immersion goal]** and **[cross-platform compatibility goal]**. Performance specifications must balance **[ui quality goal]** with **[memory efficiency goal]** and **[ui rendering performance goal]**.

```csharp
public class [GameSpecific]UIPerformanceSpecification
{
    [Header("[Game System] UI Performance Targets")]
    public int max[GameSystem]UIDrawCalls = [number];              // [Draw call limit rationale]
    public float [gameSystem]UIMemoryBudgetMB = [budget]f;       // [Memory budget rationale]
    public int max[GameSystem]UICanvasUpdates = [updates];          // [Update limit rationale]
    public bool enable[GameSystem]UIBatching = [boolean];         // [Batching rationale]

    [Header("[Game System] UI Quality Settings")]
    public [GameSystem]UIQualityLevel[] qualityLevels;       // [Quality level rationale]
    public bool enable[GameSystem]UILOD = [boolean];              // [LOD rationale]
    public float [gameSystem]UIDistanceCulling = [distance]f;     // [Culling rationale]

    [Header("[Game System] UI Memory Management")]
    public bool enable[GameSystem]UIAtlasing = [boolean];         // [Atlasing rationale]
    public int [gameSystem]UIAtlasSize = [size];               // [Atlas size rationale]
    public bool enable[GameSystem]UICompression = [boolean];      // [Compression rationale]

    public struct [GameSystem]UIQualityLevel
    {
        public string qualityName;
        public float [gameSystem]UIResolutionScale;
        public int [gameSystem]UIMaxTextureSize;
        public bool enable[GameSystem]UIAntiAliasing;
        public [UIEffectLevel] effectLevel;

        public bool Validate[GameSystem]UIQualityLevel();
        public float Calculate[GameSystem]UIPerformanceImpact();
        public [UIMemoryUsage] Estimate[GameSystem]UIMemoryUsage();
    }
}

```

## 🔧 ASSET SPECIFICATION ANALYSIS METHODOLOGY:

### **Visual Asset Requirements Extraction:**

- **From Section 6 Art Direction:** [How art style translates to asset technical requirements]
- **From Section 6 Rendering Architecture:** [What rendering capabilities require specific asset formats]
- **From Section 4 Data Architecture:** [What memory constraints affect asset specifications]
- **From Section 1 System Architecture:** [What systems require specific asset types]

### **Audio Asset Requirements Analysis:**

- **From Section 6 Audio Architecture:** [What audio capabilities require specific formats and organization]
- **From Section 2 Gameplay Architecture:** [What gameplay mechanics require specific audio assets]
- **From GDD Audio Design:** [How audio style translates to technical specifications]
- **From Platform Requirements:** [How platform constraints affect audio format decisions]

### **UI Asset Requirements Analysis:**

- **From Section 6 Platform Considerations:** [How platform differences affect UI asset requirements]
- **From Section 2 Gameplay Architecture:** [What UI elements the gameplay requires]
- **From GDD Design Pillars:** [How design goals translate to UI asset specifications]
- **From Accessibility Requirements:** [What accessibility needs require specific UI asset approaches]

### **Cross-Platform Optimization Strategy:**

- **Platform Performance Targets:** [How performance requirements affect asset specifications]
- **Memory Budget Constraints:** [How memory limitations drive asset format decisions]
- **Loading Performance Requirements:** [How loading targets affect asset organization]
- **Quality Scaling Needs:** [How quality scaling affects asset variant requirements]

## 📝 INPUT REQUIREMENTS:

- **Complete Game Design Document**
- **Section 0: Design Translation Framework output**
- **Section 1: System Architecture output**
- **Section 2: Gameplay Architecture output**
- **Section 3: Class Design output**
- **Section 4: Data Architecture output**
- **Section 5: Unity-Specific Architecture output**
- **Section 6: Platform & Technical Architecture output**

## ⚡ KEY REQUIREMENTS:

- **Extract asset requirements systematically** from GDD art direction and all previous technical sections
- **Create comprehensive asset specifications** covering visual, audio, and UI assets with detailed technical requirements
- **Design efficient asset organization systems** that support content creation workflows and automated processing
- **Establish clear naming conventions** that facilitate asset management and cross-platform deployment
- **Include platform optimization strategies** for asset formats, compression, and memory management across all target platforms
- **Integrate comprehensive accessibility requirements** across all asset categories to support inclusive design
- **Provide detailed rationale** connecting all asset specification decisions to game design goals and technical constraints
- **Consider development workflow efficiency** for solo development and AI-assisted content creation
- **Ensure asset specifications support** the game's aesthetic goals while meeting performance and platform requirements
- **Make all specifications actionable** for content creation and asset pipeline development

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

**Section 5 Output:**
[PASTE UNITY-SPECIFIC ARCHITECTURE OUTPUT HERE]

**Section 6 Output:**
[PASTE PLATFORM & TECHNICAL ARCHITECTURE OUTPUT HERE]

Generate Section 7 following this exact structure with comprehensive asset specifications, detailed technical requirements, efficient organization systems, and thorough rationale connecting all asset decisions to the game's design goals, technical requirements, and platform deployment constraints.