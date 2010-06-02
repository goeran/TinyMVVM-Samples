using System;
using System.Collections.Generic;
using NUnit.Framework;
using RichRememberTheMilk.Repositories;
using RichRememberTheMilk.ViewModel;
using TinyBDD.Specification.NUnit;

namespace RichRememberTheMilk.Tests.ViewModel
{
    public class ApplicationContextSpecs
    {
        [TestFixture]
        public class When_spawned : ApplicationContextTestContext
        {
            public override void Before()
            {
                When_ApplicationContext_is_spawned();
            }

            [Test]
            public void assure_it_has_TaskLists()
            {
                viewModel.TasksLists.ShouldNotBeNull();
            }
        }

        [TestFixture]
        public class When_initialized : ApplicationContextTestContext
        {
            public override void Before()
            {
                Given("There are TaskLists in the repository", () =>
                {
                    GetFakeFor<ITaskListRepository>().Setup(r =>
                        r.Get()).Returns(new List<TaskList>
                        {
                            new TaskList()
                        });
                });
                When_ApplicationContext_is_spawned();
            }

            [Test]
            public void Assure_tasksLists_are_loaded()
            {
                viewModel.TasksLists.Count.ShouldNotBe(0);
            }
        }
    }
}
