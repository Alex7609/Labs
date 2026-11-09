namespace Module1
{
    internal abstract class Transport
    {
        public string Name { get; }
        private double MaxWeight { get; }
        public bool IsFree { get; private set; }

        protected Transport(string name, double maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight;
            IsFree = true;
        }

        public abstract decimal CalculateCost(Order order);

        public virtual bool CanTake(Order order)
        {
            if (order.Weight <= MaxWeight)
            {
                return true;
            }
            return false;
        }

        public bool Occupy()
        {
            if (IsFree == false)
            {
                return false;
            }

            IsFree = false;
            return true;
        }

        public bool Release()
        {
            if (IsFree == false)
            {
                IsFree = true;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (IsFree == false)
            {
                return $"Бібіка {Name} зайнята.";
            }
            return $"Бібіка {Name} вільна.";
        }
    }
}
