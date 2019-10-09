using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Cnn,
        Cnbc,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
