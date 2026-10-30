namespace Lb3
{
    internal class Competitions
    {
        private List<Hunter> _hunters;

        public Competitions()
        {
            _hunters = new List<Hunter>();
        }

        public void AddHunters(Hunter hunter)
        {
            _hunters.Add(hunter);
        }

        public void Start()
        {
            const int rounds = 5;
            for (int round = 1; round <= rounds; round++)
            {
                Console.WriteLine($"Раунд:{round} ");
                foreach (var h in _hunters)
                {
                    Console.WriteLine($"Полює {h.Name}");
                    h.Hunting();

                }
            }
            Comparison();
            

        }

        public void Comparison()
        {
            foreach (var h in _hunters)
            {
                h.ShowInfo();
            }

            int maxPrey = 0;

            foreach (var h in _hunters)
            {
                if(h.Prey > maxPrey) maxPrey = h.Prey;
            }

            Hunter winner = null;
            int count = 0;

            foreach (var h in _hunters)
            {
                if (h.Prey == maxPrey)
                {
                    winner = h;
                    count++;
                }
            }

            if (count == 1)
                Console.WriteLine($"Переможець: {winner.Name}!");
            else
                Console.WriteLine("Нічия!");
        }
    }

    

    
}
