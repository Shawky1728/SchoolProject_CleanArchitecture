using System.Globalization;

namespace SchoolProject.Data.Shared
{
    public class LocalizableEntity
    {
        public string GetLocalizedValue(string valueAr, string valueEn)
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
