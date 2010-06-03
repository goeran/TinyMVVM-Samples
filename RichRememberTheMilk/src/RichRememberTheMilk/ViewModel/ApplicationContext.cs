using System.Collections.Generic;
using RichRememberTheMilk.Controllers;
using RichRememberTheMilk.Desktop.Repositories;
using TinyMVVM.Repositories;

namespace RichRememberTheMilk.ViewModel
{
    public partial class ApplicationContext
    {
        public void OnInitialize()
        {
            RegisterController<ApplicationContextController>();
        }
    }
}