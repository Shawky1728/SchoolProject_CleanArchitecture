using System.Globalization;

namespace SchoolProject.Core.Shared.Extensions
{
    public static class LocalizationExtensions
    {
        public static string GetLocalizedValue(string valueAr, string valueEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
            {
                return valueAr;
            }
            return valueEn;
        }
    }
}
