
using TinyMVVM.Repositories;
using TinyMVVM.Framework.Services;
using System;
using System.Linq;
using TinyMVVM.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RichRememberTheMilk.ViewModel.Repositories;

namespace RichRememberTheMilk.ViewModel
{
	public partial class ApplicationContext : TinyMVVM.Framework.ViewModelBase
	{
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
			//ConfigureRepository();

			TasksLists = new ObservableCollection<TaskList>();
			SelectedList = new TaskList();
	
			
			ApplyDefaultConventions();
		}

		private void ConfigureRepository()
		{
			ConfigureDependencies(config => 
				config.Bind<IRepository<ApplicationContext>>().To<ApplicationContextRepository>());
		}
	}
		
	public partial class TaskList : TinyMVVM.Framework.ViewModelBase
	{
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
		public List<Task> SelectedTasks { get; set; } 
		public string NewTaskDescription
		{
			get { return _NewTaskDescription; }
			set
			{
				if (value != _NewTaskDescription)
				{
					UIInvoker.Invoke(() =>
					{
						_NewTaskDescription = value;
						TriggerPropertyChanged("NewTaskDescription");
					});
				}
			}
		}
		private string _NewTaskDescription;

	
		
		//Commands
		public DelegateCommand Add { get; set; }
		public DelegateCommand Complete { get; set; }
		public DelegateCommand Remove { get; set; }
		public DelegateCommand SelectAll { get; set; }
		
		public TaskList()
		{
			//ConfigureRepository();

				Tasks = new ObservableCollection<Task>();
			SelectedTasks = new List<Task>();
		
			Add = new DelegateCommand();
			Complete = new DelegateCommand();
			Remove = new DelegateCommand();
			SelectAll = new DelegateCommand();
			
			ApplyDefaultConventions();
		}

		private void ConfigureRepository()
		{
			ConfigureDependencies(config => 
				config.Bind<IRepository<TaskList>>().To<TaskListRepository>());
		}
	}
		
	public partial class Task : TinyMVVM.Framework.ViewModelBase
	{
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

		public bool IsCompleted
		{
			get { return _IsCompleted; }
			set
			{
				if (value != _IsCompleted)
				{
					UIInvoker.Invoke(() =>
					{
						_IsCompleted = value;
						TriggerPropertyChanged("IsCompleted");
					});
				}
			}
		}
		private bool _IsCompleted;

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

		public byte Priority
		{
			get { return _Priority; }
			set
			{
				if (value != _Priority)
				{
					UIInvoker.Invoke(() =>
					{
						_Priority = value;
						TriggerPropertyChanged("Priority");
					});
				}
			}
		}
		private byte _Priority;

	
		
		//Commands
		public DelegateCommand Complete { get; set; }
		
		public Task()
		{
			//ConfigureRepository();

				Due = new DateTime();
				
			Complete = new DelegateCommand();
			
			ApplyDefaultConventions();
		}

		private void ConfigureRepository()
		{
			ConfigureDependencies(config => 
				config.Bind<IRepository<Task>>().To<TaskRepository>());
		}
	}
		
}