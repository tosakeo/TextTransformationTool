using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.NamingCase
{
    public class ToLowerSnakeCaseTransformation : ITextTransformation
    {

        public string Transform(string source)
        {
            return KeepLines.Transform(source, TransformLine);
        }

        private string TransformLine(string line)
        {
            var parser = new CamelCaseWordsParser(line);
            var words = parser.Parse();
            return String.Join('_', words);
        }
    }
}
