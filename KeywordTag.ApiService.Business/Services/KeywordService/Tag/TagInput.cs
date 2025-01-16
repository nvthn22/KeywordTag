namespace KeywordTag.ApiService.Business.Services.KeywordService.Tag
{
    public class TagInput
    {
        public Guid DeviceId { get; set; }
        public Guid KeywordId { get; set; }
        public int MessageId { get; set; }
    }
}
