using Microsoft.AspNetCore.Mvc;
using TextMatcher.Services;

namespace TextMatcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextMatcherController : ControllerBase
    {
        private readonly ITextMatcherService _textMatchingService;
        public TextMatcherController(ITextMatcherService textMatchingService)
        {
            _textMatchingService = textMatchingService;
        }

        [HttpGet]
        public string Get(string textString, string subTextString)
        {
            return _textMatchingService.FindMatchingStringCharacterPositions(textString, subTextString);
        }
    }
}
