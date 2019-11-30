using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Dynamic;

namespace ServiceProxy.Tests
{
    [TestClass]
    public class ServiceProxy_Should
    {
        [TestMethod]
        public void Call_Member()
        {
            dynamic c = new ExpandoObject();
            c.Add = (Func<int, int, int>)((a, c) => a + c);

            ICalculator proxy = Proxy.Create<ICalculator>(c);
            Assert.AreEqual(3, proxy.Add(1, 2));
        }
    }

    public interface ICalculator
    {
        int Add(int a, int b);
    }
}
