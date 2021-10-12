
namespace Storage
{
    public class Book :IStorable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        
        public string Id { get; set; }
        public int InStock { get; set; }

        public Book(string id,int stock, string title, string author)
        {
            Title = title;
            Author = author;
            Id = id;
            InStock = stock;
        }

        public Book()
        {

        }

        public override string ToString()
        {
            return Id + ": '" + Title + "' by " + Author + " - Available: " + InStock;
        }
    }
}
