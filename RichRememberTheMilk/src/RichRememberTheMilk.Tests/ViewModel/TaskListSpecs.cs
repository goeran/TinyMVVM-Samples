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
            public override void Before()
            {
                When_TaskList_is_spawned();
            }

            [Test]
            public void Assure_it_has_Tasks()
            {
                viewModel.Tasks.ShouldNotBeNull();
            }
        }
    }
}