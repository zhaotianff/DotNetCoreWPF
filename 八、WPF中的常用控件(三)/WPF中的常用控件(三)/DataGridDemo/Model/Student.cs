using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDemo.Model
{
    public class Student
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public DateTime Birthdate { get; set; }

        public static List<Student> GetDemoData()
        {
            return new List<Student>() 
            {
                new Student(){ID = 1,Name = "极大规模集成电路",Weight = 61,Height = 170,Birthdate = new DateTime(1990,01,01) },
                new Student(){ID = 2,Name = "哪里有",Weight = 62,Height = 171,Birthdate = new DateTime(1991,01,01) },
                new Student(){ID = 3,Name = "枯井",Weight = 63,Height = 172,Birthdate = new DateTime(1992,01,01) },
                new Student(){ID = 4,Name = "粗浅",Weight = 64,Height = 173,Birthdate = new DateTime(1993,01,01) },
            };
        }
    }
}
