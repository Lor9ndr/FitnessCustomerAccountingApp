using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;

namespace FitnessCustomerAccountingApp
{
    public class WatchComingsView : ReactiveUserControl<WatchComingsViewModel>
    {
        public WatchComingsView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}