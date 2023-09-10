using todoList.Models;

namespace todoList.Repositorys.Interfaces
{
	public interface ITaskRepository
	{
		Task<List<TaskModel>> FindAllTask();
		Task<TaskModel> FindById(int id);
		Task<TaskModel> InsertTask(TaskModel task);
		Task<TaskModel> UpdateTask(int id, TaskModel task);
		Task<bool> DeleteTask(int id);
	}
}
