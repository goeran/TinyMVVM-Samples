
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RichRememberTheMilk.ViewModel;
using TinyBDD.Specification.NUnit;
using RichRememberTheMilk.Tests.ViewModel;

namespace RichRememberTheMilk.Desktop.Tests.ViewModel
{
    public class TaskListSpecs
    {
        [TestFixture]
        public class When_spawned : TaskListTestScenario<When_spawned>
        {
            protected override void Before()
            {
                When.TaskList_is_spawned();
            }

            [Test]
            public void Then_assure_it_has_Tasks()
            {
                viewModel.Tasks.ShouldNotBeNull();
            }

            [Test]
            public void Then_assure_it_has_a_Complete_command()
            {
                viewModel.Complete.ShouldNotBeNull();
            }

            [Test]
            public void Then_assure_it_has_a_Postpone_command()
            {
                viewModel.Postpone.ShouldNotBeNull();
            }

            [Test]
            public void Then_assure_it_has_Delete_command()
            {
                viewModel.Remove.ShouldNotBeNull();
            }

            [Test]
            public void Then_assure_it_has_a_Add_command()
            {
                viewModel.Add.ShouldNotBeNull();
            }

        }

        [TestFixture]
        public class When_NewTaskDesription_is_empty : TaskListTestScenario<When_NewTaskDesription_is_empty>
        {
            protected override void Before()
            {
                Given.TaskList_is_created();

                When.NewTaskDescription_is_set(string.Empty);
            }   

            [Test]
            public void Then_assure_Add_command_cant_be_executed()
            {
                viewModel.Add.CanExecute(null).ShouldBeFalse();
            }

        }

        [TestFixture]
        public class When_Add : TaskListTestScenario<When_Add>
        {
            protected override void Before()
            {
                Given.TaskList_is_created();
                And.NewTaskDescription_is_set("hello world");

                When.execute_Add_Command();
            }

            [Test]
            public void Then_assure_New_Task_has_been_added()
            {
                viewModel.Tasks.Count.ShouldBe(1);
                viewModel.Tasks.First().Description.ShouldBe("hello world");
            }

            [Test]
            public void Then_assure_NewTaskDescription_is_cleared()
            {
                viewModel.NewTaskDescription.ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_Select_Task : SharedTaskListScenario<When_Select_Task>
        {
            protected override void Before()
            {
                Given.TaskList_is_created();
                And.it_contains_tasks(ten);

                When.first_Task_is_selected();
            }

            [Test]
            public void Then_assure_its_added_to_SelectedTasks()
            {
                viewModel.SelectedTasks.Count().ShouldBe(1);
            }
        }

        [TestFixture]
        public class When_UnSelect_Task : SharedTaskListScenario<When_UnSelect_Task>
        {
            protected override void Before()
            {
                Given.TaskList_is_created();
                And.it_contains_tasks(ten);
                And.a_Task_is_selected();

                When.unselected_Task();
            }

            [Test]
            public void Then_assure_its_removed_from_SelectedTasks()
            {
                viewModel.SelectedTasks.Count().ShouldBe(0);
            }
        }

        [TestFixture]
        public class When_Remove_selected_tasks : SharedTaskListScenario<When_Remove_selected_tasks>
        {
            protected override void Before()
            {
                Given.TaskList_is_created();
                And.it_contains_tasks(ten);
                And.a_Task_is_selected();

                When.Remove_Command_is_executed();
            }

            [Test]
            public void Then_assure_removed_from_Tasks()
            {
                viewModel.Tasks.Count.ShouldBe(ten - 1);
            }

            [Test]
            public void Then_assure_assure_its_removed_from_SelectedTasks()
            {
                viewModel.SelectedTasks.Count().ShouldBe(0);
            }
        }


        public class SharedTaskListScenario<T> : TaskListTestScenario<T> where T: class
        {
            protected const int ten = 10;

            protected void it_contains_tasks(int numberOfTasks)
            {
                for (int i = 0; i < numberOfTasks; i++ )
                {
                    viewModel.Tasks.Add(new Task());
                }
            }

            protected void first_Task_is_selected()
            {
                viewModel.Tasks.First().IsSelected = true;
            }

            protected void a_Task_is_selected()
            {
                viewModel.Tasks.First().IsSelected = true;
            }

            protected void unselected_Task()
            {
                viewModel.Tasks.First().IsSelected = false;
            }
        }

    }
}