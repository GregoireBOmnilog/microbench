namespace PerfTestConsole
{
    public record SnippetTimer(string name, long ms);
    public abstract class Snippet
    {
        protected List<SnippetTimer> checkpoints = new();

        public abstract IEnumerable<SnippetTimer> RunSnippet();
    }
}
