using System.Collections.Generic;
using RichRememberTheMilk.Repositories;

namespace RichRememberTheMilk.ViewModel
{
    public partial class ApplicationContext
    {
        public void OnInitialize()
        {
            LoadAllTaskLists();
        }

        private void LoadAllTaskLists()
        {
            foreach (var taskList in GetAllTaskLists()) 
                TasksLists.Add(taskList);
        }

        private IEnumerable<TaskList> GetAllTaskLists()
        {
            return GetInstance<ITaskListRepository>().Get();

        }
    }
}