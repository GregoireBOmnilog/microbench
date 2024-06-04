using System.Diagnostics;

namespace PerfTestConsole.Snippets
{
    internal class Jsonning : Snippet
    {
        public override IEnumerable<SnippetTimer> RunSnippet()
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(new { name = "John", age = 42 });
                var deserialized = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            }

            sw.Stop();

            return new List<SnippetTimer> { new("1000x System.Text.Json.JsonSerializer", sw.ElapsedMilliseconds) };
        }
    }
}
