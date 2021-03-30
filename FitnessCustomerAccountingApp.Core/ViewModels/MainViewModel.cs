using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace FitnessCustomerAccountingApp.Core
{
    public class MainViewModel:ReactiveObject,IScreen
    {
        [Reactive]
        public RoutingState Router { get; set; } = new RoutingState();
        public ICommand GoToAddClientViewCommand { get; set; }
        public ICommand GoToWatchClientsViewCommand { get; set; }
        public ICommand GoToAddNewCardCommand { get; set; }
        public ICommand GoToAddNewComingCommand { get; set; }
        public ICommand GoToAddNewHallCommand { get; set; }
        public ICommand GoToWatchComingsViewCommand { get; set; }
        public ICommand GoToWatchCardsViewCommand { get; set; }

        public string BackButtonContent { get; } = "\uf060";

        public ICommand GoBackCommand { get; set; }

        
        public MainViewModel()
        {
            var isAble = this.WhenAnyValue(s => s.Router.NavigationStack.Count, counter => counter > 1);
            GoBackCommand = ReactiveCommand.Create(GoBack, isAble);
            GoToAddClientViewCommand = ReactiveCommand.Create(GoToAddClientView);
            GoToWatchClientsViewCommand = ReactiveCommand.Create(GoToWatchClientsView);
            GoToAddNewCardCommand = ReactiveCommand.Create(GoToAddCardView);
            GoToAddNewComingCommand = ReactiveCommand.Create(GoToAddNewComing);
            GoToAddNewHallCommand = ReactiveCommand.Create(GoToAddNewHall);
            GoToWatchComingsViewCommand = ReactiveCommand.Create(GoToWatchComingsView);
            GoToWatchCardsViewCommand = ReactiveCommand.Create(GoToWatchCardsView);
        }

        private void GoToWatchCardsView() => GoToPage(new WatchCardsViewModel());

        private void GoToWatchComingsView() => GoToPage(new WatchComingsViewModel());

        private void GoToAddNewHall() => GoToPage(new AddNewHallViewModel());
        private void GoToAddNewComing() => GoToPage(new CreateComingViewModel());
        private void GoToAddCardView() => GoToPage(new AddNewCardViewModel());

        private void GoToAddClientView() => GoToPage(new AddNewClientViewModel());
        private void GoToWatchClientsView() => GoToPage(new WatchClientsViewModel());
        public void GoBack()
        {
            Router.NavigateBack.Execute();
        }
        public void GoToPage(BaseRoutableViewModel pagevm)
        {
            Router.Navigate.Execute(pagevm);
        }
    }
}
