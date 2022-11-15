using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CoopStudent:Student
    {

        // properties
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }


        // constructor
        public CoopStudent(string name)
            : base(name)
        {

        }
    }
}