namespace KeywordTag.ApiService.Business.Services.KeywordService.GetKeyword
{
    public class KeywordOutput
    {
        public Guid code { get; set; }
        public string name { get; set; }
        public int online { get; set; } = 2;
    }
}
