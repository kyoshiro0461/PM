using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCommon
{
    /// <summary>
    /// 工程公用方法类
    /// </summary>
    public static class ProjectCommonMethods
    {
        /// <summary>
        /// 产生随机名称
        /// </summary>
        public static string CreateRndName()
        {
            DateTime dtNow = DateTime.Now;
            Random rnd = new Random(unchecked((int)dtNow.Ticks));
            int rndnumber = rnd.Next(1000, 9999);
            string result = string.Format("{0}{1}{2}{3}{4}{5}", dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, rndnumber);
            return result;
        }
        /// <summary>
        /// 产生文件名称
        /// </summary>
        /// <returns></returns>
        public static string CreateFileName()
        {
            DateTime dtNow = DateTime.Now;
            Random rnd = new Random(unchecked((int)dtNow.Ticks));
            int rndnumber = rnd.Next(1000, 9999);
            string date = string.Format("{0:yyyyMMddhhmmss}", dtNow);
            string result = string.Format("{0}{1}", date, rndnumber);
            return result;
        }
        /// <summary>
        /// 产生文件夹名称
        /// </summary>
        /// <returns></returns>
        public static string CreateFolderName()
        {
            DateTime dtNow = DateTime.Now;
            Random rnd = new Random(unchecked((int)dtNow.Ticks));
            int rndnumber = rnd.Next(1000, 9999);
            string result = string.Format("{0:yyMMdd}", dtNow);
            return result;
        }
        /// <summary>
        /// 产生文件夹名称
        /// </summary>
        /// <returns></returns>
        public static string CreateFolderName_image()
        {

            string result = "";
            return result;
        }
    }
   
}
