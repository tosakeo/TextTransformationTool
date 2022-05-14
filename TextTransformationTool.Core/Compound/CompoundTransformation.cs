using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.Compound
{
    public class CompoundTransformation : ITextTransformation
    {
        private readonly ITextTransformation[] _transformations;

        public CompoundTransformation(params ITextTransformation[] transformations) 
            => _transformations = transformations;

        public string Transform(string source)
        {
            var result = source;
            foreach (var transformation in _transformations)
            {
                result = transformation.Transform(result);
            }
            return result;
        }
    }
}
