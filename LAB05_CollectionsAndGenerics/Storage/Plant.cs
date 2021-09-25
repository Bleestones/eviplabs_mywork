using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Plant : IStorable
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Genre { get; set; }
        public int InStock { get; set; }


        public Plant(string id, int stock, string title, string genre)
        {
            Title = title;
            Genre = genre;
            Id = id;
            InStock = stock;
        }

        public Plant()
        {

        }
        public override string ToString()
        {
            return Id + ": '" + Title + "' genre " + Genre + " - Available: " + InStock;
        }
    }
}
