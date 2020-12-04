using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Resx
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //在这里可以更改语言
            ChangeCulture(1);
        }

        public void ChangeCulture(int index)
        {
            string cultureName = "";

            switch (index)
            {
                case 0:
                    cultureName = "zh-CN";
                    break;
                case 1:
                    cultureName = "en-US";
                    break;
                default:
                    cultureName = "en-US";
                    break;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            //set control culture
            //control.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.GetCultureInfo("lang").IetfLanguageTag);
        }
    }
}
