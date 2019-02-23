using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Core
{
	public interface IBookService
	{
		Book Insert(Book book);
	}
}
