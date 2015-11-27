using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Rubberduck.Katas.Network
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Ip4Address
    {
        [FieldOffset(0)] public byte Octet1;
        [FieldOffset(1)] public byte Octet2;
        [FieldOffset(2)] public byte Octet3;
        [FieldOffset(3)] public byte Octet4;

        /// <summary>
        /// Represents the Base Ten IPv4 address.
        /// </summary>
        /// <remarks>Overlays the Octet fields, so changing this value changes the Octets & vice versa.</remarks>
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [FieldOffset(0)] private UInt32 Address;

        /// <summary>
        /// Must be a valid IPv4 address.
        /// </summary>
        /// <param name="address"></param>
        public Ip4Address(string address)
            :this(address.Split('.').Select(a => Byte.Parse(a)).ToArray())
        { }

        /// <summary>
        /// Creates a new Ip4Address from a byte array.
        /// </summary>
        /// <param name="address">
        /// Must be an array of Length 4. 
        /// Index 0 is mapped to the first octet.
        /// </param>
        public Ip4Address(byte[] address)
            :this()
        {
            const int expectedLength = 4;

            if (address.Length != expectedLength)
            {
                throw new ArgumentException($"{nameof(address)} array must have a length of {expectedLength}.", nameof(address));
            }

            Octet1 = address[0];
            Octet2 = address[1];
            Octet3 = address[2];
            Octet4 = address[3];
        }

        /// <summary>
        /// Creates a new Ip4Address from it's base ten representation.
        /// </summary>
        /// <param name="address">Base ten representation of an IPv4 address. 
        /// UInt32.MaxValue results in an IP of "255.255.255.255".
        /// </param>
        public Ip4Address(UInt32 address)
            :this()
        {
            Address = address;
        }

        public override string ToString()
        {
            return $"{Octet1}.{Octet2}.{Octet3}.{Octet4}";
        }
    }
}
