namespace Lb4
{
    internal class Library
    {

        private readonly List<Book> _books = new List<Book>();
        private readonly List<User> _users = new List<User>();


        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        private Book FindBook(int id)
        {
            foreach (var book in _books)
            {
                if (book.Id == id) return book;
            }
            return null;
        }

        private User FindUser(int id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id) return user;                   
            }
            return null;
        }
        public void ShowAllBooks()
        {
            Console.WriteLine("All books:");
            foreach (var book in _books)
            {
                Console.WriteLine($"ID book: {book.Id}, name book: {book.Name}, name author: {book.Author}");
            }
        }

        public void ShowAllUsers()
        {
            Console.WriteLine("All users and their book:");
            foreach (var user in _users)
            {
                Console.WriteLine($"User ID: {user.Id}, user name: {user.Name}");
                foreach (var book in user.Books)
                {
                    Console.WriteLine($"User book ID: {book.Id}, User book name: {book.Name}");
                }
            }
        }

        public void ShowAvailableBooks()
        {
            Console.WriteLine("Books avaliable:");
            foreach (var book in _books)
            {
                if (book.IsAvailable == true)
                {
                    Console.WriteLine($"{book.Id}, {book.Name}, {book.Author}");
                }
            }
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine("Borrowed book:");
            foreach (var book in _books)
            {
                if (book.IsAvailable == false)
                {
                    Console.WriteLine($"{book.Id}, {book.Name}, {book.Author}");
                }
            }
        }
        public void BorrowBook(int userId, int bookId)
        {
            User user = FindUser(userId);
            Book book = FindBook(bookId);
            if (user == null)
            {
                Console.WriteLine($"Dont find user with the id: {userId}");
                return;
            }
            if (book == null)
            {
                Console.WriteLine($"Dont find book with the id: {bookId}");
                return;
            }
            if (book.Borrow() == false)
            {
                Console.WriteLine("Книга вже видана");
                return;
            }
            user.AddBook(book);
            Console.WriteLine("The book was borrow");
        }

        public void ReturnBook(int userId, int bookId)
        {
            User user = FindUser(userId);
            Book book = FindBook(bookId);

            if (user == null)
            {
                Console.WriteLine($"Dont find user with the id: {userId}");
                return;
            }
            if (book == null)
            {
                Console.WriteLine($"Dont find book with the id: {bookId}");
                return;
            }
            if (user.HasBook(book) == true)
            {
                book.Return();
                user.RemoveBook(book);
                Console.WriteLine("The book was return");
                return;
            }
            Console.WriteLine("User dont have this book");
        }
    }




}
