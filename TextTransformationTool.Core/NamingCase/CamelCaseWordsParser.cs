namespace TextTransformationTool.Core.NamingCase
{
    /// <summary>
    /// キャメルケース文字列を単語ごとに分解するクラス
    /// </summary>
    class CamelCaseWordsParser
    {
        private readonly string _camelCaseWords;

        private int _currentIndex = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="camelCaseWords">キャメルケース文字列</param>
        public CamelCaseWordsParser(string camelCaseWords)
        {
            _camelCaseWords = camelCaseWords;
        }

        /// <summary>
        /// 単語単位に分解します。
        /// </summary>
        /// <returns>単語のリスト</returns>
        public IEnumerable<string> Parse()
        {
            while(true)
            {
                var word = GetNextWord();
                if (word.Length == 0)
                    yield break;

                yield return word;
            }
        }

        /// <summary>
        /// 次の単語を取得します。
        /// </summary>
        /// <returns>次の単語。無い場合は空文字。</returns>
        private string GetNextWord()
        {
            if (_camelCaseWords.Length <= _currentIndex)
                return "";

            var length = 0;
            var startIndex = _currentIndex;

            while(true)
            {
                length++;
                var nextIndex = startIndex + length;
                if (!IsEndOfWords(nextIndex) 
                    && !IsStartNextWord(nextIndex))
                {
                    continue;
                }

                _currentIndex += length;
                return _camelCaseWords.Substring(startIndex, length).ToLower();
            }
        }

        /// <summary>
        /// これ以上単語がないか判定します。
        /// </summary>
        /// <param name="nextIndex">次の文字のindex</param>
        /// <returns>true: これ以上単語がない</returns>
        private bool IsEndOfWords(int nextIndex)
        {
            return nextIndex >= _camelCaseWords.Length;
        }

        /// <summary>
        /// 次の単語の開始位置であるか判定します。
        /// </summary>
        /// <param name="nextIndex">次の文字のindex</param>
        /// <returns>true: 次の単語の開始位置である</returns>
        private bool IsStartNextWord(int nextIndex)
        {
            // 次の文字が大文字であるか、次の文字と現在の単語の文字とでアルファベットと数字等の種類の不一致がある場合は、次の単語とする。
            var nextChar = _camelCaseWords[nextIndex];
            if (char.IsUpper(_camelCaseWords[nextIndex]))
                return true;

            var currentChar = _camelCaseWords[nextIndex - 1];
            if (char.IsLetter(nextChar) != char.IsLetter(currentChar))
                return true;

            return false;
        }
    }
}
