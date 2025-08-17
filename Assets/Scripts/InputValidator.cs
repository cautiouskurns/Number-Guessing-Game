using System;
using System.Collections.Generic;
using UnityEngine;

namespace NumberGuessingGame.InputSystem
{
    /// <summary>
    /// Static utility class for comprehensive input validation in the number guessing game.
    /// Provides safe number parsing, range checking, duplicate detection, and user-friendly error messaging.
    /// </summary>
    public static class InputValidator
    {
        #region Constants
        /// <summary>
        /// Minimum valid guess value (inclusive)
        /// </summary>
        public const int MIN_GUESS_VALUE = 1;
        
        /// <summary>
        /// Maximum valid guess value (inclusive)
        /// </summary>
        public const int MAX_GUESS_VALUE = 100;
        #endregion

        #region Core Validation Methods
        /// <summary>
        /// Safely parses a string input to an integer with comprehensive error handling
        /// </summary>
        /// <param name="input">The string input to parse</param>
        /// <param name="result">The parsed integer result if successful</param>
        /// <returns>True if parsing was successful, false otherwise</returns>
        public static bool IsValidNumber(string input, out int result)
        {
            result = 0;
            
            // Handle null or empty input
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            
            // Trim whitespace for user convenience
            string trimmedInput = input.Trim();
            
            // Handle empty string after trimming
            if (string.IsNullOrEmpty(trimmedInput))
            {
                return false;
            }
            
            // Use int.TryParse for safe conversion
            return int.TryParse(trimmedInput, out result);
        }

        /// <summary>
        /// Validates that a number falls within the specified range (inclusive)
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">Minimum valid value (inclusive)</param>
        /// <param name="max">Maximum valid value (inclusive)</param>
        /// <returns>True if value is within range, false otherwise</returns>
        public static bool IsInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Checks if a guess value has not been used before in the current session
        /// </summary>
        /// <param name="value">The guess value to check</param>
        /// <param name="previousGuesses">List of previously made guesses</param>
        /// <returns>True if the guess is unique, false if it's a duplicate</returns>
        public static bool IsUniqueGuess(int value, List<int> previousGuesses)
        {
            // Handle null list gracefully
            if (previousGuesses == null)
            {
                return true;
            }
            
            // Check if the value already exists in the list
            return !previousGuesses.Contains(value);
        }

        /// <summary>
        /// Generates user-friendly error messages for different validation error types
        /// </summary>
        /// <param name="errorType">The type of validation error</param>
        /// <returns>A clear, actionable error message for the player</returns>
        public static string GetValidationMessage(ValidationError errorType)
        {
            switch (errorType)
            {
                case ValidationError.None:
                    return string.Empty;
                    
                case ValidationError.EmptyInput:
                    return "Please enter a number to make your guess.";
                    
                case ValidationError.InvalidFormat:
                    return "Please enter a valid whole number (no letters or special characters).";
                    
                case ValidationError.OutOfRange:
                    return $"Please enter a number between {MIN_GUESS_VALUE} and {MAX_GUESS_VALUE}.";
                    
                case ValidationError.DuplicateGuess:
                    return "You've already guessed that number. Try a different one!";
                    
                default:
                    return "Invalid input. Please try again.";
            }
        }
        #endregion

        #region Main Validation Method
        /// <summary>
        /// Performs comprehensive validation of a guess input, combining all validation checks
        /// </summary>
        /// <param name="input">The raw string input from the player</param>
        /// <param name="previousGuesses">List of previously made guesses in the current session</param>
        /// <returns>An InputValidation struct containing the validation result and details</returns>
        public static InputValidation ValidateGuess(string input, List<int> previousGuesses)
        {
            // Check for empty input first
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim()))
            {
                return InputValidation.CreateInvalid(
                    ValidationError.EmptyInput,
                    GetValidationMessage(ValidationError.EmptyInput),
                    ValidationLevel.Error
                );
            }

            // Attempt to parse the number
            if (!IsValidNumber(input, out int parsedValue))
            {
                return InputValidation.CreateInvalid(
                    ValidationError.InvalidFormat,
                    GetValidationMessage(ValidationError.InvalidFormat),
                    ValidationLevel.Error
                );
            }

            // Check if the number is within valid range
            if (!IsInRange(parsedValue, MIN_GUESS_VALUE, MAX_GUESS_VALUE))
            {
                return InputValidation.CreateInvalid(
                    ValidationError.OutOfRange,
                    GetValidationMessage(ValidationError.OutOfRange),
                    ValidationLevel.Error
                );
            }

            // Check for duplicate guesses
            if (!IsUniqueGuess(parsedValue, previousGuesses))
            {
                return InputValidation.CreateInvalid(
                    ValidationError.DuplicateGuess,
                    GetValidationMessage(ValidationError.DuplicateGuess),
                    ValidationLevel.Warning
                );
            }

            // All validations passed
            return InputValidation.CreateValid(parsedValue);
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Quick validation check to determine if input can be submitted
        /// </summary>
        /// <param name="input">The input string to validate</param>
        /// <param name="previousGuesses">List of previous guesses</param>
        /// <returns>True if input is valid and can be submitted</returns>
        public static bool CanSubmitInput(string input, List<int> previousGuesses)
        {
            return ValidateGuess(input, previousGuesses).IsValid;
        }

        /// <summary>
        /// Gets the validation level for UI feedback without full validation
        /// </summary>
        /// <param name="input">The input string to check</param>
        /// <returns>ValidationLevel indicating the severity of any issues</returns>
        public static ValidationLevel GetInputValidationLevel(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim()))
            {
                return ValidationLevel.Error;
            }

            if (!IsValidNumber(input, out int parsedValue))
            {
                return ValidationLevel.Error;
            }

            if (!IsInRange(parsedValue, MIN_GUESS_VALUE, MAX_GUESS_VALUE))
            {
                return ValidationLevel.Error;
            }

            return ValidationLevel.Valid;
        }
        #endregion
    }
}