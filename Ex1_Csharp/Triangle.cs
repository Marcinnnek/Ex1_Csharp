namespace Ex1_Csharp
{
    public class Triangle : Rectangle
    {
        protected double _c;
        public double C
        {
            get
            {
                return _c;
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
                        _c = value;
                    }
                }
                catch (ParameterException e)
                {
                    Console.WriteLine(e.Message);
                    double newValue = RetriveParameter();
                    _c = newValue;
                }
            }
        }

        public Triangle()
        {

        }
        public Triangle(double paramA, double paramB, double paramC) : base(paramA, paramB)
        {
            C = paramC;
        }
        public override double CalculateArea()
        {
            double result = ((_a + _b) * _c) / 2;
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = _a + _b + _c;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {_a} ,b = {_b}, c = {_c}" + GetAreaAndPerimeter();
        }
    }
}