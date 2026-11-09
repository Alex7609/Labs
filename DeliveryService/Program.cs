namespace Module1
{
    internal class Program
    {
        static void Main()
        {
            DeliveryService service = new DeliveryService();

            service.ShowActiveOrders();
            service.ShowHistoryOrders();

            Transport bike = new Bike("Велосипед");
            Transport car = new Car("Авто");
            Transport truck = new Truck("Вантажівка");
            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck);
            try
            {
                service.AddTransport(null);
            }
            catch(ArgumentNullException exx)
            {
                Console.WriteLine($"Помилка: " + exx.Message);
            }

            service.CreateOrder(1, "Квіти", 2, 5);
            service.CreateOrder(2, "Коробка", 100, 20);
            service.CreateOrder(3, "Меблі", 500, 30);
            service.CreateOrder(4, "Верстат", 2000, 10);
            service.CreateOrder(5, "Документи", 1, 15);
            try
            {
                service.CreateOrder(1, "Дубль", 5, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            try
            {
                service.CreateOrder(10, "Тест", -5, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            Console.WriteLine("\n--- Вартість ---");
            for (int id = 1; id <= 5; id++)
            {
                Console.WriteLine("Замовлення " + id + ":");
                service.ShowCost(id);
            }
            service.ShowCost(99);

            Console.WriteLine("\n--- Призначення ---");
            service.AssignOrder(5, bike);
            service.AssignOrder(3, bike);
            service.AssignOrder(1, bike);
            service.AssignOrder(2, bike);
            service.AssignOrder(1, car);
            service.AssignOrder(99, car);
            service.AssignOrder(3, truck);
            service.AssignOrder(1, null);
            service.ShowActiveOrders();

            Console.WriteLine("\n--- Доставка ---");
            service.DeliverOrder(1, new CardPayment());
            service.DeliverOrder(3, new CashPayment());
            service.DeliverOrder(1, new CardPayment());

            Console.WriteLine("\n--- Підсумок ---");
            service.ShowActiveOrders();
            service.ShowHistoryOrders();
        }

    }
}
