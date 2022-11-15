using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class FulltimeStudent:Student
    {
        // properties
        public static int MaxWeeklyHours { get; set; }
        

        // constructor
        public FulltimeStudent(string name)
            : base(name)
        {

        }
    }
}