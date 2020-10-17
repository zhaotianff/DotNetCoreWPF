using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;

namespace JumplistDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ZTURL = ".zturl";
        private const string ZTURLDescription = "zti.url";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //get jump list
            JumpList jumpList = JumpList.GetJumpList(Application.Current);

            JumpTask jumpTaskBaidu = new JumpTask();
            jumpTaskBaidu.ApplicationPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file:///","");
            jumpTaskBaidu.Description = "Open baidu in new window";
            jumpTaskBaidu.Title = "Baidu";
            jumpTaskBaidu.WorkingDirectory = Environment.CurrentDirectory;
            jumpTaskBaidu.Arguments = "baidu";
            jumpTaskBaidu.IconResourcePath = jumpTaskBaidu.ApplicationPath;
            jumpTaskBaidu.IconResourceIndex = 0;
            jumpList.JumpItems.Add(jumpTaskBaidu);

            JumpTask jumpTaskGoogle = new JumpTask();
            jumpTaskGoogle.ApplicationPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            jumpTaskGoogle.Description = "Open google in new window";
            jumpTaskGoogle.Title = "Google";
            jumpTaskGoogle.WorkingDirectory = Environment.CurrentDirectory;
            jumpTaskGoogle.Arguments = "google";
            jumpTaskBaidu.IconResourcePath = jumpTaskBaidu.ApplicationPath;
            jumpTaskBaidu.IconResourceIndex = 0;
            jumpList.JumpItems.Add(jumpTaskGoogle);

            JumpList.SetJumpList(Application.Current, jumpList);

            JumplistDemo.MainWindow mainWindow = new MainWindow(e.Args);
            Application.Current.MainWindow = mainWindow;
            mainWindow.ShowActivated = true;
            mainWindow.Show();
        }

        private void RegisterHandler()
        {
            //here add a zturl file type
            //1、 add hkey_classroot file extension and type description
            //2、 use previous description add shell\open\command & DefaultIcon(default value is file extension description)
            //3、 use executable name add heky_classroot\applications\exename\NoOpenWith 
            SetFileAssociation(ZTURL, ZTURLDescription);
        }

        public void SetFileAssociation(string extension, string des)
        {
            var regKey = AddSubKey(Registry.ClassesRoot, ZTURL);
            SetSubKeyValue(regKey, null, ZTURLDescription);
        }

        private RegistryKey AddSubKey(RegistryKey registryKey,string name)
        {
            try
            {
                return registryKey.CreateSubKey(name);
            }
            catch
            {
                return null;
            }
        }

        private void SetSubKeyValue(RegistryKey registryKey,string name,object value)
        {
            try
            {
                registryKey.SetValue(name, value);
            }
            catch
            {

            }
        }
    }
}
