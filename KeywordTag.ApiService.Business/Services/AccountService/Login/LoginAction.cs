using KeywordTag.ApiService.Business.Exceptions;
using KeywordTag.ApiService.Business.ShareModels.Output;
using KeywordTag.Database.SQLServer.Contexts;
using KeywordTag.Database.SQLServer.Tables;
using System.Net;

namespace KeywordTag.ApiService.Business.Services.AccountService.Login
{
    public class LoginAction
    {
        private readonly ILogger<LoginAction> _logger;
        private readonly KeywordTagContext KeywordTagDB;

        public LoginAction(ILogger<LoginAction> logger, KeywordTagContext keywordTagDB)
        {
            _logger = logger;
            KeywordTagDB = keywordTagDB;
        }

        public WrapResult Login(LoginInput input)
        {
            var device = KeywordTagDB.Devices.Find(input.Email);
            if (device == null)
            {
                var nodevice = new WrapResult
                {
                    Code = HttpStatusCode.NotFound,
                    Message = DeviceExMessages.DeviceNotFound
                };
                return nodevice;
            }

            if (input.Pin == device.email_pin)
            {
                var loginOutput = new LoginOutput
                {
                    id = device.code,
                    list_keyword = device.list_keyword,
                    list_keyword_tagged = device.list_keyword_tagged,
                };

                return new WrapResult(loginOutput);
            }
            else
            {
                return new WrapResult
                {
                    Code = HttpStatusCode.NotFound,
                    Message = LoginExMessages.WrongPin,
                };
            }
        }
    }
}
