using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataProvider.Implemetation
{
    public class DataProvider : IDataProvider
    {
        private readonly IMongoCollection<AddressDBO> addressCollection;
        private readonly DatabaseConfiguration settings;
        public DataProvider(DatabaseConfiguration settings)
        {
            this.settings = settings;
            MongoClient client = new MongoClient(this.settings.ConnectionString);
            var database = client.GetDatabase(this.settings.DatabaseName);
            this.addressCollection = database.GetCollection<AddressDBO>(this.settings.AddressCollectionName);
        }
        public Addresses GetAddresses()
        {
            var AllItems = GetAllAsync().Result;
            List<Address> AllAddresses = new List<Address>();
            foreach (var item in AllItems)
            {
                AllAddresses.Add(item.CastToAddress());
            }
            return new Addresses { Items = AllAddresses };
        }
        private async Task<List<AddressDBO>> GetAllAsync()
        {
            return await addressCollection.Find(c => true).ToListAsync();
        }
        /*public async Task<Customer> GetByIdAsync(string id)
        {
            return await _customer.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _customer.InsertOneAsync(customer);
            return customer;
        }
        public async Task UpdateAsync(string id, Customer customer)
        {
            await _customer.ReplaceOneAsync(c => c.Id == id, customer);
        }
        public async Task DeleteAsync(string id)
        {
            await _customer.DeleteOneAsync(c => c.Id == id);
        }*/
    }
}
