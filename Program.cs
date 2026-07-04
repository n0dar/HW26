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



            //// Вывод итогового отчета для преподавателя
            //Console.WriteLine("\n================ ОТЧЕТ ДЛЯ ЧАТА ================");
            //Console.WriteLine("Сериализуемый класс: class F { public int i1, i2, i3, i4, i5; }");
            //Console.WriteLine($"Среда разработки: Visual Studio 2022 / .NET 8.0");
            //Console.WriteLine($"Количество замеров: {iterations} итераций");
            //Console.WriteLine($"Время на вывод текста в консоль: {swConsole.ElapsedMilliseconds} мс");
            //Console.WriteLine();
            //Console.WriteLine("Мой рефлекшен (CSV):");
            //Console.WriteLine($"Время на сериализацию = {customSerializeTime} мс");
            //Console.WriteLine($"Время на десериализацию = {customDeserializeTime} мс");
            //Console.WriteLine();
            //Console.WriteLine("Стандартный механизм (System.Text.Json):");
            //Console.WriteLine($"Время на сериализацию = {standardSerializeTime} мс");
            //Console.WriteLine($"Время на десериализацию = {standardDeserializeTime} мс");
            //Console.WriteLine("=================================================");

        }
    }
}
