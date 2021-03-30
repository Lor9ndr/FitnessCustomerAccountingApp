using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace FitnessCustomerAccountingApp.Core
{
    public static class DB
    {
        private const string _fileName = "../../../Data.json";
        public static ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();
        public static ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public static ObservableCollection<Hall> Halls { get; set; } = new ObservableCollection<Hall>();
        public static ObservableCollection<Coming> Comings { get; set; } = new ObservableCollection<Coming>();

        private class AllData
        {
            public ObservableCollection<Coming> Comings { get; set; }
            public ObservableCollection<Client> Clients { get; set; }
            public ObservableCollection<Card> Cards { get; set; }
            public ObservableCollection<Hall> Halls { get; set; }
        }

        private static T Deserialize<T>(string fileName)  // данная функция читает файл джейсон и возвращает его
        {
            using var sr = new StreamReader(fileName);
            using var jsonReader = new JsonTextReader(sr);
            var serializer = new JsonSerializer();
            return serializer.Deserialize<T>(jsonReader);
        }

        private static void Serialize<T>(string fileName, T data) // данный метод сохраняет файл джейсон
        {
            using var sw = new StreamWriter(fileName);
            using var jsonWriter = new JsonTextWriter(sw);
            var serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, data);
        }

        public static void Save()
        {
            var dt = new AllData()
            {
                Cards = Cards,
                Clients = Clients,
                Halls = Halls,
                Comings = Comings,
            };
            Serialize(_fileName, dt);
        }

        public static void Load()
        {
            var data = Deserialize<AllData>(_fileName);

            if (data != null)
            {
                Cards = data.Cards;
                Clients = data.Clients;
                Halls = data.Halls;
                Comings = data.Comings;
            }
        }
    }
}