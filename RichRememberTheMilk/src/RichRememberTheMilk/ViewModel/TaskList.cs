using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RichRememberTheMilk.ViewModel
{
    public partial class TaskList
    {
        public void OnInitialize()
        {
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Task task in e.NewItems)
                {
                    task.PropertyChanged += task_PropertyChanged;
                }
            }
        }

        void task_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var task = sender as Task;
                if (task.IsSelected)
                    SelectedTasks.Add(task);
            }
        }

        public void OnAdd()
        {
            Tasks.Add(new Task()
            {
                Description = NewTaskDescription
            });

            NewTaskDescription = null;
        }

        public bool CanAdd()
        {
            return !string.IsNullOrEmpty(NewTaskDescription);
        }
    }
}
