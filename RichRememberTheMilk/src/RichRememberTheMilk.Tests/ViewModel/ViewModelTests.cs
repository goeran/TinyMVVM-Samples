
using System;
using NUnit.Framework;
using Moq;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Repositories;
using TinyMVVM.Framework.Testing;
using TinyMVVM.Framework.Testing.Services;
using TinyMVVM.Framework.Services;
using System;
using System.Linq;
using TinyMVVM.Framework;
using System.Collections.ObjectModel;
using RichRememberTheMilk.DataAccess;

namespace RichRememberTheMilk.Tests.ViewModel
{
	public abstract class ApplicationContextTestContext : TestContext
	{
		protected ApplicationContext viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake;
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake;
		protected Mock<IRepository<Task>> TaskRepositoryFake;
	
		[SetUp]
		public void Setup()
		{
			ApplicationContext.RemoveAllGlobalDependencies();
			ApplicationContext.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				TaskRepositoryFake = new Mock<IRepository<Task>>();
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		private void ConfigureRepositories()
		{
		}

		/*protected void Given_Repositories_are_configured()
		{
			ConfigureRepositories();
		}

		protected void And_Repositories_are_configured()
		{
			ConfigureRepositories();
		}*/

		protected virtual void Before()
		{
		}

		public void Given_dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			ApplicationContext.ConfigureGlobalDependencies(configAction);
		}

		public void Given_ApplicationContext_is_created()
		{
			viewModel = new ApplicationContext();
		}

		public void Given(string text, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void And_ApplicationContext_is_created()
		{
			viewModel = new ApplicationContext();
		}

		public void And_TasksLists_is_set(ObservableCollection<TaskList> value)
		{
			viewModel.TasksLists = value;
		}

		public void When_add_TasksList(Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
	
		public void And_SelectedList_is_set(TaskList value)
		{
			viewModel.SelectedList = value;
		}

	
		
	
		public void And_ApplicationContext_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		public void When_TasksLists_is_set(ObservableCollection<TaskList> value)
		{
			viewModel.TasksLists = value;
		}
		
		public void When_SelectedList_is_set(TaskList value)
		{
			viewModel.SelectedList = value;
		}
		
		
		public void When_ApplicationContext_is_spawned()
		{
			viewModel = new ApplicationContext();
		} 
		
			
		public void And(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void When(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
}

	public abstract class TaskListTestContext : TestContext
	{
		protected TaskList viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake;
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake;
		protected Mock<IRepository<Task>> TaskRepositoryFake;
	
		[SetUp]
		public void Setup()
		{
			TaskList.RemoveAllGlobalDependencies();
			TaskList.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				TaskRepositoryFake = new Mock<IRepository<Task>>();
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		private void ConfigureRepositories()
		{
		}

		/*protected void Given_Repositories_are_configured()
		{
			ConfigureRepositories();
		}

		protected void And_Repositories_are_configured()
		{
			ConfigureRepositories();
		}*/

		protected virtual void Before()
		{
		}

		public void Given_dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			TaskList.ConfigureGlobalDependencies(configAction);
		}

		public void Given_TaskList_is_created()
		{
			viewModel = new TaskList();
		}

		public void Given(string text, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void And_TaskList_is_created()
		{
			viewModel = new TaskList();
		}

		public void And_Name_is_set(String value)
		{
			viewModel.Name = value;
		}

	
		public void And_Tasks_is_set(ObservableCollection<Task> value)
		{
			viewModel.Tasks = value;
		}

		public void When_add_Task(Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
	
		
	
		public void And_TaskList_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		public void When_Name_is_set(String value)
		{
			viewModel.Name = value;
		}
		
		public void When_Tasks_is_set(ObservableCollection<Task> value)
		{
			viewModel.Tasks = value;
		}
		
		
		public void When_TaskList_is_spawned()
		{
			viewModel = new TaskList();
		} 
		
			
		public void And(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void When(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
}

	public abstract class TaskTestContext : TestContext
	{
		protected Task viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake;
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake;
		protected Mock<IRepository<Task>> TaskRepositoryFake;
	
		[SetUp]
		public void Setup()
		{
			Task.RemoveAllGlobalDependencies();
			Task.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				TaskRepositoryFake = new Mock<IRepository<Task>>();
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		private void ConfigureRepositories()
		{
		}

		/*protected void Given_Repositories_are_configured()
		{
			ConfigureRepositories();
		}

		protected void And_Repositories_are_configured()
		{
			ConfigureRepositories();
		}*/

		protected virtual void Before()
		{
		}

		public void Given_dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			Task.ConfigureGlobalDependencies(configAction);
		}

		public void Given_Task_is_created()
		{
			viewModel = new Task();
		}

		public void Given(string text, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void And_Task_is_created()
		{
			viewModel = new Task();
		}

		public void And_Description_is_set(String value)
		{
			viewModel.Description = value;
		}

	
		public void And_Due_is_set(DateTime value)
		{
			viewModel.Due = value;
		}

	
		public void And_Completed_is_set(bool value)
		{
			viewModel.Completed = value;
		}

	
		public void And_IsSelected_is_set(bool value)
		{
			viewModel.IsSelected = value;
		}

	
		
	
		public void And_Task_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		public void When_Description_is_set(String value)
		{
			viewModel.Description = value;
		}
		
		public void When_Due_is_set(DateTime value)
		{
			viewModel.Due = value;
		}
		
		public void When_Completed_is_set(bool value)
		{
			viewModel.Completed = value;
		}
		
		public void When_IsSelected_is_set(bool value)
		{
			viewModel.IsSelected = value;
		}
		
		
		public void When_Task_is_spawned()
		{
			viewModel = new Task();
		} 
		
			
		public void And(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void When(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
}

}

