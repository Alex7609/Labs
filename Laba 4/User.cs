namespace Lb4
{
    internal class User
    {
        private int _id;
        private string _name;
        private readonly List<Book> _books = new List<Book>();

        public int Id => _id;
        public string Name => _name;
        public IReadOnlyList<Book> Books => _books;

        public User(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
            
        public bool HasBook(Book book)
        {
            if(book == null) return false;
            foreach (Book book2 in _books)
            {
                if(book2.Id == book.Id) return true;
            }
            return false;
        }



    }
}
