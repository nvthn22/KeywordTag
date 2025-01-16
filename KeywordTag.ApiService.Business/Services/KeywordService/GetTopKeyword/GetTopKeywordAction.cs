using KeywordTag.ApiService.Business.Exceptions;
using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class GetTopKeywordAction
    {
        private readonly ILogger<GetMessagesAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetTopKeywordAction(ILogger<GetMessagesAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetKeyword()
        {
            var topKeyword = KeywordTagDB.TopKeywordIdView.FirstOrDefault();
            if (topKeyword == null)
            {
                var nodata = new WrapResult()
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = KeywordExMessages.NoTopKeyword,
                };
                return nodata;
            }

            var keyword = KeywordTagDB.Keywords.First(x => x.code == topKeyword.Code);

            var result = new KeywordOutput
            {
                code = keyword.code,
                name = keyword.name,
                online = topKeyword.Count,
            };

            return new WrapResult(result);
        }
    }
}
