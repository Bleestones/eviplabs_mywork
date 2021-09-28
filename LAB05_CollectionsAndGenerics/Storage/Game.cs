
namespace Storage
{    public class Game :IStorable
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Id { get; set; }
        public int InStock { get; set; }

        public Game(string id,int stock, string title, string genre, int year)
        {
            Title = title;
            Genre = genre;
            Year = year;
            Id = id;
            InStock = stock;
        }
        public Game()
        {

        }

        public override string ToString()
        {
            return Id + ": '" + Title + "'(" + Year+") - Available: "+InStock;
        }
    }
}
