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


        [HttpGet]
        [Route("Home/api/gym")]
        public IActionResult Gym()
        {
            var result = new
            {
                name = "Gym API",
                address = "Mendoza 452 Rosario, Santa Fe, Argentina.",
                phoneNumber = "+54 (341) 000 0000 00",
                email = "gymapi@hotmail.com",
                webSite = "gymapi.com.ar"
            };
            return Ok(result);

        }
    }
}
