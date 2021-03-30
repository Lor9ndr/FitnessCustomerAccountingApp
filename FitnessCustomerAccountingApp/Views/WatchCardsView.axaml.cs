using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;

namespace FitnessCustomerAccountingApp
{
    public class WatchCardsView : ReactiveUserControl<WatchCardsViewModel>
    {
        public WatchCardsView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}