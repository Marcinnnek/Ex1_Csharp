using System.Xml;
using System.IO;
using System.Xml.Serialization;


namespace Ex1_Csharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Shapes shapes = new Shapes();
            List<Shape> shapesList = new List<Shape>()
            {
                new Circle(){a=4},
                new Rectangle(){a=5,b=7},
                new Rectangle(){a=23,b=33},
                new Rectangle(){a=15,b=6},
                new Triangle(){a=10,b=5,c=5},
                new Triangle(){a=12,b=5,c=10},

            };


            shapes.shape = shapesList;

            XmlSerializer serializer = new XmlSerializer(typeof(Shapes));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(@"D:\shapeTest.xml", settings);
            serializer.Serialize(writer, shapes);
            writer.Close();

            FileStream readFileStream = new FileStream(@"D:\shapeTest.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Shapes deserilizer = (Shapes)serializer.Deserialize(readFileStream);
            int objCount = deserilizer.shape.OfType<Triangle>().Count();


            Console.WriteLine();

            List<Type> types = new List<Type>();
            foreach (var item in deserilizer.shape)
            {
                if (!types.Contains(item.GetType()))
                {
                    types.Add(item.GetType());
                }
            }

            List<Type> tempTypes = new List<Type>();

            foreach (var item in deserilizer.shape)
            {
                if (!tempTypes.Contains(item.GetType()))
                {
                    for (int i = 0; i < types.Count(); i++)
                    {
                        if (item.GetType().Name == types[i].Name)
                        {
                            using (StreamWriter sw = File.CreateText(@"D:\" + item.GetType().Name + ".txt"))
                            {
                                tempTypes.Add(item.GetType());
                                Console.WriteLine($"Type: {item.type}"); //
                                sw.WriteLine($"Type: {item.type}"); //
                                var sublist = deserilizer.shape.Where(T => T.GetType().Name == types[i].Name);
                                Console.WriteLine($"Number of records: {sublist.Count()}");//
                                sw.WriteLine($"Number of records: {sublist.Count()}");//
                                foreach (var obj in sublist)
                                {
                                    Console.WriteLine(obj.GetInfo());//
                                    sw.WriteLine(obj.GetInfo());//
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }


    [XmlRoot(ElementName = "shapes")]
    public class Shapes
    {
        [XmlElement]
        public List<Shape> shape = new List<Shape>();
    }



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
        public string GetAreaAndPerimeter()
        {
            return $", area = {CalculateArea():F2}, preimeter = {CalculatePerimeter():F2};";
        }
        public abstract string GetInfo();
    }
    public class Circle : Shape
    {
        public double a;

        public override double CalculateArea()
        {
            double result = Math.PI * Math.Pow(a, 2);
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = 2 * Math.PI * a;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {a}" + GetAreaAndPerimeter();
        }
    }
    public class Rectangle : Circle
    {
        public double b;
        public override double CalculateArea()
        {
            double result = a * b;
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = 2 * a + 2 * b;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {a} ,b = {b}" + GetAreaAndPerimeter();
        }
    }

    public class Triangle : Rectangle
    {
        public double c;
        public override double CalculateArea()
        {
            double result = ((a + b) * c) / 2;
            return result;
        }
        public override double CalculatePerimeter()
        {
            double result = a + b + c;
            return result;
        }
        public override string GetInfo()
        {
            return $"a = {a} ,b = {b}, c = {c}" + GetAreaAndPerimeter();
        }
    }
}