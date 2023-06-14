namespace Fatec.Domain.Constants
{
    public static class ErrorMessageConstants
    {
        public const string RequiredField = "Required Field.";

        public static string InvalidField(string field) => $"{field} is invalid.";
    }
}
