using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Models
{
    public enum MenuItemType
    {
        Lista,
        Noticias,
        Ajustes
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
