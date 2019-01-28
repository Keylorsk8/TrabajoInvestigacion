using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSCategorias
{
    [ServiceContract]
    public interface ICategorias
    {
        [OperationContract]
        List<Categoria> getCategorias();

        [OperationContract]
        bool insertCategoria(string nombre,string descripcion);

        [OperationContract]
        bool updateCategoria(int id, string nombre, string descripcion);
    }


    [DataContract]
    public class Categoria
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
