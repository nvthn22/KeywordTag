using KeywordTag.ApiService.Business.ShareModels.Output;

namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class GetUserKeywordsOutput
    {
        public IEnumerable<KeywordOutput> keywords { get; set; }
    }
}
