using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;
using System;

namespace FitnessCustomerAccountingApp
{
    public class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            DB.Load();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            DB.Save();
        }
    }
}