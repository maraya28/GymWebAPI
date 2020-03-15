﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
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