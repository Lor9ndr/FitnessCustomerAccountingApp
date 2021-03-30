namespace FitnessCustomerAccountingApp.Core
{
    public class Hall
    {
        public string Name { get; set; }

        public Hall(string name)
        {
            Name = name;
        }

        public Hall()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}