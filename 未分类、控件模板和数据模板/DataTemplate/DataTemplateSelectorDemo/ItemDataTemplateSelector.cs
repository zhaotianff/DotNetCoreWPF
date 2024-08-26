using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DataTemplateSelectorDemo
{
    public class ItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FileData1)
                return Application.Current.FindResource("FileData1Datatemplate") as DataTemplate;
            else
                return Application.Current.FindResource("FileData2Datatemplate") as DataTemplate;
        }
    }
}
