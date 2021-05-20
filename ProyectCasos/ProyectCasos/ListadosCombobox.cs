using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCasos
{
    public class ListadosCombobox
    {
        //SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KNIF4SO;Initial Catalog=Proyecto_Casos;User ID=sa;Password=123");
        //private SqlConnection cn = new SqlConnection("Data Source=DESKTOP-GBVPD8B;Initial Catalog=ProyectoCasos;User ID=sa;Password=1234");
       Conexion con = new Conexion();
       private SqlCommand com = new SqlCommand();
       private SqlDataReader LeerFilas;

        public DataTable ListarComboCondicionJuridica()
        {
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();         
            com.CommandText = "SP_ListarCondicionJuridica";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
            return Tabla;
        }

        public DataTable ListarComboDireccionAsignada()
        {
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarDireccionAsignada";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
            return Tabla;
        }


        public DataTable ListarComboJuzgadoFiscalia()
        {
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarJuzgadoFiscalia";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
            return Tabla;
        }

        public DataTable ListarComboEstadoCasos()
        {
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarEstadoCasos";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
            return Tabla;
        }

        public DataTable ListarComboRango()
        {
            DataTable Tabla = new DataTable();
            com.Connection = con.AbrirConeccion();
            com.CommandText = "SP_ListarRango";
            com.CommandType = CommandType.StoredProcedure;
            LeerFilas = com.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            com.Connection = con.CerrarConeccion();
            return Tabla;
        }

    }
}
