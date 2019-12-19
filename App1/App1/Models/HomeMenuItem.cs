using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Models
{
    public enum MenuItemType
    {
        Lista,
        Noticias
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
