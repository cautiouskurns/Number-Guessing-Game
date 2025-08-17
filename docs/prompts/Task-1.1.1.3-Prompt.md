# **AI TASK IMPLEMENTATION PROMPT**

You are an expert Unity developer working on a Unity project via MCP agents.

Implement **Statistical Validation & Distribution Analysis** for the Number-Guessing-Game Unity2D.

## 📚 Project Knowledge Base

**Before implementing, familiarize yourself with the project context:**

### **Core Documentation:**
- **Game Design Document**: `docs/Number-Guessing-Game-GDD.md` - Game mechanics, player experience, core vision
- **Technical Design Spec**: `docs/TDS/` - System architecture and technical requirements  
- **Development Roadmap**: `docs/Number-Guessing-Game-Roadmap.md` - Project phases and milestones

### **Current Epic Context:**
- **Epic Specification**: `docs/epics/Epic-1.1-Specification.md` - Current epic scope and acceptance criteria
- **Feature Breakdown**: `docs/tasks/Feature-1.1.1-Tasks.md` - All related tasks and dependencies

### **Implementation Resources:**
- **Unity Project**: `/Assets/Scripts/` - Existing codebase and component structure
- **Project Parameters**: `project-parameters.yaml` - Team settings, Linear integration, Unity configuration
- **MCP Guidelines**: Unity MCP tools are available for component management and testing

**📖 Read these documents to understand the full context before implementing this specific task.**

## 🎯 Task Overview
**Task ID:** 1.1.1.3 | **Priority:** Medium | **Duration:** 4 hours  
**Feature:** 1.1.1 - Random Number Generation System | **Epic:** 1.1 - Core Game Logic System | **Category:** 7.2 Integration Testing

## 🎮 Game Context

This task implements comprehensive statistical analysis to ensure proper random distribution and quality assurance for the NumberGenerator system. It ensures "Pure Logic" design pillar by mathematically validating fair number generation and supports player trust in game fairness through rigorous statistical verification. The validation system provides automated reporting and integration into quality assurance workflows, enabling continuous validation of random number generation quality.

**📖 Project Context References:**
- **Game Design Document**: `/docs/Number-Guessing-Game-GDD.md` - Core game vision and mechanics
- **Epic Specification**: `/docs/epics/Epic-1.1-Specification.md` - Technical requirements and scope
- **Feature Tasks**: `/docs/tasks/Feature-1.1.1-Tasks.md` - Complete task breakdown and dependencies
- **Development Roadmap**: `/docs/Number-Guessing-Game-Roadmap.md` - Project timeline and milestones
- **Project Parameters**: `project-parameters.yaml` - Configuration and team settings

## 📋 Task Requirements

- Statistical distribution analysis over large sample sizes (1000+ generations)
- Chi-square goodness-of-fit testing for uniform distribution validation
- Automated testing framework for continuous integration and quality assurance
- Performance measurement during bulk generation to ensure scalability
- Comprehensive reporting system showing distribution results and statistical confidence
- Integration with debug mode for deterministic validation scenarios

## 🎯 Expected Outcome

After implementation, developers should see:
- **Visual Outcome**: Statistical validation results displayed in Unity Console and potential custom Editor window
- **Functional Outcome**: Automated statistical testing confirming uniform distribution across 1-100 range
- **Integration Outcome**: Statistical validation integrated with existing NumberGenerator and debug systems
- **Performance Outcome**: Efficient bulk generation and analysis without memory leaks or performance degradation

**Verification**: Run statistical validation on 1000+ generated numbers, confirm Chi-square test passes with p-value > 0.05, verify performance remains stable during bulk operations

## 🔧 Implementation Steps

1. **Create Statistical Validator Class**: Implement StatisticalValidator component for distribution analysis and testing
2. **Implement Chi-Square Testing**: Add mathematical algorithms for goodness-of-fit testing and statistical validation
3. **Add Bulk Generation Support**: Create methods for efficient large-scale number generation and data collection
4. **Implement Analysis Algorithms**: Add distribution analysis with variance calculation and bias detection
5. **Create Reporting System**: Implement comprehensive reporting with clear statistical results and confidence levels
6. **Add Editor Integration**: Create Unity Editor tools for easy statistical validation execution and result viewing

## 🏗️ Technical Specification

