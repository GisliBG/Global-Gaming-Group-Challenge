using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Book
{
	public interface IBookRepository
	{
		Book Insert(Book book);
		List<Book> GetAll();
	}
}
