using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RichRememberTheMilk.Repositories;
using RichRememberTheMilk.ViewModel;

namespace RichRememberTheMilk.Desktop.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        public IEnumerable<TaskList> Get()
        {
            var inboxList = new TaskList { Name = "Inbox" };
            inboxList.Tasks.Add(new Task { Description = "Buy milk" });
            inboxList.Tasks.Add(new Task { Description = "Find a hot blonde Norwegian girl" });
            inboxList.Tasks.Add(new Task { Description = "Find another hot blonde Norwegian girl" });

            var workList = new TaskList { Name = "Work" };
            workList.Tasks.Add(new Task { Description = "Steal milk from work to bring home" });

            var lists = new List<TaskList>();
            lists.Add(inboxList);
            lists.Add(workList);
            return lists;
        }
    }
}
