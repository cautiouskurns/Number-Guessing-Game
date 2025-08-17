using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Statistical validation system for NumberGenerator quality assurance.
/// Provides Chi-square testing, distribution analysis, and comprehensive reporting
/// for ensuring proper random number generation quality.
/// </summary>
public class StatisticalValidator : MonoBehaviour
{
    #region Configuration
    
    [Header("Validation Configuration")]
    [SerializeField, Tooltip("Default sample size for statistical testing")]
    private int defaultSampleSize = 1000;
    
    [SerializeField, Tooltip("Confidence level for statistical tests (0.95 = 95%)")]
    [Range(0.8f, 0.99f)]
    private float confidenceLevel = 0.95f;
    
    [SerializeField, Tooltip("Enable performance monitoring during bulk generation")]
    private bool enablePerformanceMonitoring = true;
    
    [SerializeField, Tooltip("Enable detailed logging of statistical calculations")]
    private bool enableDetailedLogging = false;
    
    [Header("Analysis Results - Read Only")]
    [SerializeField, Tooltip("Last Chi-square test statistic value")]
    private float lastChiSquareValue;
    
    [SerializeField, Tooltip("Last p-value from Chi-square test")]
    private float lastPValue;
    
    [SerializeField, Tooltip("Did the last test pass the confidence threshold")]
    private bool lastTestPassed;
    
    [SerializeField, Tooltip("Last test sample size")]
    private int lastSampleSize;
    
    [SerializeField, Tooltip("Last test execution time in milliseconds")]
    private float lastExecutionTimeMs;
    
    #endregion
    
    #region Validation Result Structure
    
    [System.Serializable]
    public struct ValidationResult
    {
        public int SampleSize;
        public float ChiSquareValue;
        public float PValue;
        public bool TestPassed;
        public Dictionary<int, int> FrequencyDistribution;
        public float ExecutionTimeMs;
        public float ExpectedFrequency;
        public float MaxDeviation;
        public string Summary;
        public BiasAnalysis BiasResults;
    }
    
    [System.Serializable]
    public struct BiasAnalysis
    {
        public bool HasSignificantBias;
        public int MostFrequentValue;
        public int LeastFrequentValue;
        public float BiasPercentage;
        public string BiasDescription;
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Gets the last validation result summary
    /// </summary>
    public string LastResultSummary { get; private set; } = "No validation performed yet";
    
    /// <summary>
    /// Gets whether the last test passed statistical validation
    /// </summary>
    public bool LastTestPassed => lastTestPassed;
    
    /// <summary>
    /// Gets the last Chi-square test p-value
    /// </summary>
    public float LastPValue => lastPValue;
    
    #endregion
    
    #region Unity Lifecycle
    
    private void Start()
    {
        if (enableDetailedLogging)
            UnityEngine.Debug.Log("StatisticalValidator initialized and ready for testing");
    }
    
    #endregion
    
    #region Public Validation Methods
    
    /// <summary>
    /// Validates the distribution of random numbers using default sample size
    /// </summary>
    /// <returns>Comprehensive validation results</returns>
    public ValidationResult ValidateDistribution()
    {
        return ValidateDistribution(defaultSampleSize);
    }
    
    /// <summary>
    /// Validates the distribution of random numbers with specified sample size
    /// </summary>
    /// <param name="sampleSize">Number of samples to generate and analyze</param>
    /// <returns>Comprehensive validation results</returns>
    public ValidationResult ValidateDistribution(int sampleSize)
    {
        if (NumberGenerator.Instance == null)
        {
            UnityEngine.Debug.LogError("NumberGenerator instance not found. Cannot perform validation.");
            return CreateErrorResult("NumberGenerator not available");
        }
        
        if (sampleSize < 100)
        {
            UnityEngine.Debug.LogWarning($"Sample size {sampleSize} is too small for reliable statistical analysis. Using minimum of 100.");
            sampleSize = 100;
        }
        
        var stopwatch = enablePerformanceMonitoring ? Stopwatch.StartNew() : null;
        
        // Generate samples and analyze distribution
        var frequencies = GenerateSamplesAndCountFrequencies(sampleSize);
        var result = PerformStatisticalAnalysis(frequencies, sampleSize);
        
        if (enablePerformanceMonitoring && stopwatch != null)
        {
            stopwatch.Stop();
            result.ExecutionTimeMs = (float)stopwatch.Elapsed.TotalMilliseconds;
            lastExecutionTimeMs = result.ExecutionTimeMs;
        }
        
        // Update inspector fields
        UpdateInspectorResults(result);
        
        if (enableDetailedLogging)
            UnityEngine.Debug.Log($"Statistical validation completed: {result.Summary}");
        
        return result;
    }
    
