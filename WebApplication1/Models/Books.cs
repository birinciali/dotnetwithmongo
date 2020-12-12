using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Books : Entity
    {
        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public Books(string bookName, decimal price, string category, string author, bool isActive) : base (isActive)
        //public Books(string bookName, decimal price, string category, string author)
        {
            BookName = bookName;
            Price = price;
            Category = category;
            Author = author;
        }
    }
}