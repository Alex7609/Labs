namespace Module1
{
    internal class DeliveryService
    {
        private readonly List<Transport> _transports = new List<Transport>();
        private readonly Dictionary<Order, Transport> _activeOrders = new Dictionary<Order, Transport>();
        private readonly List<DeliveryRecord> _history = new List<DeliveryRecord>();
        private readonly List<Order> _orders = new List<Order>();



        public void AddTransport(Transport transport)
        {
            if (transport == null)
            {
                throw new ArgumentNullException(nameof(transport), "Транспорт не може бути null.");
            }
            _transports.Add(transport);
        }

        public Order CreateOrder(int id, string description, double weight, double distance)
        {
            foreach (var order in _orders)
            {
                if (order.Id == id)
                {
                    throw new ArgumentException($"Замовлення з номером {id} вже iснує.");
                }
            }
            Order order1 = new Order(id, description, weight, distance);
            _orders.Add(order1);
            return order1;
        }

        private Order? FindOrder(int orderId)
        {
            foreach (var order in _orders)
            {
                if (orderId == order.Id)
                {
                    return order;
                }
            }
            return null;
        }

        public void ShowCost(int orderId)
        {
            Order? order = FindOrder(orderId);
            if (order == null)
            {
                Console.WriteLine($"Не знайдено замовлення за номером {orderId}");
                return;
            }
            bool found = false;
            foreach (var transport in _transports)
            {
                if (transport.CanTake(order) == true)
                {
                    Console.WriteLine($"Може взяти транспорт: {transport.Name}, {transport.CalculateCost(order)} грн");
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Жоден транспорт не може взяти замовлення.");
            }
        }

        public bool AssignOrder(int orderId, Transport transport)
        {
            Order? order = FindOrder(orderId);
            if (transport == null)
            {
                Console.WriteLine($"Транспорт не вказано");
                return false;
            }
            if (order == null)
            {
                Console.WriteLine($"Не знайдено замовлення за номером {orderId}");
                return false;
            }
            if (_activeOrders.ContainsKey(order))
            {
                Console.WriteLine($"{order} вже активно.");
                return false;
            }
            if (transport.IsFree == false)
            {
                Console.WriteLine($"{transport.Name} зайнятий");
                return false;
            }
            if (!transport.CanTake(order))
            {
                Console.WriteLine($"{transport.Name} не може взяти {orderId}");
                return false;
            }
            transport.Occupy();
            _activeOrders.Add(order, transport);
            Console.WriteLine($"Замовлення номер {orderId} призначено на {transport.Name}");
            return true;
        }
        public bool DeliverOrder(int orderId, IPayment payment)
        {
            Order? order = FindOrder(orderId);
            if (payment == null)
            {
                Console.WriteLine("Спосіб оплати не вказано");
                return false;
            }
            if (order == null)
            {
                Console.WriteLine($"Не існує {orderId}");
                return false;
            }
            _activeOrders.TryGetValue(order, out Transport? transport);
            if (transport == null)
            {
                Console.WriteLine("Замовлення не активне (не призначене або вже доставлене)");
                return false;
            }
            decimal sum = transport.CalculateCost(order);
            payment.Pay(sum);
            transport.Release();
            _activeOrders.Remove(order);
            DeliveryRecord delivery = new DeliveryRecord(order, sum, payment.Name, transport);
            _history.Add(delivery);
            Console.WriteLine($"Замовлення {order} доставлено");
            return true;
        }
        public void ShowActiveOrders()
        {
            Console.WriteLine("Активні замовлення:");
            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("Немає активних замовлень");
                return;
            }

            foreach (var pair in _activeOrders)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Name}");
            }
        }

        public void ShowHistoryOrders()
        {
            Console.WriteLine("Історія замовлень: ");
            if (_history.Count == 0)
            {
                Console.WriteLine("Історiя замовлень порожня");
                return;
            }
            foreach (var record in _history)
            {
                Console.WriteLine($"{record}");
            }
        }
    }
}
