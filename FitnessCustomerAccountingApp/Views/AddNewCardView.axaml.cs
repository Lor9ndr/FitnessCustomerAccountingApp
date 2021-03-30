using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;

namespace FitnessCustomerAccountingApp
{
    public class AddNewCardView : ReactiveUserControl<AddNewCardViewModel>
    {
        public AddNewCardView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}