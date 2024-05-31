using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDemo
{
    public class Student
    {
        public string Name { get; set; }

        public List<SubItem> SubItems { get; set; }
    }

    public class SubItem
    {
       public string Id { get; set; }
    }
}
