using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RichRememberTheMilk.Desktop.Repositories;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Repositories;

namespace RichRememberTheMilk.WPF
{
    internal class Bootstrapper
    {
        public static void Initialize()
        {
            ApplicationContext.ConfigureGlobalDependencies(config =>
            {
                config.Bind<IRepository<TaskList>>().To<TaskListRepository>();
            });
        }
    }
}
