using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ent_bitacora
    {
           public int CODIGO_BITACORA 
           {
               get;
               set;
           }
           
           public int ID_MOVIMIENTO 
           {
               get;
               set;
           }
           public string COD_COMPANIA 
            {
               get;
               set;
           }
           public string DESCRIPCION 
           {
               get;
               set;
           }
           public DateTime FECHA 
           {
               get;
               set;
           }
           public string DESCRIPCION_TIPO_MOVIMIENTO
           {
               get;
               set;
           }    
          public string USUARIO 
          {
               get;
               set;
           }       
           public string PASO_APROBACION 
           {
               get;
               set;
           } 
    }
}
