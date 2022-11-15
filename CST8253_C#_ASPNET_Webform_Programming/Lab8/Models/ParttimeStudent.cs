using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class ParttimeStudent: Student
    {

        // ****** properties ******
        public static int MaxNumOfCourses { get; set; }


        // ****** constructor ******
        public ParttimeStudent(string name)
            : base(name)
        {

        }

        // ****** method ******
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            
            // throw exception
            if (selectedCourses.Count > MaxNumOfCourses)
                {
                    throw new Exception($"Your selection exceeds maximum number of courses (Max {MaxNumOfCourses}) courses");
                }

                
        }

        public override string ToString()
        {
            string studentInfo = $"{this.Id.ToString()} – {this.Name}(Part time)";
            return studentInfo;
        }

    }
}