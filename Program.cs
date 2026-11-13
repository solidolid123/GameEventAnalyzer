using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;

namespace Variant11;

internal static class Program
{
    private static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Зачётный проект 11: Анализатор игровых событий");
        Console.WriteLine(new string('=', 64));

        // Стартовый сценарий нужен для проверки структуры проекта.
        // Реализацию индивидуальных требований выполняйте в ProjectService.
        var service = new ProjectService();
        await service.RunAsync();

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для завершения.");
        Console.ReadLine();
    }
}

public sealed class ProjectService
{
    public async Task RunAsync()
    {
        // TODO: перенесите предметную логику в отдельные методы и классы.
        // TODO: не размещайте весь проект в Main.
        // TODO 1: Создать модель игрового события.
        // TODO 2: Сгенерировать тестовые события с фиксированным seed.
        // TODO 3: Реализовать последовательную статистику через LINQ.
        // TODO 4: Реализовать эквивалентную статистику через PLINQ.
        // TODO 5: Сохранить порядок результатов там, где он требуется, используя AsOrdered или OrderBy.
        // TODO 6: Сравнить результаты LINQ и PLINQ на одинаковых данных.
        // TODO 7: Измерить производительность на нескольких размерах коллекции.

        // TODO 8: Добавить Aggregate с локальным аккумулятором.
        // TODO 9: Добавить стабильную сортировку с ThenBy.
        // TODO 10: Проверить пустую коллекцию и отсутствие событий нужного типа.

        Console.WriteLine("Стартовый проект собран. Реализуйте задания варианта.");
        await Task.CompletedTask;
    }
}
