using System.Xml;
using System.Xml.Serialization;


namespace Ex1_Csharp
{
    [XmlRoot(ElementName = "shapes")]
    public class Shapes
    {
        [XmlElement]
        public List<Shape> shape = new List<Shape>();
    }
}