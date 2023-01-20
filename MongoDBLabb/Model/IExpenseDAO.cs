namespace MongoDBLabb.Model;

internal interface IExpenseDAO
{
    void Create(ExpenseODM expense);
    List<ExpenseODM> ReadAll();
    ExpenseODM ReadOne(int index);
    void UpdateOne(int id, ExpenseODM expense);
    void Delete(int id);

}
