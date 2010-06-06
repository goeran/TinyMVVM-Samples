using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TinyMVVM.Framework;

namespace RichRememberTheMilk.ViewModel
{
    public partial class TaskList
    {
        public void OnInitialize()
        {
            PopulateMoreActions();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void PopulateMoreActions()
        {
            MoreActions.Add(SelectAll);
            MoreActions.Add(DeselectAll);
            MoreActions.Add(Remove);
        }

        void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Task task in e.NewItems)
                    task.PropertyChanged += task_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Task task in e.OldItems)
                    task.PropertyChanged -= task_PropertyChanged;
            }
        }

        void task_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                SelectedTasks = GetSelectedTasks();
            }
        }

        private List<Task> GetSelectedTasks()
        {
            return (from task in Tasks
                   where task.IsSelected
                   select task).ToList();
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

        public void OnRemove()
        {
            foreach (var selectedTask in SelectedTasks)
                Tasks.Remove(selectedTask);
            SelectedTasks = GetSelectedTasks();
        }

        public void OnComplete()
        {
            SelectedTasks.ForEach(task =>
            {
                task.Complete.Execute(null);
            });
        }

        public void OnSelectAll()
        {
            foreach (var task in Tasks)
                task.IsSelected = true;
            SelectAll.TriggerCanExecuteChanged();
        }

        public bool CanSelectAll()
        {
            return Tasks.Where(t => t.IsSelected).Count() != Tasks.Count;
        }

        public void OnDeselectAll()
        {
            foreach (var task in Tasks)
                task.IsSelected = false;
        }
    }
}
