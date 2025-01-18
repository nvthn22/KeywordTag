using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class GetTopKeywordsAction
    {
        private readonly ILogger<GetMessagesAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetTopKeywordsAction(ILogger<GetMessagesAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetKeywords()
        {
            var quantity = new SqlParameter("@Quantity", 1);
            var keywordsQuery = KeywordTagDB.KeywordViews.FromSqlRaw("EXEC kt.GetTopKeywords @Quantity", quantity).ToList();
            var keywords = keywordsQuery.Select(k => new KeywordOutput
            {
                code = k.code,
                name = k.name,
                online = k.online,
            });

            return new WrapResult(keywords);
        }
    }
}
