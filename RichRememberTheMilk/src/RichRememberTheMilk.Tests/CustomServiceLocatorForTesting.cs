using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Moq;
using RichRememberTheMilk.Repositories;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Framework.Testing;

namespace RichRememberTheMilk.Desktop.Tests
{
    [Export(typeof(ServiceLocatorForTesting))]
    public class CustomServiceLocatorForTesting : ServiceLocatorForTesting
    {
        [Export(typeof(ITaskListRepository))]
        public ITaskListRepository TaskListRepository;

        [Export(typeof(Mock<ITaskListRepository>))]
        public Mock<ITaskListRepository> TaskListRepositoryFake;
        
        private List<Object> dependencies = new List<object>();

        public CustomServiceLocatorForTesting()
        {
            TaskListRepositoryFake = new Mock<ITaskListRepository>();
            TaskListRepository = TaskListRepositoryFake.Object;
            dependencies.Add(TaskListRepositoryFake);
            dependencies.Add(TaskListRepository);
        }

        public override T GetInstance<T>()
        {
            return dependencies.Where(i => i is T).SingleOrDefault() as T;
        }
    }
}
