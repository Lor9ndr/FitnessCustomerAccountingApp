using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;

namespace FitnessCustomerAccountingApp
{
    public class AddNewHallView : ReactiveUserControl<AddNewHallViewModel>
    {
        public AddNewHallView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}