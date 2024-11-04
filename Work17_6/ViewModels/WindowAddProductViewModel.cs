using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task.Common;

namespace Work17_6.ViewModels
{
    public class WindowAddProductViewModel
    {
        public Action<int, string, string> OnAddEntry;
        public string Email { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }

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
            int productId = 0;
            if (int.TryParse(ProductId, out productId))
                OnAddEntry?.Invoke(productId, ProductName, Email);
        }
    }
}
