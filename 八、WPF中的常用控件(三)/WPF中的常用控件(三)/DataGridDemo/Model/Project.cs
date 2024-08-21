using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDemo.Model
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        /// <summary>
        /// 生成测试项目
        /// </summary>
        /// <returns></returns>
        public static List<Project> GetDemoProjects()
        {
            List<Project> list = new List<Project>()
            {
                new Project(){ProjectId = 1,ProjectName = "C++" },
                new Project(){ProjectId = 2,ProjectName = "C#" },
                new Project(){ProjectId = 3,ProjectName = "Java" }
            };

            return list;
        }
    }
}
