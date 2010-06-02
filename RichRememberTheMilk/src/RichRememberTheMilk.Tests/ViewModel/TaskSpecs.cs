using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RichRememberTheMilk.Tests.ViewModel;
using TinyBDD.Specification.NUnit;

namespace RichRememberTheMilk.Desktop.Tests.ViewModel
{
    public class TaskSpecs
    {
        [TestFixture]
        public class When_spawned : TaskTestContext
        {
            public override void Before()
            {
                When_Task_is_spawned();
            }

            [Test]
            public void assure_Completed_is_false_by_default()
            {
                viewModel.Completed.ShouldBeFalse();
            }

            [Test]
            public void assure_IsSelected_is_false_by_default()
            {
                viewModel.IsSelected.ShouldBeFalse();
            }
        }

    }
}
