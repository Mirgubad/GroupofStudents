using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupofStudents
{
    class Group
    {
        public string  Name { get; set; }

       public  List<Student> students;
        public Group(string name)
        {
            Name = name;
            students = new();
        }
    }
}
