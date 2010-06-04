
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
	public abstract class ScenarioClass<T> where T: class
	{
        protected T Given { get { return this as T; } }
        protected T And { get { return this as T; } }
        protected T When { get { return this as T; } }
        protected T Then { get { return this as T; } }
	}

	public abstract class ApplicationContextTestContext<T> : ScenarioClass<T> where T: class
	{
		protected ApplicationContext viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
		protected Mock<IRepository<Task>> TaskRepositoryFake = new Mock<IRepository<Task>>();
	
		[SetUp]
		public void Setup()
		{
			ApplicationContext.RemoveAllGlobalDependencies();
			ApplicationContext.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		protected virtual void Before()
		{
		}

		[TearDown]
		public void TearDown()
		{
			After();
			ApplicationContext.RemoveAllGlobalDependencies();
		}

		protected virtual void After()
		{
		}

		//Given
		public void dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			ApplicationContext.ConfigureGlobalDependencies(configAction);
		}

		//Given & And
		public void ApplicationContext_is_created()
		{
			viewModel = new ApplicationContext();
		}

		//And
		public void TasksLists_is_set(ObservableCollection<TaskList> value)
		{
			viewModel.TasksLists = value;
		}

		//When
	public void add_TasksList(Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
	
		public void SelectedList_is_set(TaskList value)
		{
			viewModel.SelectedList = value;
		}

	
		

		//And
		public void ApplicationContext_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		//When
		public void ApplicationContext_is_spawned()
		{
			viewModel = new ApplicationContext();
		} 
		
		//And
	}

	public abstract class TaskListTestContext<T> : ScenarioClass<T> where T: class
	{
		protected TaskList viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
		protected Mock<IRepository<Task>> TaskRepositoryFake = new Mock<IRepository<Task>>();
	
		[SetUp]
		public void Setup()
		{
			TaskList.RemoveAllGlobalDependencies();
			TaskList.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		protected virtual void Before()
		{
		}

		[TearDown]
		public void TearDown()
		{
			After();
			TaskList.RemoveAllGlobalDependencies();
		}

		protected virtual void After()
		{
		}

		//Given
		public void dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			TaskList.ConfigureGlobalDependencies(configAction);
		}

		//Given & And
		public void TaskList_is_created()
		{
			viewModel = new TaskList();
		}

		//And
		public void Name_is_set(String value)
		{
			viewModel.Name = value;
		}

	
		public void Tasks_is_set(ObservableCollection<Task> value)
		{
			viewModel.Tasks = value;
		}

		//When
	public void add_Task(Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
	
		public void SelectedTasks_is_set(ObservableCollection<Task> value)
		{
			viewModel.SelectedTasks = value;
		}

		//When
	public void add_SelectedTask(Action unitOfWork)
		{
			unitOfWork.Invoke();
		}
	
		public void NewTaskDescription_is_set(string value)
		{
			viewModel.NewTaskDescription = value;
		}

	
		

		//And
		public void TaskList_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		//When
		public void TaskList_is_spawned()
		{
			viewModel = new TaskList();
		} 
		
		//And
		public void Add_Command_is_executed()
		{
			viewModel.Add.Execute(null);
		}

		//When
		public void execute_Add_Command()
		{
			viewModel.Add.Execute(null);
		}
		public void Complete_Command_is_executed()
		{
			viewModel.Complete.Execute(null);
		}

		//When
		public void execute_Complete_Command()
		{
			viewModel.Complete.Execute(null);
		}
		public void Postpone_Command_is_executed()
		{
			viewModel.Postpone.Execute(null);
		}

		//When
		public void execute_Postpone_Command()
		{
			viewModel.Postpone.Execute(null);
		}
		public void Delete_Command_is_executed()
		{
			viewModel.Delete.Execute(null);
		}

		//When
		public void execute_Delete_Command()
		{
			viewModel.Delete.Execute(null);
		}
	}

	public abstract class TaskTestContext<T> : ScenarioClass<T> where T: class
	{
		protected Task viewModel;

		protected Mock<IRepository<ApplicationContext>> ApplicationContextRepositoryFake = new Mock<IRepository<ApplicationContext>>();
		protected Mock<IRepository<TaskList>> TaskListRepositoryFake = new Mock<IRepository<TaskList>>();
		protected Mock<IRepository<Task>> TaskRepositoryFake = new Mock<IRepository<Task>>();
	
		[SetUp]
		public void Setup()
		{
			Task.RemoveAllGlobalDependencies();
			Task.ConfigureGlobalDependencies(config =>
			{
				config.Bind<IUIInvoker>().To<UIInvokerForTesting>();

				config.Bind<IRepository<ApplicationContext>>().ToInstance(ApplicationContextRepositoryFake.Object);
				config.Bind<IRepository<TaskList>>().ToInstance(TaskListRepositoryFake.Object);
				config.Bind<IRepository<Task>>().ToInstance(TaskRepositoryFake.Object);
		
			});

			Before();
		}

		protected virtual void Before()
		{
		}

		[TearDown]
		public void TearDown()
		{
			After();
			Task.RemoveAllGlobalDependencies();
		}

		protected virtual void After()
		{
		}

		//Given
		public void dependencies_are_configured(Action<DependencyConfigSemantics> configAction)
		{
			Task.ConfigureGlobalDependencies(configAction);
		}

		//Given & And
		public void Task_is_created()
		{
			viewModel = new Task();
		}

		//And
		public void Description_is_set(String value)
		{
			viewModel.Description = value;
		}

	
		public void Due_is_set(DateTime value)
		{
			viewModel.Due = value;
		}

	
		public void Completed_is_set(bool value)
		{
			viewModel.Completed = value;
		}

	
		public void IsSelected_is_set(bool value)
		{
			viewModel.IsSelected = value;
		}

	
		

		//And
		public void Task_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		//When
		public void Task_is_spawned()
		{
			viewModel = new Task();
		} 
		
		//And
	}

}

