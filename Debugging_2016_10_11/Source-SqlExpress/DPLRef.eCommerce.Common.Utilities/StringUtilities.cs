using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;

namespace DPLRef.eCommerce.Common.Utilities
{
    public static class StringUtilities
    {
        public static string DataContractToXml<T>(T dataContract)
        {
            using (var memoryStream = new MemoryStream())
            using (var memoryStreamReader = new StreamReader(memoryStream))
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, dataContract);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return memoryStreamReader.ReadToEnd();
            }
        }

        public static string DataContractToJson<T>(T dataContract)
        {
            return JsonConvert.SerializeObject(dataContract, Formatting.Indented);
        }
    }
}
