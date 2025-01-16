using KeywordTag.ApiService.Business.Services.AccountService.Login;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using KeywordTag.Database.SQLServer.Tables;

namespace KeywordTag.ApiService.Business.Services.AccountService.GetPincode
{
    public class GetPincodeAction
    {
        private readonly ILogger<GetPincodeAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public GetPincodeAction(ILogger<GetPincodeAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult GetPincode(GetPincodeInput input)
        {
            var device = KeywordTagDB.Devices.Find(input.Email);

            if (device == null)
            {
                device = new Device
                {
                    code = Guid.NewGuid(),
                    email = input.Email,
                    email_pin = 123,
                    list_keyword = ";",
                    list_keyword_tagged = ";",
                };

                KeywordTagDB.Devices.Add(device);
            }

            var result = new WrapResult()
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Vui lòng check email của bạn để lấy mã pin."
            };

            return result;
        }
    }
}
