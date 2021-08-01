using System;
using Contracts.Interfaces;
using Contracts.Models;
using System.Linq;

namespace Contracts.Implementation
{
    public class Searcher : ISearcher
    {
        private readonly IDataProvider dataProvider;
        delegate Address a(int first, int second);
        public Searcher(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public Addresses SerachAdderess(string serachString)
        {
            var addresses = dataProvider.GetAddresses();
            var wer = addresses.Items.Where(x=> x.Index.Length.ToString().Length>5).Select(x => x.ExactAddress.EndsWith('a')).ToArray();
            if (!string.IsNullOrEmpty(serachString))
                return new Addresses
                {
                    Items = addresses.Items.Where(x => x.ExactAddress.ToLower().Contains(serachString.ToLower())).ToList()
                };
            else
                return new Addresses
                {
                    Items = new System.Collections.Generic.List<Address> { } 
                };
        }
    }
}
