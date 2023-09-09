using System.ComponentModel;

namespace todoList.Enums
{
	public enum StatusTask
	{
		[Description("A fazer")]
		ToDo = 1,
		[Description("Fazendo")]
		InProgress = 2,
		[Description("Completa")]
		Complete = 3,
	}
}
