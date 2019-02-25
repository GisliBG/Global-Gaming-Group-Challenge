using Model.Book;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

		public IEnumerable<Book> GetAll()
		{
			try
			{
				connection.Open();
				string sql = "SELECT * FROM BOOKS";
				var cmd = new MySqlCommand(sql, connection);
				var reader = cmd.ExecuteReader();
				List<Book> books = new List<Book>();
				while(reader.Read())
				{
					books.Add(new Book()
					{
						ISBN = reader.GetString(0),
						Title = reader.GetString(1),
						Author = reader.GetString(2),
						Language = reader.GetString(3),
						Pages = reader.GetString(4),
						id = reader.GetGuid(5)
					});
				}
				reader.Close();
				connection.Close();
				return books;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public Book Insert(Book book)
		{
			try
			{
				connection.Open();
				string sql = "INSERT INTO BOOKS (ISBN, TITLE, AUTHOR, LANGUAGE, PAGES, id) VALUES (@isbn, @title, @author, @language, @pages, @id)";
				var cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.Add("@id", MySqlDbType.Binary).Value = book.id;
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
