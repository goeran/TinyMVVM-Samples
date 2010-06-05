using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RichRememberTheMilk.ViewModel;

namespace RichRememberTheMilk.WPF.Views
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : UserControl
    {
        private TaskList ViewModel
        {
            get
            {
                return DataContext as TaskList;
            }
        }

        public TaskListView()
        {
            InitializeComponent();
        }

        private void txtNewTaskDescription_KeyDown(object sender, KeyEventArgs e)
        {
            var binding = BindingOperations.GetBindingExpression(sender as TextBox, TextBox.TextProperty);
            binding.UpdateSource();

            if (e.Key == Key.Enter)
            {
                ViewModel.Add.Execute(null);
            }
        }
    }
}
