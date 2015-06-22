using System;

namespace SuperMarketPricing
{
    public struct Sku
    {
        private readonly char _value;

        public Sku(char value)
        {
            _value = value;
        }

        public Sku(Sku sku)
        {
            _value = sku._value;
        }

        public static explicit operator char (Sku v)
        {
            return v._value;
        }

        public static explicit operator Sku(char v)
        {
            return new Sku(v);
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
            if (obj == null) { return false; }

            Sku sku;
            try
            {
                sku = (Sku)obj;
            }
            catch
            {
                return false;
            }

            return _value == (char)sku;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
