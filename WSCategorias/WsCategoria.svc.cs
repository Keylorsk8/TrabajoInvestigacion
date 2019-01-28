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
    public class WsCategoria : ICategorias
    {
        public List<Categoria> getCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProductoContext"].ConnectionString);
            SqlCommand query = new SqlCommand("Select * from Categorias",cn);
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

        public bool insertCategoria(string nombre, string descripcion)
        { 
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProductoContext"].ConnectionString);
            SqlCommand query = new SqlCommand($"Insert into Categoria values {nombre},{descripcion}", cn);
            try
            {
                cn.Open();
                query.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        public bool updateCategoria(int id, string nombre, string descripcion)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProductoContext"].ConnectionString);
            SqlCommand query = new SqlCommand($"Update Categoria set CategoriaNombre = {nombre},Descripcion = {descripcion} where CategoriaID = {id}", cn);
            try
            {
                cn.Open();
                query.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
