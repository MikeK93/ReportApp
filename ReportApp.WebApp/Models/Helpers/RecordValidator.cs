using System;
using System.Linq;

namespace ReportApp.Models.Helpers
{
    public static class RecordValidator
    {
        private static Func<char, bool> NameValidationRuleExpression
        {
            get { return c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || char.IsWhiteSpace(c); }
        }

        public static bool IsDescriptionValid(string value)
        {
            if (value == null)
                return false;

            value = value.Trim();
            return value.Length <= 400 && value.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '!' || c == '?' || c == '.' || c == ',' || char.IsWhiteSpace(c));
        }

        public static bool IsNameValid(string value)
        {
            if (value == null)
                return false;

            value = value.Trim();
            return value.Length <= 50 && value.All(NameValidationRuleExpression);
        }
    }
}