using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Repository
{
	public class DataAccess
	{
		private string connectionString = "server=localhost;user=root;database=db;port=3306;password=Test@123";
		private MySqlConnection connection;

		public DataAccess()
		{
			
			connection = new MySqlConnection(connectionString);
			
		}

		public void Insert(string sql)
		{
				connection.Open();
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				connection.Close();	
		}

		~DataAccess()
		{
			connection.Dispose();
		}
	}
}
