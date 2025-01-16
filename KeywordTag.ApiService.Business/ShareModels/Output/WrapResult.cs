using System.Net;

namespace KeywordTag.ApiService.Business.ShareModels.Output
{
    public class WrapResult
    {
        public HttpStatusCode Code { get; set; }
        public string? Message { get; set; }
        public object? Value { get; set; }

        public WrapResult() { }

        public WrapResult(object value)
        {
            Code = HttpStatusCode.OK;
            Value = value;
        }

        public WrapResult(HttpStatusCode code, object value)
        {
            Code = code;
            Value = value;
        }
    }
}
