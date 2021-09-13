using System;
using System.Collections.Generic;

namespace MoreEverything.Console.Fun
{
    // TODO: Remove?
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

        public void Update()
        {
            if (focusedMenu is not null)
            {
                if (!focusedMenu.IsSelected())
                {
                    focusedMenu.RemoveFocus();
                    focusedMenu = null;
                    Reset();
                }
            }

            focusedMenu?.Update();
        }

        public void Draw()
        {
            System.Console.Clear();
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine("To navigate through the menu, use the arrow keys.\r\n");

            if (focusedMenu is null)
            {
                menuItems.ForEach(m => m.Draw((menuItems.IndexOf(m) == selectedIndex)));
                System.Console.WriteLine("\r\nTo exit, press escape.");
            }
            else
            {
                focusedMenu.Draw(false);
                System.Console.WriteLine("\r\nTo leave this menu, press escape.");
            }
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
            menuItems.Find(m => m.IsSelected())?.Deselect();
            menuItems[selectedIndex]?.Select();
        }

        private void Reset()
        {
            selectedIndex = 0;
            SelectItem();
        }

        public void Run()
        {
            while (!Exit)
            {
                Draw();
                ProcessInput();
            }
        }
    }
}