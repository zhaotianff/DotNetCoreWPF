using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo
{
    public class Model
    {
        public string ModelName { get; set; }

        public string ModelNumber { get; set; }

        public double UnitCost { get; set; }

        public string ProductImagePath { get; set; }

        public static List<Model> GetTestData()
        {
            var list = new List<Model>();

            Model model1 = new Model();
            model1.ModelName = "RTX4090ti";
            model1.ModelNumber = "100";
            model1.UnitCost = 101;
            model1.ProductImagePath = "pack://application:,,,/ListViewDemo;component/1.jpg";

            Model model2 = new Model();
            model2.ModelName = "i9-13900K";
            model2.ModelNumber = "200";
            model2.UnitCost = 201;
            model2.ProductImagePath = "pack://application:,,,/ListViewDemo;component/2.jpg";

            Model model3 = new Model();
            model3.ModelName = "EF 70-200";
            model3.ModelNumber = "300";
            model3.UnitCost = 301;
            model3.ProductImagePath = "pack://application:,,,/ListViewDemo;component/3.jpg";

            list.Add(model1);
            list.Add(model2);
            list.Add(model3);

            return list;
        }
    }
}
