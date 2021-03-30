using Avalonia;
using Avalonia.Markup.Xaml;
using FitnessCustomerAccountingApp.Core;
using ReactiveUI;
using Splat;

namespace FitnessCustomerAccountingApp
{
    public class App : Application
    {
        public App()
        {
        }

        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        // ����� ����� ������ ����������. ����� �� ������ �������������������
        // ��� MVVM ���������, DI ��������� � ������ ����������. � ���� ������
        // ����� ���������� � �������� ApplicationLifetime, �� ������ ��������
        // ���������������� ��������� ��� ���������� �������������.

        public override void OnFrameworkInitializationCompleted()
        {
            IoC.Setup();

            Locator.CurrentMutable.RegisterLazySingleton(() => new ConventionalViewLocator(), typeof(IViewLocator));
            // ������������ ������ �������������.
            Locator.CurrentMutable.RegisterConstant<IScreen>(IoC.Get<MainViewModel>());
            Locator.CurrentMutable.Register(() => new AddNewClientView(), typeof(IViewFor<AddNewClientViewModel>));
            Locator.CurrentMutable.Register(() => new WatchClientsView(), typeof(IViewFor<WatchClientsViewModel>));
            Locator.CurrentMutable.Register(() => new AddNewCardView(), typeof(IViewFor<AddNewCardViewModel>));
            Locator.CurrentMutable.Register(() => new CreateComingView(), typeof(IViewFor<CreateComingViewModel>));
            Locator.CurrentMutable.Register(() => new AddNewHallView(), typeof(IViewFor<AddNewHallViewModel>));
            Locator.CurrentMutable.Register(() => new WatchComingsView(), typeof(IViewFor<WatchComingsViewModel>));
            Locator.CurrentMutable.Register(() => new WatchCardsView(), typeof(IViewFor<WatchCardsViewModel>));

            new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();

            // �������� �������� ������ ������������� � �������������� �������� ������.
            base.OnFrameworkInitializationCompleted();
        }
    }
}