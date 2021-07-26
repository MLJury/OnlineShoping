using System.Collections.Generic;

namespace OnlineShoping.Utils
{
    public interface IObjectSerializer
    {
        string Serialize(object obj, string ignoreFirstNodeContainTitle = default);
        T Deserialize<T>(string serializedValue);
        string GetValueByKey(string serializedObj, string key);
        T ConverObj<T, W>(W obj);
    }
}
