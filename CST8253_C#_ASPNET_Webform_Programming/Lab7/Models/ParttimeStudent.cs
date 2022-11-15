using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class ParttimeStudent: Student
    {

        // properties
        public static int MaxNumOfCourses { get; set; }


        // constructor
        public ParttimeStudent(string name)
            : base(name)
        {

        }
    }
}