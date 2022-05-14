using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.NamingCase
{
    /// <summary>
    /// スネークケースからキャメルケースの変換処理
    /// </summary>
    public class ToCamelCaseTransformation : ITextTransformation
    {
        private readonly ToPascalCaseTransformation _toPascalCase = new ToPascalCaseTransformation();

        /// <summary>
        /// 変換処理を行います。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string Transform(string source)
        {
            var pascal = _toPascalCase.Transform(source);
            return KeepLines.Transform(pascal, line => ToLowerFirst(line));
        }

        private static string ToLowerFirst(string line)
        {
            if (string.IsNullOrEmpty(line))
                return "";

            if (line.Length == 1)
                return line.ToLower();

            return
                line.Substring(0, 1).ToLower()
                + line.Substring(1);
            ;
        }
    }
}