### **Class Structure:**
```csharp
public class StatisticalValidator : MonoBehaviour
{
    [Header("Validation Configuration")]
    [SerializeField] private int defaultSampleSize = 1000;
    [SerializeField] private float confidenceLevel = 0.95f;
    [SerializeField] private bool enablePerformanceMonitoring = true;
    
    [Header("Analysis Results")]
    [SerializeField, ReadOnly] private float lastChiSquareValue;
    [SerializeField, ReadOnly] private float lastPValue;
    [SerializeField, ReadOnly] private bool lastTestPassed;
    
    public struct ValidationResult
    {
        public int SampleSize;
        public float ChiSquareValue;
        public float PValue;
        public bool TestPassed;
        public Dictionary<int, int> FrequencyDistribution;
        public string Summary;
    }
    
    public ValidationResult ValidateDistribution(int sampleSize);
    public ValidationResult ValidateWithSeed(int seed, int sampleSize);
    #if UNITY_EDITOR
    [MenuItem("NumberGuessingGame/Validation/Run Statistical Test")]
    public static void RunValidationFromMenu();
    #endif
}
```

### **Core Logic:**
Comprehensive statistical analysis system validating random number distribution quality over large sample sizes, with Chi-square goodness-of-fit testing for uniform distribution validation and automated reporting.

### **Dependencies:**
Tasks 1.1.1.1 (Core NumberGenerator) and 1.1.1.2 (Debug Mode) must be complete, mathematical libraries for statistical calculations, Unity Editor scripting for menu integration.

**📋 Task Dependencies:**
- **Prerequisites**: Tasks 1.1.1.1 (Core NumberGenerator) and 1.1.1.2 (Debug Mode) provide foundation and deterministic testing
- **Blocks**: None - this task can run in parallel with Task 1.1.1.4 (Event Integration)
- **Related Systems**: Quality assurance workflows, continuous integration testing, statistical reporting

**🔗 Implementation Context:**
- **Existing Codebase**: Integrate with existing NumberGenerator and debug systems without breaking functionality
- **Unity Project Setup**: Ensure statistical calculations work correctly and efficiently within Unity environment
- **MCP Integration**: Use Unity MCP tools for component creation and validation testing

### **Performance Constraints:**
Efficient analysis algorithms for large sample sizes, memory optimization during bulk generation, performance monitoring to ensure scalability without memory leaks.

### **Architecture Guidelines:**
- Follow Single Responsibility Principle - statistical validation focused on distribution analysis only
- Keep validation logic separate from core generation to maintain clean architecture
- Only implement statistical methods explicitly required for quality assurance
- Avoid complex statistical features beyond uniform distribution validation
- Align with TDS quality assurance patterns emphasizing reliable, testable systems

## 🔧 Unity Integration

**GameObject Setup:** Create StatisticalValidator GameObject in _GameSystems hierarchy or attach as component to NumberGenerator
**Scene Hierarchy:** Position alongside NumberGenerator for easy access and logical organization
**Inspector Config:** Configuration fields for sample size, confidence level, and performance monitoring with read-only results display
**System Connections:** Integration with NumberGenerator for bulk generation, debug mode for deterministic testing, Unity Console for result reporting

## ✅ Success Criteria

- [ ] Distribution testing over 1000+ samples demonstrates statistically significant uniform distribution
- [ ] Chi-square test passes with p-value > 0.05 indicating proper randomness
- [ ] No significant bias toward any number ranges or specific values detected
- [ ] Automated validation can be executed via Unity Editor tools and continuous integration
- [ ] Performance remains consistent during bulk generation without memory leaks
- [ ] Statistical reports provide clear, actionable information about distribution quality
- [ ] Integration with debug mode enables testing with both random and fixed seeds
- [ ] No compilation errors
- [ ] Follows Unity best practices and Single Responsibility Principle
- [ ] Aligns with TDS architectural patterns
- [ ] Meets GDD player experience requirements
- [ ] Satisfies epic-level acceptance criteria

## 🛠️ Unity MCP Implementation

**📖 Reference Documentation:**
- Unity MCP Implementation Guidelines: Follow established patterns for component creation and testing
- Project Parameters: Use `project-parameters.yaml` for Linear integration and Unity paths
- Execute Linear Command: Use updated workflow with comment-based completion tracking

**🔧 Implementation Approach:**
Follow **Quality Assurance Component** pattern: Create dedicated statistical validation system with automated testing capabilities, Unity Editor integration, and comprehensive reporting.

