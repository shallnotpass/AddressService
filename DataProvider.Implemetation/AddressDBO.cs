using Contracts.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataProvider.Implemetation
{
    [BsonIgnoreExtraElements]
    internal class AddressDBO
    {
        [BsonElement("Index")]
        public string Index { get; set; }
        [BsonElement(" ExactAddress")]
        public string ExactAddress { get; set; }
        public Address CastToAddress()
        {
            return new Address { Index = this.Index, ExactAddress = this.ExactAddress };
        }
    }
}
