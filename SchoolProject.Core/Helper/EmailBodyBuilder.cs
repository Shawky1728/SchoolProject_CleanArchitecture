namespace SchoolProject.Core.Helper
{
    public static class EmailBodyBuilder
    {
        public static string GenerateEmailBody(
            string template,
            Dictionary<string, string> templateValues)
        {
            var templatePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Templates",
                $"{template}.html");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Template '{template}.html' was not found.");

            using var streamReader = new StreamReader(templatePath);

            var body = streamReader.ReadToEnd();

            foreach (var item in templateValues)
            {
                body = body.Replace(item.Key, item.Value);
            }

            return body;
        }
    }
}
