using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.Simple
{
    public class ToLowerTransformation : ITextTransformation
    {
        public string Transform(string source) => source.ToLower();
    }
}
