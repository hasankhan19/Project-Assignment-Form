using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;


namespace CSharp_Final_Exam
{
    class Project
    {
        public int projectId;
        public string projectName;
        public string dueDate;
        Hashtable students = new Hashtable();

        public Project(int projectId, String projectName, string dueDate)
        {
            this.projectId = projectId;
            this.projectName = projectName;
            this.dueDate = dueDate;
        }

        public void AddStudent(Student student)
        {
            students.Add(students.Keys, student);
        }
        
        public string GetProjectInfo()
        {
            string str = "ProjectID:" + projectId.ToString() + "\n Project Name:" + projectName + "\n Due Date:" + dueDate;
            return str;
        }
        public int getProjectId()
        {
            return this.projectId;
        }

        public String getProjectName()
        {
            return this.projectName;
        }

        internal bool ContainsKey(int v)
        {
            throw new NotImplementedException();
        }

        public String getDueDate()
        {
            return this.dueDate;
        }

        public int findStudent(Student p)
        {
            Student s = (Student)students[p.getStudentId()];
            if (s == null)
                return 0;

            return 1;
        }
    }
}
