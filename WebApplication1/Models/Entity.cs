using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class Entity
    {
        //[BsonIgnore]
        //public virtual string Id { get { return _id.ToString(); } set { _id = ObjectId.Parse(value); } }

        //[BsonId]
        //[BsonIgnoreIfDefault]
        //[JsonIgnore]
        //public virtual ObjectId _id { get; set; }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public virtual DateTime CreatedOn { get; private set; }
        public virtual bool IsActive { get; set; }

        public Entity(bool isActive)
        {
            CreatedOn = DateTime.Now;
            IsActive = isActive;
        }
    }
}
