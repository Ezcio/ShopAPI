using System;

namespace Sklep.Entities
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string NameItem { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Specification { get; set; }
    }
}
