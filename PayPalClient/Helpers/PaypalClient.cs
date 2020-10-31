using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using PayPalCheckoutSdk.Core;
using PayPalHttp;

namespace PayPalClient.Helpers
{
    public class PayPalClient
    {
        private static PayPalEnvironment environment;
        public static void SetEnvironment(string clientID, string clientSecret, bool SandBox = true)
        {
            if (SandBox) environment = new SandboxEnvironment(clientID, clientSecret);
            else environment = new LiveEnvironment(clientID, clientSecret);
        }

        internal static void SetEnvironment(string clientID, string clientSecretID, object sandBox)
        {
            throw new NotImplementedException();
        }

        public static HttpClient client()
        {
            return new PayPalHttpClient(environment);
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment, refreshToken);
        }
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                        memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
