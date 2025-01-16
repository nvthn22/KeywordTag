using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;

namespace KeywordTag.ApiService.Business.Services.MessageService.GetMessages
{
    public class GetMessagesAction
    {
        private readonly ILogger<GetMessagesAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetMessagesAction(ILogger<GetMessagesAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetMessages(GetMessagesInput input)
        {
            var messages = KeywordTagDB.Messages
                .Where(m => m.name.Contains(input.Filter))
                .Skip(input.Skip).Take(input.Take)
                .Select(m => new MessageUnitOutput
                {
                    code = m.code,
                    name = m.name,
                });

            var result = new MessageOutput
            {
                messages = messages
            };

            return new WrapResult(result);
        }
    }
}
