using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities
{
    public class BaseEntity<TKey>
    {
        TKey _id;

        [BsonRepresentation(BsonType.String)]
        [BsonId]
        public virtual TKey Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        protected BaseEntity(TKey id) => Id = id;

        protected BaseEntity() { }
    }

    public abstract class BaseEntity 
        : BaseEntity<string>
    {
        protected BaseEntity(string id)
            : base(id) { }



        protected BaseEntity() { }
    }
}
