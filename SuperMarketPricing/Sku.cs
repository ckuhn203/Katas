using System;

namespace SuperMarketPricing
{
    public struct Sku
    {
        public static long MaxValue = 9999999999;
        public static long MinValue = 1;

        private readonly long _value;

        public Sku(long value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Sku value must be between {MinValue} and {MaxValue}.");
            }

            _value = value;
        }

        public static explicit operator long (Sku v)
        {
            return v._value;
        }

        public static explicit operator Sku(long v)
        {
            try
            {
                return new Sku(v);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidCastException($"Sku value must be between {MinValue} and {MaxValue}.", ex);
            }

        }

        public static bool operator ==(Sku sku1, Sku sku2)
        {
            return sku1.Equals(sku2);
        }

        public static bool operator !=(Sku sku1, Sku sku2)
        {
            return !sku1.Equals(sku2);
        }

        public override bool Equals(object obj)
        {
            var sku = obj as Sku?;

            if (sku == null)
            {
                return false;
            }

            return _value == ((Sku)sku)._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString("0000000000");
        }
    }
}
