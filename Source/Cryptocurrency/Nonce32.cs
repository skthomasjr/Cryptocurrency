using System;
using System.Linq;

namespace Cryptocurrency
{
    public struct Nonce32
    {
        private byte[] data;

        public static implicit operator Nonce32(byte[] value)
        {
            return new Nonce32 { data = value };
        }

        public static implicit operator Nonce32(int value)
        {
            return new Nonce32 { data = BitConverter.GetBytes(value) };
        }

        public static implicit operator Nonce32(string value)
        {
            return new Nonce32
            {
                data = Enumerable.Range(0, value.Length)
                    .Where(index => index % 2 == 0)
                    .Select(index => Convert.ToByte(value.Substring(index, 2), 16))
                    .ToArray()
            };
        }

        public static implicit operator Nonce32(uint value)
        {
            return new Nonce32 { data = BitConverter.GetBytes(value) };
        }

        public static explicit operator byte[](Nonce32 value)
        {
            return value.data;
        }

        public static explicit operator int(Nonce32 value)
        {
            return BitConverter.ToInt32(value.data, 0);
        }

        public static explicit operator string(Nonce32 value)
        {
            return BitConverter.ToString(value.data).Replace("-", string.Empty).ToLowerInvariant();
        }

        public static explicit operator uint(Nonce32 value)
        {
            return BitConverter.ToUInt32(value.data, 0);
        }

        public byte[] ToBytes()
        {
            return (byte[])this;
        }

        public int ToInt32()
        {
            return (int)this;
        }

        public override string ToString()
        {
            return (string)this;
        }

        public uint ToUInt32()
        {
            return (uint)this;
        }
    }
}