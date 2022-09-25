using Ex1_Csharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Csharp_Tests
{
    public class MyXmlDeserializerTests
    {
        [Fact]
        public void DeserializeObjectsTest()
        {
            //arrage
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = "XmlTestFile.xml";
            string xmlLocation = projectDirectory + @"\" + fileName;

            Shapes shapesRoot = new Shapes();
            List<Shape> shapesList = new List<Shape>();

            shapesList.Add(new Circle(7));
            shapesList.Add(new Rectangle(5, 7));
            shapesList.Add(new Triangle(10, 5, 5));
            shapesRoot.shape = shapesList;

            //act
            MyXmlSerializer<Shapes, Shape> myXmlSerializer = new MyXmlSerializer<Shapes, Shape>();
            var deserialziedXML = myXmlSerializer.DeserializeXml(xmlLocation);
            
            //assert
            Assert.Equal(shapesList.ElementAt(0).GetInfo(), deserialziedXML.shape.ElementAt(0).GetInfo());
            Assert.Equal(shapesList.ElementAt(1).GetInfo(), deserialziedXML.shape.ElementAt(1).GetInfo());
            Assert.Equal(shapesList.ElementAt(2).GetInfo(), deserialziedXML.shape.ElementAt(2).GetInfo());
        }

        public void SerializeObjectsTest()
        {
            //arrage
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string serializedFile = "XmlSerializedTestFile.xml";
            string deserializedFile = "XmlDeserialziedTestFile.xml";

            string xmlDeSerial = projectDirectory + @"\" + deserializedFile;
            string xmlSerial = projectDirectory + @"\" + serializedFile;
            Shapes shapesRoot = new Shapes();
            List<Shape> shapesList = new List<Shape>();

            shapesList.Add(new Circle(9));
            shapesList.Add(new Rectangle(14, 6));
            shapesList.Add(new Triangle(5, 12, 11));
            shapesRoot.shape = shapesList;

            //act
            MyXmlSerializer<Shapes, Shape> myXmlSerializer = new MyXmlSerializer<Shapes, Shape>();
            var deserialziedXML = myXmlSerializer.DeserializeXml(xmlDeSerial);
            myXmlSerializer.SerialzieXml(xmlSerial, shapesRoot);

            Console.WriteLine();
            //assert

        }
    }
}
