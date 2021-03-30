using System;

namespace FitnessCustomerAccountingApp.Core
{
    public class Coming
    {
        public string Id;

        public Coming()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Comment { get; set; }
        public Client Client { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Dt { get; set; }
        public Hall Hall { get; set; }
    }
}