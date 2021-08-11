using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectCasos
{
    class Conexion
    {
        static private string CadenaConeccion = "Data Source=ASUS-JOSE\\SQLEXPRESS;Initial Catalog=ProyectoCasos;Integrated Security=True";
        //static private string CadenaConeccion = "Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234";
        //static private string CadenaConeccion = "Data Source=DESKTOP-T0686SL;Initial Catalog=Proyecto_Casos;User ID=sa;Password=lfer";
        private SqlConnection Coneccion = new SqlConnection(CadenaConeccion); 

        public SqlConnection AbrirConeccion()
        {
            if(Coneccion.State==ConnectionState.Closed)
            
                Coneccion.Open();
                return Coneccion;            
        }
        public SqlConnection CerrarConeccion()
        {
            if (Coneccion.State == ConnectionState.Open)
            
                Coneccion.Close();
                return Coneccion;           
        }
    }
}
