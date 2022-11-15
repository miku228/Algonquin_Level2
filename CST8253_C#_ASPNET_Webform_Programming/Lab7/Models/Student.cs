using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Student
    {

        // properties
        public int Id { get; } // read only
        public string Name { get; }  // read only

        // constructor 
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
    }
}