using System;
using UnityEngine;

namespace NumberGuessingGame.InputSystem
{
    /// <summary>
    /// Represents the type of validation error that occurred during input processing
    /// </summary>
    [System.Serializable]
    public enum ValidationError
    {
        None = 0,
        InvalidFormat = 1,
        OutOfRange = 2,
        DuplicateGuess = 3,
        EmptyInput = 4
    }

    /// <summary>
    /// Represents the outcome of comparing a guess against the target number
    /// </summary>
    [System.Serializable]
    public enum GuessOutcome
    {
        Higher = 0,     // Guess is too low, target is higher
        Lower = 1,      // Guess is too high, target is lower
        Correct = 2,    // Guess matches target exactly
        Invalid = 3     // Guess could not be processed
    }

    /// <summary>
    /// Represents the severity level of validation feedback for UI color coding
    /// </summary>
    [System.Serializable]
    public enum ValidationLevel
    {
        Valid = 0,      // Input is valid (green feedback)
        Warning = 1,    // Input has warnings (yellow feedback)
        Error = 2       // Input has errors (red feedback)
    }

    /// <summary>
    /// Encapsulates the result of input validation with error details and parsed value
    /// </summary>
    [System.Serializable]
    public struct InputValidation
    {
        [Header("Validation Result")]
        public bool IsValid;
        public int ParsedValue;
        
        [Header("Error Information")]
        public ValidationError ErrorType;
        public string ErrorMessage;
        public ValidationLevel Severity;

        /// <summary>
        /// Creates a valid InputValidation result
        /// </summary>
        public static InputValidation CreateValid(int parsedValue)
        {
            return new InputValidation
            {
                IsValid = true,
                ParsedValue = parsedValue,
                ErrorType = ValidationError.None,
                ErrorMessage = string.Empty,
                Severity = ValidationLevel.Valid
            };
        }

        /// <summary>
        /// Creates an invalid InputValidation result with error details
        /// </summary>
        public static InputValidation CreateInvalid(ValidationError errorType, string errorMessage, ValidationLevel severity = ValidationLevel.Error)
        {
            return new InputValidation
            {
                IsValid = false,
                ParsedValue = 0,
                ErrorType = errorType,
                ErrorMessage = errorMessage,
                Severity = severity
            };
        }

        /// <summary>
        /// Returns a string representation for debugging purposes
        /// </summary>
        public override string ToString()
        {
            if (IsValid)
            {
                return $"Valid: {ParsedValue}";
            }
            return $"Invalid: {ErrorType} - {ErrorMessage} (Severity: {Severity})";
        }
    }

    /// <summary>
    /// Encapsulates the complete result of a guess attempt including outcome and game state
    /// </summary>
    [System.Serializable]
    public struct GuessResult
    {
        [Header("Guess Information")]
        public int GuessValue;
        public GuessOutcome Outcome;
        public string FeedbackText;
        
        [Header("Game State")]
        public int AttemptsRemaining;
        public bool GameEnded;
        public DateTime Timestamp;

        /// <summary>
        /// Creates a GuessResult for a processed guess
        /// </summary>
        public static GuessResult Create(int guessValue, GuessOutcome outcome, string feedbackText, int attemptsRemaining, bool gameEnded)
        {
            return new GuessResult
            {
                GuessValue = guessValue,
                Outcome = outcome,
                FeedbackText = feedbackText,
                AttemptsRemaining = attemptsRemaining,
                GameEnded = gameEnded,
                Timestamp = DateTime.Now
            };
        }

        /// <summary>
        /// Creates a GuessResult for an invalid guess
        /// </summary>
        public static GuessResult CreateInvalid(string feedbackText, int attemptsRemaining)
        {
            return new GuessResult
            {
                GuessValue = 0,
                Outcome = GuessOutcome.Invalid,
                FeedbackText = feedbackText,
                AttemptsRemaining = attemptsRemaining,
                GameEnded = false,
                Timestamp = DateTime.Now
            };
        }

        /// <summary>
        /// Returns a string representation for debugging purposes
        /// </summary>
        public override string ToString()
        {
            return $"Guess: {GuessValue} | Outcome: {Outcome} | Feedback: {FeedbackText} | Attempts Left: {AttemptsRemaining} | Game Ended: {GameEnded} | Time: {Timestamp:HH:mm:ss}";
        }
    }
}