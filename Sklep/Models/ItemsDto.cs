using System;

namespace Sklep.Models
{
    public class ItemsDto
    {
        public string NameItem { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Specification { get; set; }

    }
}
