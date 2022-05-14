using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextTransformationTool.Core.Compound;
using TextTransformationTool.Core.NamingCase;
using TextTransformationTool.Core.Simple;

namespace TextTransformationTool.Core
{
    public class TextTransformationFactory
    {
        public ITextTransformation Create(TextTransformationMode mode)
        {
            switch (mode)
            {
                case TextTransformationMode.ToLower:
                    return new ToLowerTransformation();

                case TextTransformationMode.ToUpper:
                    return new ToUpperTransformation();

                case TextTransformationMode.ToCamelCase:
                    return new ToCamelCaseTransformation();

                case TextTransformationMode.ToPascalCase:
                    return new ToPascalCaseTransformation();

                case TextTransformationMode.ToLowerSnakeCase:
                    return new ToLowerSnakeCaseTransformation();

                case TextTransformationMode.ToUpperSnakeCase:
                    return new CompoundTransformation(
                        new ToLowerSnakeCaseTransformation(),
                        new ToUpperTransformation()
                        );

                default:
                    throw new ArgumentException("Invalid mode");
            }
        }
    }
}
