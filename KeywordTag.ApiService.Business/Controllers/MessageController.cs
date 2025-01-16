using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.ApiService.Business.ShareModels.Output;
using Microsoft.AspNetCore.Mvc;

namespace KeywordTag.ApiService.Business.Controllers
{
    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly GetMessagesAction _getMessagesAction;

        public MessageController(GetMessagesAction getMessagesAction, ILogger<MessageController> logger)
        {
            _getMessagesAction = getMessagesAction;
            _logger = logger;
        }

        [HttpPost("msg")]
        public ActionResult<WrapResult> GetMessages([FromBody] GetMessagesInput input)
        {
            input.Skip = 0;
            input.Take = 10;
            var result = _getMessagesAction.GetMessages(input);

            return result;
        }
    }
}
