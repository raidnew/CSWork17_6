using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task.Common;
using Work17_6.Models;

namespace Work17_6.ViewModels;

public class WindowCustomersViewModel
{
    public Action OnAddCustomer;
    public Action OnDeleteCustomer;
    public SummaryContext Model { get; set; }

    private ICommand _clickAdd;
    private ICommand _clickDelete;
    private ICommand _hasEdited;

    public ICommand ClickAddCustomer
    {
        get
        {
            return _clickAdd ?? (_clickAdd = new CommandHandler(() => OnAddCustomer?.Invoke(), () => true));
        }
    }

    public ICommand ClickDelete
    {
        get
        {
            return _clickDelete ?? (_clickDelete = new CommandHandler(() => DeleteCustomer(), () => IsEntrySelected));
        }
    }

    public ICommand HasEdited
    {
        get
        {
            return _hasEdited ?? (_hasEdited = new CommandHandler(() => EditCustomer(), () => IsEntrySelected));
        }
    }

    public BindingList<Customer> Customers {  get; set; }

    private bool IsEntrySelected { get => SelectedItem != null; }

    public Customer SelectedItem { get; set; }

    private void DeleteCustomer()
    {
        Model.DeleteCustomerEntry(SelectedItem.ID);
    }

    private void EditCustomer()
    {
        Model.EditCustomerEntry(SelectedItem.ID, 
            SelectedItem.FirstName, 
            SelectedItem.LastName, 
            SelectedItem.ThirdName, 
            SelectedItem.Phone, 
            SelectedItem.Email);
    }


}
