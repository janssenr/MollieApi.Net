using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class MethodTest
    {
        [TestMethod]
        public void TestIssuersNullWorks()
        {
            var method = new Method();
            Assert.IsNull(method.Issuers);

            //var issuers = method.Issuers();

            //Assert.IsInstanceOfType(issuers, typeof(IssuerCollection));
            //Assert.AreEqual(0, issuers.Count);
        }
    }
}
