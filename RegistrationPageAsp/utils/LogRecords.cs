using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;


namespace utils
{
    public class LogRecords
    {
        public static void LogRecord(Exception ex,string logPath)
        {
            string exp = ex.ToString() + Environment.NewLine;

            while (ex.InnerException != null)
            {
                exp += ex.InnerException.ToString() + Environment.NewLine;
                ex = ex.InnerException;
            }

            string date = DateTime.Now.ToString("dddd, dd MMMM yyyy") +".txt";

            string pathName = logPath + date;

            if (File.Exists(pathName))
            {
                File.AppendAllText(pathName, DateTime.Now.ToString() + Environment.NewLine + exp + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(pathName, exp + Environment.NewLine);
            }
        }
    }
}
