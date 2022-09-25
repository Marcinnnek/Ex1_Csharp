using System.Xml.Serialization;


namespace Ex1_Csharp
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    public abstract class Shape
    {
        public string type;
        public Shape()
        {

            type = GetType().Name;
            Console.WriteLine(type);
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        internal string GetAreaAndPerimeter()
        {
            return $", area = {CalculateArea():F2}, preimeter = {CalculatePerimeter():F2}";
        }
        public abstract string GetInfo();

        internal static double RetriveParameter()
        {
            double newValue = 0;
            bool result = false;
            do
            {
                result = double.TryParse(Console.ReadLine(), out newValue);
            } while (!result);
            return newValue;
        }
    }
}