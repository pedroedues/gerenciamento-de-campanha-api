using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities
{
    public class Campanha
    {
        [BsonRepresentation(BsonType.String)]
        [BsonId]

        public string Id { get; private set; }

        public int MaximoDeCliques { get; private set; }

        public string LinkDeAcesso { get; private set; }

        public IList<Link> Links { get; private set; }

        public Campanha()
        {
            
        }
    }
}
