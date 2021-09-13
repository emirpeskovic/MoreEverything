using System;
using System.Collections.Generic;

namespace MoreEverything.Console.Fun
{
    public class InteractiveMenu
    {
        public bool Exit { get; private set; }
        private List<IMenuItem> menuItems;
        private IMenuItem focusedMenu;
        private int selectedIndex = 0;

        public InteractiveMenu()
        {
            menuItems = new List<IMenuItem>();
        }

        public void AddMenu(IMenuItem menuItem) => menuItems.Add(menuItem);

        public void Draw()
        {
            System.Console.Clear();
            System.Console.WriteLine(selectedIndex);
            if (focusedMenu is null)
            {
                menuItems.ForEach(m => m.Draw((menuItems.IndexOf(m) == selectedIndex)));
                System.Console.WriteLine("\r\nTo exit, press escape.");
            }
            else
                focusedMenu?.Draw(true);
        }

        public void ProcessInput()
        {
            var key = System.Console.ReadKey().Key;
            if (focusedMenu is null)
            {
                switch (key)
                {
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (!(selectedIndex - 1 >= 0))
                            break;
                        selectedIndex--;
                        SelectItem();
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex + 1 > menuItems.Count - 1)
                            break;
                        selectedIndex++;
                        SelectItem();
                        break;
                    case ConsoleKey.Enter:
                        menuItems[selectedIndex]?.Focus();
                        focusedMenu = menuItems[selectedIndex] ?? null;
                        break;
                    default:
                        break;
                }
            }
            else
                focusedMenu?.ProcessInput(key);
        }

        private void SelectItem()
        {
            menuItems.Find(m => m.IsSelected())?.Select();
            menuItems[selectedIndex]?.Select();
        }

        public void Run()
        {
            SelectItem();
            while (!Exit)
            {
                Draw();
                ProcessInput();
            }
        }
    }
}