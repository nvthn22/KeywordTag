namespace KeywordTag.ApiService.Business.Services.MessageService.GetMessages
{
    public class MessageOutput
    {
        public IEnumerable<MessageUnitOutput> messages { get; set; }
    }

    public class MessageUnitOutput
    {
        public int code { get; set; }
        public string name { get; set; }
    }
}
