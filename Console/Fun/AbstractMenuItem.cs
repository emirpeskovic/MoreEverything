using System;

namespace MoreEverything.Console.Fun
{
    public abstract class AbstractMenuItem : IMenuItem
    {
        protected string FunctionName;
        protected Action Action;

        protected bool Selected;
        protected bool Focused;

        public abstract void Update();
        public abstract void Draw(bool white);
        public abstract void ProcessInput(ConsoleKey key);
        public string GetName() => FunctionName;

        public virtual void Select()
        {
            Selected = true;
        }

        public void Deselect()
        {
            Selected = false;
        }

        public bool IsSelected() => Selected;

        public virtual void Focus()
        {
            Focused = true;
        }

        public virtual void RemoveFocus()
        {
            Focused = false;
        }

        public virtual bool IsFocused() => Focused;
    }
}