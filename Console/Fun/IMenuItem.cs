using System;

namespace MoreEverything.Console.Fun
{
    public interface IMenuItem
    {
        void Update();
        void Draw(bool white = false);
        void ProcessInput(ConsoleKey key);
        string GetName();
        void Select();
        void Deselect();
        bool IsSelected();
        void Focus();
        void RemoveFocus();
        bool IsFocused();
    }
}