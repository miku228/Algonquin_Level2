using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Car
    {
        // ****** properties ******
        public int Id { get; } // read only
        public string Name { get; }  // read only
        public string CarType { get; }  // read only
        public int NumberofSeats { get; }

        public Boolean Electoric { get; }

        public List<Store> RegisteredStores { get; set; }


        // ****** constructor ******

        public Car(string name, int numberofSeats, Boolean electric, string cartype = "")
        {
            // initialize 6 random digits Id
            Random random = new Random();
            string sId = "";
            for (int i = 0; i < 6; i++)
            {
                sId += random.Next(10).ToString();
            }
            Id = Int32.Parse(sId);

            Name = name;
            NumberofSeats = numberofSeats;
            Electoric = electric;
            CarType = cartype;

        }

        // ****** method ******

        public virtual void RegisterStores(List<Store> selectedStores)
        {
            // clear list data
            RegisteredStores = new List<Store>();

            // then adds the selectedCourses to the RegisteredCourse
            for (int i = 0; i < selectedStores.Count; i++)
            {
                RegisteredStores.Add(selectedStores[i]);
            }

        }



    }
}