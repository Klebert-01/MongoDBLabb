﻿namespace MongoDBLabb.View;

internal interface IUI
{
    public string GetInput();
    public void Print(string text);
    public void Clear();
    public void Exit();
    public void PrintMenu();
}
