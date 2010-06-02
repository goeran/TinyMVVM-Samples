
using System;
using NUnit.Framework;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Framework.Testing;
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

		[SetUp]
		public void SetupScenario()
		{
			ServiceLocator.SetLocator(ServiceLocatorForTesting.GetServiceLocator());
			
			Setup();
			Before();
		}

		[TearDown]
		public void TearDownScenario()
		{
			TearDown();
			After();
		}

		public virtual void Setup()
		{
		}

		public virtual void Before()
		{
		}

		public virtual void After()
		{
		}

		public virtual void TearDown()
		{
		}

		public void Given(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void Given_ApplicationContext_is_created()
		{
			viewModel = new ApplicationContext();
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
	
		
	
		public void And_ApplicationContext_PropertyChangeRecording_is_Started()
		{
			viewModel.PropertyChangeRecorder.Start();
		}

		public void When_TasksLists_is_set(ObservableCollection<TaskList> value)
		{
			viewModel.TasksLists = value;
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

		public void When(string description)
		{
		}

		public void When_ApplicationContext_is_initialized()
		{
			viewModel = new ApplicationContext();
		}
}

	public abstract class TaskListTestContext : TestContext
	{
		protected TaskList viewModel;

		[SetUp]
		public void SetupScenario()
		{
			ServiceLocator.SetLocator(ServiceLocatorForTesting.GetServiceLocator());
			
			Setup();
			Before();
		}

		[TearDown]
		public void TearDownScenario()
		{
			TearDown();
			After();
		}

		public virtual void Setup()
		{
		}

		public virtual void Before()
		{
		}

		public virtual void After()
		{
		}

		public virtual void TearDown()
		{
		}

		public void Given(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void Given_TaskList_is_created()
		{
			viewModel = new TaskList();
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

		public void When(string description)
		{
		}

		public void When_TaskList_is_initialized()
		{
			viewModel = new TaskList();
		}
}

	public abstract class TaskTestContext : TestContext
	{
		protected Task viewModel;

		[SetUp]
		public void SetupScenario()
		{
			ServiceLocator.SetLocator(ServiceLocatorForTesting.GetServiceLocator());
			
			Setup();
			Before();
		}

		[TearDown]
		public void TearDownScenario()
		{
			TearDown();
			After();
		}

		public virtual void Setup()
		{
		}

		public virtual void Before()
		{
		}

		public virtual void After()
		{
		}

		public virtual void TearDown()
		{
		}

		public void Given(string description, Action unitOfWork)
		{
			unitOfWork.Invoke();
		}

		public void Given_Task_is_created()
		{
			viewModel = new Task();
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

		public void When(string description)
		{
		}

		public void When_Task_is_initialized()
		{
			viewModel = new Task();
		}
}

}

