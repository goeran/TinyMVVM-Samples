using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
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
        public class When_Add : TaskListTestContext
        {
            [SetUp]
            public void Setup()
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

    }
}