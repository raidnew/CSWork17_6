using System;
using System.Windows;
using Work17_6.ViewModels;

namespace Work17_6.Views
{
    /// <summary>
    /// Interaction logic for WindowSummary.xaml
    /// </summary>
    public partial class WindowSummary : Window
    {
        public WindowSummary()
        {
            InitializeComponent();
        }

        private void DataGrid_CellChanged(object sender, EventArgs e)
        {
            if ((DataContext as WindowSummaryViewModel).HasEdited.CanExecute(this))
                (DataContext as WindowSummaryViewModel).HasEdited.Execute(this);
        }
    }
}
