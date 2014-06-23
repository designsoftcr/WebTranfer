using System;
using System.DirectoryServices;
namespace WebAssetsTransfer.Functions
{
    public class cls_active_directoy
    {
        public bool autentificar(string usuario, string contrasena)
        {
            DirectoryEntry entry = new DirectoryEntry(cls_configuracion.LDAP, cls_configuracion.Domain + "\\" + usuario, contrasena);
            bool result2;
            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    result2 = false;
                }
                else
                {
                    result2 = true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return result2;
        }
    }
}
