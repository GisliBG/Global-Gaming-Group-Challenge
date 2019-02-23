using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Book;
using Repository;

namespace Test.CoreTests
{
	[TestClass]
	public class BookServiceTests
	{
		private IBookRepository _bookRepository;
		private IBookService _bookService;

		[TestInitialize]
		public void Setup()
		{
			_bookRepository = new MockBookRepository();
			_bookService = new BookService(_bookRepository);
		}

		[TestMethod]
		public void InsertBook()
		{
			// Arrange
			var newBook = new Book() { Author = "Author", ISBN = "1234", Language = "Svenska", Pages = "0", Title = "Title" };

			// Act
			var result = _bookService.Insert(newBook);

			// Assert
			Assert.IsInstanceOfType(result, typeof(Book));

		}
	}
}
