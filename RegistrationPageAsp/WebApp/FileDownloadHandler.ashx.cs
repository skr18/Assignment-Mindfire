using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApp
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            // string comandname = e.CommandArgument.ToString();

            int docId = int.Parse(context.Request.Form.Get("Id"));
            string doc1 = UserDocumentBusiness.downloadFile(docId);
            string ext = Path.GetExtension(doc1).ToLower();

            string doc = System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
            doc += doc1;
            context.Response.Clear();
           // context.Response.ContentType = $"application/{ext}";
            //context.Response.ContentType = $"application/{ext}";
            context.Response.ContentType = "application/force-download";
            context.Response.AppendHeader("Content-Disposition", $"attachment; filename={doc1}");

            //context.Response.AddHeader("Content-Disposition", "attachment; filename=" +doc1);
           // context.Response.AddHeader("Content-Length", doc.Length.ToString());
            
            //context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(doc));
            //context.Response.WriteFile(doc);
            //context.Response.Flush();
            // Transimiting file  
            //context.Response.WriteFile(doc);
            context.Response.TransmitFile(doc);
            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}