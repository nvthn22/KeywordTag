using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using System.Net.WebSockets;

namespace KeywordTag.ApiService.Business.Services.KeywordService.Checkin
{
    public class CheckinAction
    {
        private readonly ILogger<CheckinAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public CheckinAction(ILogger<CheckinAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult Checkin(CheckinInput input)
        {
            var checkin = KeywordTagDB.Checkins.Where(c => c.code_device == input.Id && c.code_keyword == input.KeywordId).FirstOrDefault();
            if (checkin == null)
            {
                checkin = new Database.SQLServer.Tables.Checkin
                {
                    code = Guid.NewGuid(),
                    code_device = input.Id,
                    code_keyword = input.KeywordId,
                };
            }

            checkin.code_keyword = input.KeywordId;
            checkin.checkintime = DateTime.UtcNow;
            KeywordTagDB.SaveChanges();

            var last10Minutes = DateTime.UtcNow.AddMinutes(-10);
            var countLast10Minutes = KeywordTagDB.Checkins
                .Count(c => c.code_keyword.Equals(input.KeywordId) && c.checkintime >= last10Minutes);

            var messagesIds = KeywordTagDB.Tags.Where(t => t.code_keyword == input.KeywordId).Select(t => t.code_message).Distinct();
            var messages = KeywordTagDB.Messages.Where(m => messagesIds.Contains(m.code))
                .Select(m => new MessageService.GetMessages.MessageUnitOutput
                {
                    code = m.code,
                    name = m.name,
                });

            var result = new CheckinOutput
            {
                countLast10Minutes = countLast10Minutes,
                messages = messages
            };

            return new WrapResult(result);
        }
    }
}
