using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RichRememberTheMilk.ViewModel;

namespace RichRememberTheMilk.Repositories
{
    public interface ITaskListRepository
    {
        IEnumerable<TaskList> Get();
    }
}
