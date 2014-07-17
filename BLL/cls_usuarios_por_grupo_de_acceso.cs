using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Text;
namespace BLL
{
    public class cls_usuarios_por_grupo_de_acceso
    {
        private BostonEntities db = new BostonEntities();

        public DataTable select_usuario_por_grupo_de_acceso(int Id_Grupo, string Cod_Compania, string Usuario)
        {
                var usuario =
                from c in this.db.AFT_MOV_GRUPO_USUARIOS
                where c.USUARIO == Usuario && c.ID_GRUPO == Id_Grupo && c.ESTADO == true && c.COD_COMPANIA == Cod_Compania 
                select new
                {
                    USUARIO = c.USUARIO,
                    ID_GRUPO = c.ID_GRUPO
                };
                return usuario.AsDataTable();

        }

        public bool update_cusuarios_por_grupo_de_acceso(string Id_Empleado, int Id_Grupo, string Cod_Compania, string Usuario, bool Estado, string Cod_Cia_Pro)
        {
            bool result = false;
            //using (TransactionScope transaction = new TransactionScope())
            //{
                try
                {
                   // AFT_MOV_GRUPO_USUARIOS grupo = new AFT_MOV_GRUPO_USUARIOS();
                  //  grupo = this.db.AFT_MOV_GRUPO_USUARIOS.Single((AFT_MOV_GRUPO_USUARIOS a) => a.ID_EMPLEADO == old_Id_Empleado);

                    //this.db.DeleteObject(grupo);

                    //AFT_MOV_GRUPO_USUARIOS gruponew = new AFT_MOV_GRUPO_USUARIOS();
                    //gruponew.ID_EMPLEADO = Id_Empleado;
                    //gruponew.ID_GRUPO = Id_Grupo;
                    //gruponew.COD_COMPANIA = Cod_Compania;
                    //gruponew.USUARIO = Usuario;
                    //gruponew.ESTADO = Estado;
                    //this.db.AddToAFT_MOV_GRUPO_USUARIOS(gruponew);

                    //this.db.SaveChanges();
                    //transaction.Complete();

                    int status = 0;

                    if (Estado)
                        status = 1;

                    StringBuilder sbupdate = new StringBuilder();
                    sbupdate.Append("UPDATE    AFT_MOV_GRUPO_USUARIOS SET ");
                    sbupdate.Append(" ESTADO =" + status);
                    sbupdate.Append(" , USUARIO = '" + Usuario + "'");
                    sbupdate.Append(" WHERE ID_GRUPO =" + Id_Grupo);
                    sbupdate.Append(" AND ID_EMPLEADO = '" + Id_Empleado + "'");
                    sbupdate.Append(" AND COD_COMPANIA = '" + Cod_Compania + "'");
                    sbupdate.Append(" AND COD_CIA_PRO = '" + Cod_Cia_Pro + "'");
                    int resultquery = db.ExecuteStoreCommand(sbupdate.ToString());
                    result = true;
                }
                catch (Exception)
                {
                    //throw;
                    result = false;
                }
                
            //}
            return result;
        }

        public bool create_cusuarios_por_grupo_de_acceso( string Id_Empleado, int Id_Grupo, string Cod_Compania, string Usuario, bool Estado, string Cod_Cia_Pro)
        {
            bool result = false;
            //using (TransactionScope transaction = new TransactionScope())
            //{
                try
                {
                    //AFT_MOV_GRUPO_USUARIOS grupo = new AFT_MOV_GRUPO_USUARIOS();
                    //grupo.ID_EMPLEADO = Id_Empleado;
                    //grupo.ID_GRUPO = Id_Grupo;
                    //grupo.COD_COMPANIA = Cod_Compania;
                    //grupo.USUARIO = Usuario;
                    //grupo.ESTADO = Estado;
                    //this.db.AddToAFT_MOV_GRUPO_USUARIOS(grupo);
                    //this.db.SaveChanges();
                    //transaction.Complete();

                    int status = 0;

                    if (Estado)
                        status = 1;

                    StringBuilder sbcreate = new StringBuilder();
                    sbcreate.Append("INSERT INTO AFT_MOV_GRUPO_USUARIOS VALUES ");
                    sbcreate.Append("( '" + Id_Empleado + "' , ");
                    sbcreate.Append(" " + Id_Grupo + " , ");
                    sbcreate.Append(" '" + Cod_Compania + "' , ");
                    sbcreate.Append(" " + status + " , ");
                    sbcreate.Append(" '" + Usuario + "' , ");
                    sbcreate.Append(" '" + Cod_Cia_Pro + "' ) ");

                    int resultquery = db.ExecuteStoreCommand(sbcreate.ToString());
                    result = true;
                }
                catch (Exception)
                {
                    //throw;
                    result = false;
                }
                
           // }
            return result;
        }

        public bool delete_cusuarios_por_grupo_de_acceso(string Id_Empleado, int Id_Grupo, string Cod_Compania, string Cod_Cia_Pro)
        {
            bool result = false;
            //using (TransactionScope transaction = new TransactionScope())
            //{
                try
                {
                    //AFT_MOV_GRUPO_USUARIOS grupo = new AFT_MOV_GRUPO_USUARIOS();
                    //grupo = this.db.AFT_MOV_GRUPO_USUARIOS.First((AFT_MOV_GRUPO_USUARIOS a) => a.ID_EMPLEADO == Id_Empleado);
                    //this.db.DeleteObject(grupo);
                    //this.db.SaveChanges();
                    //transaction.Complete();

                    StringBuilder sbdelete = new StringBuilder();
                    sbdelete.Append("DELETE FROM AFT_MOV_GRUPO_USUARIOS ");
                    sbdelete.Append(" WHERE ID_GRUPO =" + Id_Grupo);
                    sbdelete.Append(" AND ID_EMPLEADO = '" + Id_Empleado + "'");
                    sbdelete.Append(" AND COD_COMPANIA = '" + Cod_Compania + "'");
                    sbdelete.Append(" AND COD_CIA_PRO = '" + Cod_Cia_Pro + "'");

                    int resultquery = db.ExecuteStoreCommand(sbdelete.ToString());
                    result = true;
                }
                catch (Exception)
                {
                    //throw;
                    result = false;
                }
               
            //}
            return result;
        }
    }
}
