using Microsoft.AspNetCore.Mvc;
using GymWebAPI.Models;

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

        [HttpGet]
        [Route("Home/api/gym")]
        public IActionResult Gym()
        {
            var result = GymSingleton.Instance;
            return Ok(result);
        }
    }
}
