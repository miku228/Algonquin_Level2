using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CoopStudent:Student
    {

        // ****** properties ******
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }


        // ****** constructor ******
        public CoopStudent(string name)
            : base(name)
        {

        }

        // ****** method ******
        public override void RegisterCourses(List<Course> selectedCourses)
        {

            base.RegisterCourses(selectedCourses);
            int totalhours = base.TotalWeeklyHours();

            // throw exception
            if (totalhours > MaxWeeklyHours)
                {
                    this.RegisteredCourses.Clear();
                    throw new Exception($"Your selection exceeds the maximum weekly hours(Max {MaxWeeklyHours} hours/week)");
                }

                if (selectedCourses.Count > MaxNumOfCourses)
                {
                    this.RegisteredCourses.Clear();
                    throw new Exception($"Your selection exceeds maximum number of courses (Max {MaxNumOfCourses}) courses");
                }


        }

        public override string ToString()
        {
            string studentInfo = $"{this.Id.ToString()} – {this.Name}(Coop)";
            return studentInfo;
        }



    }
}