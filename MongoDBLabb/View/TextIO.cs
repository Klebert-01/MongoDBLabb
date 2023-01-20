internal class TextIO : IUI 
{

    public void Clear()
    {
        //no implementation
    }

    public void Exit()
    {
        System.Environment.Exit(0);
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }
    public void PrintMenu()
    {
        Print("~~~~ExpenseManager5000~~~~\n" +
                "Välj i menyn:\n" +
                "[1] Visa alla utgifter\n" +
                "[2] Filtrera efter indexnr(kanske mellan år sen)\n" +
                "[3] Lägg till ny\n" +
                "[4] Uppdatera befintlig\n" +
                "[5] Radera utgift\n" +
                "[6] Avsluta");
    }
}