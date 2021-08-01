using NUnit.Framework;
using Contracts;
using Contracts.Interfaces;
using Contracts.Implementation;
using NSubstitute;
using Contracts.Models;
using FluentAssertions;

namespace Contracts.UnitTest
{
    public class SearcherTests
    {
        private ISearcher searcher;
        [SetUp]
        public void Setup()
        {
            var dataProvider = Substitute.For<IDataProvider>();

            dataProvider.GetAddresses().Returns(new Models.Addresses
            { 
                Items = new System.Collections.Generic.List<Address> 
                { 
                    new Address {Index = "2345", ExactAddress = "Moscow"},
                    new Address {Index = "5643", ExactAddress = "Volgograd"},
                    new Address {Index = "7897", ExactAddress = "Samara"},
                    new Address {Index = "0574", ExactAddress = "Novonikolayevsk"},
                    new Address {Index = "5734", ExactAddress = "Saint-Petersberg"}
                }
            });

            searcher = new Searcher(dataProvider);
        }

        [Test]
        public void NullTest()
        {
            Addresses Result = searcher.SerachAdderess(null);
            Result.Should().BeEquivalentTo(new Addresses { Items = new System.Collections.Generic.List<Address> { } });
        }

        [Test]
        public void LowercaseTest()
        {
            var Result = searcher.SerachAdderess("moscow");
            Result.Should().BeEquivalentTo(new Addresses {Items = new System.Collections.Generic.List<Address> { new Address { Index = "2345", ExactAddress = "Moscow" } } });
        }

        [Test]
        public void SymbolsTest()
        {
            var Result = searcher.SerachAdderess("日本語%.");
            Result.Should().BeEquivalentTo(new Addresses { Items = new System.Collections.Generic.List<Address> { } });
        }

        [Test]
        public void EmptyStringTest()
        {
            var Result = searcher.SerachAdderess("");
            Result.Should().BeEquivalentTo(new Addresses { Items = new System.Collections.Generic.List<Address> { } });
        }

        [Test]
        public void SubstringTest()
        {
            var Result = searcher.SerachAdderess("cow");
            Result.Should().BeEquivalentTo(new Addresses { Items = new System.Collections.Generic.List<Address> { new Address { Index = "2345", ExactAddress = "Moscow" } } });
        }

        [Test]
        public void LongStringTest()
        {
            var Result = searcher.SerachAdderess("4444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444");
            Result.Should().BeEquivalentTo(new Addresses { Items = new System.Collections.Generic.List<Address> { } });
        }
    }
}