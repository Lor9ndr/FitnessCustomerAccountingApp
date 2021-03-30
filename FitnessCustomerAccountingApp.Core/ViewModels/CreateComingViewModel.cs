using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FitnessCustomerAccountingApp.Core
{
    public class CreateComingViewModel:BaseRoutableViewModel
    {
        [Reactive]
        public ObservableCollection<Client> Clients { get; set; } = DB.Clients;
        [Reactive]
        public string Comment { get; set; }
        [Reactive]
        public Client Client { get; set; }
        [Reactive]
        public TimeSpan Time { get; set; }
        [Reactive]
        public DateTime Dt { get; set; }
        [Reactive]
        public Hall Hall { get; set; }
        public ICommand AddNewComingCommand { get; set; }
        public CreateComingViewModel() 
        {
            AddNewComingCommand = ReactiveCommand.Create(AddNewComing);
        }
        private void AddNewComing()
        {
            var coming = new Coming()
            {
                Hall = Hall,
                Dt = Dt,
                Time = Time,
                Client = Client,
                Comment = Comment
            };
            foreach (Coming item in DB.Comings)
                if (item.Id == coming.Id)
                    return;
            DB.Comings.Add(coming);
            ClearAll();
        }
        private void ClearAll()
        {
            Hall = null;
            Dt = new DateTime();
            Time = new TimeSpan();
            Client = null;
            Comment = string.Empty;
        }
    }
}
