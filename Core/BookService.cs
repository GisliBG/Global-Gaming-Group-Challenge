using System;
using Repository;

namespace Core
{
	public class BookService
	{
		Repository.BookRepository test;
		public BookService()
		{
			test = new Repository.BookRepository();
		}

		public Model.Book Insert(Model.Book newBook)
		{
			try
			{
				newBook.id = Guid.NewGuid();
				return test.Insert(newBook);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			

		}
	}
}
