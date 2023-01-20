using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBLabb.Model;

public class ExpenseODM
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("produkt")]
    public string? Product { get; set; }
    [BsonElement("pris")]
    public decimal? Price { get; set; }
    [BsonElement("retailer")]
    public string? Retailer { get; set; }
    [BsonElement("datum")]
    public DateTime? Date { get; set; }
    [BsonElement("index")]
    public int Index { get; set; }


}
