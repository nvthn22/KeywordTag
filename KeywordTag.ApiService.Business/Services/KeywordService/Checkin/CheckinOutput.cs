using KeywordTag.ApiService.Business.Services.MessageService.GetMessages;

namespace KeywordTag.ApiService.Business.Services.KeywordService.Checkin
{
    public class CheckinOutput
    {
        public int countLast10Minutes { get; set; }
        public IEnumerable<MessageUnitOutput> messages { get; set; }
    }
}
