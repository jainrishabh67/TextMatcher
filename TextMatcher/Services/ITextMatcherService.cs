namespace TextMatcher.Services
{
    public interface ITextMatcherService
    {
        string FindMatchingStringCharacterPositions(string mainText, string subText);
    }
}
