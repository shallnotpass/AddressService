using Microsoft.Extensions.Options;

namespace DataProvider.Implemetation
{
    public class DatabaseConfiguration
    {
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}