using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Course
    {

		// ****** properties ****** 
		public string Code { get; }  // read only
		public string Title { get; }  // read only
		public int WeeklyHours { get; set; } // read and write



		// ****** constructor ****** 
		public Course(string code, string title)
		{
			this.Code = code;
			this.Title = title;

		}
	}
}