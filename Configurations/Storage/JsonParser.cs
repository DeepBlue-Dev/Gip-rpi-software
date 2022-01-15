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

        public string ObjectToJson<T>([NotNull]T obj) where T : IParsable
        {
            return JsonConvert.SerializeObject(obj);
            
        }
    }
}