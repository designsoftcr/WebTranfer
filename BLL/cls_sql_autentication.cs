using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using CapaLog;

namespace WebAssetsTransfer.Functions
{
    public class cls_sql_autentication
    {
        private BostonEntities db = new BostonEntities();

        public bool sql_autentificar(string usuario, string contrasena)
        {
            //DirectoryEntry entry = new DirectoryEntry(cls_configuracion.LDAP, cls_configuracion.Domain + "\\" + usuario, contrasena);
            bool result2;
            try
            {
                //DirectorySearcher search = new DirectorySearcher(entry);
                //SearchResult result = search.FindOne();
                var result = db.AFM_CATAL_EMPLE.FirstOrDefault(a=>a.USUARIO_SESION==usuario && a.USUARIO_SESION == contrasena);
                if (result == null)
                {
                    result2 = false;
                }
                else
                {
                    result2 = true;
                }
            }
            catch (System.Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                throw;
            }
            return result2;
        }
    }
}
