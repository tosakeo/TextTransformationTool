using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformationTool.Core.NamingCase
{
    /// <summary>
    /// スネークケースからパスカルケースの変換処理
    /// </summary>
    public class ToPascalCaseTransformation : ITextTransformation
    {
        /// <summary>
        /// 変換処理を行います。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string Transform(string source)
        {
            return KeepLines.Transform(source, TransformLine);
        }

        private string TransformLine(string line)
        {
            var words = SplitIntoWards(line);
            return WordsToCamelCase(words);
        }

        private static IEnumerable<string> SplitIntoWards(string snakeWords)
        {
            return snakeWords.Split('_').Select(x => x.ToLower());
        }

        private static string WordsToCamelCase(IEnumerable<string> words)
        {
            var wordsWithUpperFirst = words.Select(x => ToUpperFirst(x));
            return string.Concat(wordsWithUpperFirst);
        }

        private static string ToUpperFirst(string word)
        {
            if (string.IsNullOrEmpty(word)) 
                return "";
            
            if (word.Length == 1) 
                return word.ToUpper();

            return
                word.Substring(0, 1).ToUpper()
                + word.Substring(1).ToLower();
                ;
        }
    }
}
