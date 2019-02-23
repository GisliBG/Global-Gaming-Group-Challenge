using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public interface IBookRepository
	{
		Book Insert(Book book);
	}
}
