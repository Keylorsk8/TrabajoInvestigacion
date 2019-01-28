using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSCategorias
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WsCategoria : ICategorias
    {
        public List<Categoria> getCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProductoContext"].ToString());
            SqlCommand query = new SqlCommand("Select * from Categorias");
            try
            {
                cn.Open();
                SqlDataReader reader = query.ExecuteReader();
                Categoria ca;
                while (reader.Read())
                {
                    ca = new Categoria();
                    ca.Id = Convert.ToInt32(reader[0]);
                    ca.Nombre = Convert.ToString(reader[1]);
                    ca.Descripcion = Convert.ToString(reader[2]);
                    categorias.Add(ca);
                }
                return categorias;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