    /// <summary>
    /// Validates distribution using deterministic seed for reproducible testing
    /// </summary>
    /// <param name="seed">Seed for deterministic generation</param>
    /// <param name="sampleSize">Number of samples to generate</param>
    /// <returns>Validation results with deterministic generation</returns>
    public ValidationResult ValidateWithSeed(int seed, int sampleSize)
    {
        if (NumberGenerator.Instance == null)
        {
            UnityEngine.Debug.LogError("NumberGenerator instance not found. Cannot perform seeded validation.");
            return CreateErrorResult("NumberGenerator not available");
        }
        
        #if UNITY_EDITOR
        // Use debug mode if available for deterministic testing
        bool wasDebugMode = NumberGenerator.Instance.IsDebugMode;
        int originalSeed = NumberGenerator.Instance.DebugSeed;
        
        try
        {
            NumberGenerator.Instance.EnableDebugMode(seed);
            var result = ValidateDistribution(sampleSize);
            result.Summary += $" (Seeded with {seed})";
            return result;
        }
        finally
        {
            // Restore original debug state
            if (wasDebugMode)
                NumberGenerator.Instance.EnableDebugMode(originalSeed);
            else
                NumberGenerator.Instance.DisableDebugMode();
        }
        #else
        // Fallback for non-editor builds
        UnityEngine.Debug.LogWarning("Seeded validation requires debug mode, which is only available in Editor builds.");
        return ValidateDistribution(sampleSize);
        #endif
    }
    
    #endregion
    
    #region Sample Generation and Analysis
    
    /// <summary>
    /// Generates samples and counts frequency distribution
    /// </summary>
    private Dictionary<int, int> GenerateSamplesAndCountFrequencies(int sampleSize)
    {
        var frequencies = new Dictionary<int, int>();
        var generator = NumberGenerator.Instance;
        
        // Initialize frequency counts for expected range
        for (int i = generator.MinValue; i <= generator.MaxValue; i++)
        {
            frequencies[i] = 0;
        }
        
        // Generate samples and count frequencies
        for (int i = 0; i < sampleSize; i++)
        {
            int sample = generator.GenerateNewTarget();
            
            if (frequencies.ContainsKey(sample))
                frequencies[sample]++;
            else
                UnityEngine.Debug.LogWarning($"Generated value {sample} outside expected range {generator.MinValue}-{generator.MaxValue}");
        }
        
        return frequencies;
    }
    
    /// <summary>
    /// Performs comprehensive statistical analysis on frequency data
    /// </summary>
    private ValidationResult PerformStatisticalAnalysis(Dictionary<int, int> frequencies, int sampleSize)
    {
        var result = new ValidationResult
        {
            SampleSize = sampleSize,
            FrequencyDistribution = frequencies
        };
        
        // Calculate expected frequency for uniform distribution
        int range = NumberGenerator.Instance.MaxValue - NumberGenerator.Instance.MinValue + 1;
        result.ExpectedFrequency = (float)sampleSize / range;
        
        // Perform Chi-square goodness-of-fit test
        result.ChiSquareValue = CalculateChiSquareStatistic(frequencies, result.ExpectedFrequency);
        result.PValue = CalculatePValue(result.ChiSquareValue, range - 1);
        
        // Determine test result based on confidence level
        float alpha = 1.0f - confidenceLevel;
        result.TestPassed = result.PValue > alpha;
        
        // Perform bias analysis
        result.BiasResults = AnalyzeBias(frequencies, result.ExpectedFrequency);
        
        // Calculate maximum deviation from expected
        result.MaxDeviation = CalculateMaxDeviation(frequencies, result.ExpectedFrequency);
        
        // Generate summary
        result.Summary = GenerateResultSummary(result);
        LastResultSummary = result.Summary;
        
        return result;
    }
    
