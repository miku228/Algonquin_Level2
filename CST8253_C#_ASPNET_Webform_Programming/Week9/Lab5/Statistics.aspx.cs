using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set input & output fields title
            lblFNum.Text = "First Number: ";
            lblSNum.Text = "Second Number: ";
            lblTNum.Text = "Third Number: ";

            lblMax.Text = "Maximum: ";
            lblMin.Text = "Minimum: ";
            lblAvg.Text = "Average: ";
            lblTotal.Text = "Total: ";

            // Error message visible
            lblErrorMsg.Visible = false;

            List<double> nums = new List<double>();

            // once submit button is clicked or rerloaded
            if (IsPostBack)
            {
                try
                {
                    // clear outputs
                    lblCalMax.Text = "";
                    lblCalMin.Text = "";
                    lblCalAvg.Text = "";
                    lblCalTotal.Text = "";

                    // 1.convert user input to double from string
                    // 2. add to list
                    nums.Add(double.Parse(TxtbxFNum.Text));
                    nums.Add(double.Parse(TxtbxSNum.Text));
                    nums.Add(double.Parse(TxtbxTNum.Text));


                    // set outputs
                    lblCalMax.Text = nums.Max().ToString();
                    lblCalMin.Text = nums.Min().ToString();
                    lblCalAvg.Text = nums.Average().ToString();
                    lblCalTotal.Text = nums.Sum().ToString();

                }
                catch (Exception exception)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Error: " + exception.Message;
                }
            }
        }
    }
}