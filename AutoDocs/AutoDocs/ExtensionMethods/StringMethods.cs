namespace AutoDocs.ExtensionMethods
{
    public static class StringMethods
    {
        public static string SplitOnUpperCase (
            this string input, 
            bool splitOnUnderScore = true, 
            bool capitalizeFirstLetter = true, 
            bool capitalizeOnlyFirstWord = false )
        {
            // Remove leading underscore e.g: _HelloWorld -> hello World
            if (input.StartsWith("_"))
            {
                input = input.Substring(1);
            }

            // Replace consecutive underscores with single space
            if (splitOnUnderScore)
            {
                input = System.Text.RegularExpressions.Regex.Replace(input, "[_]+", " ");
            }

            string pattern = splitOnUnderScore 
                ? "(?<=[a-z0-9])[_A-Z]" 
                : "(?<=[a-z0-9])[A-Z]";

            string replaced = System.Text.RegularExpressions.Regex.Replace(
                input, pattern, m => m.Value == "_" ? " " : " " + m.Value, 
                System.Text.RegularExpressions.RegexOptions.Compiled
            );

            if (capitalizeFirstLetter)
            {
                replaced = char.ToUpper(replaced[0]) + replaced.Substring(1);
            }

            if (capitalizeOnlyFirstWord)
            {
                replaced = char.ToUpper(replaced[0]) + replaced.Substring(1).ToLower();
            }

            return replaced.Trim();

        }
    }
}