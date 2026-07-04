using HW26.Serializers;
using HW26.Tests;

namespace HW26
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"ОС: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
            Console.WriteLine($"Платформа: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"Процессор: {Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")} ({Environment.ProcessorCount} логических ядер)");
            Console.WriteLine($"Оперативная память: {(double)GC.GetGCMemoryInfo().TotalAvailableMemoryBytes / (1024 * 1024 * 1024):F2} ГБ");

            const int iterations = 10000;
            Console.WriteLine($"\nКоличество замеров: {iterations} итераций");
            F testObject = F.Get();

            Console.WriteLine("\nМой рефлекшен:");
            Test<F> test = new(new CSVSerializer(), iterations);
            test.Deserialize(test.Serialize(testObject));

            Console.WriteLine("\nСтандартный механизм (System.Text.Json):");
            test = new(new JSONSerializer(), iterations);
            test.Deserialize(test.Serialize(testObject));
        }
    }
}
