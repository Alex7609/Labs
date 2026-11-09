namespace Module1
{
    internal class Order
    {
        private readonly int _id;
        private readonly string _description;
        private readonly double _weight;
        private readonly double _distance;

        public int Id => _id;
        public string Description => _description;
        public double Weight => _weight;
        public double Distance => _distance;


        public Order(int id, string description, double weight, double distance)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Номер замовлення має бути більшим за 0.");
            }
            _id = id;

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Введіть опис замовлення.");
            }
            _description = description;

            if (weight <= 0)
            {
                throw new ArgumentException("Вага має бути більшою за 0.");
            }
            _weight = weight;

            if (distance <= 0)
            {
                throw new ArgumentException("Відстань має бути більшою за 0.");
            }
            _distance = distance;
        }

        public override string ToString()
        {
            return $"Номер замовлення: {Id}, опис: {Description}, " +
                $"вага: {Weight} кг, відстань {Distance} км";
        }
    }
}
