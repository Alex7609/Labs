namespace Lb4
{
    internal class Program
    {
        static void Main()
        {
            Run();
        }


        static void Run()
        {
            Library library = new Library();
            User user1 = new User(1, "Jotaro");
            Book book1 = new Book(1, "Jojo bizzare gay adventure", "Hirohika Araki");
            User user2 = new User(2, "Dio");
            Book book2 = new Book(2, "Golden wind", "Hirohika Araki");

            library.AddBook(book1);
            library.AddUser(user1);
            library.AddBook(book2);
            library.AddUser(user2);
            library.ShowAllBooks();
            library.ShowAllUsers();
            library.ShowAvailableBooks();
            library.BorrowBook(1, 1);
            library.BorrowBook(2, 1);
            library.ShowBorrowedBooks();
            library.ShowAllUsers();
            library.ReturnBook(2, 1);
            library.ReturnBook(1, 1);
            library.ShowAvailableBooks();
            library.BorrowBook(99, 1);
            library.BorrowBook(1, 99);
        }
    }
}
