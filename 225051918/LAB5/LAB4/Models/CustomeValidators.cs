using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB4.Models
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords) { _maxWords = maxWords; }
        public override bool IsValid(object value)
        {
            var s = (value as string);
            if (string.IsNullOrWhiteSpace(s)) return true;
            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length <= _maxWords;
        }
    }

    public class NotEqualAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;
        public NotEqualAttribute(string otherProperty) { _otherProperty = otherProperty; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var other = validationContext.ObjectType.GetProperty(_otherProperty)?.GetValue(validationContext.ObjectInstance, null) as string;
            var thisVal = value as string;
            if (!string.IsNullOrEmpty(thisVal) && !string.IsNullOrEmpty(other) && string.Equals(thisVal.Trim(), other.Trim(), StringComparison.OrdinalIgnoreCase))
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly int _minYear;
        public DateRangeAttribute(int minYear) { _minYear = minYear; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime dt)) return new ValidationResult("Invalid date");
            var min = new DateTime(_minYear, 1, 1);
            var max = DateTime.Today;
            if (dt < min || dt > max) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class HireDateRangeAttribute : ValidationAttribute
    {
        private readonly int _maxYearsAgo;
        public HireDateRangeAttribute(int maxYearsAgo) { _maxYearsAgo = maxYearsAgo; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime dt)) return new ValidationResult("Invalid date");
            var min = DateTime.Today.AddYears(-_maxYearsAgo);
            var max = DateTime.Today;
            if (dt < min || dt > max) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }

    public class StartDateRangeAttribute : ValidationAttribute
    {
        private readonly int _maxYearsAgo;
        public StartDateRangeAttribute(int maxYearsAgo) { _maxYearsAgo = maxYearsAgo; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime dt)) return new ValidationResult("Invalid date");
            var min = DateTime.Today.AddYears(-_maxYearsAgo);
            var max = DateTime.Today;
            if (dt < min || dt > max) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}