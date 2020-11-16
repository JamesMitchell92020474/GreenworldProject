using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace GreenWorldApp.Views
{
    public static class MongoService
    {
        static IMongoCollection<ProductItem> productItemsCollection;
        readonly static string dbName = "IT6041Project";
        readonly static string collectionName = "IT6041App_products";
        static MongoClient client;

        static IMongoCollection<ProductItem> ProductItemsCollection
        {
            get
            {
                if (client == null || productItemsCollection == null)
                {
                    var conx = "mongodb+srv://admin:admin@it6041project.mxz4f.mongodb.net/test?authSource=admin&replicaSet=atlas-zyx1o5-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true";
                    //MongoClientSettings settings = MongoClientSettings.FromUrl(
                    //    new MongoUrl(conx)
                    //);

                    //settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                    MongoClient client = new MongoClient(conx);
                    //client = new MongoClient();
                    var db = client.GetDatabase(dbName);

                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    productItemsCollection = db.GetCollection<ProductItem>(collectionName, collectionSettings);
                }

                return productItemsCollection;
            }
        }

        public async static Task<List<ProductItem>> GetAllItems()
        {
            var allItems = await ProductItemsCollection
                .Find(new BsonDocument())
                .ToListAsync();

            return allItems;
        }

        public async static Task<List<ProductItem>> SearchByName(string name)
        {
            var results = await ProductItemsCollection
                            .AsQueryable()
                            .Where(tdi => tdi.Name.Contains(name))
                            .Take(10)
                            .ToListAsync();

            return results;
        }

        public async static Task InsertItem(ProductItem item)
        {
            await ProductItemsCollection.InsertOneAsync(item);
        }

        public async static Task<bool> DeleteItem(ProductItem item)
        {
            var result = await ProductItemsCollection.DeleteOneAsync(tdi => tdi.Id == item.Id);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
