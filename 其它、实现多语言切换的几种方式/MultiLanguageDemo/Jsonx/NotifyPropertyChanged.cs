using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jsonx
{
    /// <summary>
    /// 绑定通知类
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            RaisePropertyChanged(PropertyName);
        }

        protected void RaiseAllChanged()
        {
            RaisePropertyChanged("");
        }
    }
}
