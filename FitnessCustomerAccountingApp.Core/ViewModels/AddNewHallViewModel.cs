using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace FitnessCustomerAccountingApp.Core
{
    public class AddNewHallViewModel : BaseRoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        public ICommand AddNewHallCommand { get; set; }

        public AddNewHallViewModel()
        {
            var canAdd = this.WhenAnyValue(s => s.Name, name => !string.IsNullOrEmpty(name));
            AddNewHallCommand = ReactiveCommand.Create(AddNewHall, canAdd);
        }

        private void AddNewHall()
        {
            foreach (Hall item in DB.Halls)
                if (item.Name == Name)
                    return;
            DB.Halls.Add(new Hall(Name));
            Name = string.Empty;
        }
    }
}