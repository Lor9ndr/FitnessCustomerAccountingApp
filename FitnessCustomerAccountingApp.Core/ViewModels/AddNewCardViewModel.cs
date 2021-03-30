using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using System.Windows.Input;

namespace FitnessCustomerAccountingApp.Core
{
    public class AddNewCardViewModel : BaseRoutableViewModel
    {
        private byte _discount;

        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public bool IsActive { get; set; }

        [Reactive]
        public byte Discount
        {
            get => _discount; set
            {
                if (value is <= 100 and >= 0)
                    _discount = value;
            }
        }

        [Reactive]
        public TimeSpan StartOfActivity { get; set; }

        [Reactive]
        public TimeSpan EndOfActivity { get; set; }

        [Reactive]
        public int CountOfDays { get; set; }

        [Reactive]
        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get => Price - Price * Discount / 100; }
        public ICommand AddNewCardCommand { get; set; }

        public AddNewCardViewModel()
        {
            var canAdd = this.WhenAnyValue(
               s => s.Name, s => s.StartOfActivity, s => s.EndOfActivity,
               (name, startOfActivity, endOfActivity) =>
               !string.IsNullOrEmpty(name) && StartOfActivity < EndOfActivity
               ).DistinctUntilChanged();

            AddNewCardCommand = ReactiveCommand.Create(AddNewCard, canAdd);
        }

        private void AddNewCard()
        {
            DB.Cards.Add(new Card()
            {
                Name = Name,
                IsActive = IsActive,
                Discount = Discount,
                StartOfActivity = StartOfActivity,
                EndOfActivity = EndOfActivity,
                CountOfDays = CountOfDays,
                Price = Price
            });
            ClearAll();
        }

        public void ClearAll()
        {
            Name = string.Empty;
            Discount = 0;
            CountOfDays = 0;
            Price = 0;
            StartOfActivity = new TimeSpan();
            EndOfActivity = new TimeSpan();
        }
    }
}