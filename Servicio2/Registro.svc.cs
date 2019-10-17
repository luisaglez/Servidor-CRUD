using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace Servicio2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Registro" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Registro.svc o Registro.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Registro : IRegistro
    {
       
        public void guardar(int a, string b, string c, string d, int e, string f, string g, string h)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "insert into  Alumno4 values('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "','" + g + "','" + h + "')";
            cmd = new SqlCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string[] buscar(int cla)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            string[] datos = new string[8];
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "select * from Alumno4 where No_control=" + cla;
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            if (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetString(2);
                datos[3] = dato.GetString(3);
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetString(5);
                datos[6] = dato.GetString(6);
                datos[7] = dato.GetString(7);
            }
            con.Close();
            return datos;
        }

        public List<string> mostrar()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            var datos = new string[8];
            var consulta = new List<string>();
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "select * from Alumno4";
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            int i = 0;
            while (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetString(2);
                datos[3] = dato.GetString(3);
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetString(5);
                datos[6] = dato.GetString(6);
                datos[7] = dato.GetString(7);
                consulta.InsertRange(i, datos);
                i = i + 8;
            }
            con.Close();
            return consulta;
        }
       
        public bool borrar (int a)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "delete from Alumno4 where No_control=" + a;
            cmd = new SqlCommand(cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }


        public bool editar(int a, string b, string c, string d, int e, string f, string g, string h)
            {
            SqlConnection con;
        SqlCommand cmd;
        string cadena = "";
        con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
        con.Open();
            cadena = "UPDATE Alumno4 SET No_control = ('" + a + "'), Nombres= ('" + b + "'), Apellidos= ('" + c + "') , Carrera= ('" + d + "') , Semestre= ('" + e + "'), Direccion= ('" + f + "'), Telefono= ('" + g + "') , Sexo= ('" + h + "')where No_control = ('" + a + "') ";
            cmd = new SqlCommand(cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();


        }


}
}

