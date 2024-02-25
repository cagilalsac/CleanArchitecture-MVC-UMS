﻿using Microsoft.AspNetCore.Mvc;
using Persistence.Seeds;
using System.Text;

namespace MVC.Controllers
{
    public class DbController : Controller
    {
        public IActionResult Seed()
        {
            SeedDb seedDb = new SeedDb();
            seedDb.Initialize();
            return Content("<label style=\"color:red;\"><b>Database seed successful.</b></label>", "text/html", Encoding.UTF8);
        }
    }
}
