using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextTransformationTool.Core;
using TextTransformationTool.Core.NamingCase;

namespace Test.TextTransformationTool.Core
{
    /// <summary>
    /// �X�l�[�N�P�[�X����L�������P�[�X�̕ϊ������e�X�g
    /// </summary>
    [TestClass]
    public class ToCamelCaseTransformationTest
    {
        [TestMethod]
        public void ����Q�P����()
        {
            var snake = "test";

            var camel = Transform(snake);
            Assert.AreEqual("Test", camel); ;
        }

        [TestMethod]
        public void ����Q�P����()
        {
            var snake = "test_case";

            var camel = Transform(snake);

            Assert.AreEqual("TestCase", camel);
        }

        [TestMethod]
        public void ����Q�啶��()
        {
            var snake = "TEST_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("TestCase", camel);
        }

        [TestMethod]
        public void ����Q1�����P��܂�()
        {
            var snake = "TEST_A_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("TestACase", camel);
        }

        [TestMethod]
        public void ����Q�����܂�()
        {
            var snake = "TEST_123_CASE";

            var camel = Transform(snake);

            Assert.AreEqual("Test123Case", camel);
        }

        /// <summary>
        /// �X�l�[�N�P�[�X����L�������P�[�X�ւ̕ϊ��������s���܂��B
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