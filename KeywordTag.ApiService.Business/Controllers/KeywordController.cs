using KeywordTag.ApiService.Business.Services.KeywordService.Checkin;
using KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword;
using KeywordTag.ApiService.Business.Services.KeywordService.Tag;
using KeywordTag.ApiService.Business.ShareModels.Output;
using Microsoft.AspNetCore.Mvc;

namespace KeywordTag.ApiService.Business.Controllers
{
    [ApiController]
    [Route("keyword")]
    public class KeywordController : ControllerBase
    {
        private readonly ILogger<KeywordController> _logger;
        private readonly CheckinAction _checkinAction;
        private readonly AddKeywordAction _addKeywordAction;
        private readonly GetTopKeywordsAction _getTopKeywordAction;
        private readonly GetUserKeywordsAction _getUserKeywordsAction;
        private readonly TagAction _tagAction;

        public KeywordController(
            AddKeywordAction addKeywordAction,
            CheckinAction checkinAction,
            TagAction tagAction,
            GetTopKeywordsAction getTopKeywordAction,
            GetUserKeywordsAction getUserKeywordsAction,
            ILogger<KeywordController> logger)
        {
            _addKeywordAction = addKeywordAction;
            _checkinAction = checkinAction;
            _getTopKeywordAction = getTopKeywordAction;
            _getUserKeywordsAction = getUserKeywordsAction;
            _tagAction = tagAction;
            _logger = logger;
        }

        [HttpGet("gettopkeywords")]
        public ActionResult<WrapResult> GetTopKeywords()
        {
            var result = _getTopKeywordAction.GetKeywords();
            return result;
        }

        [HttpPost("addkeyword")]
        public ActionResult<WrapResult> AddKeyword([FromBody] AddKeywordInput input)
        {
            var result = _addKeywordAction.AddKeyword(input);
            return result;
        }

        [HttpPost("getuserkeywords")]
        public ActionResult<WrapResult> GetUserKeywords([FromBody] GetUserKeywordsInput input)
        {
            var result = _getUserKeywordsAction.GetUserKeywords(input);
            return result;
        }

        [HttpPost("checkin")]
        public ActionResult<WrapResult> Checkin([FromBody] CheckinInput input)
        {
            var result = _checkinAction.Checkin(input);
            return result;
        }

        [HttpPost("tag")]
        public ActionResult<WrapResult> Tag([FromBody] TagInput input)
        {
            var result = _tagAction.Tag(input);
            return result;
        }
    }
}
