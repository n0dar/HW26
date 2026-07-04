using System.Text.Json;

namespace HW26.Serializers
{
    internal class JSONSerializer : IMySerialize
    {
        T? IMySerialize.Deserialize<T>(string str) where T : default
        {
            return JsonSerializer.Deserialize<T>(str);
        }

        string IMySerialize.Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
