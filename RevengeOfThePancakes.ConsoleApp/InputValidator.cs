using System.Text.RegularExpressions;

namespace RevengeOfThePancakes.ConsoleApp
{
    public class InputValidator
    {
        public bool IsValidPancakeString(string pancakeString)
        {
            if (! string.IsNullOrEmpty(pancakeString) && pancakeString.Length <= 100)
            {
                return Regex.Match(pancakeString, "^[-+]+$").Success;
            }

            return false;
        }
    }
}