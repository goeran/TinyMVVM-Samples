
using System.Collections.Generic;
using TinyMVVM.Repositories;
using TinyMVVM.Specifications;
using TinyMVVM.Framework.Services;
using System;
using System.Linq;
using TinyMVVM.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RichRememberTheMilk.ViewModel.Repositories
{
	public partial class ApplicationContextRepository : IRepository<ApplicationContext>
	{
		public IEnumerable<ApplicationContext> Get()
	    {
	        throw new NotImplementedException();
	    }

	    public IEnumerable<ApplicationContext> Get(ISpecification<ApplicationContext> spec)
	    {
	        throw new NotImplementedException();
	    }

		//public partial IEnumerable<ApplicationContext> Haldis();
	}
		
	public partial class TaskListRepository : IRepository<TaskList>
	{
		public IEnumerable<TaskList> Get()
	    {
	        throw new NotImplementedException();
	    }

	    public IEnumerable<TaskList> Get(ISpecification<TaskList> spec)
	    {
	        throw new NotImplementedException();
	    }

		//public partial IEnumerable<TaskList> Haldis();
	}
		
	public partial class TaskRepository : IRepository<Task>
	{
		public IEnumerable<Task> Get()
	    {
	        throw new NotImplementedException();
	    }

	    public IEnumerable<Task> Get(ISpecification<Task> spec)
	    {
	        throw new NotImplementedException();
	    }

		//public partial IEnumerable<Task> Haldis();
	}
		
}