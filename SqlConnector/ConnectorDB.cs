using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PracticasCRUD.Models;

namespace PracticasCRUD.SqlConnector
{
    public class ConnectorDB
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        private static readonly SqlConnection conn = new SqlConnection(connectionString);
        public static List<Category> getCategories()
        {
            List<Category> datos = new List<Category>();
            SqlCommand cmd = new SqlCommand() {
                CommandText = "usp_get_Category",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                datos.Add(new Category(
                    Convert.ToInt32(reader["CategoryID"].ToString()),
                    reader["CategoryName"].ToString(),
                    reader["Description"].ToString()
                    )
                );
            }
            conn.Close();
            return datos;
        }
        public static Boolean borrarCategory(int id)
        {
            SqlCommand cmd = new SqlCommand(connectionString) {
                CommandText = "usp_delete_Category",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("CategoryID", id));
            cmd.Connection = conn; 
            conn.Open();
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            return x>0;
        }
        public static Boolean editarCategory(Category c)
        {
            SqlCommand cmd = new SqlCommand() {
                CommandText = "usp_edit_Category",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Connection= conn;
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("CategoryID", c.CategoryID),
                new SqlParameter("CategoryName", c.CategoryName),
                new SqlParameter("Description", c.Description)}
                );
            conn.Open();
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            return x>0;
        }
        public static Boolean crearCategory(Category c)
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "usp_new_Category",
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Connection = conn;
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("CategoryName", c.CategoryName),
                new SqlParameter("Description", c.Description)}
                );
            conn.Open();
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            return x > 0;
        }
    }
}