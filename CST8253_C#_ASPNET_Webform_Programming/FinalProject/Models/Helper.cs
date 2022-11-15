using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Helper
    {


        public static List<Store> GetAvailableStores()
        {
            List<Store> stores = new List<Store>();

            Store store = new Store("CA00001", "Ottawa");
            store.StoreSpeciality = 1;
            stores.Add(store);

            store = new Store("CA00002", "Tronto");
            store.StoreSpeciality = 2;
            stores.Add(store);

            store = new Store("CA00003", "Gatineau");
            store.StoreSpeciality = 3;
            stores.Add(store);

            store = new Store("CA00004", "Montreal");
            store.StoreSpeciality = 2;
            stores.Add(store);

            store = new Store("CA00005", "Vancourver");
            store.StoreSpeciality = 3;
            stores.Add(store);

            return stores;
        }

        public static Store GetStoreByCode(string code)
        {
            foreach (Store s in GetAvailableStores())
            {
                if (s.Code == code)
                {
                    return s;
                }
            }
            return null;
        }
    }
}