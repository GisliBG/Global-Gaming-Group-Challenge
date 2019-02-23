
using Model.Book;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.CoreTests
{
	public class MockBookRepository : IBookRepository
	{
		public Book Insert(Book book)
		{
			return book;
		}
	}
}
