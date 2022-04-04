using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Configurations.Storage;
using MailKit.Net;

namespace Configurations
{
    public class ConfigurationManager
    {
        private bool CheckIfConfigurationExists<T>(bool CreateFile, T obj) where T : IParsable, new()
        {
            if (!File.Exists(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName))){
                if (!CreateFile) { return false; }
                File.Create(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName));
                WriteConfig<T>(obj);
                return true;
            }
            return true;
        }
        //  writes a config to disk, if it doesnt exist, it will make a config file
        public void WriteConfig<T>([NotNull]T obj) where T : IParsable
        {
            JsonParser parser = new JsonParser();
            File.WriteAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName),parser.ObjectToJson(obj));
        }
        
        public T ReadConfig<T>(T obj) where T : IParsable
        {
            JsonParser parser = new JsonParser();
            return parser.JsonToObject<T>(
                File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)));
        }

        public T ReadConfigEX<T>(T obj) where T : IParsable,new()
        {
            if (!CheckIfConfigurationExists<T>(true, obj)) { throw new Exception("the config file did not exist"); }
            if(File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)) is null or "") { return new T(); }
            return new JsonParser().JsonToObjectEX(File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)), obj);
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