using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class RegisteredInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // clear table rows except header row
            for (int i = 1; i < tblAddedCars.Rows.Count; i++)
            {
                tblAddedCars.Rows.RemoveAt(i);

            }

            List<Car> registered_cars_list = new List<Car>();

            if (Session["cars"] == null)
            {
                // initialize the table
                // add a row 
                TableRow rowNew = new TableRow();
                tblAddedCars.Rows.Add(rowNew);

                TableCell cell = new TableCell();
                rowNew.Cells.Add(cell);
                cell.ColumnSpan = 6;
                cell.Text = "No Car Yet!";

            }
            else if (Session["cars"] != null)
            {
                //hlToRegerterCourse.Visible = true;

                registered_cars_list = (List<Car>)Session["cars"];
                // initialize the table with students
                for (int i = 0; i < registered_cars_list.Count(); i++)
                {
                    // add a row 
                    TableRow rowNew = new TableRow();
                    tblAddedCars.Rows.Add(rowNew);

                    // 1. a cell for id
                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.ColumnSpan = 1;
                    cell.Text = registered_cars_list[i].Id.ToString();

                    for (int l = 0; l < 5; l++)
                    {
                        cell = new TableCell();
                        rowNew.Cells.Add(cell);
                        cell.ColumnSpan = 1;

                        string cellText = "";

                        switch (l)
                        {
                            case 0:
                                //2. a cell for Name
                                cellText = registered_cars_list[i].Name;
                                break;
                            case 1:
                                // 3. a cell for Car Type
                                cellText = registered_cars_list[i].CarType;
                                break;
                            case 2:
                                // 4. a cell for Max Riding Capacit
                                cellText = registered_cars_list[i].NumberofSeats.ToString();
                                break;
                            case 3:
                                // 5. a cell for Engine Type
                                cellText = registered_cars_list[i].Electoric == true ? "Electric" : "Gasoline";
                                break;
                            case 4:
                                // 6. a cell for Registered Store
                                foreach (Store s in registered_cars_list[i].RegisteredStores)
                                {
                                    cellText += s.Name + ", ";
                                }
                                cellText = cellText.Remove(cellText.Length - 2);
                                break;
                        }

                        cell.Text = cellText;


                    }





                }
            }
        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            if (Session["cars"] != null)
            {
                Session["cars"] = null;
                Response.Redirect(Request.Url.OriginalString);

            }

        }
    }
}