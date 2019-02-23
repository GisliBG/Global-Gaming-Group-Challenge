using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Controllers 
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : Controller
	{
		private readonly IBookService _bookService;
		private readonly ILogger<BooksController> _logger;

		public BooksController(IBookService bookService , ILogger<BooksController> logger)
		{
			_bookService = bookService;
			_logger = logger;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] Book book)
		{
			Book newBook = new Model.Book()
			{
				ISBN = book.ISBN,
				Author = book.Author,
				Title = book.Title,
				Language = book.Language,
				Pages = book.Pages
			};
			try
			{
				book = _bookService.Insert(newBook);
				return Ok(book);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error creating new book");
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
