using Microsoft.EntityFrameworkCore;
using todoList.Data;
using todoList.Models;
using todoList.Repositorys.Interfaces;

namespace todoList.Repositorys
{
	public class UserRepository : IUserRepository
	{
		private readonly TodoListContex _dbContext;
		public UserRepository(TodoListContex todoListContext)
		{
			_dbContext = todoListContext;
		}
		public async Task<List<UserModel>> FindAllUser()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<UserModel> FindById(int id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<UserModel> InsertNewUser(UserModel user)
		{
			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<UserModel> UpdateUser(int id, UserModel user)
		{
			UserModel currentUser = await FindById(id) ?? throw new Exception($"Usuário id:{id} não encontrado");

			if (user.Name != null)
			{
				currentUser.Name = user.Name;
			}

			if (user.Email != null)
			{
				currentUser.Email = user.Email;
			}

			_dbContext.Update(currentUser);
			await _dbContext.SaveChangesAsync();

			return currentUser;
		}

		public async Task<bool> DeleteUser(int id)
		{
			UserModel currentUser = await FindById(id) ?? throw new Exception($"Usuário id:{id} não encontrado");

			_dbContext.Users.Remove(currentUser);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<UserTasksModel> FindUserTask(int id)
		{
			UserModel user = await FindById(id) ?? throw new Exception("Usuario não encontrado");
			List<TaskModel> tasks = _dbContext.Tasks.Where(x => x.Id == user.Id).ToList();

			UserTasksModel userTasks = new UserTasksModel(user)
			{
				tasks = tasks
			};

			return userTasks;
		}
	}
}
