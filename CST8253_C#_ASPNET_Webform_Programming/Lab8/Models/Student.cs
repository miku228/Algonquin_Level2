using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Student
    {

        // ****** properties ******
        public int Id { get; } // read only
        public string Name { get; }  // read only
        
        public List<Course> RegisteredCourses { get; set; }



        // ****** constructor ******
        // one parameter( stirng: name)
        public Student(string name)
        {
            // initialize 6 random digits Id
            Random random = new Random();
            string sId = "";
            for(int i = 0; i < 6; i++)
            {
                sId += random.Next(10).ToString();
            }
            Id = Int32.Parse(sId);

            Name = name;
        }


        // ****** method ******
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            // clear list data
            RegisteredCourses = new List<Course>();

            // then adds the selectedCourses to the RegisteredCourse
            for(int i = 0; i < selectedCourses.Count; i++)
            {
                RegisteredCourses.Add(selectedCourses[i]);
            }

        }

        // returns the calculated total hours of all registered courses by the student
        public int TotalWeeklyHours() 
        {
            int totalhours = 0;

            for (int i = 0; i < RegisteredCourses.Count; i++)
            {
                totalhours += RegisteredCourses[i].WeeklyHours;
            }

            return totalhours;
        }

    }
}