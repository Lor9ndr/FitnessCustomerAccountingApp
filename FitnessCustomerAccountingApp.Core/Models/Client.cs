using System;

namespace FitnessCustomerAccountingApp.Core
{
    public class Client
    {
        #region Public Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public Card Card { get; set; }
        public DateTime ActiveUntill { get => DateTime.Now.AddDays(Card.CountOfDays); }
        public string Phone { get; set; }

        #endregion Public Properties

        #region Constructors

        public Client()
        {
        }

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        #endregion Constructors

        public override string ToString()
        {
            return Surname + ' ' + Name;
        }
    }
}