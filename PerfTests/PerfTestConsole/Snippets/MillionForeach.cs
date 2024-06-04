using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfTestConsole.Snippets
{
    public class MillionForeach : Snippet
    {
        public override IEnumerable<SnippetTimer> RunSnippet()
        {
            var list1 = Enumerable.Range(0, 1000).Select(i => new MyInt(i));
            var list2 = Enumerable.Range(0, 1000).Select(i => new MyInt(i));

            var listIntermediary = new List<int>();
            var listRes = new List<MyInt>();
            var sw = Stopwatch.StartNew();

            foreach (var i in list1)
            {
                foreach (var i2 in list2)
                {
                    listIntermediary.Add(i.v + i2.v);
                }
            }

            checkpoints.Add(new SnippetTimer("1000 * 1000 adds in nested foreaches", sw.ElapsedMilliseconds));
            var ellapsedBeforeSelect = sw.ElapsedMilliseconds;

            listRes = listIntermediary.Select(r => new MyInt(r)).ToList();

            checkpoints.Add(new SnippetTimer("1000 * 1000 select with new record", sw.ElapsedMilliseconds - ellapsedBeforeSelect));

            return checkpoints;
        }
    }
}
