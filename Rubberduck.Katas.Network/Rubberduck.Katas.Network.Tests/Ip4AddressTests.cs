using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rubberduck.Katas.Network.Tests
{
    [TestClass]
    public class Ip4AddressTests
    {
        [TestMethod]
        public void CanCreateFromString()
        {
            Ip4Address ip = new Ip4Address("192.10.1.1");

            Assert.AreEqual(192, ip.Octet1);
            Assert.AreEqual(10, ip.Octet2);
            Assert.AreEqual(1, ip.Octet3);
            Assert.AreEqual(1, ip.Octet4);
        }

        [TestMethod]
        public void CanCreateFromByteArray()
        {
            Ip4Address ip = new Ip4Address(new byte[] {192, 10, 1, 1});

            Assert.AreEqual(192, ip.Octet1);
            Assert.AreEqual(10, ip.Octet2);
            Assert.AreEqual(1, ip.Octet3);
            Assert.AreEqual(1, ip.Octet4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ByteArrayLengthCannotBeLessThan4()
        {
            var ip = new Ip4Address(new byte[] {});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ByteArrayLengthCannotBeGreaterThan4()
        {
            var ip = new Ip4Address(new byte[] {1, 1, 1, 1, 1});
        }

        [TestMethod]
        public void CanCreateFromBaseTenAddress()
        {
            //i.e. can create from an integer.
            var ip = new Ip4Address(UInt32.MaxValue); //0xFFFFFFFF

            Assert.AreEqual(255, ip.Octet1);
            Assert.AreEqual(255, ip.Octet2);
            Assert.AreEqual(255, ip.Octet3);
            Assert.AreEqual(255, ip.Octet4);
        }

        [TestMethod]
        public void ToStringReturnsExpectedResult()
        {
            var ip = new Ip4Address(new byte[] {10, 10, 1, 1});

            Assert.AreEqual("10.10.1.1", ip.ToString());
        }
    }
}
