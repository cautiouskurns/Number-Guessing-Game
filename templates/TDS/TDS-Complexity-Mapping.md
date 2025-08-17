# TDS Complexity Mapping Specification

This document defines exactly which sections, subsections, and features are included at each complexity level when generating Technical Design Specifications.

## Overview

The complexity levels (`simple`, `intermediate`, `detailed`) control both the **scope** and **depth** of each TDS section:

- **Simple**: Core functionality only, minimal technical depth
- **Intermediate**: Balanced feature set with moderate technical detail  
- **Detailed**: Comprehensive coverage with full technical depth

---

## Section 0: Design Translation Framework

### Simple Complexity
**Required Subsections:**
- 0.1 Design Pillars Extraction (core pillars only)
- 0.2 Technical Requirements (basic requirements only)
- 0.3 Platform Constraints (target platform only)

**Excluded:**
- Advanced constraint analysis
- Detailed competitive analysis
- Complex technical trade-off discussions

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 0.4 Development Constraints (team size, timeline)
- Extended technical requirements analysis

**Enhanced Features:**
- Multiple platform considerations
- Basic competitive analysis
- Moderate technical depth

### Detailed Complexity
**Required Subsections:**
- All sections with full depth
- 0.5 Success Metrics Definition
- 0.6 Risk Assessment Framework

**Enhanced Features:**
- Comprehensive constraint analysis
- Detailed competitive benchmarking
- Advanced technical trade-off analysis

---

## Section 1: System Architecture

### Simple Complexity
**Required Subsections:**
- 1.1 System Dependency Map (core systems only: 3-5 systems)
- 1.2 Component Hierarchy (basic GameObject organization)
- 1.3 Manager Pattern Structure (singleton pattern only)

**System Scope:**
- Core gameplay system
- Basic input system
- Simple UI system
- Basic audio system

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 1.4 Event/Communication Architecture (basic event system)

**System Scope:**
- All Simple systems plus:
- Save/load system
- Settings system
- Performance monitoring (basic)
- Platform-specific optimizations

### Detailed Complexity
**Required Subsections:**
- All sections with full architectural depth
- Advanced manager patterns (observer, command, state)
- Complex communication architectures
- Performance profiling integration

**System Scope:**
- All Intermediate systems plus:
- Analytics integration
- Modding support systems
- Advanced networking (if applicable)
- Comprehensive debugging systems

---

## Section 2: Gameplay Architecture

### Simple Complexity
**Required Subsections:**
- 2.1 Core Game Loop (basic loop only)
- 2.2 Player Interaction System (primary interactions only)
- 2.3 Game State Management (basic states: menu, playing, paused)

**Gameplay Features:**
- Core mechanic implementation
- Basic player controls
- Simple win/lose conditions
- Essential UI feedback

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 2.4 Progression System Architecture (if game requires progression)
- 2.5 Feedback Systems (visual/audio feedback)

**Gameplay Features:**
- All Simple features plus:
- Secondary mechanics
- Settings and options
- Basic accessibility features
- Achievement system (if applicable)

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive gameplay depth
- 2.6 AI Behavior Architecture (if game has AI)
- 2.7 Advanced Interaction Patterns
- 2.8 Emergent Gameplay Considerations

**Gameplay Features:**
- All Intermediate features plus:
- Complex interaction chains
- Advanced AI behaviors
- Comprehensive accessibility
- Detailed analytics tracking

---

## Section 3: Class Design

### Simple Complexity
**Required Subsections:**
- 3.1 Core Game Classes (5-8 essential classes)
- 3.2 Player/Entity Classes (basic player representation)
- 3.3 Basic Utility Classes (essential helpers only)

**Class Depth:**
- Basic class structure
- Essential public methods
- Core properties only
- Minimal inheritance

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 3.4 Manager Classes (system coordination)
- 3.5 Data Container Classes

**Class Depth:**
- All Simple features plus:
- Interface implementations
- Basic inheritance patterns
- Event handling methods
- Moderate encapsulation

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive class design
- 3.6 Advanced Patterns (factory, observer, command)
- 3.7 Performance-Critical Classes
- 3.8 Testing and Validation Classes

**Class Depth:**
- All Intermediate features plus:
- Complex inheritance hierarchies
- Advanced design patterns
- Comprehensive error handling
- Performance optimization

---

## Section 4: Data Architecture

### Simple Complexity
**Required Subsections:**
- 4.1 Core Data Structures (essential game data only)
- 4.2 Save Data Architecture (basic save system)

**Data Features:**
- Basic data types
- Simple serialization
- Local storage only
- Essential configuration data

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 4.3 Configuration Management
- 4.4 Asset Loading Strategy

