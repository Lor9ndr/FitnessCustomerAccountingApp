using System.Collections.ObjectModel;

namespace FitnessCustomerAccountingApp.Core
{
    public class WatchCardsViewModel:BaseRoutableViewModel
    {
        public ObservableCollection<Card> Cards { get; set; } 
        public WatchCardsViewModel() { Cards = DB.Cards; }
    }
}
