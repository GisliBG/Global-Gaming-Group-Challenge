﻿using Model.Purchase;
using Model.User;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public class UserRepository : IUserRepository
	{
		private string connectionString = "****";
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
				cmd = SetParamsToUsers(cmd, user.Id, user.Email, user.Password, user.FirstName, user.LastName, user.Address, user.Phone);
				cmd.ExecuteNonQuery();
				connection.Close();
				return user;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private MySqlCommand SetParamsToUsers(MySqlCommand cmd, Guid id, string email, string password, string firstName, string lastName, string address, string phone)
		{
			cmd.Parameters.Add("@id", MySqlDbType.Binary).Value = id;
			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.Parameters.AddWithValue("@first", firstName);
			cmd.Parameters.AddWithValue("@last", lastName);
			cmd.Parameters.AddWithValue("@address", address);
			cmd.Parameters.AddWithValue("@phone", phone);

			return cmd;
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
				reader.Close();
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

		public void Update(User user)
		{
			try
			{
				connection.Open();
				string sql = "UPDATE USERS SET Email = @email, Password = @password, FIRST_NAME = @first, LAST_NAME = @last, ADDRESS = @address, PHONE = @phone WHERE Id = @id";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd = SetParamsToUsers(cmd, user.Id, user.Email, user.Password, user.FirstName, user.LastName, user.Address, user.Phone);
				cmd.ExecuteNonQuery();
				connection.Close();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void PurchaseBooks(Purchase purchase, Guid userId)
		{
			try
			{
				connection.Open();
				string purchaseSQL = "INSERT INTO PURCHASE (id, user_id) VALUES (@id, @userId)";
				MySqlCommand cmd = new MySqlCommand(purchaseSQL, connection);
				cmd.Parameters.Add("@id", MySqlDbType.Binary).Value = purchase.Id;
				cmd.Parameters.Add("@userId", MySqlDbType.Binary).Value = userId;
				cmd.ExecuteNonQuery();

				foreach(var purchaseItem in purchase.purchaseItems)
				{
					string purchaseItemSQL = "INSERT INTO PURCHASE_ITEM (purchase_id, book_id, total_price, number_of_items) VALUES (@purchaseId, @bookId, @totalPrice, @numberOfItems)";
					cmd = new MySqlCommand(purchaseItemSQL, connection);
					cmd.Parameters.Add("@purchaseId", MySqlDbType.Binary).Value = purchase.Id;
					cmd.Parameters.Add("@bookId", MySqlDbType.Binary).Value = purchaseItem.Book.id;
					cmd.Parameters.AddWithValue("@totalPrice", purchaseItem.Book.Price * purchaseItem.Quantity);
					cmd.Parameters.AddWithValue("@numberOfItems", purchaseItem.Quantity);
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Purchase> GetPurchases(Guid userId)
		{
			try
			{
				connection.Open();
				string sql =	"SELECT P.id, PI.book_id, PI.total_price, PI.number_of_items, b.title, b.author, b.ISBN, b.Language, b.pages, b.price, b.In_stock " +
								"FROM PURCHASE AS P " +
								"Left JOIN PURCHASE_ITEM AS PI ON p.id = PI.purchase_id " +
								"Left JOIN Books as b ON PI.book_id = b.id " +
								"WHERE p.user_id = @userId";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.Add("@userId", MySqlDbType.Binary).Value = userId;

				var reader = cmd.ExecuteReader();

				List<Purchase> purchases = new List<Purchase>();
				while (reader.Read())
				{
					if(purchases.Find(p => p.Id == reader.GetGuid(0)) == null)
					{
						purchases.Add(new Purchase() { Id = reader.GetGuid(0), purchaseItems = new List<PurchaseItem>() });
					}
					
					purchases[purchases.Count - 1].purchaseItems.Add(new PurchaseItem()
					{
						Id = reader.GetGuid(0),
						Book = new Model.Book.Book()
						{
							id = reader.GetGuid(1),
							Title = reader.GetString(4),
							Author = reader.GetString(5),
							ISBN = reader.GetString(6),
							Language = reader.GetString(7),
							Pages = reader.GetString(8),
							Price = reader.GetInt32(9),
							InStock = reader.GetInt32(10)
						},
						TotalPrice = reader.GetInt32(2),
						Quantity = reader.GetInt32(3)
					});
				}
				reader.Close();
				connection.Close();
				return purchases;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
