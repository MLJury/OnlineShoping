using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoping.Utils
{
    class ObjectSerializer : IObjectSerializer
    {
        public T Deserialize<T>(string serializedValue)
            => JsonConvert.DeserializeObject<T>(serializedValue);

        public string Serialize(object obj, string ignoreFirstNodeContainTitle = default)
        {
            string serializedString = JsonConvert.SerializeObject(obj, Formatting.None,
                                                                new JsonSerializerSettings()
                                                                {
                                                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                                });

            if (ignoreFirstNodeContainTitle != null 
                && ignoreFirstNodeContainTitle != string.Empty)
            {
                JObject jObj = JObject.Parse(serializedString);
                var listProperties = jObj
                                        .Properties()
                                        .Where(w => w.Name.Contains(ignoreFirstNodeContainTitle))
                                        .Select(s => s.Name)
                                        .ToList();

                var fafa = jObj.ToString();
                foreach (var item in listProperties)
                {
                    jObj.Remove(item);
                }

                serializedString = jObj.ToString();
            }

            return serializedString;
        }

        public string GetValueByKey(string serializedObj, string key)
        {
            JObject jObj = JObject.Parse(serializedObj);
            var result = (string)jObj
                            .Properties()
                            .Where(w => w.Name == key)
                            .FirstOrDefault()
                            .Value;
            return result;
        }

        public T ConverObj<T, W>(W obj)
        {
            var serializedObj = Serialize(obj);
            return this.Deserialize<T>(serializedObj);
        }
    }
}