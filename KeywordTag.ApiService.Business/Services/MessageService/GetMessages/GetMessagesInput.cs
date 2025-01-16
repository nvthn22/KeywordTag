namespace KeywordTag.ApiService.Business.Services.MessageService.GetMessages
{
    public class GetMessagesInput
    {
        public string Filter { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
