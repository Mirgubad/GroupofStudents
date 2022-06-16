using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupofStudents
{
    class Student
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string  SurName { get; set; }
        public int Age { get; set; }
        public double  Grade { get; set; }
        private static  int _id=1;
        public Student()
        {
            ID = _id;
            ++_id;
        }

    }
}
