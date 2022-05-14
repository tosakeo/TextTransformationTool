using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextTransformationTool.Core;
using TextTransformationTool.Core.NamingCase;

namespace Test.TextTransformationTool.Core
{
    /// <summary>
    /// スネークケースからキャメルケースの変換処理テスト
    /// </summary>
    [TestClass]
    public class ToLowerSnakeCaseTransformationTest
    {
        [TestMethod]
        public void 一単語()
        {
            var camel = "Test";
            var snake = Transform(camel);
            Assert.AreEqual("test", snake);
        }

        [TestMethod]
        public void 二単語()
        {
            var camel = "TestCase";
            var snake = Transform(camel);
            Assert.AreEqual("test_case", snake);
        }

        [TestMethod]
        public void 一語単語含む()
        {
            var camel = "TestACase";
            var snake = Transform(camel);
            Assert.AreEqual("test_a_case", snake);
        }

        [TestMethod]
        public void 数字含む()
        {
            var camel = "Test123Case";
            var snake = Transform(camel);
            Assert.AreEqual("test_123_case", snake);
        }


        [TestMethod]
        public void 複数行()
        {
            var camel = 
@"Test123
CaseAaa";
            var snake = Transform(camel);
            var expect =
@"test_123
case_aaa";
            Assert.AreEqual(expect, snake);
        }

        private string Transform(string source)
        {
            var transformation = new ToLowerSnakeCaseTransformation();
            return transformation.Transform(source);

        }
    }
}
