using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using System.Windows.Input;

namespace FitnessCustomerAccountingApp.Core
{
    public class AddNewClientViewModel : BaseRoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Surname { get; set; }

        [Reactive]
        public string Email { get; set; }

        [Reactive]
        public DateTime BirthDay { get; set; }

        [Reactive]
        public string Address { get; set; }

        [Reactive]
        public string Passport { get; set; }

        [Reactive]
        public string Phone { get; set; }

        [Reactive]
        public Card Card { get; set; }

        public ICommand AddNewClientCommand { get; set; }

        public AddNewClientViewModel()
        {
            var canAdd = this.WhenAnyValue(
                s => s.Name, s => s.Surname, s => s.Phone, s => s.Email, s => s.Address, s => s.BirthDay, s => s.Passport,
                (name, surname, phone, email, addres, birthday, passport) =>
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(surname) &&
                !string.IsNullOrEmpty(passport) &&
                !string.IsNullOrEmpty(phone) &&
                !string.IsNullOrEmpty(email) && email.Contains('@')
                ).DistinctUntilChanged();

            AddNewClientCommand = ReactiveCommand.Create(AddNewClient, canAdd);
        }

        public void AddNewClient()
        {
            foreach (Client item in DB.Clients)
                if (item.Passport == Passport)
                    return;

            DB.Clients.Add(new Client()
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                BirthDay = BirthDay,
                Address = Address,
                Passport = Passport,
                Phone = Phone,
                Card = Card
            });
            ClearAll();
        }

        private void ClearAll()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            BirthDay = DateTime.Now;
            Address = string.Empty;
            Passport = string.Empty;
            Phone = string.Empty;
        }
    }
}