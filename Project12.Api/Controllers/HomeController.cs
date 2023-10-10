using Microsoft.AspNetCore.Mvc;

namespace Project12.Api.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}