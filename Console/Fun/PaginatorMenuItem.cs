using System;
using System.Collections.Generic;

namespace MoreEverything.Console.Fun
{
    public abstract class PaginatorMenuItem<T> : AbstractMenuItem
    {
        protected List<T> listOfItems;
        protected int pageSize = 0;

        public PaginatorMenuItem(string functionName, Action action, List<T> items, int pageSize)
        {
            FunctionName = functionName;
            Action = action;
            listOfItems = items;
            this.pageSize = pageSize;
        }
    }
}