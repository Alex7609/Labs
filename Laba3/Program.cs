namespace Lb3
{
    internal class Program
    {
        static void Main()
        {

            RunPart1();
            RunPart2();

        }

        static void RunPart1()
        {
            Hunter first = new Hunter("Кiра");
            first.ShowInfo();
            PlayTurn(first);
        }


        static void RunPart2()
        {
            Competitions competitions = new Competitions();
            Hunter hunter1 = new Hunter("Джотаро");
            Hunter hunter2 = new Hunter("Какьоїн");
            competitions.AddHunters(hunter1);
            competitions.AddHunters(hunter2);

            hunter1.ShowInfo();
            hunter2.ShowInfo();
            competitions.Start();


        }

        static void PlayTurn(Hunter hunter)
        {
            while (true)
            {
                Console.WriteLine("1 - Полювати");
                Console.WriteLine("2 - Купити стрiли");
                Console.WriteLine("3 - iнформацiя");
                Console.WriteLine("4 - Вихiд");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        hunter.Hunting();
                        break;
                    case "2":
                        Console.WriteLine("Введiть кiлькiсть стрiл, щоб купити їх: ");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            hunter.BuyArrow(count);
                        }
                        else
                        {
                            Console.WriteLine("Введено некоректне число.");
                        }
                        break;
                    case "3":
                        hunter.ShowInfo();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неправильний вибiр");
                        break;
                }
            }
        }

    }
}
