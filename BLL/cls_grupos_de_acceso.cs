using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Text;
namespace BLL
{
    public class cls_grupos_de_acceso
    {
        private BostonEntities db = new BostonEntities();
        
        public bool update_grupos_de_acceso(int Id_Grupo, string Email_Grupo, bool Estado, string Cod_PropCompany)
		{
            bool result = false;
            //using (TransactionScope transaction = new TransactionScope())
            //{
                try
                {
                    //AFT_MOV_GRUPOS_ACCESOS grupo = new AFT_MOV_GRUPOS_ACCESOS();
                    //grupo = this.db.AFT_MOV_GRUPOS_ACCESOS.First((AFT_MOV_GRUPOS_ACCESOS a) => a.ID_GRUPO == Id_Grupo);
                    //grupo.ESTADO = Estado;
                    //grupo.EMAIL_GRUPO = Email_Grupo;
                    //grupo.COD_CIA_PRO = Cod_PropCompany;
                    //this.db.SaveChanges();
                    //transaction.Complete();
                    int status = 0;

                    if (Estado)
                        status = 1;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE    AFT_MOV_GRUPOS_ACCESOS SET "); 
                    sb.Append(" ESTADO =" + status );
                    sb.Append(" , EMAIL_GRUPO = '" + Email_Grupo + "'");
                    sb.Append(" WHERE ID_GRUPO =" + Id_Grupo);
                    sb.Append(" AND COD_CIA_PRO = '" + Cod_PropCompany + "'");

                    int resultquery = db.ExecuteStoreCommand(sb.ToString());
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                   // throw;
                }
               
            //}
            return result;
		}
    }
}
