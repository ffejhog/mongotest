using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTDDesignMongoDemo.Database;
using UTDDesignMongoDemo.Models;

namespace UTDDesignMongoDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save()
        {
            ViewData["Message"] = "Save stuff here";

            return View();
        }

        public IActionResult Read()
        {
            ViewData["Message"] = "Read Stuff here";

            return View();
        }

        public IActionResult Delete()
        {
            MongoAccessor dbAccessor = new MongoAccessor();
            dbAccessor.deleteAll(MongoAccessor.APPOINTMENTCOLLECTION);

            return View();
        }

        public IActionResult SaveGood()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
