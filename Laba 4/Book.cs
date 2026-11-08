namespace Lb4
{
    internal class Book
    {
        private int _id;
        private string _name;
        private string _author;
        public bool IsAvailable {  get; private set; }

        public int Id => _id;
        public string Name => _name;
        public string Author => _author;

        public Book(int id, string name, string author)
        {
            _id = id;
            _name = name;
            _author = author;
            IsAvailable = true;
        }

        public bool Borrow()
        {
            if (IsAvailable == false)
            {
                return false;
            }

            IsAvailable = false;
            return true;
        }

        public bool Return()
        {
            if (IsAvailable == false)
            {
                IsAvailable = true;
                return true;
            }
            return false;
        }

        
    }

    

}
