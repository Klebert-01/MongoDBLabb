using LayeredCRUDDemo.Model;
using LayeredCRUDDemo.View;

IUI io = new TextIO();
IExpenseDAO expenseDAO = new ExpenseDAO("djuphallen", "mongodb+srv://arvidbw:J5nzR5nz118!@cluster1.qjfqka6.mongodb.net/test");
dbController dbController = new dbController(io, expenseDAO);

bool on = true;

while (on)
{
    
    io.Print("Välj i menyn:\n[1] Visa alla utgifter\n[2] Filtrera efter indexnr(kanske mellan år sen)\n[3] Lägg till ny\n[4] Uppdatera befintlig\n[5] Radera utgift\n[6] Avsluta");
    int.TryParse(io.GetInput(), out int userInput);

    switch (userInput)
    {
        case 1:
            dbController.ReadAll();
            break;
        case 2:
            dbController.ReadOne();
            // filterera efter datum
            break;
        case 3:
            dbController.Create();
            //lägg till ny
            break;
        case 4:
            dbController.UpdateOne();
            //uppdatera befintlig
            break;
        case 5:
            dbController.DeleteOne();
            // delete
            break;
        case 6:
            on = false;
            break;
        default:
            io.Print("Välj mellan 1-5 i menyn");
            break;
    }
}


