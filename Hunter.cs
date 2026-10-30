namespace Lb3
{
    internal class Hunter
    {
        private string _name;
        private int _health;
        private int _gold;
        private int _arrow;
        private int _prey;
        private const int ArrowPrice = 20;
        private static readonly Random _rnd = new Random();

        public string Name => _name;
        public int Health => _health;
        public int Gold => _gold;
        public int Arrow => _arrow;
        public int Prey => _prey;

        public Hunter(string name) 
        {
            _name = name;
            _health = 100;
            _gold = 300;
            _arrow = 10;
            _prey = 0;
        }

        public void Hunting()
        {
            if (_health <= 0)
            {
                Console.WriteLine("Здоров'я 0, полувати не мозна.");
                return;
            }

            if (_arrow <= 0)
            {
                Console.WriteLine("У вас недостатньо стрiл");
                return;
            }

            int roll = _rnd.Next(1, 3);

            _arrow--;
            
            if (roll == 1)
            {
                _prey++;
                _gold += 15;
                Console.WriteLine("Успiшне полювання, +1 здобич та +15 золота");
            }
            else if (roll == 2)
            {
                _health = _health - 10;

                if (_health < 0)
                {
                    _health = 0;
                }
                Console.WriteLine($"Невдале полювання, -стрiла, -10хп. Здоров'я: {_health}");
            }
        }

        public void BuyArrow(int count)
        {

            if (count <= 0)
            {
                Console.WriteLine("Кiлькiсть має бути бiльшою за 0.");
                return;
            }
            
            int totalPrice = count * ArrowPrice;
            if (_gold >= totalPrice)
            {
                _arrow += count;
                _gold -= totalPrice;
                Console.WriteLine($"Ви купили {count} стрiл(и).");
            }
            else
            {
                Console.WriteLine("Недостатньо голди для покупки такої кiлькостi стрiл.");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Iм'я: {Name}");
            Console.WriteLine($"Хп: {Health}");
            Console.WriteLine($"Голда: {Gold}");
            Console.WriteLine($"Стрiли: {Arrow}");
            Console.WriteLine($"Здобич: {Prey}");
        }
    }
}
