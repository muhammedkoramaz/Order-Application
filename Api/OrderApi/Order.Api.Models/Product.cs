using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Security.Cryptography;

namespace Order.Api.Models
{
    public class Product
    {
        public Product()
        {
            Id = ObjectId.GenerateNewId();

        }
        [BsonId]
        public ObjectId Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

    }
}
