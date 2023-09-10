namespace todoList.Models
{
	public class UserTasksModel : UserModel
	{
		public  List<TaskModel> tasks { get; set; }
		public UserTasksModel(UserModel user)
		{
			Id = user.Id;
			Name = user.Name;
			Email = user.Email;
			tasks = new List<TaskModel>();
		}
	}
}
