namespace Module1
{
    internal class Truck : Transport
    {
        private const decimal BaseCost = 200m;
        private const decimal CostPerKm = 15m;
        private const decimal CostPerKg = 0.5m;
        private const double WeightLimit = 1000.0;
        public Truck(string name) : base(name, WeightLimit) { }


        public override decimal CalculateCost(Order order)
        {
            return BaseCost + (CostPerKm * (decimal)order.Distance) + (CostPerKg * (decimal)order.Weight);
        }
        
    }
}
