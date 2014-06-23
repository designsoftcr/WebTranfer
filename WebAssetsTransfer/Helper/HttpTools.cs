using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAssetsTransfer.Helper
{
    public class HttpTools
    {

        public static string HttpUrlPath
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["HttpUrlPath"] == null || string.IsNullOrEmpty(System.Web.HttpContext.Current.Session["HttpUrlPath"].ToString()))
                {
                    System.Web.HttpContext.Current.Session["HttpUrlPath"] = GetAbsPath();
                }

                return System.Web.HttpContext.Current.Session["HttpUrlPath"].ToString().Trim();
            }
        }

        public static string GetAbsPath()
        {

            string strScheme = System.Web.HttpContext.Current.Request.Url.Scheme;
            string strUrl = string.Empty;
            string strSufix = string.Empty;

            if (System.Configuration.ConfigurationManager.AppSettings["RequiresSSL"] != null)
            {
                if (System.Configuration.ConfigurationManager.AppSettings["RequiresSSL"].ToUpper() == "TREUE")
                {
                    strScheme = System.Uri.UriSchemeHttps;
                }
            }

            if (!strSufix.Equals(string.Empty))
            {
                if (!strSufix.Substring(0, 1).Equals("/")) strSufix = "/" + strSufix;
            }
            string strHost = System.Web.HttpContext.Current.Request.Url.Host;
            string strPort = System.Web.HttpContext.Current.Request.Url.Port.ToString();
            string strApplicationPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            if (!string.IsNullOrEmpty(strPort.Trim()))
            {
                strPort = ":" + strPort;
                if (strApplicationPath.Trim() == "/")
                {
                    strApplicationPath = string.Empty;
                }
            }
            string strIsLocalAbsPath = string.Empty;
            if (System.Configuration.ConfigurationManager.AppSettings["IsLocalAbsPath"] != null)
            {
                strIsLocalAbsPath = System.Configuration.ConfigurationManager.AppSettings["IsLocalAbsPath"].ToString();
            }
            if (System.Web.HttpContext.Current.Request.Url.Host.Trim().ToUpper() == "localhost".ToUpper() || System.Web.HttpContext.Current.Request.Url.Host.Trim().ToUpper() == "127.0.0.1".ToUpper())
            {
                strIsLocalAbsPath = "1";
            }
            else {
                strIsLocalAbsPath = "0";
            }
            
            if (strIsLocalAbsPath == "0")
            {
                strUrl = string.Concat(strScheme,
                                     System.Uri.SchemeDelimiter,
                                     System.Web.HttpContext.Current.Request.Url.Host, strPort.Trim(),
                                     System.Web.HttpContext.Current.Request.ApplicationPath, strSufix);
            }
            else
            {
                strUrl = string.Concat(strScheme,
                                     System.Uri.SchemeDelimiter,
                                     System.Web.HttpContext.Current.Request.Url.Host, strPort.Trim(),
                                     strApplicationPath,
                                     strSufix);
            }

            return strUrl;
        }
    }
}