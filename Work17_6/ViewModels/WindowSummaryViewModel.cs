using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data;
using Task.Common;
using System.Diagnostics;
using System.Windows.Controls;
using Work17_6.Models;

namespace Work17_6.ViewModels;


public class WindowSummaryViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public Action OnAddProductEntry;
    public Action OnViewCustomers;

    private ICommand _clickAdd;
    private ICommand _clickDelete;
    private ICommand _hasEdited;
    private ICommand _clickViewCustomers;
    
    public ICommand ClickAddProduct
    {
        get
        {
            return _clickAdd ?? (_clickAdd = new CommandHandler(() => OnAddProductEntry?.Invoke(), () => true));
        }
    }

    public ICommand ClickDelete
    {
        get
        {
            return _clickDelete ?? (_clickDelete = new CommandHandler(() => DeleteProductEntry(), () => IsEntrySelected));
        }
    }

    public ICommand HasEdited
    {
        get
        {
            return _hasEdited ?? (_hasEdited = new CommandHandler(() => EditProductEntry(), () => IsEntrySelected));
        }
    }

    public ICommand ClickViewCustomers
    {
        get
        {
            return _clickViewCustomers ?? (_clickViewCustomers = new CommandHandler(() => OnViewCustomers?.Invoke(), () => true ));
        }
    }

    private bool IsEntrySelected 
    { 
        get
        {
            return SelectedItem != null;
        } 
    }

    public BindingList<Product> Products { get; set; }
    public Product SelectedItem { get; set; }
    public SummaryContext Model { get; set;}

    public WindowSummaryViewModel()
    {
    }

    private void DeleteProductEntry()
    {
        Model.DeleteProductEntry(SelectedItem.ID);
    }

    private void EditProductEntry()
    {
        Model.EditProductEntry(SelectedItem.ID, SelectedItem.ProductId, SelectedItem.Name, SelectedItem.Email);
    }
}