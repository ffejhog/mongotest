using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using UTDDesignMongoDemo.Database;
using UTDDesignMongoDemo.Models;

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
            List<AppointmentModel> appointmentsToInsert = new List<AppointmentModel>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    
                    String headerLine = reader.ReadLine();
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {


                        AppointmentModel newAppointment = new AppointmentModel();
                        String[] seperatedValues = line.Split('|');

                        if (seperatedValues.Length == 5)
                        {
                            newAppointment.LastName = seperatedValues[0];
                            newAppointment.FirstName = seperatedValues[1];
                            newAppointment.CalendarName = seperatedValues[2];
                            newAppointment.StartDateTime = DateTime.ParseExact(seperatedValues[3],
                                "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            newAppointment.EndDateTime = DateTime.ParseExact(seperatedValues[4], "yyyy-MM-dd HH:mm:ss",
                                System.Globalization.CultureInfo.InvariantCulture);
                            newAppointment.Reason = "";
                        }
                        else if (seperatedValues.Length == 6)
                        {
                            newAppointment.LastName = seperatedValues[0];
                            newAppointment.FirstName = seperatedValues[1];
                            newAppointment.CalendarName = seperatedValues[2];
                            newAppointment.StartDateTime = DateTime.ParseExact(seperatedValues[3],
                                "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            newAppointment.EndDateTime = DateTime.ParseExact(seperatedValues[4], "yyyy-MM-dd HH:mm:ss",
                                System.Globalization.CultureInfo.InvariantCulture);
                            newAppointment.Reason = seperatedValues[5];
                        }
                        appointmentsToInsert.Add(newAppointment);
                        
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            MongoAccessor database = new MongoAccessor();
            database.addManyRecords(appointmentsToInsert, MongoAccessor.APPOINTMENTCOLLECTION);

            return RedirectToAction("SaveGood", "Home");
        }


    }
}