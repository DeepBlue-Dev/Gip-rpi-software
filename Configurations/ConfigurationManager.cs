using System.IO;
using Configurations.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Configurations
{
    public class ConfigurationManager
    {
        //  writes a config to disk, if it doesnt exist, it will make a config file
        public void WriteConfig<T>([NotNull]T obj) where T : IParsable
        {
            JsonParser parser = new JsonParser();
            File.WriteAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName),parser.ObjectToJson(obj));
        }
        
        //  TODO, test this function, since this could allow a safer and easier way to read configs from file without fucking names up
        public T ReadConfig<T>(T obj) where T : IParsable
        {
            JsonParser parser = new JsonParser();
            return parser.JsonToObject<T>(
                File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)));
        }

        public T ReadConfig<T>([NotNull] string configurationFileName) where T : IParsable
        {
            JsonParser parser = new JsonParser();
            return parser.JsonToObject<T>(File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, configurationFileName)));
        }

        public List<string> ListAllConfigs()
        {
            List<string> configs = Directory.GetFiles(StorageConfig.ConfigBasePath).ToList();
            return configs;
        }

        public void DeleteConfig<T>([NotNull]T obj) where T : IParsable
        {
            File.Delete(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName));
        }

        public void DeleteConfig([NotNull]string configName)
        {
            File.Delete(String.Concat(StorageConfig.ConfigBasePath, configName));
        }
        
    }
}