using Microsoft.AspNetCore.Mvc;

namespace KeywordTag.ApiService.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            var text = "Hello world!";
            return new ActionResult<string>(text);
        }
    }
}
