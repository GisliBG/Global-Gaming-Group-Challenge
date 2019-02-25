
using Model.Book;
using MySql.Data.MySqlClient;
using System;

namespace Repository
{
	public class BookRepository : IBookRepository
	{
		private string connectionString = "server=localhost;user=root;database=db;port=3306;password=Test@123";
		private MySqlConnection connection;

		public BookRepository()
		{
			connection = new MySqlConnection(connectionString);
		}

		public Book Insert(Book book)
		{
			try
			{
				connection.Open();
				string sql = "INSERT INTO BOOKS (id, ISBN, TITLE, AUTHOR, LANGUAGE, PAGES) VALUES (@id, @isbn, @title, @author, @language, @pages)";
				var cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@id", MySqlDbType.Binary).Value = book.id;
				cmd.Parameters.AddWithValue("@isbn", book.ISBN);
				cmd.Parameters.AddWithValue("@title", book.Title);
				cmd.Parameters.AddWithValue("@author", book.Author);
				cmd.Parameters.AddWithValue("@language", book.Language);
				cmd.Parameters.AddWithValue("@pages", book.Pages);
				cmd.ExecuteNonQuery();
				connection.Close();
				return book;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
