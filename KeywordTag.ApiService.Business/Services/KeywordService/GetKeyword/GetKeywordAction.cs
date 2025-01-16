using KeywordTag.ApiService.Business.Exceptions;
using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using KeywordTag.Database.SQLServer.Tables;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class GetKeywordAction
    {
        private readonly ILogger<GetMessagesAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetKeywordAction(ILogger<GetMessagesAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetKeyword(GetKeywordInput input)
        {
            var keyword = KeywordTagDB.Keywords.FirstOrDefault(k => k.name == input.Name);
            var device = KeywordTagDB.Devices.FirstOrDefault(d => d.code == input.DevicedId);

            if (device == null)
            {
                return new WrapResult
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = DeviceExMessages.DeviceNotFound,
                };
            }

            if (keyword == null)
            {
                keyword = new Keyword
                {
                    code = Guid.NewGuid(),
                    name = input.Name
                };

                KeywordTagDB.Keywords.Add(keyword);
            }

            if (!device.list_keyword.Contains(";" + keyword.code + ";"))
            {
                device.list_keyword += keyword.code + ";";
            }

            var result = new KeywordOutput
            {
                code = keyword.code,
                name = keyword.name,
            };

            return new WrapResult(result);
        }
    }
}
