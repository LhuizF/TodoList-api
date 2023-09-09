using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList.Models;

namespace todoList.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<UserModel>> GetAllUsers() 
		{
			Console.WriteLine("VASCO");
			return Ok();
		}
	}
}
