using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Repositories;
using TinyMVVM.Specifications;

namespace RichRememberTheMilk.Controllers
{
    public class ApplicationContextController
    {
        private ApplicationContext viewModel;
        private IRepository<TaskList> taskListRepository;

        public ApplicationContextController(ApplicationContext viewModel, IRepository<TaskList> taskListRepository)
        {
            this.taskListRepository = taskListRepository;
            this.viewModel = viewModel;

            LoadAllTaskLists();
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
