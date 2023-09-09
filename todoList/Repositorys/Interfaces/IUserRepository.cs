using todoList.Models;

namespace todoList.Repositorys.Interfaces
{
	public interface IUserRepository
	{
		Task<List<UserModel>> FindAllUser();
		Task<UserModel> FindById(int id);
		Task<UserModel> InsertNewUser(UserModel user);
		Task<UserModel> UpdateUser(int id, UserModel user);
		Task<bool> DeleteUser(int id);
	}
}
