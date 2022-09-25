namespace Ex1_Csharp
{
   
    public class Program
    {
        static void Main(string[] args)
        {
            TestMethod();
        }

        private static void TestMethod()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = "XmlShapesFile.xml";

            string testFileLocation = projectDirectory + @"\\TextFiles\\";
            string xmlLocation = projectDirectory + @"\\" + fileName;
            
            Shapes shapesRoot = new Shapes();
            List<Shape> shapesList = new List<Shape>();

            shapesList.Add(new Circle(7));
            shapesList.Add(new Circle(25));
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
                myXmlSerializer.SerialzieXml(xmlLocation, shapesRoot);

                var deserialziedXML = myXmlSerializer.DeserializeXml(xmlLocation);
                Console.WriteLine();

                GenerateTextFile.SaveAsText(deserialziedXML, testFileLocation);

                Console.WriteLine();
            }
            catch (InvalidOperationException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}