namespace TextMatcher.Services
{
    using System.Text;

    /// <summary>
    /// Handler to match the sub-string against main string
    /// </summary>
    public class TextMatcherService : ITextMatcherService
    {
        public string FindMatchingStringCharacterPositions(string inputText, string subText)
        {
            // Check empty or null string occurences
            if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(subText))
            {
                return "Either one or both of the string(s) are blank or null";
            }

            var matchResult = FindMatchesOfString(inputText, subText);

            if (string.IsNullOrEmpty(matchResult))
            {
                return "No string matched..";
            }

            return matchResult;
        }

        public bool IsCaseInsensitiveCharacterMatching(char a, char b)
        {
            return char.ToLower(a) == char.ToLower(b);
        }

        private string FindMatchesOfString(string inputText, string subText)
        {
            var output = new StringBuilder();

            var inputTextSize = inputText.Length;
            var subTextSize = subText.Length;

            // Mark the current Index for both of the input strings
            // index in c# strings array starts from 0
            var inputTextMarker = 0;
            var subTextMarker = 0;

            while (true)
            {
                // break the loop when reached to the end of the mainText
                if (inputTextMarker == inputTextSize)
                {
                    break;
                }

                // if the current character of the text "expands" the current match 
                if (IsCaseInsensitiveCharacterMatching(inputText[inputTextMarker], subText[subTextMarker]))
                {
                    subTextMarker++; // move to the next subText character
                    inputTextMarker++; // move to the next inputText character

                    // reached till the end of the the subText
                    if (subTextMarker == subTextSize)
                    {
                        output.AppendFormat("{0},", (inputTextMarker - subTextSize) + 1);

                        // reset subText marker, so we can keep looking
                        subTextMarker = 0;
                    }
                }

                // if the current state is not zero (we have not reached the empty string yet) we try to
                // "expand" the next best (largest) match
                else if (subTextMarker > 0)
                {
                    subTextMarker = 0;
                }

                // if we reached the empty string and failed to "expand" even it; we go to the next 
                // character from the text, the state of the automation remains zero
                else
                {
                    inputTextMarker++;
                }
            }

            return output.ToString().TrimEnd(',');
        }
    }
}