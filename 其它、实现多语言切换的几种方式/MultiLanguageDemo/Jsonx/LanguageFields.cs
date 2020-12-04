using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jsonx
{
    /// <summary>
    /// 语言字段类
    /// </summary>
    public class LanguageFields : NotifyPropertyChanged
    {
        /// <summary>
        /// 需要被重写的方法 用于获取语言字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string GetValue(string key) => "";

        protected virtual void SetValue(string Key, string value) { }

        /// <summary>
        /// 使用CallerMemberName特性传递当前属性名
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        string Get([CallerMemberName] string propertyName = null)
        {
            return GetValue(propertyName);
        }

        void Set(string value, [CallerMemberName] string propertyName = null)
        {
            SetValue(propertyName, value);
        }

        public string OK { get => Get(); set => Set(value); }
        public string Cancel { get => Get(); set => Set(value); }
        public string ChangeLanguage { get => Get(); set => Set(value); }
        public string zh_CN { get => Get(); set => Set(value); }
        public string en_US { get => Get(); set => Set(value); }
    }
}
