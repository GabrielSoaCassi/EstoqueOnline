using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EstoqueOnline.Domain.Models
{
    public class Estoque
    {
        [BsonId]
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
        [BsonElement("localizacao")]
        public string? Localizacao { get; set; }
        [BsonElement("items")]
        public IEnumerable<Item>? Items { get; set; }
        public Estoque(string userId,string localizacao)
        {
            Id = userId;
            CreatedDate = DateTime.Now;
            Localizacao = localizacao;
        }
    }
}
