using KeywordTag.ApiService.Business.Services.AccountService.GetPincode;
using KeywordTag.ApiService.Business.Services.AccountService.Login;
using KeywordTag.ApiService.Business.ShareModels.Output;
using Microsoft.AspNetCore.Mvc;

namespace KeywordTag.ApiService.Business.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly LoginAction _loginAction;
        private readonly GetPincodeAction _getPincodeAction;

        public AccountController(ILogger<AccountController> logger,
            LoginAction loginAction,
            GetPincodeAction getPincodeAction)
        {
            _logger = logger;
            _loginAction = loginAction;
            _getPincodeAction = getPincodeAction;
        }

        [HttpPost("login")]
        public ActionResult<WrapResult> Login([FromBody] LoginInput input)
        {
            var result = _loginAction.Login(input);
            return result;
        }

        [HttpPost("getpincode")]
        public ActionResult<WrapResult> GetPincode([FromBody] GetPincodeInput input)
        {
            var result = _getPincodeAction.GetPincode(input);
            return result;
        }
    }
}
