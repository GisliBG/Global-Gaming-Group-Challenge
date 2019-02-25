
using Model.Book;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.CoreTests
{
	public class MockBookRepository : IBookRepository
	{
		public IEnumerable<Book> GetAll()
		{
			throw new NotImplementedException();
		}

		public Book Insert(Book book)
		{
			return book;
		}
	}
}
