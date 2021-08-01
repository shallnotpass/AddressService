using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IDataProvider
    {
        Addresses GetAddresses();
    }
}
