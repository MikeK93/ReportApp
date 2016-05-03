using System;
using System.Linq;

namespace ReportApp.WebApp.Models.Helpers
{
    public class RecordValidator : IRecordValidator
    {
        public bool IsDescriptionValid(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            value = value.Trim();
            return value.Length <= 400 && value.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '!' || c == '?' || c == '.' || c == ',' || char.IsWhiteSpace(c));
        }

        public bool IsNameValid(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            value = value.Trim();
            return value.Length <= 50 && value.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '-' || char.IsWhiteSpace(c));
        }
    }
}