**Data Features:**
- All Simple features plus:
- JSON serialization
- Basic data validation
- Settings persistence
- Asset streaming basics

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive data management
- 4.5 Performance Data Structures
- 4.6 Data Validation Framework
- 4.7 Migration and Versioning

**Data Features:**
- All Intermediate features plus:
- Binary serialization
- Advanced data validation
- Cloud storage integration
- Data analytics collection

---

## Section 5: Unity-Specific Architecture

### Simple Complexity
**Required Subsections:**
- 5.1 Scene Organization (basic single-scene or simple multi-scene)
- 5.2 Prefab Architecture (basic prefabs, no variants)
- 5.3 Component Composition (basic MonoBehaviour patterns)

**Unity Features:**
- Basic scene management
- Simple prefab usage
- Standard Unity components
- Basic resource loading

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 5.4 ScriptableObject Usage (configuration and events)
- 5.5 Resource Management (addressable basics)

**Unity Features:**
- All Simple features plus:
- Additive scene loading
- Prefab variants
- ScriptableObject events
- Basic addressable system

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive Unity architecture
- 5.6 Build and Deployment Optimization
- Advanced editor tool integration
- Performance profiling integration

**Unity Features:**
- All Intermediate features plus:
- Complex scene streaming
- Advanced prefab systems
- Custom editor tools
- Build pipeline automation

---

## Section 6: Platform Technical Architecture

### Simple Complexity
**Required Subsections:**
- 6.1 Core Platform Optimization (target platform only)
- 6.2 Input Architecture (basic input for target platform)

**Platform Features:**
- Single platform optimization
- Basic input handling
- Essential platform compliance
- Minimal accessibility features

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 6.3 Multi-Platform Considerations (2-3 platforms)
- 6.4 Performance Optimization

**Platform Features:**
- All Simple features plus:
- Cross-platform input
- Platform-specific optimizations
- Basic performance monitoring
- Standard accessibility compliance

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive platform coverage
- 6.5 Advanced Platform Features
- 6.6 Accessibility Architecture
- 6.7 Platform Validation and Certification

**Platform Features:**
- All Intermediate features plus:
- Advanced platform integrations
- Comprehensive accessibility
- Automated testing
- Certification compliance

---

## Section 7: Asset Specification

### Simple Complexity
**Required Subsections:**
- 7.1 Core Asset Requirements (essential assets only)
- 7.2 Basic Asset Pipeline

**Asset Scope:**
- Essential sprites/models
- Basic audio assets
- Simple UI assets
- Basic placeholder assets

### Intermediate Complexity
**Required Subsections:**
- All Simple subsections plus:
- 7.3 Asset Optimization Strategy
- 7.4 Asset Validation Framework

**Asset Scope:**
- All Simple assets plus:
- Enhanced visual assets
- Background music and SFX
- Particle effects
- UI animations

### Detailed Complexity
**Required Subsections:**
- All sections with comprehensive asset management
- 7.5 Advanced Asset Pipeline
- 7.6 Asset Performance Analysis
- 7.7 Localization Asset Strategy

**Asset Scope:**
- All Intermediate assets plus:
- High-quality production assets
- Comprehensive audio design
- Advanced effects and shaders
- Localization assets

---

## Implementation Guidelines

### For AIG-103 (TDS Generation)
When generating TDS sections, check the complexity level and:

1. **Include only the required subsections** for that complexity level
2. **Adapt the depth of technical detail** appropriately
3. **Scale the scope** of systems, classes, and features
4. **Reference this mapping** to ensure consistency

### For `/setup-game-project` Command
The complexity level flows through as:
```yaml
COMPLEXITY_LEVEL: "intermediate"
DOCUMENTATION_DEPTH: "intermediate"  # References this mapping
```

### Usage in TDS Generation Prompts
Each TDS prompt should include:
```
Based on COMPLEXITY_LEVEL: {complexity_level}
- Include sections: [reference this mapping]
- Technical depth: [reference complexity guidelines]  
- Feature scope: [reference complexity scope]
```

---

## Complexity Level Guidelines Summary

| Aspect | Simple | Intermediate | Detailed |
|--------|--------|-------------|----------|
| **TDS Sections** | 4-5 core sections | 6-7 sections | All 8 sections |
| **Technical Depth** | Basic implementation | Moderate architecture | Comprehensive design |
| **Code Examples** | Simple patterns | Moderate patterns | Advanced patterns |
| **System Count** | 3-5 core systems | 5-8 systems | 8-12+ systems |
| **Class Count** | 5-8 classes | 10-15 classes | 15-25+ classes |
| **Platform Focus** | Single platform | 2-3 platforms | Multi-platform |
| **Feature Scope** | Core features only | Core + secondary | Comprehensive features |
| **Validation** | Basic testing | Moderate validation | Comprehensive QA |

This mapping ensures consistent complexity application across all TDS sections while maintaining appropriate scope and technical depth for each project level.