public class ExpenseDAO : IExpenseDAO
{
    IMongoCollection<ExpenseODM> collection;

    public ExpenseDAO(string db, string MongoURI)
    {
        var client = new MongoClient(MongoURI);
        var database = client.GetDatabase(db);
        this.collection = database.GetCollection<ExpenseODM>("expenses");
    }

    // CRUD Metoder
    public void Create(ExpenseODM expense)
    {

        this.collection.InsertOne(expense);
    }
    public List<ExpenseODM> ReadAll()
    {
        var result = this.collection.Find(new BsonDocument()).ToList();
        return result;
    }
    public ExpenseODM ReadOne(int index)
    {
        var readOneFilter = Builders<ExpenseODM>.Filter.Eq("index", index);
        var result = this.collection.Find(readOneFilter).FirstOrDefault();
        return result;
    }
    public void UpdateOne(int index, ExpenseODM expense)
    {
        var updateFilter = Builders<ExpenseODM>.Filter.Eq("index", index);

        var update = Builders<ExpenseODM>.Update
            .Set("produkt", expense.Product)
            .Set("pris", expense.Price)
            .Set("datum", expense.Date)
            .Set("retailer", expense.Retailer)
            .Set("index", index);
        this.collection.UpdateOne(updateFilter, update);
    }
    public void Delete(int index)
    {
        var deleteFilter = Builders<ExpenseODM>.Filter.Eq("index", index);
        this.collection.DeleteOne(deleteFilter);
    }
}