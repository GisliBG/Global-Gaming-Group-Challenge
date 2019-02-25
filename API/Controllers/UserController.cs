using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Purchase;
using Model.User;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly ILogger<UserController> _logger;

		public UserController(IUserService userService, ILogger<UserController> logger)
		{
			_userService = userService;
			_logger = logger;
		}

		[HttpGet("{userId}")]
		public IActionResult GetUser(string userId)
		{
			if(userId == null)
			{
				return BadRequest();
			}

			try
			{
				var user = _userService.GetUser(new Guid(userId));
				return Ok(user);
			}
			catch(Exception ex)
			{
				_logger.LogError("Error Getting user", ex);
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult AddUser([FromBody] User user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return StatusCode(412);
			}

			try
			{
				var newUser = _userService.CreateUser(user);
				return Ok(user);
			}
			catch(Exception ex)
			{
				_logger.LogError("Error creating new user", ex);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
			
		}

		[HttpPut]
		public IActionResult UpdateUser([FromBody] User user)
		{
			if(user == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return StatusCode(412);
			}

			try
			{
				_userService.UpdateUser(user);
				return Ok();
			}
			catch(Exception ex)
			{
				_logger.LogError("Error updating user", ex);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete]
		public IActionResult RemoveUser([FromBody] User user)
		{
			if (user == null || user.Id == null || user.Password == null)
			{
				return BadRequest();
			}

			try
			{
				_userService.RemoveUser(user);
				return Ok();
			}
			catch(Exception ex)
			{
				_logger.LogError("Error creating new user", ex);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPost("Purchase/{userId}")]
		public IActionResult PurchaseBooks([FromBody] List<PurchaseItem> bookPurchases, string userId)
		{
			if(bookPurchases == null || String.IsNullOrEmpty(userId))
			{
				return BadRequest();
			}

			try
			{
				var purchase = _userService.Purchase(bookPurchases, new Guid(userId));
				return Ok(purchase);
			}
			catch (Exception ex)
			{
				_logger.LogError("Error purchasing", ex);
				return new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}
		}

	}
}