namespace Ex1_Csharp
{
    public class Circle : Shape
    {
        protected double _a;

        public double A
        {
            get
            {
                return _a;
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
                        _a = value;
                    }
                }
                catch (ParameterException e)
                {
                    Console.WriteLine(e.Message);
                    double newValue = RetriveParameter();
                    _a = newValue;
                }
            }
        }


        public Circle()
        {

        }
        public Circle(double paramA) : base()
        {
            A = paramA;
        }

        public override double CalculateArea()
        {
            double result = Math.PI * Math.Pow(_a, 2);
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = 2 * Math.PI * _a;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {_a}" + GetAreaAndPerimeter();
        }
    }
}