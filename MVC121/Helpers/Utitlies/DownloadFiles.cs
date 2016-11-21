using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using MVC121.Areas.Administrator.Models;

namespace MVC121.Helpers.Utilities
{
    //این کلاس برای زمانیست که اطلاعات فایل ها صرفا در پوشه و نه در بانک اطلاعات و پوشه ثبت میگردند
    public class DownloadFiles
    {
        public List<DownLoadFileInformation> GetFiles()
        {
            List<DownLoadFileInformation> lstFiles = new List<DownLoadFileInformation>();
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/MyFiles"));
            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                lstFiles.Add(new DownLoadFileInformation()
                {
                    FileID = i=i-1,
                    FilePathName = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return lstFiles;
        }

    }
}