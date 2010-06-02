using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RichRememberTheMilk.Repositories;
using RichRememberTheMilk.ViewModel;

namespace RichRememberTheMilk.Controllers
{
    public class ApplicationContextController
    {
        private ApplicationContext viewModel;
        private ITaskListRepository taskListRepository;

        public ApplicationContextController(ApplicationContext viewModel, ITaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;
            this.viewModel = viewModel;

            //LoadAllTaskLists();
        }

        private void LoadAllTaskLists()
        {
            foreach (var taskList in GetAllTaskLists())
                viewModel.TasksLists.Add(taskList);
        }

        private IEnumerable<TaskList> GetAllTaskLists()
        {
            return taskListRepository.Get();

        }
    }
}
