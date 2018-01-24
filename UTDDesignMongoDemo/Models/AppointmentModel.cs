using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTDDesignMongoDemo.Models
{
    public class AppointmentModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CalendarName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Reason { get; set; }
    }
}
