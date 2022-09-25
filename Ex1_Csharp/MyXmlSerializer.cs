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
}