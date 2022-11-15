using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class SuvCar:Car
    {
        // ****** properties ******
        // public static string CarType { get; }


        // ****** constructor ******
        public SuvCar(string name, int numberofSeats, Boolean electric, string cartype = "family & sports")
            : base(name, numberofSeats, electric, cartype)
        {

        }

        // ****** method ******
        public override void RegisterStores(List<Store> selectedStores)
        {
            base.RegisterStores(selectedStores);

        }

        public override string ToString()
        {
            string carInfo = $"{this.Id.ToString()} – {this.Name}(Type:{CarType} Car)";
            return carInfo;
        }
    }
}