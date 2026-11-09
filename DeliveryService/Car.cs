namespace Module1
{
    internal class Car : Transport
    {
        private const decimal BaseCost = 50m;
        private const decimal CostPerKm = 8m;
        private const decimal CostPerKg = 1m;
        private const double WeightLimit = 200.0;
        public Car(string name) : base(name, WeightLimit) { }


        public override decimal CalculateCost(Order order)
        {
            return BaseCost + (CostPerKm * (decimal)order.Distance) + (CostPerKg * (decimal)order.Weight);
        }


    }
}
