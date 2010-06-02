
using TinyMVVM.Framework.Services;
using System;
using System.Linq;
using TinyMVVM.Framework;
using System.Collections.ObjectModel;
using RichRememberTheMilk.DataAccess;

namespace RichRememberTheMilk.ViewModel
{
	public partial class ApplicationContext : TinyMVVM.Framework.ViewModelBase
	{
		protected IUIInvoker UIInvoker { get; set; }

		//State
		public ObservableCollection<TaskList> TasksLists { get; set; } 
		public TaskList SelectedList
		{
			get { return _SelectedList; }
			set
			{
				if (value != _SelectedList)
				{
					UIInvoker.Invoke(() =>
					{
						_SelectedList = value;
						TriggerPropertyChanged("SelectedList");
					});
				}
			}
		}
		private TaskList _SelectedList;

	
		
		//Commands
		
		public ApplicationContext()
		{
		
			ServiceLocator.SetLocatorIfNotSet(() => ServiceLocator.GetServiceLocator());
			UIInvoker = ServiceLocator.Instance.GetInstance<IUIInvoker>();
		
			ApplyDefaultConventions();
		}
	}
		
	public partial class TaskList : TinyMVVM.Framework.ViewModelBase
	{
		protected IUIInvoker UIInvoker { get; set; }

		//State
		public String Name
		{
			get { return _Name; }
			set
			{
				if (value != _Name)
				{
					UIInvoker.Invoke(() =>
					{
						_Name = value;
						TriggerPropertyChanged("Name");
					});
				}
			}
		}
		private String _Name;

		public ObservableCollection<Task> Tasks { get; set; } 
	
		
		//Commands
		
		public TaskList()
		{
		
			ServiceLocator.SetLocatorIfNotSet(() => ServiceLocator.GetServiceLocator());
			UIInvoker = ServiceLocator.Instance.GetInstance<IUIInvoker>();
		
			ApplyDefaultConventions();
		}
	}
		
	public partial class Task : TinyMVVM.Framework.ViewModelBase
	{
		protected IUIInvoker UIInvoker { get; set; }

		//State
		public String Description
		{
			get { return _Description; }
			set
			{
				if (value != _Description)
				{
					UIInvoker.Invoke(() =>
					{
						_Description = value;
						TriggerPropertyChanged("Description");
					});
				}
			}
		}
		private String _Description;

		public DateTime Due
		{
			get { return _Due; }
			set
			{
				if (value != _Due)
				{
					UIInvoker.Invoke(() =>
					{
						_Due = value;
						TriggerPropertyChanged("Due");
					});
				}
			}
		}
		private DateTime _Due;

		public bool Completed
		{
			get { return _Completed; }
			set
			{
				if (value != _Completed)
				{
					UIInvoker.Invoke(() =>
					{
						_Completed = value;
						TriggerPropertyChanged("Completed");
					});
				}
			}
		}
		private bool _Completed;

		public bool IsSelected
		{
			get { return _IsSelected; }
			set
			{
				if (value != _IsSelected)
				{
					UIInvoker.Invoke(() =>
					{
						_IsSelected = value;
						TriggerPropertyChanged("IsSelected");
					});
				}
			}
		}
		private bool _IsSelected;

	
		
		//Commands
		
		public Task()
		{
		
			ServiceLocator.SetLocatorIfNotSet(() => ServiceLocator.GetServiceLocator());
			UIInvoker = ServiceLocator.Instance.GetInstance<IUIInvoker>();
		
			ApplyDefaultConventions();
		}
	}
		
}