using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FinalProject
{
    public partial class RegisterStore : System.Web.UI.Page
    {
        // session data
        List<Car> cars_list = new List<Car>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cars"] != null) cars_list = (List<Car>)Session["cars"];

            // first page load -> set lists
            if (!this.IsPostBack)
            {
                lblEMessage.Text = "";
                lblEMessage.Visible = false;

                // set available stores as a check box list item
                foreach (Store s in Helper.GetAvailableStores())
                {
                    string speciality = "";
                    switch (s.StoreSpeciality)
                    {
                        case 1:
                            speciality = "family";
                            break;
                        case 2:
                            speciality = "sports";
                            break;
                        case 3:
                            speciality = "family & sports";
                            break;
                    }

                    string storeInfo = $"{s.Name} Store – Speciality : {speciality}";

                    cblAvailableStores.Items.Add(new ListItem(storeInfo, s.Code));
                }

            }

        }


        protected void cmdSubmit_Click(object sender, System.EventArgs e)
        {
            // for session data
            // Dictionary<string, List<string>> dselectedStores = new Dictionary<string, List<string>>();
            // List<Car> cars_list = new List<Car>();
            List<Store> lselectedStores = new List<Store>();



            // get data from user input
            string name = txtbCName.Text;
            string cTypeId = ddlCType.SelectedValue;
            int MaxRCapacity = Int32.Parse(ddlMRiding.SelectedValue);
            Boolean electric = false;
            if (rblEType.SelectedItem.Text == "Electric") electric = true;


            // add the item to cars_list
            switch (cTypeId)
            {
                case "1":
                    // familiy car
                    cars_list.Add(new FamilyCar(name, MaxRCapacity, electric));
                    break;
                case "2":
                    // sports car
                    cars_list.Add(new SportsCar(name, MaxRCapacity, electric));
                    break;
                case "3":
                    // suv car
                    cars_list.Add(new SuvCar(name, MaxRCapacity, electric));
                    break;
            };

            // Add the car object to session state.
            Session["cars"] = cars_list;



            // set selected stores to list
            foreach (ListItem lstItem in cblAvailableStores.Items)
            {
                if (lstItem.Selected)
                {
                    // for session data
                    lselectedStores.Add(Helper.GetStoreByCode(lstItem.Value));
                }
            }

            // check the store specialty and car type whether fit or not
            int cindex = cars_list.Count() - 1;
            try
            {
                cars_list[cindex].RegisterStores(lselectedStores);

            }
            catch (Exception ex)
            {
                // remove current registered car object 
                cars_list.RemoveAt(cindex);
                if (cars_list.Count == 0) Session.Remove("cars");

                // show error message
                lblEMessage.Visible = true;
                lblEMessage.Text = ex.Message;

            }


            // Make Cars input info to be blancked
            txtbCName.Text = "";
            ddlCType.SelectedIndex = 0;
            ddlMRiding.SelectedIndex = 0;
            rblEType.ClearSelection();
            cblAvailableStores.ClearSelection();





        }
    }
}