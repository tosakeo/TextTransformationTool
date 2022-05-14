using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.NamingCase
{
    internal class KeepLines
    {
        public static string Transform(string source, Func<string, string> transformLine)
        {
            var lines = new List<string>();
            foreach (var line in SplitLines(source))
            {
                lines.Add(transformLine(line));
            }
            return string.Join(Environment.NewLine, lines);
        }

        private static IEnumerable<string> SplitLines(string source)
        {
            return source.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
                );
        }
    }
}
