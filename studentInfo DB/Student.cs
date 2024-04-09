using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentInfo_DB
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Regestration { get; set; }

        public Student(string name, int age, string regestration)
        {
            Name = name;
            Age = age;
            Regestration = regestration;    
        }
    }
}
