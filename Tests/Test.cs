using HW26.Serializers;
using System.Diagnostics;

namespace HW26.Tests
{
    public class Test<T>(IMySerialize serializer, int iterations) where T : new()
    {
        private readonly IMySerialize _serializer = serializer;
        private readonly int _iterations = iterations;
        public string Serialize(T obj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < _iterations; i++)
            {
                _serializer.Serialize(obj);
            }
            sw.Stop();
            string res = _serializer.Serialize(obj);
            Console.WriteLine($"полученная строка\n{res}");
            Console.WriteLine($"Время на сериализацию = {sw.ElapsedMilliseconds} мс");
            return res;
        }
        public void Deserialize(string str)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < _iterations; i++)
            {
                _ = _serializer.Deserialize<T>(str);
            }
            sw.Stop();
            Console.WriteLine($"Время на десериализацию = {sw.ElapsedMilliseconds} мс");
        }
    }
}
