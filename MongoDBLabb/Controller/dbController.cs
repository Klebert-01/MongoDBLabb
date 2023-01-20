internal class dbController
{
    private IUI io;
    private IExpenseDAO expenseDAO;

    public dbController(IUI io, IExpenseDAO expenseDAO)
    {
        this.io = io;
        this.expenseDAO = expenseDAO;
    }
    public void Create()
    {
        try
        {
            io.Print("Ange produktnamn:");
            string newExpenseProduct = io.GetInput();   // tar emot produktnamn

            io.Print("Pris:");
            decimal.TryParse(io.GetInput(), out decimal newExpensePrice);   // tar emot pris

            io.Print("Återförsäljare:");
            string newExpenseRetailer = io.GetInput();  // tar emot återförsäljare

            io.Print("Datum:\n(YYYY-MM-DD)");
            DateTime.TryParse(io.GetInput(), out DateTime newExpenseDate);  // tar emot datum
            newExpenseDate = newExpenseDate.ToLocalTime();

            int newExpenseIndex = expenseDAO.ReadAll().Count() + 1; // skapar nytt indexnr, antal dokument i collection + 1

            foreach (var document in expenseDAO.ReadAll())
            {
                if (newExpenseIndex == document.Index)  // om indexnr redan finns + 1
                    newExpenseIndex++;
            }

            var newExpense = new ExpenseODM()   // skapar nytt ExpenseODM-objekt
            {
                Product = newExpenseProduct,
                Price = newExpensePrice,
                Retailer = newExpenseRetailer,
                Date = newExpenseDate,
                Index = newExpenseIndex
            };

            expenseDAO.Create(newExpense);  // kallar på createmetoden från ExpenseDAO med [newExpense] som parameter

            io.Print($"{newExpense.Product} med indexnr {newExpense.Index} tillagd!");
        }
        catch (Exception ex)    // skriver ut exception och hoppar ur metoden om fel
        {
            io.Print($"gick ej att lägga till..\n{ex}");
            return;
        }
    }

    public void ReadAll()
    {
        string toShortDate;
        foreach (var expense in expenseDAO.ReadAll())   // för varje dokument i kollektion
        {
            toShortDate = expense.Date.ToString().Remove(10);   // rensar bort tid osv från datetime
            io.Print($"#{expense.Index} {expense.Product} {expense.Price} sek, Inköpt på {expense.Retailer} den {toShortDate}");    // skriver ut
        }
    }
    public void ReadOne()
    {

        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index); // ta emot index användare vill söka på

        var selectedExpense = expenseDAO.ReadAll().Find(e => e.Index == index); // matchar input mot key index i varje dok i kollektionen

        if (selectedExpense == null)    // om ingen matchning, går ur metoden
        {
            io.Print($"No match\n");
            return;
        }

        string selectedExpenseToShortDate = selectedExpense.Date.ToString().Remove(10);   // rensar bort tid osv från datetime
        io.Print($"#{selectedExpense.Index} {selectedExpense.Product} {selectedExpense.Price} sek, Inköpt på {selectedExpense.Retailer} den {selectedExpenseToShortDate}");
    }
    public void UpdateOne()
    {
        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index); // ta emot index användare vill söka på

        var selectedExpense = expenseDAO.ReadAll().Find(e => e.Index == index);

        if (selectedExpense == null)
        {
            io.Print($"No match\n");
            return;
        }

        io.Print("Ange produktnamn:");
        string updatedExpenseProduct = io.GetInput();  // tar emot uppdaterat produktnamn

        io.Print("Pris:");
        decimal.TryParse(io.GetInput(), out decimal updatedExpensePrice);   // tar emot uppdaterat pris

        io.Print("Återförsäljare:");
        string updatedExpenseRetailer = io.GetInput();  // tar emot uppdaterad återförsäljare

        io.Print("Datum:\n(YYYY-MM-DD)");
        DateTime.TryParse(io.GetInput(), out DateTime updatedExpenseDate);  // tar emot uppdaterat datum
        updatedExpenseDate = updatedExpenseDate.ToLocalTime();

        var updatedExpense = new ExpenseODM()  // skapar nytt ExpenseODM objekt med ovan parametrar
        {
            Product = updatedExpenseProduct,
            Price = updatedExpensePrice,
            Retailer = updatedExpenseRetailer,
            Date = updatedExpenseDate
        };

        expenseDAO.UpdateOne(index, updatedExpense);  // kallar på UpdateOne metoden från [ExpenseDAO] och sätter indexnr & nya objektet som parameter 
        io.Print($"utgift uppdaterad!");
    }



    public void DeleteOne()
    {
        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index); // ta emot index användare vill söka på

        var selectedExpense = expenseDAO.ReadAll().Find(e => e.Index == index);

        if (selectedExpense == null)
        {
            io.Print($"No match\n");
            return;
        }
        io.Print($"Deleting {selectedExpense.Product} with index #{selectedExpense.Index}\n");
        expenseDAO.Delete(index);
    }
}
