﻿using Microsoft.AspNetCore.Mvc;

namespace CRUD_IN_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
