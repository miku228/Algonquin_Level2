using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab6.Models;
using Lab7.Models;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void check_selectedItem()
        {

            Student[] students_Array;
            students_Array = (Student[])Session["students"];
            // set selected student id
            string selectedSID = ddlSInfo.Items[ddlSInfo.SelectedIndex].Value;

            // set selected courses
            List<Course> lselectedCourses = new List<Course>();

            // calculate selected items amount and total hours
            foreach (ListItem lstItem in cblAvailableCourses.Items)
            {
                if (lstItem.Selected)
                {
                    // for session data
                    lselectedCourses.Add(Helper.GetCourseByCode(lstItem.Value));
                }
            }

            try
            {
                foreach (Student s in students_Array)
                {
                    if (s.Id == Int32.Parse(selectedSID))
                    {
                        s.RegisterCourses(lselectedCourses);

                    }
                }

            }
            catch (Exception ex)
            {
                lblRSummary.Visible = false;
                lblEMessage.Visible = true;
                lblEMessage.Text = ex.Message;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // first page load -> set lists
            if (!this.IsPostBack)
            {
                // set available courses as a check box list item
                foreach (Course c in Helper.GetAvailableCourses())
                {
                    cblAvailableCourses.Items.Add(new ListItem(c.Title, c.Code));
                }

                // initialize student dropdown list
                if (Session["students"] != null)
                {
                    Student[] students_Array;
                    students_Array = (Student[])Session["students"];

                    ListItem list = new ListItem();

                    foreach (Student student in students_Array)
                    {
                        list = new ListItem(student.ToString(), student.Id.ToString());
                        ddlSInfo.Items.Add(list);
                    }
                    ddlSInfo.Items.Insert(0, new ListItem("-- Select --", "0"));

                }
            }

            // set first status to items
            lblRSummary.Text = "";
            lblEMessage.Text = "";

            cblAvailableCourses.Visible = true;
            btnSubmit.Visible = true;
            lblRSummary.Visible = true;
            lblEMessage.Visible = false;


        }

        protected void cmdSubmit_Click(object sender, System.EventArgs e)
        {
            // for session data
            Dictionary<string, List<string>> dselectedCourses = new Dictionary<string, List<string>>();
            List<string> lselectedCourses = new List<string>();

            if (Session["selectedCourses"] != null) dselectedCourses = (Dictionary<string, List<string>>)Session["selectedCourses"];

            int totalSelectedHour = 0;

            // calculate selected items amount and total hours
            foreach (ListItem lstItem in cblAvailableCourses.Items)
            {
                if (lstItem.Selected)
                {

                    // for session data
                    lselectedCourses.Add(lstItem.Value);

                    Course selectedCourse = Helper.GetCourseByCode(lstItem.Value);
                    totalSelectedHour += Convert.ToInt32(selectedCourse.WeeklyHours);
                }
            }
            if(lselectedCourses.Count == 0)
            {
                lblRSummary.Visible = false;
                lblEMessage.Visible = true;
                lblEMessage.Text = $"You need select at least one Course!!";

            }


            lblRSummary.Text = $"Selected Student has registered {lselectedCourses.Count.ToString()} course(s), {totalSelectedHour.ToString()} hours weekly.";

            // set selected courses info to session
            if (dselectedCourses.ContainsKey(ddlSInfo.SelectedValue))
            {
                dselectedCourses[ddlSInfo.SelectedValue] = lselectedCourses;
            }
            else
            {
                dselectedCourses.Add(ddlSInfo.SelectedValue, lselectedCourses);
            }

            Session["selectedCourses"] = dselectedCourses;

            check_selectedItem();


        }

        // set checked status to available courses according to session data
        protected void studentSelected(object sender, EventArgs e)
        {
            string selectedSID = ddlSInfo.Items[ddlSInfo.SelectedIndex].Value;

            Dictionary<string, List<string>> dselectedCourses = new Dictionary<string, List<string>>();
            List<string> lselectedCourses = new List<string>();

            dselectedCourses = (Dictionary<string, List<string>>)Session["selectedCourses"];
            if (dselectedCourses != null && dselectedCourses.ContainsKey(selectedSID)) lselectedCourses = dselectedCourses[selectedSID];

            // set un-checked to available courses list from session data
            foreach (ListItem lstItem in cblAvailableCourses.Items)
            {
                lstItem.Selected = false;
            }

            if (Session["selectedCourses"] != null && lselectedCourses.Count != 0)
            {
                // set checked to available courses list from session data
                foreach (ListItem lstItem in cblAvailableCourses.Items)
                {
                    foreach (string courseCode in lselectedCourses)
                    {
                        if (lstItem.Value == courseCode)
                        {
                            lstItem.Selected = true;
                        }
                    }
                }
            }




        }
    }
}