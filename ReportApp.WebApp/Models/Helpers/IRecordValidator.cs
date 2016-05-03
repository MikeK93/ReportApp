namespace ReportApp.WebApp.Models.Helpers
{
    public interface IRecordValidator
    {
        bool IsDescriptionValid(string value);

        bool IsNameValid(string value);
    }
}