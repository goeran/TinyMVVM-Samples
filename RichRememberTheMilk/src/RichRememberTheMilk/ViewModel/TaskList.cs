using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RichRememberTheMilk.ViewModel
{
    public partial class TaskList
    {
        public void OnAdd()
        {
            Tasks.Add(new Task()
            {
                Description = NewTaskDescription
            });

            NewTaskDescription = null;
        }
    }
}
