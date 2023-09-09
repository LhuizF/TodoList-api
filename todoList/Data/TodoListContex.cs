using Microsoft.EntityFrameworkCore;
using todoList.Data.Map;
using todoList.Models;

namespace todoList.Data
{
	public class TodoListContex : DbContext
	{
		public TodoListContex(DbContextOptions<TodoListContex> options) : base(options) { }

		public DbSet<UserModel> Users { get; set; }
		public DbSet<TaskModel> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMap());
			modelBuilder.ApplyConfiguration(new TaskMap());
			base.OnModelCreating(modelBuilder);
		}
	}
}
