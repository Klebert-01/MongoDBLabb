IUI io = new TextIO();
IExpenseDAO expenseDAO = new ExpenseDAO("djuphallen", "MONGODB CONNECTION STRING HÄR");
dbController dbController = new dbController(io, expenseDAO);

while (true)
{
    io.PrintMenu();
    
    int.TryParse(io.GetInput(), out int userInput);
    switch (userInput)
    {
        case 1:
            dbController.ReadAll();
            //läs alla
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
            io.Exit();
            // avsluta
            break;
        default:
            io.Print("Välj mellan 1-5 i menyn");
            break;
    }
}


