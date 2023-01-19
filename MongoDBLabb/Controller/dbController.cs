using LayeredCRUDDemo.Model;
using LayeredCRUDDemo.View;
using MongoDB.Driver;
using System;
using System.Globalization;

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
        io.Print("Ange produktnamn:");
        string newExpenseProduct = io.GetInput();

        io.Print("Pris:");
        decimal.TryParse(io.GetInput(), out decimal newExpensePrice);

        io.Print("Återförsäljare:");
        string newExpenseRetailer = io.GetInput();

        io.Print("Datum:\n(YYYY-MM-DD)");
        DateTime.TryParseExact(io.GetInput(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newExpenseDate);
        newExpenseDate = newExpenseDate.ToLocalTime();

        int newExpenseIndex = expenseDAO.ReadAll().Count() + 1; // newExpenseIndex = antal dokument i collection + 1

        //expenseDAO.ReadAll().Where(document => newExpenseIndex == document.Index).Select(x => newExpenseIndex++); // samma som nedan med lambda

        foreach (var document in expenseDAO.ReadAll())  // om nytt index redan finns i collection -> newExpenseIndex + 1
        {
            if (newExpenseIndex == document.Index)
                newExpenseIndex++;
        }

        try
        {
            var newExpense = new ExpenseODM() { Product = newExpenseProduct, Price = newExpensePrice, Retailer = newExpenseRetailer, Date = newExpenseDate, Index = newExpenseIndex };

            expenseDAO.Create(newExpense);
            io.Print($"{newExpense.Product} med indexnr {newExpense.Index} tillagd!");
        }
        catch (Exception ex)
        {
            io.Print($"gick ej att lägga till..\n{ex}");
            return;
        }
    }
    public void ReadAll()
    {
        string toShortDate;
        foreach (var expense in expenseDAO.ReadAll())
        {
            toShortDate = expense.Date.ToString().Remove(10);   // rensar bort tid osv från datetime
            io.Print($"#{expense.Index} {expense.Product} {expense.Price} sek, Inköpt på {expense.Retailer} den {toShortDate}");
        }
        io.Print(""); // behövs bara i konsollversion
    }
    public void ReadOne()
    {
        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index);

        if (index < 1 || index > expenseDAO.ReadAll().Count())
        {
            io.Print($"No match\n");
            return;
        }
        var selectedExpense = expenseDAO.ReadOne(index);
        string selectedExpenseToShortDate = selectedExpense.Date.ToString().Remove(10);   // rensar bort tid osv från datetime
        io.Print($"#{selectedExpense.Index} {selectedExpense.Product} {selectedExpense.Price} sek, Inköpt på {selectedExpense.Retailer} den {selectedExpenseToShortDate}");
    }
    public void UpdateOne()
    {
        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index);

        foreach (var document in expenseDAO.ReadAll())
        {
            if (index == document.Index)
            {
                io.Print("Ange produktnamn:");
                string updatedExpenseProduct = io.GetInput();

                io.Print("Pris:");
                decimal.TryParse(io.GetInput(), out decimal updatedExpensePrice);

                io.Print("Återförsäljare:");
                string updatedExpenseRetailer = io.GetInput();

                io.Print("Datum:\n(YYYY-MM-DD)");
                DateTime.TryParseExact(io.GetInput(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime updatedExpenseDate);
                updatedExpenseDate = updatedExpenseDate.ToLocalTime();

                var updatedExpense = new ExpenseODM() { Product = updatedExpenseProduct, Price = updatedExpensePrice, Retailer = updatedExpenseRetailer, Date = updatedExpenseDate };

                expenseDAO.UpdateOne(index, updatedExpense);
                io.Print($"utgift uppdaterad!");

                return;
            }
        }
        io.Print($"No match\n");
    }
    public void DeleteOne()
    {
        io.Print($"Ange indexnummer och tryck ENTER:");
        int.TryParse(io.GetInput(), out int index);

        foreach (var document in expenseDAO.ReadAll())
        {
            if (index == document.Index)
            {
                var selectedExpense = expenseDAO.ReadOne(index);
                io.Print($"Deleting {selectedExpense.Product} with index #{selectedExpense.Index}\n");
                expenseDAO.Delete(index);
                return;
            }
        }
        io.Print($"No match\n");
    }
}
