using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDemo.Model
{
    public class User
    {
        public string UserName { get; set; }

        public bool IsEnable { get; set; }

        public Uri Site { get; set; }

        public string Gender { get; set; }

        public Model.Project SelectedProject { get; set; }

        public Uri Avatar { get; set; }


        public static List<User> GetDemoUsers()
        {
            List<User> users = new List<User>();

            User user1 = new User();
            user1.UserName = "用户1";
            user1.IsEnable = true;
            user1.Site = new Uri("https://myfreetime.cn");
            user1.Gender = "Female";
            user1.SelectedProject = Model.Project.GetDemoProjects()[0];
            user1.Avatar = new Uri("pack://application:,,,/avatar1.jpeg",UriKind.Absolute);

            User user2 = new User();
            user2.UserName = "用户2";
            user2.IsEnable = true;
            user2.Site = new Uri("https://myfreetime.cn");
            user2.Gender = "Male";
            user2.SelectedProject = Model.Project.GetDemoProjects()[1];
            user2.Avatar = new Uri("pack://application:,,,/avatar2.jpeg", UriKind.Absolute);

            User user3 = new User();
            user3.UserName = "用户3";
            user3.IsEnable = false;
            user3.Site = new Uri("https://myfreetime.cn");
            user3.Gender = "Female";
            user3.SelectedProject = Model.Project.GetDemoProjects()[2];
            user3.Avatar = new Uri("pack://application:,,,/avatar3.jpeg", UriKind.Absolute);

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            return users;
        }
    }
}
