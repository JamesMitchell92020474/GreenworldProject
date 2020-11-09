using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GreenWorldApp.Views
{
    public class ProductItem
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productItemName")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}

