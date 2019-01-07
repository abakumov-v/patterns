using System;
using System.Collections.Generic;
using _09.Composite.Menus.Abstract;

namespace _09.Composite.Menus
{
    public class WaitressWithMenus
    {
        private readonly List<IMenu> _menus;

        public WaitressWithMenus(List<IMenu> menus)
        {
            _menus = menus;
        }

        public void PrintMenu()
        {
            using (var menuIterator = _menus.GetEnumerator())
            {
                while (menuIterator.MoveNext())
                {
                    var menu = menuIterator.Current;
                    PrintMenu(menu.GetEnumerator());
                }
            }
        }

        private void PrintMenu(IEnumerator<MenuItem> iterator)
        {
            while (iterator.MoveNext())
            {
                PrintMenuItem(iterator.Current);
            }
        }
        
        private void PrintMenuItem(MenuItem menuItem)
        {
            Console.WriteLine($"{menuItem.GetName()}  {menuItem.GetPrice()}\n  {menuItem.GetDescription()}");
        }
    }
}