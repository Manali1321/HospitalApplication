using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalApplication.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        //A service can be provided at many locations.
        public ICollection<Location> Locations { get; set; }    // creating bridging table between location and services entity


    }
}