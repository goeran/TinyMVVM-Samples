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
        public class When_spawned : TaskListTestContext
        {
            protected override void Before()
            {
                When_TaskList_is_spawned();
            }

            [Test]
            public void Assure_it_has_Tasks()
            {
                viewModel.Tasks.ShouldNotBeNull();
            }

            [Test]
            public void assure_it_has_a_Complete_command()
            {
                viewModel.Complete.ShouldNotBeNull();
            }

            [Test]
            public void assure_it_has_a_Postpone_command()
            {
                viewModel.Postpone.ShouldNotBeNull();
            }

            [Test]
            public void assure_it_has_Delete_command()
            {
                viewModel.Delete.ShouldNotBeNull();
            }

            [Test]
            public void assure_it_has_a_Add_command()
            {
                viewModel.Add.ShouldNotBeNull();
            }

        }

        [TestFixture]
        public class When_NewTaskDesription_is_empty : TaskListTestContext
        {
            protected override void Before()
            {
                Given_TaskList_is_created();

                When_NewTaskDescription_is_set(string.Empty);
            }   

            [Test]
            public void assure_Add_command_cant_be_executed()
            {
                viewModel.Add.CanExecute(null).ShouldBeFalse();
            }

        }

        [TestFixture]
        public class When_Add : TaskListTestContext
        {
            protected override void Before()
            {
                Given_TaskList_is_created();
                And("Task name is added", () =>
                {
                    viewModel.NewTaskDescription = "hello world";
                });

                When_execute_Add_Command();
            }

            [Test]
            public void assure_New_Task_has_been_added()
            {
                viewModel.Tasks.Count.ShouldBe(1);
                viewModel.Tasks.First().Description.ShouldBe("hello world");
            }

            [Test]
            public void assure_NewTaskDescription_is_cleared()
            {
                viewModel.NewTaskDescription.ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_Select_Task : TaskListTestContext
        {
            protected override void Before()
            {
                Given_TaskList_is_created();
                And("it contains Tasks", () =>
                {
                    viewModel.Tasks.Add(new Task());
                    viewModel.Tasks.Add(new Task());
                });

                When("first Task is selected", () =>
                    viewModel.Tasks.First().IsSelected = true);
            }

            [Test]
            public void Then_assure_its_added_to_SelectedTasks()
            {
                viewModel.SelectedTasks.ShouldHave(1);
            }
        }

        [TestFixture]
        public class When_UnSelect_Task : TaskListTestContext
        {
            protected override void Before()
            {
            }
        }

    }
}