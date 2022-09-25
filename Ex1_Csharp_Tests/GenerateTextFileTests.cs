using Ex1_Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Csharp_Tests
{
    public class GenerateTextFileTests
    {
        [Fact]
        public void SaveAsTextTest()
        {
            //arrage
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = "XmlToTextFile.xml";
            string xmlFile = projectDirectory + @"\" + fileName;
            string testFileLocation = projectDirectory + @"\\TextFiles\\";

            Shapes shapesRoot = new Shapes();
            List<Shape> shapesList = new List<Shape>();

            shapesList.Add(new Circle(7));
            shapesList.Add(new Rectangle(15, 6));
            shapesList.Add(new Triangle(12, 5, 10));

            shapesRoot.shape = shapesList;

            string expectedCircle = "Type: Circle\r\nNumber of records: 1\r\na = 7, area = 153,94, preimeter = 43,98\r\n";
            string expectedRectangle = "Type: Rectangle\r\nNumber of records: 1\r\na = 15 ,b = 6, area = 90,00, preimeter = 42,00\r\n";
            string expectedTriangle = "Type: Triangle\r\nNumber of records: 1\r\na = 12 ,b = 5, c = 10, area = 85,00, preimeter = 27,00\r\n";

            MyXmlSerializer<Shapes, Shape> myXmlSerializer = new MyXmlSerializer<Shapes, Shape>();
            myXmlSerializer.SerialzieXml(xmlFile, shapesRoot);

            var deserialziedXML = myXmlSerializer.DeserializeXml(xmlFile);

            GenerateTextFile.SaveAsText(deserialziedXML, testFileLocation);

            string currentCircle = System.IO.File.ReadAllText(testFileLocation + @"\" + "Circle.txt");
            string currentRectangle = System.IO.File.ReadAllText(testFileLocation + @"\" + "Rectangle.txt");
            string currentTriangle = System.IO.File.ReadAllText(testFileLocation + @"\" + "Triangle.txt");

            Assert.Equal(expectedCircle, currentCircle);
            Assert.Equal(expectedRectangle, currentRectangle);
            Assert.Equal(expectedTriangle, currentTriangle);

        }
    }
}
