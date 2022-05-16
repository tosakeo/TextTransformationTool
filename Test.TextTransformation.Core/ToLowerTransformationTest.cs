using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextTransformationTool.Core;
using TextTransformationTool.Core.Simple;

namespace Test.TextTransformationTool.Core
{
    /// <summary>
    /// スネークケースからキャメルケースの変換処理テスト
    /// </summary>
    [TestClass]
    public class ToLowerTransformationTest
    {
        [TestMethod]
        public void 小文字化()
        {
            var camel = "TEST";
            var snake = Transform(camel);
            Assert.AreEqual("test", snake);
        }

        [TestMethod]
        public void 英字以外()
        {
            var camel = "123,./";
            var snake = Transform(camel);
            Assert.AreEqual("123,./", snake);
        }

        private string Transform(string source)
        {
            var transformation = new ToLowerTransformation();
            return transformation.Transform(source);

        }
    }
}
