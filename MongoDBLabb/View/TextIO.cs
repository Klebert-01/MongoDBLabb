using LayeredCRUDDemo.View;
/// <summary>
/// textio används vid konsoll input/output
/// </summary>
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
}