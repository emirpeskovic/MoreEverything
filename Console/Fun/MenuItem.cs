using System;
using System.Collections.Generic;

namespace MoreEverything.Console.Fun
{
    public class MenuItem : IMenuItem
    {
        private string FunctionName;
        private bool Selected;
        private bool Focused;
        private Action Action;
        private List<MenuItem> SubMenuItems;

        public MenuItem(string functionName, Action action)
        {
            FunctionName = functionName;
            Action = action;
            // SubMenuItems = new List<MenuItem>(); ? Keep null ? 
        }

        public MenuItem(string functionName, Action action, List<MenuItem> subMenuItems)
        {
            FunctionName = functionName;
            Action = action;
            SubMenuItems = subMenuItems;
        }

        public virtual void Draw(bool white)
        {
            if (!Selected)
                System.Console.WriteLine(FunctionName);
            else
            {
                if (!Focused)
                {
                    System.Console.BackgroundColor = ConsoleColor.White;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.WriteLine(FunctionName);
                    System.Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    if (SubMenuItems is null)
                        Action?.Invoke();
                    else
                        SubMenuItems?.ForEach(s => s.Draw(false));
                }
            }
        }

        public virtual void ProcessInput(ConsoleKey key)
        {
            //Action?.Invoke();
        }

        public string GetName() => FunctionName;
        public void Select() => Selected = !Selected;
        public void Focus() => Focused = !Focused;

        public bool IsSelected() => Selected;
    }
}