    /// <summary>
    /// Calculates Chi-square test statistic for goodness-of-fit
    /// </summary>
    private float CalculateChiSquareStatistic(Dictionary<int, int> observed, float expected)
    {
        float chiSquare = 0f;
        
        foreach (var frequency in observed.Values)
        {
            float deviation = frequency - expected;
            chiSquare += (deviation * deviation) / expected;
        }
        
        return chiSquare;
    }
    
    /// <summary>
    /// Calculates approximate p-value for Chi-square statistic
    /// Using simplified approach suitable for Unity environment
    /// </summary>
    private float CalculatePValue(float chiSquare, int degreesOfFreedom)
    {
        // Simplified p-value calculation for uniform distribution testing
        // For 99 degrees of freedom (1-100 range), critical values are approximately:
        // α = 0.05: χ² ≈ 123.2
        // α = 0.01: χ² ≈ 135.8
        
        if (degreesOfFreedom == 99) // Standard case for 1-100 range
        {
            if (chiSquare <= 123.2f) return 0.10f; // p > 0.05, good
            if (chiSquare <= 135.8f) return 0.03f; // 0.01 < p < 0.05, acceptable
            return 0.005f; // p < 0.01, poor distribution
        }
        
        // Fallback approximation for other ranges
        float expectedChiSquare = degreesOfFreedom;
        if (chiSquare <= expectedChiSquare * 1.2f) return 0.10f;
        if (chiSquare <= expectedChiSquare * 1.4f) return 0.03f;
        return 0.005f;
    }
    
    /// <summary>
    /// Analyzes potential bias in the distribution
    /// </summary>
    private BiasAnalysis AnalyzeBias(Dictionary<int, int> frequencies, float expectedFrequency)
    {
        var analysis = new BiasAnalysis();
        
        int maxFreq = frequencies.Values.Max();
        int minFreq = frequencies.Values.Min();
        
        analysis.MostFrequentValue = frequencies.First(f => f.Value == maxFreq).Key;
        analysis.LeastFrequentValue = frequencies.First(f => f.Value == minFreq).Key;
        
        float deviation = Math.Max(maxFreq - expectedFrequency, expectedFrequency - minFreq);
        analysis.BiasPercentage = (deviation / expectedFrequency) * 100f;
        
        // Consider bias significant if deviation > 20% from expected
        analysis.HasSignificantBias = analysis.BiasPercentage > 20f;
        
        if (analysis.HasSignificantBias)
        {
            analysis.BiasDescription = $"Significant bias detected: {analysis.BiasPercentage:F1}% deviation. " +
                                     $"Value {analysis.MostFrequentValue} appears {maxFreq} times, " +
                                     $"value {analysis.LeastFrequentValue} appears {minFreq} times " +
                                     $"(expected: {expectedFrequency:F1})";
        }
        else
        {
            analysis.BiasDescription = $"No significant bias detected. Maximum deviation: {analysis.BiasPercentage:F1}%";
        }
        
        return analysis;
    }
    
    /// <summary>
    /// Calculates maximum deviation from expected frequency
    /// </summary>
    private float CalculateMaxDeviation(Dictionary<int, int> frequencies, float expected)
    {
        float maxDev = 0f;
        foreach (int freq in frequencies.Values)
        {
            float dev = Math.Abs(freq - expected);
            if (dev > maxDev) maxDev = dev;
        }
        return maxDev;
    }
    
    #endregion
    
    #region Reporting and Utilities
    
    /// <summary>
    /// Generates comprehensive summary of validation results
    /// </summary>
    private string GenerateResultSummary(ValidationResult result)
    {
        string status = result.TestPassed ? "PASSED" : "FAILED";
        string biasStatus = result.BiasResults.HasSignificantBias ? "BIAS DETECTED" : "NO BIAS";
        
        return $"Statistical Test {status} | " +
               $"Samples: {result.SampleSize} | " +
               $"Chi²: {result.ChiSquareValue:F2} | " +
               $"p-value: {result.PValue:F3} | " +
               $"Max deviation: {result.MaxDeviation:F1} | " +
               $"{biasStatus}";
    }
    
