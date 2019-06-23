using Microsoft.AspNetCore.Mvc;

namespace GymWebAPI.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            return View();
        }
    }
}
