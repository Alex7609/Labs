namespace Module1
{
    internal interface IPayment
    {
        string Name { get; }
        void Pay(decimal amount);
    }

    internal class CardPayment : IPayment
    {
        public string Name => "Картка";
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {Name}: {amount} гриблів");
        }
    }

    internal class CashPayment : IPayment 
    {
        public string Name => "Готiвка";

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {Name}: {amount} гриблів");
        }
    }
}
