using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Book;
using System;
using System.Collections.Generic;

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
		
		[HttpGet]
		public ActionResult<IEnumerable<Book>> GetAll()
		{
			try
			{
				var books = _bookService.GetAll();
				return Ok(books);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error getting books");
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody] Book book)
		{

			if (book == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return StatusCode(412);
			}

			try
			{
				book = _bookService.Insert(book);
				return Ok(book);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error creating new book");
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		
	}
}
