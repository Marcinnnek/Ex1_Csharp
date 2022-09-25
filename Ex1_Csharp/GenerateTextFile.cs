namespace Ex1_Csharp
{
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
}