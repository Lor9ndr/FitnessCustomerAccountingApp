using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;

namespace FitnessCustomerAccountingApp.Core
{
    public class WatchClientsViewModel:BaseRoutableViewModel
    {
        [Reactive]
        public ObservableCollection<Client> Clients { get; set; }
        [Reactive]
        public ObservableCollection<Card> Cards { get; set; }

        public WatchClientsViewModel() 
        {
            Clients = DB.Clients;
            Cards = DB.Cards;
        }
    }
}
