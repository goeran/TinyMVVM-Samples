using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using RichRememberTheMilk.Desktop.Repositories;
using RichRememberTheMilk.Repositories;
using RichRememberTheMilk.ViewModel;
using TinyMVVM.Framework;
using TinyMVVM.Framework.Services.Impl;
using TinyMVVM.Framework.Testing;

namespace RichRememberTheMilk.Desktop
{
    [Export(typeof(IServiceLocator))]
    public class ServiceLocatorForClient : DefaultServiceLocator
    {
        private List<Object> dependencies = new List<object>();

        public ServiceLocatorForClient()
        {
            dependencies.Add(new TaskListRepository());
            dependencies.Add(new BackgroundWorker());
            dependencies.Add(new UIInvoker());
        }

        public override T GetInstance<T>()
        {
            return dependencies.Where(i => i is T).SingleOrDefault() as T;
        }
    }
}
