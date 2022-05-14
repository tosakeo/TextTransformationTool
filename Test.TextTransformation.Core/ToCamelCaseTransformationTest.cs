using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextTransformationTool.Core;
using TextTransformationTool.Core.NamingCase;

namespace Test.TextTransformationTool.Core
{
    /// <summary>
    /// スネークケースからキャメルケースの変換処理テスト
    /// </summary>
    [TestClass]
    public class ToCamelCaseTransformationTest
    {
        [TestMethod]
        public void 正常＿単語一つ()
        {
            var snake = "test";

            var camel = Transform(snake);
            Assert.AreEqual("Test", camel); ;
        }

        [TestMethod]
        public void 正常＿単語二つ()
        {
            var snake = "test_case";

            var camel = Transform(snake);

            Assert.AreEqual("TestCase", camel);
        }

        [TestMethod]
        public void 正常＿大文字()
        {
            var snake = "TEST_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("TestCase", camel);
        }

        [TestMethod]
        public void 正常＿1文字単語含む()
        {
            var snake = "TEST_A_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("TestACase", camel);
        }

        [TestMethod]
        public void 正常＿数字含む()
        {
            var snake = "TEST_123_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("Test123Case", camel);
        }

        /// <summary>
        /// スネークケースからキャメルケースへの変換処理を行います。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private string Transform(string source)
        {
            var transformation = new ToPascalCaseTransformation();
           return transformation.Transform(source);

        }


    }
}