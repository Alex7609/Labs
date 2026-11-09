namespace Module1
{
    internal class DeliveryRecord
    {
        private readonly Order _order;
        private readonly decimal _price;
        private readonly string _paymentmethod;
        private readonly Transport _transport;

        public DeliveryRecord(Order order, decimal price, string paymentmethod, Transport transport)
        {
            _order = order;
            _price = price;
            _paymentmethod = paymentmethod;
            _transport = transport;
        }

        public override string ToString()
        {
            return $"{_order}, сума: {_price} гриблів, метод оплати: {_paymentmethod}, бібіка: {_transport.Name}";
        }
    }
}
