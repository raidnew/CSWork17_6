using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task.Common;

namespace Work17_6.ViewModels;

public class WindowAddCustomerViewModel
{
    public Action<string, string, string, string, string> OnAddEntry;
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string ThirdName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    private ICommand _clickAddCommand;
    public ICommand ClickAddCommand
    {
        get
        {
            return _clickAddCommand ?? (_clickAddCommand = new CommandHandler(AddEntry, () => CanAdd));
        }
    }

    private bool CanAdd { get => true; }

    private void AddEntry()
    {
        OnAddEntry?.Invoke(LastName, FirstName, ThirdName, Phone, Email);
    }
}
