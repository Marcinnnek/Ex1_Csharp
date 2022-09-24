using System.Xml;
using System.Xml.Serialization;


namespace Ex1_Csharp
{
    public class MyXmlSerializer<T1, T2> where T1 : new() //T1 Shapes, T2 Shape
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(T1));
        private XmlWriterSettings settings = new XmlWriterSettings();

        public MyXmlSerializer()
        {
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
        }

        public void SerialzieXml(string XMLlocation, T1 shapeList)
        {
            XmlWriter writer = XmlWriter.Create(XMLlocation, settings);
            serializer.Serialize(writer, shapeList);
            writer.Close();
        }
        public T1 DeserializeXml(string XMLlocation)
        {
            FileStream readFileStream = new FileStream(XMLlocation, FileMode.Open, FileAccess.Read, FileShare.Read);
            T1 deserilizer = (T1)serializer.Deserialize(readFileStream);
            return deserilizer;
        }
    }

    public static class GenerateTextFile
    {
        private static List<Type> types = new List<Type>();
        private static List<Type> tempTypes = new List<Type>();
        public static void SaveAsText(Shapes deserialziedXML, string filesLocation)
        {
            deserialziedXML.GetObjectTypes();

            foreach (var item in deserialziedXML.shape)
            {
                if (!tempTypes.Contains(item.GetType()))
                {
                    for (int i = 0; i < types.Count(); i++)
                    {
                        if (item.GetType().Name == types[i].Name)
                        {
                            using (StreamWriter sw = File.CreateText(filesLocation + item.GetType().Name + ".txt"))
                            {
                                tempTypes.Add(item.GetType());
                                Console.WriteLine($"Type: {item.type}"); //
                                sw.WriteLine($"Type: {item.type}"); //
                                var sublist = deserialziedXML.shape.Where(T => T.GetType().Name == types[i].Name);
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
        }

        private static void GetObjectTypes(this Shapes deserialziedXML)
        {
            foreach (var item in deserialziedXML.shape)
            {
                if (!types.Contains(item.GetType()))
                {
                    types.Add(item.GetType());
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TestMethod();
        }

        private static void TestMethod()
        {
            string xmllocation = @"D:\shapeTest.xml";
            string testFilelocation = @"D:\";

            Shapes shapesRoot = new Shapes();
            List<Shape> shapesList = new List<Shape>();

            shapesList.Add(new Circle(7));
            shapesList.Add(new Rectangle(5, 7));
            shapesList.Add(new Rectangle(23, 33));
            shapesList.Add(new Rectangle(15, 6));
            shapesList.Add(new Triangle(10, 5, 5));
            shapesList.Add(new Triangle(12, 5, 10));
            shapesList.Add(new Triangle(20, 35, 15));

            shapesRoot.shape = shapesList;

            try
            {
                MyXmlSerializer<Shapes, Shape> myXmlSerializer = new MyXmlSerializer<Shapes, Shape>();
                myXmlSerializer.SerialzieXml(xmllocation, shapesRoot);

                var deserialziedXML = myXmlSerializer.DeserializeXml(xmllocation);
                Console.WriteLine();

                GenerateTextFile.SaveAsText(deserialziedXML, testFilelocation);

                Console.WriteLine();
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine(e.Message);
            }
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
                    double newValue = 0;
                    bool result = false;
                    do
                    {
                        result = double.TryParse(Console.ReadLine(), out newValue);
                    } while (!result);
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
                    double newValue = 0;
                    bool result = false;
                    do
                    {
                        result = double.TryParse(Console.ReadLine(), out newValue);
                    } while (!result);
                    _b = newValue;
                }
            }
        }

        public Rectangle()
        {

        }
        public Rectangle(double paramB, double paramA) : base(paramA)
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
                    double newValue = 0;
                    bool result = false;
                    do
                    {
                        result = double.TryParse(Console.ReadLine(), out newValue);
                    } while (!result);
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