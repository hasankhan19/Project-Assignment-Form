using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CSharp_Final_Exam
{
    public partial class ProjectAssignmentForm : Form
    {
        public ProjectAssignmentForm()
        {
            InitializeComponent();
        }

        ArrayList users = new ArrayList();
        Hashtable project = new Hashtable();
        Hashtable students = new Hashtable();


        private void button1_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                error += "The field can't be empty.\n";

            }
            else
            {
                foreach (Users u in users)
                {
                    if (u.getUsersId() == Convert.ToInt32(textBox1.Text))
                    {
                        error += "Users Id is unavailable\n";

                        break;
                    }
                }

                if (error == "")
                {
                    Users u1 = new Users(Convert.ToInt32(textBox1.Text), textBox2.Text);

                    users.Add(u1);
                    String text = "Users " + textBox1.Text + " added";
                    MessageBox.Show(text);
                    comboBox1.Items.Add(textBox1.Text);
                }
                else
                {
                    MessageBox.Show(error);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           if (textBox1.Text=="")
            {
                MessageBox.Show("Enter User ID");
            }


            else          {
                textBox7.Text = "";

                // search department in ArrayList
                foreach (Users user in users)
                {
                    if (user.getUsersId() == (Convert.ToInt32(textBox1.Text)))
                    {
                        Hashtable p = user.getProject();
                        foreach (Project project in p.Values)
                        {
                            textBox7.Text = textBox7.Text +"\n"+ project.getProjectId();
                        }
                       
                    }
                }

                if (textBox7.Text=="")
                {
                    MessageBox.Show("User not found.");
                }
            }
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox9.Text.Equals("") || textBox10.Text.Equals("") || textBox11.Text.Equals("") || textBox12.Text.Equals(""))
            {
                error += "The field can't be empty.\n";
            }
            else
            {
                foreach (Student s in students)
                {
                    if (s.getStudentId() == Convert.ToInt32(textBox11.Text))
                    {
                        error += "\n-Student Id Already exists.";
                        break;
                    }

                }
                if (error == "")
                {
                    Student s1 = new Student(Convert.ToInt32(textBox11.Text), textBox10.Text, textBox12.Text, textBox9.Text);
                    students.Add(s1.getStudentId(), s1);
                    String text = "Student " + textBox11.Text + " added";
                    MessageBox.Show(text);

                }
                else
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string message="";
            string id = (textBox11.Text);
            if (id == "")
                MessageBox.Show("Enter student ID ");
            else
            {

                if (students.ContainsKey((Convert.ToInt32(textBox11.Text))))
                {
                    Student s = (Student)students[(Convert.ToInt32(textBox11.Text))];
                    message += "First Name: " + s.getFirstName() + "\n";
                    message += "Last Name: " + s.getLastName() + "\n";
                    message += "Email: " + s.getEmail() + "\n";
                    MessageBox.Show(message);
                }
                else
                    MessageBox.Show("Project not found");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox6.Text.Equals("") || comboBox2.SelectedIndex < 0)
            {
                error += "The field can't be empty.\n";
            }


            if (error == "")
            {
                foreach (Project c in project.Values)
                {
                    if (c.getProjectId() == Convert.ToInt32(comboBox2.SelectedItem.ToString()))
                    {

                        Student s = (Student)students[Convert.ToInt32(textBox6.Text)];
                        if (s == null)
                        {
                            MessageBox.Show("Student not found.");
                            break;

                        }

                        if (c.findStudent(s) == 1)
                        {
                            MessageBox.Show("Student already exists.");
                        }

                        if (c.findStudent(s) == 0)
                        {

                            c.AddStudent(s);
                            MessageBox.Show("Student: " + s.getFirstName() + " " + s.getLastName() + " added into Project: " + c.getProjectName());

                        }


                    }


                }
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            String error = "";
            if (textBox4.Text.Equals("") || textBox3.Text.Equals("") || textBox5.Text.Equals(""))
            {
                error += "The field can't be empty.\n";
                MessageBox.Show(error);
            }
            else
            {
                foreach (String project in project.Keys)
                {
                    if (project == textBox4.Text)
                    {
                        error += "Course Id alerady exists\n";
                        MessageBox.Show(error);
                    }
                }
                if (error == "")
                {
                    Project p1 = new Project(Convert.ToInt32(textBox4.Text), textBox3.Text, textBox5.Text);


                    project.Add(p1.getProjectId(), p1);
                    String text = "Project " + textBox4.Text + " added";
                    MessageBox.Show(text);
                    comboBox2.Items.Add(textBox4.Text);
                    comboBox3.Items.Add(textBox4.Text);
                }
                else
                {
                    MessageBox.Show(error);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message="";
            if (textBox4.Text == "")
                MessageBox.Show("Course ID must be entered");
            else
            {

                if (project.ContainsKey((Convert.ToInt32(textBox4.Text))))
                {
                    Project c = (Project)project[(Convert.ToInt32(textBox4.Text))];
                    message += "Name: " + c.getProjectName() + "\n";
                    message += "Due Date: " + c.getDueDate() + "\n";
                   
                    MessageBox.Show(message);
                }
                else
                    MessageBox.Show("Course not found");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String error = "";
            if (comboBox3.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
            {
                error += "The field can't be empty.\n";
                MessageBox.Show("Error");
            }


            else
            {
                foreach (Users user in users)
                {

                    if (user.getUsersId() == (Convert.ToInt32(comboBox1.SelectedItem.ToString())))
                    {

                        Project p = (Project)project[(Convert.ToInt32(comboBox3.SelectedItem.ToString()))];
                        if (p == null)
                            {
                                MessageBox.Show("Course not found");
                            }
                        
                        else
                        {
                            if (user.findCourse(p) == 1)
                            {
                                MessageBox.Show("Course already exists.");
                            }
                            else
                            {
                                user.AddProject(p);
                                MessageBox.Show("course: " + p.getProjectName() + " added into department: " + user.getTeachersName());
                            }

                        }
                        break;

                    }
                    else
                    {
                        MessageBox.Show("Department not available");
                    }
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            foreach (Users dept in project)
            {
                comboBox1.Items.Add(dept.getUsersId());
            }
        }
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            Project p;
            foreach (DictionaryEntry de in project)
            {
                p = (Project)de.Value;
                comboBox2.Items.Add(p.getProjectId());
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
