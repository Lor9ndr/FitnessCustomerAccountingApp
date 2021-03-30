using System.Collections.ObjectModel;

namespace FitnessCustomerAccountingApp.Core
{
    public class WatchComingsViewModel:BaseRoutableViewModel
    {
        public ObservableCollection<Coming> Comings { get; set; }
        public ObservableCollection<Hall> Halls { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public WatchComingsViewModel()
        {
            Comings = DB.Comings;
            Halls = DB.Halls;
            Clients = DB.Clients;
        }

    }
}
