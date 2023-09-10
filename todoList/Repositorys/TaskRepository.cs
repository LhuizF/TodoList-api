using Microsoft.EntityFrameworkCore;
using todoList.Data;
using todoList.Models;
using todoList.Repositorys.Interfaces;

namespace todoList.Repositorys
{
	public class TaskRepository : ITaskRepository
	{
		private readonly TodoListContex _dbContext;
		public TaskRepository(TodoListContex todoListContext)
		{
			_dbContext = todoListContext;
		}
		public async Task<List<TaskModel>> FindAllTask()
		{
			return await _dbContext.Tasks
				.Include(x => x.User)
				.ToListAsync();
		}

		public async Task<TaskModel> FindById(int id)
		{
			return await _dbContext.Tasks
				.Include(x => x.User)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<TaskModel> InsertTask(TaskModel task)
		{
			await _dbContext.Tasks.AddAsync(task);
			await _dbContext.SaveChangesAsync();

			return task;
		}

		public async Task<TaskModel> UpdateTask(int id, TaskModel task)
		{
			TaskModel currentTask = await FindById(id) ?? throw new Exception($"Tarefa id:{id} não encontrado");

			if (task.Name != null)
			{
				currentTask.Name = task.Name;
			}

			if (task.Description != null)
			{
				currentTask.Description = task.Description;
			}

			if (task.Status != null)
			{
				currentTask.Status = task.Status;
			}

			if (task.UserId != null)
			{
				currentTask.UserId = task.UserId;
			}

			_dbContext.Update(currentTask);
			await _dbContext.SaveChangesAsync();

			return currentTask;
		}

		public async Task<bool> DeleteTask(int id)
		{
			TaskModel currentTask = await FindById(id) ?? throw new Exception($"Usuário id:{id} não encontrado");

			_dbContext.Tasks.Remove(currentTask);
			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