    /// <summary>
    /// Updates inspector fields with latest results
    /// </summary>
    private void UpdateInspectorResults(ValidationResult result)
    {
        lastChiSquareValue = result.ChiSquareValue;
        lastPValue = result.PValue;
        lastTestPassed = result.TestPassed;
        lastSampleSize = result.SampleSize;
    }
    
    /// <summary>
    /// Creates error result for failed validations
    /// </summary>
    private ValidationResult CreateErrorResult(string errorMessage)
    {
        return new ValidationResult
        {
            Summary = $"VALIDATION ERROR: {errorMessage}",
            TestPassed = false,
            FrequencyDistribution = new Dictionary<int, int>()
        };
    }
    
    /// <summary>
    /// Gets detailed frequency distribution report
    /// </summary>
    public string GetFrequencyReport(ValidationResult result)
    {
        if (result.FrequencyDistribution == null || result.FrequencyDistribution.Count == 0)
            return "No frequency data available";
        
        var report = new System.Text.StringBuilder();
        report.AppendLine($"Frequency Distribution Report (Sample Size: {result.SampleSize})");
        report.AppendLine($"Expected frequency per value: {result.ExpectedFrequency:F1}");
        report.AppendLine("Value | Frequency | Deviation");
        
        foreach (var freq in result.FrequencyDistribution.OrderBy(f => f.Key))
        {
            float deviation = freq.Value - result.ExpectedFrequency;
            report.AppendLine($"{freq.Key,3} | {freq.Value,9} | {deviation,+9:F1}");
        }
        
        return report.ToString();
    }
    
    #endregion
    
    #if UNITY_EDITOR
    #region Unity Editor Integration
    
    [MenuItem("NumberGuessingGame/Validation/Run Statistical Test")]
    public static void RunValidationFromMenu()
    {
        var validator = FindObjectOfType<StatisticalValidator>();
        if (validator == null)
        {
            UnityEngine.Debug.LogError("StatisticalValidator not found in scene. Add StatisticalValidator component to a GameObject.");
            return;
        }
        
        UnityEngine.Debug.Log("Starting statistical validation from menu...");
        var result = validator.ValidateDistribution();
        
        UnityEngine.Debug.Log($"Statistical Test Results:\n{result.Summary}");
        
        if (validator.enableDetailedLogging)
        {
            UnityEngine.Debug.Log($"Detailed Results:\n{validator.GetFrequencyReport(result)}");
        }
    }
    
    [MenuItem("NumberGuessingGame/Validation/Run Large Sample Test (5000)")]
    public static void RunLargeSampleTest()
    {
        var validator = FindObjectOfType<StatisticalValidator>();
        if (validator == null)
        {
            UnityEngine.Debug.LogError("StatisticalValidator not found in scene.");
            return;
        }
        
        UnityEngine.Debug.Log("Starting large sample statistical validation (5000 samples)...");
        var result = validator.ValidateDistribution(5000);
        
        UnityEngine.Debug.Log($"Large Sample Test Results:\n{result.Summary}");
        UnityEngine.Debug.Log($"Execution time: {result.ExecutionTimeMs:F2}ms");
    }
    
    [MenuItem("NumberGuessingGame/Validation/Test With Debug Seed")]
    public static void TestWithDebugSeed()
    {
        var validator = FindObjectOfType<StatisticalValidator>();
        if (validator == null)
        {
            UnityEngine.Debug.LogError("StatisticalValidator not found in scene.");
            return;
        }
        
        UnityEngine.Debug.Log("Testing with deterministic seed (12345)...");
        var result = validator.ValidateWithSeed(12345, 1000);
        
        UnityEngine.Debug.Log($"Seeded Test Results:\n{result.Summary}");
    }
    
    [MenuItem("NumberGuessingGame/Validation/Show Last Results")]
    public static void ShowLastResults()
    {
        var validator = FindObjectOfType<StatisticalValidator>();
        if (validator == null)
        {
            UnityEngine.Debug.LogError("StatisticalValidator not found in scene.");
            return;
        }
        
        UnityEngine.Debug.Log($"Last Validation Results:\n{validator.LastResultSummary}");
    }
    
    #endregion
    #endif
}