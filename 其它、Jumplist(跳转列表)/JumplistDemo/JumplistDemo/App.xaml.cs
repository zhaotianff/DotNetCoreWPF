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
            //register file extension
            RegisterHandler();

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

            JumpPath jumpPathGithub = new JumpPath();
            jumpPathGithub.CustomCategory = "Common";
            jumpPathGithub.Path = Environment.CurrentDirectory + "\\github.zturl";
            jumpList.JumpItems.Add(jumpPathGithub);

            JumpList.SetJumpList(Application.Current, jumpList);

            JumplistDemo.MainWindow mainWindow = new MainWindow(e.Args);
            Application.Current.MainWindow = mainWindow;
            mainWindow.ShowActivated = true;
            mainWindow.Show();
        }

        private void RegisterHandler()
        {
            if (Registry.ClassesRoot.GetSubKeyNames().Contains(ZTURL))
                return;

            //here add a zturl file type
            //1、 add hkey_classroot file extension and type description
            //2、 use previous description add shell\open\command & DefaultIcon(default value is file extension description)
            //3、 use executable name add heky_classroot\applications\exename\NoOpenWith 
            SetFileAssociation(ZTURL, ZTURLDescription);
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathWidthParameter = $"{path} \"%1\"";
            CreateShell(ZTURLDescription, pathWidthParameter);
            CreateNoOpenWith(System.IO.Path.GetFileName(path));
        }

        private void UnRegisterHandler()
        {
            RemoveSubKey(Registry.ClassesRoot, ZTURL);
            RemoveSubKey(Registry.ClassesRoot, ZTURLDescription);
            var name = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            RemoveSubKey(Registry.ClassesRoot, $"Applications\\{name}");
        }

        public void SetFileAssociation(string extension, string des)
        {
            var regKey = AddSubKey(Registry.ClassesRoot, ZTURL);
            SetSubKeyValue(regKey, null, des);
        }

        public void CreateShell(string des,string path)
        {
            try
            {
                var regKey = AddSubKey(Registry.ClassesRoot, des);
                regKey = AddSubKey(regKey, "shell\\open\\command");
                SetSubKeyValue(regKey, null,path);
            }
            catch
            {

            }
        }

        private void CreateNoOpenWith(string name)
        {
            try
            {
                var regKeyPath = $"Applications\\{name}";
                var regKey = AddSubKey(Registry.ClassesRoot, regKeyPath);
                SetSubKeyValue(regKey, "NoOpenWith", "");
            }
            catch
            {

            }
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

        private bool RemoveSubKey(RegistryKey registryKey,string subKey)
        {
            try
            {
                registryKey.DeleteSubKeyTree(subKey);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
