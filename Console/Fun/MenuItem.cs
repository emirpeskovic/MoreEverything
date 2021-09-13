using System;
using System.Collections.Generic;

namespace MoreEverything.Console.Fun
{
    public class MenuItem : AbstractMenuItem
    {
        private IMenuItem focusedMenu;
        private int selectedIndex = 0;
        private List<IMenuItem> SubMenuItems;

        public MenuItem(string functionName, Action action)
        {
            FunctionName = functionName;
            Action = action;
            // SubMenuItems = new List<MenuItem>(); ? Keep null ? 
        }

        public MenuItem(string functionName, Action action, List<IMenuItem> subMenuItems)
        {
            FunctionName = functionName;
            Action = action;
            SubMenuItems = subMenuItems;
        }

        public override void Update()
        {
            if (focusedMenu is not null)
                if (!focusedMenu.IsSelected())
                {
                    focusedMenu.RemoveFocus();
                    focusedMenu = null;
                    selectedIndex = 0;
                    SelectItem();
                }
        }

        public override void Draw(bool white = false)
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
                    {
                        SubMenuItems?.ForEach(s => s.Draw(SubMenuItems.IndexOf(s) == selectedIndex));
                    }
                }
            }
        }

        public override void ProcessInput(ConsoleKey key)
        {
            if (focusedMenu is null)
            {
                switch (key)
                {
                    case ConsoleKey.Escape:
                        Deselect();
                        RemoveFocus();
                        break;
                    case ConsoleKey.UpArrow:
                        if (!(selectedIndex - 1 >= 0))
                            break;
                        selectedIndex--;
                        SelectItem();
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex + 1 > SubMenuItems?.Count - 1)
                            break;
                        selectedIndex++;
                        SelectItem();
                        break;
                    case ConsoleKey.Enter:
                        SubMenuItems?[selectedIndex]?.Focus();
                        focusedMenu = SubMenuItems?[selectedIndex] ?? null;
                        break;
                    default:
                        break;
                }
            }
            else
                focusedMenu?.ProcessInput(key);
        }

        public override void RemoveFocus() // wait why am I doing this again?
        {
            base.Focus();
            SubMenuItems?.ForEach(s =>
            {
                s.Deselect();
                s.RemoveFocus();
            });
        }
        private void SelectItem()
        {
            SubMenuItems?.Find(m => m.IsSelected())?.Deselect();
            SubMenuItems?[selectedIndex]?.Select();
        }
    }
}