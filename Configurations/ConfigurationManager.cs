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
            if (!File.Exists(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName))){  //  check if file exists
                if (!CreateFile) { return false; }  //  programmer said not to create a new file
                File.Create(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName));    //  create file
                WriteConfig<T>(obj);    //  write object to file;
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
            return new JsonParser().JsonToObject<T>(File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)));
        }

        public T ReadConfigEX<T>(T obj) where T : IParsable,new()
        {
            if (!CheckIfConfigurationExists<T>(true, obj)) { throw new Exception("config file not found"); }    //  check if config exists, if not create file, if that fails generate exception
            string text = File.ReadAllText(String.Concat(StorageConfig.ConfigBasePath, obj.ConfigurationFileName)); //  fetch contents of file
            if ( text is null or "") { return new T(); }  //  return new empty instance of T when the config file is not found
            return new JsonParser().JsonToObjectEX(text, obj);
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