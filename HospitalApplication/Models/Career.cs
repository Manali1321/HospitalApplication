using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalApplication.Models
{
    public class Career
    {
        public int CareerId { get; set; }
        public string JobName { get; set; }
        public int JobId { get; set; }

        public string JobDescription { get; set; }



        //A job belongs to a specific department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }


        //A job belongs to a specific department of specific location
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }


    }
}