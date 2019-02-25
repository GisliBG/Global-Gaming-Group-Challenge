using Model.User;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public class UserRepository : IUserRepository
	{
		private string connectionString = "server=localhost;user=root;database=db;port=3306;password=Test@123";
		private MySqlConnection connection;

		public UserRepository()
		{
			connection = new MySqlConnection(connectionString);
		}

		public User AddUser(User user)
		{
			try
			{
				connection.Open();
				string sql = "INSERT INTO USERS (id, EMAIL, Password, FIRST_NAME, LAST_NAME, ADDRESS, PHONE) VALUES (@id, @email, @password, @first, @last, @address, @phone)";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.Add("@id", MySqlDbType.Binary).Value = user.Id;
				cmd.Parameters.AddWithValue("@email", user.Email);
				cmd.Parameters.AddWithValue("@password", user.Password);
				cmd.Parameters.AddWithValue("@first", user.FirstName);
				cmd.Parameters.AddWithValue("@last", user.LastName);
				cmd.Parameters.AddWithValue("@address", user.Address);
				cmd.Parameters.AddWithValue("@phone", user.Phone);
				cmd.ExecuteNonQuery();
				connection.Close();
				return user;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public User GetUser(Guid id)
		{
			try
			{
				connection.Open();
				string sql = "SELECT * FROM USERS WHERE id = @id";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@id", id);
				var reader = cmd.ExecuteReader();
				reader.Read();
				User user = new User();
				var readerid = (Guid)reader[0];
				user.Id = new Guid(readerid.ToByteArray());
				user.Email = reader.GetValue(1).ToString();
				user.Password = reader.GetValue(2).ToString();
				user.FirstName = reader.GetValue(3).ToString();
				user.LastName = reader.GetValue(4).ToString();
				user.Address = reader.GetValue(5).ToString();
				user.Phone = reader.GetValue(6).ToString();
				connection.Close();
				return user;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void Remove(Guid id)
		{
			try
			{
				connection.Open();
				string sql = "DELETE FROM USERS WHERE id = @id";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.Add("@id", MySqlDbType.Binary).Value = id;
				cmd.ExecuteNonQuery();
				connection.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}

		
	}
}
