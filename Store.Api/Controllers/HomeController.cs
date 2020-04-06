using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello World";
        }
    }
}