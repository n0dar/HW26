namespace HW26.Serializers
{
    public interface IMySerialize
    {
        string Serialize<T>(T obj);
        T? Deserialize<T>(string str) where T : new();
    }
}
