using System.IO;
using System.Xml.Serialization;

namespace Assets
{
    public static class Helper
    {
        public static string Serialize<T>(this T toSerialize)
        {
            var xml = new XmlSerializer(typeof(T));
            var writer = new StringWriter();

            xml.Serialize(writer, toSerialize);

            return writer.ToString();
        }

        public static T Deserialize<T>(this string toDeserialize)
        {
            var xml = new XmlSerializer(typeof(T));
            var reader = new StringReader(toDeserialize);
            return (T) xml.Deserialize(reader);
        }
    }
}