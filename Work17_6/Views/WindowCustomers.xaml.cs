using System;
using System.Windows;
using Work17_6.ViewModels;

namespace Work17_6.Views
{
    /// <summary>
    /// Interaction logic for WindowCustomers.xaml
    /// </summary>
    public partial class WindowCustomers : Window
    {
        public WindowCustomers()
        {
            InitializeComponent();
        }

        private void DataGrid_CellChanged(object sender, EventArgs e)
        {
            if ((DataContext as WindowCustomersViewModel).HasEdited.CanExecute(this))
                (DataContext as WindowCustomersViewModel).HasEdited.Execute(this);
        }
    }
}
