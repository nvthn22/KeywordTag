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
        private readonly GetKeywordAction _getKeywordAction;
        private readonly GetTopKeywordAction _getTopKeywordAction;
        private readonly TagAction _tagAction;

        public KeywordController(
            GetKeywordAction getKeywordAction,
            CheckinAction checkinAction,
            TagAction tagAction,
            GetTopKeywordAction getTopKeywordAction,
            ILogger<KeywordController> logger)
        {
            _getKeywordAction = getKeywordAction;
            _checkinAction = checkinAction;
            _getTopKeywordAction = getTopKeywordAction;
            _tagAction = tagAction;
            _logger = logger;
        }

        [HttpGet("gettopkeyword")]
        public ActionResult<WrapResult> GetTopKeyword()
        {
            var result = _getTopKeywordAction.GetKeyword();
            return result;
        }

        [HttpPost("getkeyword")]
        public ActionResult<WrapResult> GetKeyword([FromBody] GetKeywordInput input)
        {
            var result = _getKeywordAction.GetKeyword(input);
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
