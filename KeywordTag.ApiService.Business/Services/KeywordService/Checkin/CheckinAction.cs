using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;

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
            var checkin = KeywordTagDB.Checkins.Find(input.DeviceId, input.KeywordId);
            if (checkin == null)
            {
                checkin = new Database.SQLServer.Tables.Checkin
                {
                    code = Guid.NewGuid(),
                    code_device = input.DeviceId,
                    code_keyword = input.KeywordId,
                };

                checkin.checkintime = DateTime.UtcNow;
                KeywordTagDB.Checkins.Add(checkin);
            }

            var last10Minutes = DateTime.UtcNow.AddMinutes(-10);
            var countLast10Minutes = KeywordTagDB.Checkins
                .Count(c => c.code_keyword.Equals(input.KeywordId) && c.checkintime >= last10Minutes);

            var result = new CheckinOutput
            {
                countLast10Minutes = countLast10Minutes,
            };

            return new WrapResult(result);
        }
    }
}
