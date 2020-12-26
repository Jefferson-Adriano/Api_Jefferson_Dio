using System;
using Api.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Seriallization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Api.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }

        public MongoDB(IConfiguration configuration) 
        {
            try
            {
                {
                    var settings = MongoClientSettings.FromUrl(new MongoUrl)(configuration["ConnectionString"]);
                    var client = new MongoClient(settings);
                    DB = client.GetDatabase(configuration[NomeBranco]);
                    MapClasses();
                }
            }
            catch (Exception ex)
            {
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var convetionPack = new ConventionPack { new CamelCaseElementNameConvetion() };
            ConvetionRegitry.Register("camelCase", convetionPack, t => true)

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements((true));
                });
            }
        }
    }
}