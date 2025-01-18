using KeywordTag.ApiService.Business.Exceptions;
using KeywordTag.ApiService.Business.Services.KeywordService.AddKeyword;
using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using KeywordTag.Database.SQLServer.Tables;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class AddKeywordAction
    {
        private readonly ILogger<GetMessagesAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public AddKeywordAction(ILogger<GetMessagesAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult AddKeyword(AddKeywordInput input)
        {
            var keyword = KeywordTagDB.Keywords.FirstOrDefault(k => k.name == input.Name);
            var device = KeywordTagDB.Devices.FirstOrDefault(d => d.code == input.Id);

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
            KeywordTagDB.SaveChanges();

            var result = new AddKeywordOutput
            {
                KeywordIds = device.list_keyword
            };

            return new WrapResult(result);
        }
    }
}
