using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;

namespace FitnessCustomerAccountingApp
{
    public class AddNewClientView : ReactiveUserControl<AddNewClientViewModel>
    {
        public AddNewClientView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}