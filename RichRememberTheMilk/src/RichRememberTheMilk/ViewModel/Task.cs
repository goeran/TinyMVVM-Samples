using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RichRememberTheMilk.ViewModel
{
    public partial class Task
    {
        public void OnComplete()
        {
            IsCompleted = true;
        }
    }
}
