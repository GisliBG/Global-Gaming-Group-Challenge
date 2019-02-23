using System;
using Repository;

namespace Core
{
	public class BookService : IBookService
	{
		IBookRepository _bookRepository;
		public BookService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public Model.Book Insert(Model.Book newBook)
		{
			try
			{
				newBook.id = Guid.NewGuid();
				return _bookRepository.Insert(newBook);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			

		}
	}
}
