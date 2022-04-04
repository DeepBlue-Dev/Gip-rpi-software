using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Newtonsoft.Json;

namespace Configurations.Storage
{
    public class JsonParser
    {
        
        public T JsonToObject<T>([NotNull]string json) where T : IParsable
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T JsonToObjectEX<T>([NotNull]string json, T obj) where T : IParsable  //  EXPERIMENTAL
        {
            Console.WriteLine(String.Concat("json->obj ", JsonConvert.DeserializeObject<T>(json)));
            
             obj = JsonConvert.DeserializeObject<T>(json);
             if(obj is EmailConfiguration.EmailConfiguration)
            {
                (obj as EmailConfiguration.EmailConfiguration).Recipients.ForEach((recipient) => Console.Write($"{recipient}, "));
            }
            return obj;
        }

        public string ObjectToJson<T>([NotNull]T obj) where T : IParsable
        {
            Console.WriteLine(String.Concat("obj->json ",JsonConvert.SerializeObject(obj)));
            return JsonConvert.SerializeObject(obj);
            
        }
    }
}