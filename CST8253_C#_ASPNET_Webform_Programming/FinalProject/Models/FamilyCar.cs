using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class FamilyCar:Car
    {

        // ****** properties ******
        // public static string CarType { get; } = "family";


        // ****** constructor ******
        public FamilyCar(string name, int numberofSeats, Boolean electric, string cartype = "family")
            : base(name, numberofSeats, electric, cartype)
        {

        }

        // ****** method ******
        public override void RegisterStores(List<Store> selectedStores)
        {
            base.RegisterStores(selectedStores);

            for (int i = 0; i < RegisteredStores.Count; i++)
            {
                if (RegisteredStores[i].StoreSpeciality == 2)
                {
                    
                    this.RegisteredStores.Clear();
                    throw new Exception($"Selected Store(s) cannot store {CarType} type car.");

                }
            }

        }

        public override string ToString()
        {
            string carInfo = $"{this.Id.ToString()} – {this.Name}(Type:{CarType} Car)";
            return carInfo;
        }
    }
}