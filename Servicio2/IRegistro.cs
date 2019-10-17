using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRegistro" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRegistro
    {
        [OperationContract]
        void guardar(int a, string b, string c, string d, int e, string f, string g, string h);
        [OperationContract]
        string[] buscar(int cla);
        [OperationContract]
        List<string> mostrar();
        [OperationContract]
        bool borrar(int a);
        [OperationContract]
        bool editar(int a, string b, string c, string d, int e, string f, string g, string h);
    }
}