**⚠️ Fallback Approach:**
If MCP unavailable, manually create StatisticalValidator.cs, implement statistical algorithms using System.Math, and create Editor menu items through [MenuItem] attributes.

**🎯 MCP Integration Requirements:**
- **Unity State Management**: Ensure Unity exits play mode after any tests or validation
- **Component Integration**: Use `manage_gameobject` to create StatisticalValidator component with proper setup
- **Script Management**: Use `manage_script` for clean code creation with proper mathematical implementations
- **Error Handling**: Check Unity console via `read_console` for compilation and statistical calculation issues
- **Linear Integration**: Implementation will be tracked via Linear comments (preserves task descriptions)

### **MCP Priority Implementation:**

**Primary (Use When Available):**
- Use `manage_gameobject` to create StatisticalValidator GameObject with component attachment
- Use `manage_script` to create StatisticalValidator.cs with statistical algorithms and Editor integration
- Use `read_console` to validate statistical calculations and error checking
- Validate statistical testing through Unity Editor menu execution

**Secondary (Fallback):**
- Manual StatisticalValidator.cs creation with mathematical algorithm implementation
- Manual Unity Editor menu item setup and statistical testing verification
- Traditional Unity workflow for component setup and validation testing

## 📁 Deliverables

- `Assets/Scripts/StatisticalValidator.cs` - Complete statistical validation system with Chi-square testing and reporting
- StatisticalValidator GameObject or component integration with NumberGenerator in scene hierarchy
- Unity Editor menu items under "NumberGuessingGame/Validation/" for statistical testing access
- Comprehensive reporting system with statistical results and confidence analysis

## 🧪 Validation

**Functional Validation:**
Execute statistical validation on 1000+ generated numbers, verify Chi-square test calculations produce accurate p-values, confirm uniform distribution detection and bias analysis.

**Integration Validation:**  
Verify integration with NumberGenerator bulk generation, test debug mode compatibility for deterministic validation, confirm Editor menu functionality and result display.

**Performance Validation:**
Measure analysis performance for large sample sizes, monitor memory usage during bulk generation, validate scalability without performance degradation.

**Epic Alignment Validation:**
Ensure statistical validation supports Epic 1.1 quality requirements and random number generation reliability standards.

**GDD Compliance Validation:**
Confirm statistical validation supports "Pure Logic" design pillar through mathematical fairness verification, ensuring player trust in game randomness.

## 🔄 Response Contract

**Required Output Format:**
1. **Implementation Plan** (4-6 bullets covering statistical algorithm implementation, Chi-square testing approach, Unity integration strategy, and performance optimization)
2. **Code Files** (StatisticalValidator.cs with complete statistical analysis, Chi-square testing, and Unity Editor integration)  
3. **Unity Setup Method** (MCP commands for component creation and statistical testing setup, with manual implementation fallback)
4. **Integration Notes** (brief explanation of how statistical validation integrates with NumberGenerator and provides quality assurance for Epic 1.1)

**File Structure:** Assets/Scripts/StatisticalValidator.cs with proper mathematical implementations and Unity integration
**Code Standards:** Unity C# naming conventions, proper mathematical algorithm implementation, clear statistical reporting format

## 🚨 Resilience Flags

**StubMissingDeps:** Create basic statistical validation if advanced mathematical libraries unavailable
**ValidationLevel:** Comprehensive - thorough statistical analysis with multiple validation methods  
**Reusability:** Reusable - statistical validation pattern applicable to other random systems requiring quality assurance

## 🔍 Dependency Handling

**Missing Dependencies:**
- **If System.Math functions limited:** Implement basic statistical calculations manually with proper algorithms
- **If Chi-square tables unavailable:** Use simplified distribution validation with variance analysis
- **If Unity Editor integration fails:** Provide alternative validation access through Inspector buttons or console commands

**Fallback Behaviors:**
- Default to basic distribution counting if advanced statistical analysis fails
- Log informative warnings for statistical calculation issues or invalid sample sizes
- Gracefully handle edge cases like extremely small sample sizes or calculation errors
- Align with TDS resilience patterns for robust quality assurance operation

**Risk Mitigation:**
Comprehensive error handling for mathematical calculations, proper validation of input parameters and sample sizes, defensive programming for statistical edge cases and numerical precision.

Execute this implementation now.