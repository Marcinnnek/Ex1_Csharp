namespace Ex1_Csharp
{
    public class Rectangle : Circle
    {
        protected double _b;
        public double B
        {
            get
            {
                return _b;
            }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ParameterException("Inocrrect parameter! Parameter must be a number greater than zero!");
                    }
                    else
                    {
                        _b = value;
                    }
                }
                catch (ParameterException e)
                {
                    Console.WriteLine(e.Message);
                    double newValue = RetriveParameter();
                    _b = newValue;
                }
            }
        }

        public Rectangle()
        {

        }
        public Rectangle(double paramA, double paramB) : base(paramA)
        {
            B = paramB;
        }
        public override double CalculateArea()
        {
            double result = _a * _b;
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = 2 * _a + 2 * _b;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {_a} ,b = {_b}" + GetAreaAndPerimeter();
        }
    }
}