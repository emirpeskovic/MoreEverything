using System;

namespace MoreEverything.Console.Fun
{
    public interface IMenuItem
    {
        void Draw(bool white);
        void ProcessInput(ConsoleKey key);
        string GetName();
        void Select();
        bool IsSelected();
        void Focus();
    }
}