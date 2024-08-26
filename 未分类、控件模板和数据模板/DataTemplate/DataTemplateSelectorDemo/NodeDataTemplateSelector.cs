using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DataTemplateSelectorDemo
{
    public class NodeDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Disk)
                return Application.Current.FindResource("DiskDatatemplate") as DataTemplate;
            else
                return Application.Current.FindResource("FolderDatatemplate") as DataTemplate;
        }
    }
}
