
using TinyMVVM.Repositories;
using TinyMVVM.Framework.Services;
using System;
using System.Linq;
using TinyMVVM.Framework;
using System.Collections.ObjectModel;
using RichRememberTheMilk.DataAccess;
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
	
		
		//Commands
		
		public TaskList()
		{
			//ConfigureRepository();

				Tasks = new ObservableCollection<Task>();
	
			
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
			//ConfigureRepository();

				Due = new DateTime();
			
			
			ApplyDefaultConventions();
		}

		private void ConfigureRepository()
		{
			ConfigureDependencies(config => 
				config.Bind<IRepository<Task>>().To<TaskRepository>());
		}
	}
		
}