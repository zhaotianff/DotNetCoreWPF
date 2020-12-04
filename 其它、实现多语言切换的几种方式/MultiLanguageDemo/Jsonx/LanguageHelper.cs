using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Jsonx
{
    public class LanguageHelper : LanguageFields
    {   
        private JObject currentLanguage;           //当前语言的JObject对象 
        private static readonly string dir = Environment.CurrentDirectory;  //语言文件夹
        private CultureInfo currentCulture;   //当前语言

        public static LanguageHelper Instance { get; } = new LanguageHelper();

        LanguageHelper()
        {
            CurrentCulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// 当前语言属性 当值更新时，加载语言并更新绑定
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get => currentCulture;
            set
            {
                currentCulture = value;
                CultureInfo.CurrentUICulture = value;
                currentLanguage = LoadLang(value.Name); 
                LanguageChanged?.Invoke(value);
                RaiseAllChanged();
            }
        }

        /// <summary>
        /// 加载语言文件 
        /// </summary>
        /// <param name="LanguageId"></param>
        /// <returns></returns>
        JObject LoadLang(string LanguageId)
        {
            try
            {
                var filePath = System.IO.Path.Combine(dir, $"{LanguageId}.json");
                return JObject.Parse(File.ReadAllText(filePath));
            }
            catch
            {
                return new JObject();
            }
        }

        /// <summary>
        /// 索引器方法 用于查找语言字段值
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string this[string Key]
        {
            get
            {
                if (Key == null)
                    return "";

                if (currentLanguage != null && currentLanguage.TryGetValue(Key, out var value) && value.ToString() is string s && !string.IsNullOrWhiteSpace(s))
                    return s;

                return Key;
            }
        }

        /// <summary>
        /// 重写 GetValue方法，调用索引器方法 
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        protected override string GetValue(string PropertyName) => this[PropertyName];

        /// <summary>
        /// 语言更改事件
        /// </summary>
        public event Action<CultureInfo> LanguageChanged;
    }
}
