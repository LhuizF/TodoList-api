using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList.Models;
using todoList.Repositorys.Interfaces;

namespace todoList.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly ITaskRepository _taskRepository;

		public TaskController(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
		{
			List<TaskModel> tasks = await _taskRepository.FindAllTask();
			return Ok(tasks);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TaskModel>> FindById(int id)
		{
			TaskModel tasks = await _taskRepository.FindById(id);
			return Ok(tasks);
		}

		[HttpPost]
		public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel task)
		{
			TaskModel newTask= await _taskRepository.InsertTask(task);
			return Ok(newTask);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel task, int id)
		{
			task.Id = id;
			TaskModel updatedTask = await _taskRepository.UpdateTask(id, task);
			return Ok(updatedTask);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<TaskModel>> Delete(int id)
		{
			bool isDelete = await _taskRepository.DeleteTask(id);
			return Ok(isDelete);
		}
	}
}

