namespace Module1
{
    internal class Bike : Transport
    {
        private const decimal BaseCost = 20m;
        private const decimal CostPerKm = 5m;
        private const double WeightLimit = 10.0;
        private const double DistanceLimit = 10.0;
        public Bike(string name) : base(name, WeightLimit) { }

        public override decimal CalculateCost(Order order)
        {
            return BaseCost + (CostPerKm * (decimal)order.Distance);
        }

        public override bool CanTake(Order order)
        {
            return base.CanTake(order) && order.Distance <= DistanceLimit;
        }


    }
}
