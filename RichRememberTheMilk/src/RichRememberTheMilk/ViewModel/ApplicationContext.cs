using System.Collections.Generic;
using RichRememberTheMilk.Controllers;
using RichRememberTheMilk.Desktop.Repositories;
using RichRememberTheMilk.Repositories;

namespace RichRememberTheMilk.ViewModel
{
    public partial class ApplicationContext
    {
        public void OnInitialize()
        {
            ConfigureDependencies(config => config.Bind<ITaskListRepository>().To<TaskListRepository>());
            RegisterController<ApplicationContextController>();
        }
    }
}