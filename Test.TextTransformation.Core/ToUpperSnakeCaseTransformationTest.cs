using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextTransformationTool.Core;
using TextTransformationTool.Core.Compound;
using TextTransformationTool.Core.Simple;
using TextTransformationTool.Core.NamingCase;

namespace Test.TextTransformationTool.Core
{
    /// <summary>
    /// スネークケースからキャメルケースの変換処理テスト
    /// </summary>
    [TestClass]
    public class ToUpperSnakeCaseTransformationTest
    {
        [TestMethod]
        public void 一単語()
        {
            var camel = "Test";
            var snake = Transform(camel);
            Assert.AreEqual("TEST", snake);
        }

        [TestMethod]
        public void 二単語()
        {
            var camel = "TestCase";
            var snake = Transform(camel);
            Assert.AreEqual("TEST_CASE", snake);
        }

        [TestMethod]
        public void 一語単語含む()
        {
            var camel = "TestACase";
            var snake = Transform(camel);
            Assert.AreEqual("TEST_A_CASE", snake);
        }

        [TestMethod]
        public void 数字含む()
        {
            var camel = "Test123Case";
            var snake = Transform(camel);
            Assert.AreEqual("TEST_123_CASE", snake);
        }


        [TestMethod]
        public void 複数行()
        {
            var camel = 
@"Test123
CaseAaa";
            var snake = Transform(camel);
            var expect =
@"TEST_123
CASE_AAA";
            Assert.AreEqual(expect, snake);
        }

        private string Transform(string source)
        {
            var transformation = new CompoundTransformation(
                new ToLowerSnakeCaseTransformation(),
                new ToUpperTransformation()
                );
            return transformation.Transform(source);

        }
    }
}
