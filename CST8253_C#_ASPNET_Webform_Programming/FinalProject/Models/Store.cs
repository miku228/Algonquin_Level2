using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Store
    {

		// ****** properties ****** 
		public string Code { get; }  // read only
		public string Name { get; }  // read only

		// 1 -> "family", 2 -> "sports", 3 -> both
		public int StoreSpeciality { get; set; } // read and write



		// ****** constructor ****** 
		public Store(string code, string name)
		{
			this.Code = code;
			this.Name = name;

		}


	}
}