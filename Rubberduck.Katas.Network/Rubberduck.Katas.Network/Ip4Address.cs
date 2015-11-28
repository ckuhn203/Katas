using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Rubberduck.Katas.Network
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Ip4Address : IEquatable<Ip4Address>, IComparable<Ip4Address>
    {
        /// <summary>
        /// Represents the Base Ten IPv4 address as a raw integer.
        /// </summary>
        /// <remarks>Overlays the Octet fields, so changing this value changes the Octets & vice versa.</remarks>
        [FieldOffset(0)]
        // ReSharper disable once BuiltInTypeReferenceStyle
        public readonly UInt32 Address;

        // Each Octet is mapped to a byte of the address.
        [FieldOffset(0)]
        public readonly byte Octet1;
        [FieldOffset(1)]
        public readonly byte Octet2;
        [FieldOffset(2)]
        public readonly byte Octet3;
        [FieldOffset(3)]
        public readonly byte Octet4;

        /// <summary>
        /// Creates a new Ip4Address from a byte array.
        /// </summary>
        /// <param name="address">
        /// Must be an array of Length 4. 
        /// Index 0 is mapped to the first octet.
        /// </param>
        public Ip4Address(byte[] address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            const int expectedLength = 4;

            if (address.Length != expectedLength)
            {
                throw new ArgumentException($"{nameof(address)} array must have a length of {expectedLength}.", nameof(address));
            }

            // Set address because we must set all fields in the struct, else there is a compiler error.
            // It seems the compiler isn't aware that they're really the same thing.
            // We could call `:this()`, but I don't want to initalize it before arg checking.
            Address = 0;

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
            : this()
        {
            Address = address;
        }

        /// <summary>
        /// Creates a new Ip4Address from a well formed IP address. i.e. "10.10.1.255"
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">If the <paramref name="address"/> is not a valid IPv4 address.</exception>
        public Ip4Address(string address)
            : this(ParseStringAddress(address))
        { }

        // Using a private method because this work must be done prior to passing it off to a chained ctor call.
        private static byte[] ParseStringAddress(string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            // Validation pattern shamelessly borrowed from http://www.regextester.com/22
            // It validates not only the format, but the number ranges too, 
            // so by time we're casting to a byte, it's a safe operation.
            var ipRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");

            if (!ipRegex.IsMatch(address))
            {
                throw new ArgumentException($"{address} is not a valid IPv4 address.", nameof(address));
            }

            return address.Split('.').Select(Byte.Parse).ToArray();
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. 
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        public override bool Equals(object obj)
        {
            if (!(obj is Ip4Address))
            {
                return false;
            }

            return this.Equals((Ip4Address)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Ip4Address other)
        {
            return Address.Equals(other.Address);
        }

        public static bool operator ==(Ip4Address ip1, Ip4Address ip2)
        {
            return ip1.Equals(ip2);
        }

        public static bool operator !=(Ip4Address ip1, Ip4Address ip2)
        {
            return !(ip1 == ip2);
        }

        /// <summary>
        /// Compares the current object with another object of the same type by doing a byte by byte comparison of the Octets.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An Ip4Address to compare with this object.</param>
        /// <remarks>
        /// Comparing the <seealso cref="Address"/> is not sufficient because it represents 4 bytes (Octets) of data, not a single integer.
        /// Therefore, this implementation does an Octet by Octet comparison.
        /// </remarks>
        public int CompareTo(Ip4Address other)
        {
            if (this.Equals(other))
            {
                return 0;
            }

            var octet1Comparison = Octet1.CompareTo(other.Octet1);

            if (octet1Comparison != 0)
            {
                return octet1Comparison;
            }

            var octet2Comparison = Octet2.CompareTo(other.Octet2);

            if (octet2Comparison != 0)
            {
                return octet2Comparison;
            }

            var octet3Comparison = Octet3.CompareTo(other.Octet3);

            if (octet3Comparison != 0)
            {
                return octet3Comparison;
            }

            // Should never return 0 at this point, because we checked very early if they were equal.
            return Octet4.CompareTo(other.Octet4);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Octet1}.{Octet2}.{Octet3}.{Octet4}";
        }

        /// <summary>
        /// Returns the Octets in the form of a byte array. 
        /// </summary>
        /// <returns>
        /// A byte array of length 4, containing the Octets of the address.
        /// <see cref="Octet1"/> is mapped to index 0 of the array.
        /// </returns>
        public byte[] ToByteArray()
        {
            return new byte[] { Octet1, Octet2, Octet3, Octet4 };
        }
    }
}
