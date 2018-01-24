using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UTDDesignMongoDemo.Controllers
{
    public class UploadFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFile")]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> Post(IFormFile file)
        {
            long size = file.Length;

            //Get a place to store the temp file on the server
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            //Do stuff with file into mongo

            FileStream onServerFile = new FileStream(filePath, FileMode.Open);
            

            return RedirectToAction("SaveGood", "Home");
        }


    }
}