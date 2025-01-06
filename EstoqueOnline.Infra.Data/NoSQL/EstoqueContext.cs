using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EstoqueOnline.Infra.Data.NoSQL
{
    public class EstoqueContext
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;
        public EstoqueContext(IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("EstoqueDb");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoCollection<Estoque>? _estoque => _database.GetCollection<Estoque>("estoques");
    }
}
