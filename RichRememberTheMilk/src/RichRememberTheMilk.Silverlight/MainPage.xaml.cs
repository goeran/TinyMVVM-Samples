using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using RichRememberTheMilk.Controllers;
using RichRememberTheMilk.ViewModel;

namespace RichRememberTheMilk.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            var viewModel = new ApplicationContext();
            viewModel.CreateController<ApplicationContextController>();
            DataContext = viewModel;
        }
    }
}
