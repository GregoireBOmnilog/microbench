// See https://aka.ms/new-console-template for more information
using PerfTestConsole;
using PerfTestConsole.Snippets;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

SnippetRunner runner = new();

runner
    .Run(new MillionForeach(), 15)
    .ToList()
    .ForEach(r => Console.WriteLine($"{r.name} : {r.averageMs}ms"));

runner
    .Run(new Jsonning(), 15)
    .ToList()
    .ForEach(r => Console.WriteLine($"{r.name} : {r.averageMs}ms"));


//test_foreach_with_select_and_records(15);

//test_exception_time(15);

Console.WriteLine("END");
Console.ReadLine();

void test_exception_time(int v)
{
    for (int i = 0; i < 10; i++)
    {
        forEachException();
    }
}



void forEachInForEachWithRecordAlloc(int someInt)
{

}

void forEachException()
{
    int nbIter = 100;
    var sw = Stopwatch.StartNew();

    for (int i = 0; i < nbIter; i++)
    {
        try
        {
            throw new Exception(i.ToString());
        }
        catch (Exception e) { }
    }

    var ellapsedMs = sw.ElapsedMilliseconds;

    Console.WriteLine($"Took {ellapsedMs}ms for a count of {nbIter} exceptions thrown and caught.");
}

public record MyInt(int v);
