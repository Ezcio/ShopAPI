using System;

namespace Sklep.Entities
{
    public class Opinion
    {
        public Guid OpinionId { get; set; }
        public Guid ItemId { get; set; }

        public Item Item { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
