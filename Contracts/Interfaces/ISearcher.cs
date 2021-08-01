using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface ISearcher
    {
        public Addresses SerachAdderess(string serachString);
    }
}
