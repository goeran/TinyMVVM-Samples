using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RichRememberTheMilk.ViewModel;
using TinyBDD.Specification.NUnit;
using TinyMVVM.Framework.Services;
using TinyMVVM.Framework.Testing.Services;
using TinyMVVM.Specifications;

namespace RichRememberTheMilk.Tests.ViewModel
{
    public class ApplicationContextSpecs
    {
        [TestFixture]
        public class When_spawned : ApplicationContextTestScenario<When_spawned>
        {
            protected override void Before()
            {
                When.ApplicationContext_is_spawned();
            }

            [Test]
            public void assure_it_has_TaskLists()
            {
                viewModel.TasksLists.ShouldNotBeNull();
            }
        }

        [TestFixture]
        public class When_initialized : ApplicationContextTestScenario<When_initialized>
        {
            protected override void Before()
            {
                Given.there_are_TaskLists_in_the_repository();

                When.ApplicationContext_is_spawned();
            }

            [Test]
            public void Then_assure_tasksLists_are_loaded()
            {
                viewModel.TasksLists.Count.ShouldBe(1);
            }

            [Test]
            public void Then_assure_first_TaskList_is_set_as_SelectedList()
            {
                viewModel.SelectedList.ShouldBe(viewModel.TasksLists.First());
            }


            private void there_are_TaskLists_in_the_repository()
            {
                TaskListRepositoryFake.Setup(r =>
                    r.Get()).Returns(new List<TaskList>
                    {
                        new TaskList()
                    });
            }
        }
    }
}
