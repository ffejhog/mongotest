using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTDDesignMongoDemo.Models
{
    public class AppointmentModel
    {
        private string LastName { get; set; }
        private string FirstName { get; set; }
        private string CalendarName { get; set; }
        private DateTime StartDateTime { get; set; }
        private DateTime EndDateTime { get; set; }
        private string Reason { get; set; }
    }
}
