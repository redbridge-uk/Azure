using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Redbridge.Diagnostics.Tests
{
	[TestClass]
    public class TestDebugEventArgs
    {
        [TestMethod]
        public void ConstructDebugEventArgs()
        {
            var e = new DebugEventArgs("I am a debug message bringing bad tidings.");
            Assert.AreEqual("I am a debug message bringing bad tidings.", e.Message, "Unexpected debug message.");
        }
    }
}
