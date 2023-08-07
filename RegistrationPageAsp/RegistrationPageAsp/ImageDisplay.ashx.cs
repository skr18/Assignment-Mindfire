using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RegistrationPageAsp
{
    /// <summary>
    /// Summary description for ImageDisplay
    /// </summary>
    public class ImageDisplay : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["ImageName"]))
            {
                string filePath = WebConfigurationManager.AppSettings["myImagesPath"];
                string fileName = context.Request.QueryString["ImageName"];
                string contentType = "image/" + Path.GetExtension(fileName).Replace(".", "");
                using (FileStream fs = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        br.Close();
                        fs.Close();
                        context.Response.ContentType = contentType;
                        context.Response.BinaryWrite(bytes);
                        context.Response.End();
                    }
                }
            }
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