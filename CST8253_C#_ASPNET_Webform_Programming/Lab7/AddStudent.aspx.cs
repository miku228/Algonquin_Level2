using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            table_initalize(0);

        }

        protected void table_initalize(int flag)
        {
            // clear table rows except header row
            for (int i = 1; i < tblAddedStudents.Rows.Count; i++)
            {
                tblAddedStudents.Rows.RemoveAt(i);
            }

            Student[] students;

            if (Session["students"] == null || flag == 0)
            {
                // initialize the table
                // add a row 
                TableRow rowNew = new TableRow();
                tblAddedStudents.Rows.Add(rowNew);

                TableCell cell = new TableCell();
                rowNew.Cells.Add(cell);
                cell.ColumnSpan = 2;
                cell.Text = "No Student Yet!";

            }
            else if (Session["students"] != null)
            {
                students = (Student[])Session["students"];
                // initialize the table with students
                for (int i = 0; i < students.Length; i++)
                {
                    // add a row 
                    TableRow rowNew = new TableRow();
                    tblAddedStudents.Rows.Add(rowNew);

                    // a cell for id
                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = students[i].Id.ToString();

                    // a cell for Name
                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = students[i].Name;

                    // Response.Write(students[i]);
                }
            }
        }

        // Add button is clicked
        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            string name = txtbSName.Text;
            string id = ddlSType.SelectedValue;

            if (txtbSName.Text != "" && ddlSType.SelectedValue != "0") 
            {
                Student[] students;
                List<Student> students_list = new List<Student>();
                if (Session["students"] != null)
                {
                    students = (Student[])Session["students"];
                    students_list = students.ToList();
                }


                string value = ddlSType.SelectedValue;

                // add the item to student_list
                switch (ddlSType.SelectedValue)
                {
                    case "1":
                        students_list.Add(new FulltimeStudent(txtbSName.Text));
                        break;
                    case "2":
                        students_list.Add(new ParttimeStudent(txtbSName.Text));
                        break;
                    case "3":
                        students_list.Add(new CoopStudent(txtbSName.Text));
                        break;
                };

                // convert list to array
                students = students_list.ToArray();

                // Add the student object to session state.
                Session["students"] = students;

            }

            // Make Student Name Text box be blancked
            txtbSName.Text = "";
            ddlSType.SelectedValue = "0";

            table_initalize(1);



        }


        protected void cmdClear_Click(object sender, EventArgs e)
        {
           
            Session["students"] = null;
            // Session.Clear();

            table_initalize(0);

        }
    }
}