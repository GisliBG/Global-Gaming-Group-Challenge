using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Model.Book
{
	public interface IBookService
	{
		Book Insert(Book book);
		List<Book> GetAll();
	}
}
