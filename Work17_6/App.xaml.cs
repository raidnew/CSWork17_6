//using Connections;
using System.Configuration;
using System.Data;
using System.Windows;
using Work17_6.Models;
using Work17_6.Views;
using Work17_6.ViewModels;
using System.Xml.Linq;

namespace Work17_6;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private SummaryContext _summary;
    WindowAddProduct _windowAddProduct;
    WindowCustomers _windowCustomer;
    WindowSummary _windowSummary;
    WindowAddCustomer _windowAddCustomer;

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _summary = new SummaryContext();

        /*
        Test tst = new Test();
        tst.AddTest();
        */

        ShowSummaryWindow();
    }

    private void ShowSummaryWindow()
    {
        WindowSummaryViewModel wndvm = new WindowSummaryViewModel();
        wndvm.Model = _summary;
        wndvm.Products  =_summary.GetItemSourceProducts();
        wndvm.OnViewCustomers += ShowCustomersWindow;
        wndvm.OnAddProductEntry += ShowAddProductEntryWindow;
        _windowSummary = new WindowSummary();
        _windowSummary.DataContext = wndvm;
        _windowSummary.Show();
    }

    private void AddNewProductEntry(int id, string name, string email)
    {
        _summary.AddProductEntry(id, name, email);
        _windowAddProduct.Close();
    }

    private void ShowAddProductEntryWindow()
    {
        WindowAddProductViewModel windowAddProductViewModel = new WindowAddProductViewModel();
        windowAddProductViewModel.OnAddEntry += AddNewProductEntry;
        _windowAddProduct = new WindowAddProduct();
        _windowAddProduct.DataContext = windowAddProductViewModel;
        _windowAddProduct.Show();
    }


    private void ShowCustomersWindow()
    {
        WindowCustomersViewModel windowCustomersViewModel = new WindowCustomersViewModel();
        windowCustomersViewModel.Model = _summary;
        windowCustomersViewModel.Customers = _summary.GetItemSourceCustomers();
        windowCustomersViewModel.OnAddCustomer = ShowAddCustomerWindow;
        _windowCustomer = new WindowCustomers();
        _windowCustomer.DataContext = windowCustomersViewModel;
        _windowCustomer.Show();
    }

    private void ShowAddCustomerWindow()
    {
        WindowAddCustomerViewModel windowAddProductViewModel = new WindowAddCustomerViewModel();
        windowAddProductViewModel.OnAddEntry += AddNewCustomerEntry;
        _windowAddCustomer = new WindowAddCustomer();
        _windowAddCustomer.DataContext = windowAddProductViewModel;
        _windowAddCustomer.Show();
    }

    private void AddNewCustomerEntry(string lastName, string firstName, string thirdName, string phone, string email)
    {
        _summary.AddCustomerEntry(firstName, lastName, thirdName, email, phone);
        _windowAddCustomer.Close();
    }

    internal class Test
    {
        public Test() { }

        public void AddTest()
        {
            SummaryContext context = new SummaryContext();
            int i;
            for (i = 0; i < 20; i++)
                context.Products.Add(new Product($"Name{1}", 12, $"Email{1}{1}@domain.zone"));

            for (i = 0; i < 20; i++)
                context.Customers.Add(new Customer(i, $"Name{i}", $"lName{i}", $"tName{i}", "123123", $"asf{i}{i}{i}@asdA.ADS"));

            context.SaveChanges();
        }
    }

}

