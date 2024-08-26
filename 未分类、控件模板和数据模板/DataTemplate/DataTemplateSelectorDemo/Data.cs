using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorDemo
{
    #region  TreeView使用
    public class Disk
    {
        public string DiskName { get; set; }

        public List<Folder> Folders { get; set; } = new List<Folder>();
    }

    public class Folder
    {
        public string FullPath { get; set; }

        public long Size { get; set; }
    }
    #endregion

    #region ListBox使用
    public class FileData
    {
        public string FileName { get; set; }
    }

    public class FileData1 : FileData
    {
        public string FileData1Property { get; set; }
    }

    public class FileData2:FileData
    {
        public string FileData2Property { get; set; }
    }


    #endregion
}
