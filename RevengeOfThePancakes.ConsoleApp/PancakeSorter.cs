using System;
using System.Linq;

namespace RevengeOfThePancakes.ConsoleApp
{
    public class PancakeSorter
    {
        private readonly InputValidator _inputValidator;
        private const string InvalidExceptionMessage = "Bad pancake string provided";
        
        public PancakeSorter(InputValidator inputValidator = null)
        {
            // Cute little hack makes this testable in the absence of going all out with DI
            // A real solution we'd create an interface and inject it, making it more easily mockable
            _inputValidator = inputValidator ?? new InputValidator();
        }
        
        public (string, int) Sort(string pancakeString, int attempts = 0)
        {
            if (! _inputValidator.IsValidPancakeString(pancakeString)) throw new Exception(InvalidExceptionMessage);
            
            // For most people, a while loop is easier to follow than recursion.
            // Since it's not super beneficial here to do recursion I did both.
            while (true)
            {
                if (pancakeString.Contains("-"))
                {
                    pancakeString = DoSort(pancakeString);
                    attempts++;
                    continue;
                }

                return (pancakeString, attempts);
            }
        }

        // If you really, actually, were looking for a recursive example
        public (string, int) SortRecursive(string pancakeString, int attempts = 0)
        {
            if (! _inputValidator.IsValidPancakeString(pancakeString)) throw new Exception(InvalidExceptionMessage);
            
            if (pancakeString.Contains("-"))
            {
                pancakeString = DoSort(pancakeString);
                attempts++;
                return SortRecursive(pancakeString, attempts);
            }
            
            return (pancakeString, attempts);
        }

        private string DoSort(string pancakeString)
        {
            var reversedPancake = new string(pancakeString.Reverse().ToArray());

            var firstNegativeCake = reversedPancake.IndexOf("-", StringComparison.Ordinal);
            var toSwap = reversedPancake.Substring(firstNegativeCake).ToCharArray(); // Substring() without a second parameter just reads to end of string
            for (var i = 0; i < toSwap.Length; i++)
            {
                toSwap[i] = toSwap[i].Equals('-') ? '+' : '-';
            }

            return new string(
                reversedPancake.Remove(firstNegativeCake) // .Remove() without a second parameter just removes to end of string
                               .Insert(firstNegativeCake, new string(toSwap))
                               .Reverse()
                               .ToArray());
        }
    }
}