using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace CSharp_Final_Exam
{
    class Users
    {
        public int teacherId;
        public string teacherName;
        public Hashtable projects = new Hashtable();
        public static ArrayList users = new ArrayList();

        public Users(int teacherId, String teacherName)
        {
            this.teacherId = teacherId;
            this.teacherName = teacherName;
        }

        public void AddProject(Project project)
        {
            
            projects.Add(projects.Keys, project);
        }
        public string FindCourse(Project project)
        {
            string str = "not found";

            foreach (Project p in this.projects)
            {
                if (p == project)
                    str = "found";
                break;

            }
            return str;
        }
       
        public int findCourse(Project project)
        {

            
            if (project.ContainsKey(project.getProjectId()))
                return 1;
            else
                return 0;
            
        }


        // getting Due Date
        public String findDueDate(String name)
        {
            return "";

        }

        // getters for Teacher/User
        public int getUsersId()
        {
            return this.teacherId;
        }

        public String getTeachersName()
        {
            return this.teacherName;
        }

        public Hashtable getProject()
        {
            return this.projects;
        }
    }
}
