using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EstoqueOnline.Domain.Models
{
    public class Item
    {
        [BsonElement("codigo")]
        public string Codigo { get;set; }
        [BsonElement("nome")]
        public string Nome { get;set; }
        [BsonElement("quantidade")]
        public int Quantidade { get;set; }
        [BsonElement("valor")]
        public decimal? Valor { get;set; }
    }
}
