using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml;

namespace Xmlx
{
    public class Utility
    {
        XmlDocument doc;
        XmlDataProvider xdp;

        public XmlDataProvider ChooseLanguage(Window w, string Lang)
        {
            doc = new XmlDocument();
            xdp = new XmlDataProvider();
            switch (Lang)
            {
                case "中文":
                    doc.Load("./lang/ZH-CN/language.xml");
                    xdp.Document = doc;
                    xdp.XPath = @"/Language";
                    w.DataContext = xdp;
                    break;
                case "English":
                    doc.Load("./lang/EN-US/language.xml");
                    xdp.Document = doc;
                    xdp.XPath = @"/Language";
                    w.DataContext = xdp;
                    break;
                default:
                    break;

            }

            return xdp;

        }
    }
}
