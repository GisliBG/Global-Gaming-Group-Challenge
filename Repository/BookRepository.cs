
using Model;
using System;

namespace Repository
{
	public class BookRepository
	{
		DataAccess db;
		public BookRepository()
		{
			db = new DataAccess();
		}

		public Book Insert(Model.Book book)
		{
			try
			{
				string sql = "INSERT INTO BOOKS (id, ISBN, TITLE, AUTHOR, LANGUAGE, PAGES) VALUES ('";
				sql += book.id.ToByteArray() + "', '" + book.ISBN + "', '" + book.Title + "', '" + book.Author + "', '" + book.Language + "', '" + book.Pages + "')";
				db.Insert(sql);
				return book;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
