using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList.Models;
using todoList.Repositorys.Interfaces;

namespace todoList.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		[HttpGet]
		public async Task<ActionResult<List<UserModel>>> GetAllUsers()
		{
			List<UserModel> users = await _userRepository.FindAllUser();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserModel>> FindById(int id)
		{
			UserModel user = await _userRepository.FindById(id);
			return Ok(user);
		}

		[HttpPost]
		public async Task<ActionResult<UserModel>> Create([FromBody] UserModel newUser)
		{
			UserModel user = await _userRepository.InsertNewUser(newUser);
			return Ok(user);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id)
		{
			UserModel updatedUser = await _userRepository.UpdateUser(id, user);
			return Ok(updatedUser);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<UserModel>> Delete(int id)
		{
			bool isDelete = await _userRepository.DeleteUser(id);
			return Ok(isDelete);
		}

		[HttpGet("{id}/tasks")]
		public async Task<ActionResult<UserModel>> FindAllUserTasks(int id)
		{

			var userTasks = await _userRepository.FindUserTask(id);

			return Ok(userTasks);
		}
	}
}
