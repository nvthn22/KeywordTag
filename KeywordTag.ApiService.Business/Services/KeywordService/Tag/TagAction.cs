using KeywordTag.ApiService.Business.Exceptions;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;

namespace KeywordTag.ApiService.Business.Services.KeywordService.Tag
{
    public class TagAction
    {
        private readonly ILogger<TagAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public TagAction(ILogger<TagAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult Tag(TagInput input)
        {
            var device = KeywordTagDB.Devices.Find(input.DeviceId);
            if (device == null)
            {
                return new WrapResult
                {
                    Code = System.Net.HttpStatusCode.NotFound,
                    Message = DeviceExMessages.DeviceNotFound,
                };
            }

            var tag = KeywordTagDB.Tags.Find(input.DeviceId, input.KeywordId);
            if (tag == null)
            {
                tag = new Database.SQLServer.Tables.Tag
                {
                    code = input.DeviceId,
                    code_keyword = input.KeywordId,
                    code_message = input.MessageId,
                    tagtime = DateTime.UtcNow,
                };

                KeywordTagDB.Tags.Add(tag);
            }

            return new WrapResult(true);
        }
    }
}
