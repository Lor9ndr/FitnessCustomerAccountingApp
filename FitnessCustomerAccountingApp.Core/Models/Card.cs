using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitnessCustomerAccountingApp.Core
{
    public class Card : INotifyPropertyChanged
    {
        private decimal _price;
        private byte _discount;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }

        public byte Discount
        {
            get => _discount; set
            {
                if (value is <= 100 and >= 0)
                {
                    _discount = value;
                    OnPropertyChanged("PriceWithDiscount");
                }
            }
        }

        public TimeSpan StartOfActivity { get; set; }

        public TimeSpan EndOfActivity { get; set; }

        public int CountOfDays { get; set; }

        public decimal Price
        {
            get => _price; set
            {
                _price = value;
                this.OnPropertyChanged("Price");
                this.OnPropertyChanged("PriceWithDiscount");
            }
        }

        public decimal PriceWithDiscount
        {
            get => (decimal)(Price - Price * Discount / 100);
        }

        public Card()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}