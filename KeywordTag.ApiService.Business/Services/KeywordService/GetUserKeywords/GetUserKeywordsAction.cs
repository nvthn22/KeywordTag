using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class GetUserKeywordsAction
    {
        private readonly ILogger<GetUserKeywordsAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetUserKeywordsAction(ILogger<GetUserKeywordsAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetUserKeywords(GetUserKeywordsInput input)
        {
            var keywordIds = new SqlParameter("@KeywordIds", input.KeywordIds);
            var keywordsQuery = KeywordTagDB.KeywordViews.FromSqlRaw("kt.GetUserKeywords @KeywordIds", keywordIds).ToList();
            var keywords = keywordsQuery.Select(k => new KeywordOutput
            {
                code = k.code,
                name = k.name,
                online = k.online,
            });

            var result = new GetUserKeywordsOutput
            {
                keywords = keywords.AsEnumerable(),
            };

            return new WrapResult(result);
        }
    }
}
