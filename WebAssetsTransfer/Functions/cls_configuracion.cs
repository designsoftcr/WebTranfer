using System;
using System.Configuration;
namespace WebAssetsTransfer.Functions
{
    public class cls_configuracion
    {
        public static string Domain
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain"];
            }
        }
        public static string LDAP
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAP"];
            }
        }
        public static string Host
        {
            get
            {
                return ConfigurationManager.AppSettings["Host"];
            }
        }
        public static int Port
        {
            get
            {
                return System.Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            }
        }
        public static string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["Password"];
            }
        }
        public static string From
        {
            get
            {
                return ConfigurationManager.AppSettings["From"];
            }
        }
        public static bool SSL
        {
            get
            {
                return System.Convert.ToBoolean(ConfigurationManager.AppSettings["SSL"]);
            }
        }

        public static bool Authentication
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["Authentication"]);
            }
        }
        //GPE 12.09.2013 add
        //public static string NavigateURL
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings["NavigateURL"];
        //    }
        //}

        public static string ExportExcelPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ExportExcelPath"];
            }
        }
    }
}
