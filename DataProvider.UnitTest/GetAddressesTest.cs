using NUnit.Framework;
using Contracts;
using DataProvider.Implemetation;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Contracts.Interfaces;
using Contracts.Models;
using FluentAssertions;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataProvider.UnitTest
{
    public class Tests
    {
        private IDataProvider data_provider;
        private IConfiguration configuration;
        [SetUp]
        public void Setup()
        {
            string jsonString = File.ReadAllText("settingsDB.json");
            DatabaseConfiguration configObj = JsonSerializer.Deserialize<DatabaseConfiguration>(jsonString);
            DatabaseConfiguration config = configObj;
            data_provider = new DataProvider.Implemetation.DataProvider(config);
        }

        [Test]
        public void Test1()
        {
            var Result = data_provider.GetAddresses();
            Result.Should().NotBeNull();
        }
    }
}