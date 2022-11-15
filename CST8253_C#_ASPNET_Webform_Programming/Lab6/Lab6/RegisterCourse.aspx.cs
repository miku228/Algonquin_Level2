using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab6.Models;

namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // first page load -> set lists
            if (!this.IsPostBack)
            {
                foreach (Course c in Helper.GetAvailableCourses())
                {
                    cblAvailableCourses.Items.Add(new ListItem(c.Title, c.Code));
                }
            }

            lblErrorMsg.Text = "";
            cblAvailableCourses.Visible = true;
            btnSubmit.Visible = true;
            lblBeforeSelectedTxt.Visible = true;

            // unvisible
            lblErrorMsg.Visible = false;
            tblSelectedCourses.Visible = false;
            lblAfterSelected.Visible = false;
            btnReload.Visible = false;
        }

        protected void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            int totalSelectedHour = 0;
            int selectedAmount = 0;

            int maxHour = 100;
            int maxCourseAmount = 100;

            if (txtbSName.Text == "")
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "You must enter a name";
            }
            else if (rblStudentType.SelectedValue == "")
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "You must select a student type";
            }
            else
            {
                // clear table rows except header row
                for (int i = 1; i < tblSelectedCourses.Rows.Count; i++)
                {
                    tblSelectedCourses.Rows.RemoveAt(i);
                }


                // calculate selected items amount and total hours
                foreach (ListItem lstItem in cblAvailableCourses.Items)
                {
                    if (lstItem.Selected)
                    {
                        selectedAmount++;
                        Course selectedCourse = Helper.GetCourseByCode(lstItem.Value);
                        totalSelectedHour += Convert.ToInt32(selectedCourse.WeeklyHours);

                        // make the table to show selected courses
                        // make row
                        TableRow rowNew = new TableRow();
                        tblSelectedCourses.Rows.Add(rowNew);

                        TableCell cell = new TableCell();
                        rowNew.Cells.Add(cell);
                        cell.Text = selectedCourse.Code;

                        cell = new TableCell();
                        rowNew.Cells.Add(cell);
                        cell.Text = selectedCourse.Title;

                        cell = new TableCell();
                        rowNew.Cells.Add(cell);
                        cell.Text = selectedCourse.WeeklyHours.ToString();
                    }
                }

                // check student status and maxHours/maxCourseAmout
                if (rblStudentType.SelectedValue == "1")
                {
                    maxHour = 16;

                }
                else if (rblStudentType.SelectedValue == "2")
                {
                    maxCourseAmount = 3;
                }
                else
                {
                    maxHour = 4;
                    maxCourseAmount = 2;
                }

                if (maxHour < totalSelectedHour)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = $"Your selection exceeds the maximum weekly hours: {maxHour}";
                }
                else if (maxCourseAmount < selectedAmount)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = $"Your selection exceeds the maximum number of courses: {maxCourseAmount}";
                }
                else if (totalSelectedHour == 0 & selectedAmount == 0)
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = $"Your must select courses at least one";
                }
                else
                {
                    cblAvailableCourses.Visible = false;
                    btnSubmit.Visible = false;
                    lblBeforeSelectedTxt.Visible = false;

                    tblSelectedCourses.Visible = true;
                    lblAfterSelected.Visible = true;
                    btnReload.Visible = true;

                    TableRow rowNew = new TableRow();
                    tblSelectedCourses.Rows.Add(rowNew);

                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.ColumnSpan = 2;
                    cell.Text = "Total";

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = totalSelectedHour.ToString();

                }



            }
        }

        protected void cmdReload_Click(object sender, System.EventArgs e)
        {
            Response.Redirect(Request.Url.OriginalString);
            // Server.Transfer(Request.Url.LocalPath);
        }

    }
}