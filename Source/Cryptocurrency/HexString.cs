using System;
using System.Linq;
using System.Numerics;

namespace Cryptocurrency
{
    public struct HexString
    {
        private byte[] data;

        public static implicit operator HexString(BigInteger value)
        {
            return new HexString { data = value.ToByteArray() };
        }

        public static implicit operator HexString(byte[] value)
        {
            return new HexString { data = value };
        }

        public static implicit operator HexString(string value)
        {
            return new HexString
            {
                data = Enumerable.Range(0, value.Length)
                    .Where(index => index % 2 == 0)
                    .Select(index => Convert.ToByte(value.Substring(index, 2), 16))
                    .ToArray()
            };
        }

        public static explicit operator BigInteger (HexString value)
        {
            return new BigInteger(value.data);
        }

        public static explicit operator byte[] (HexString value)
        {
            return value.data;
        }

        public static explicit operator string(HexString value)
        {
            return BitConverter.ToString(value.data).Replace("-", string.Empty).ToLowerInvariant();
        }

        public byte GetByte(int position)
        {
            return data[position];
        }

        public BigInteger ToBigInteger()
        {
            return (BigInteger)this;
        }

        public byte[] ToBytes()
        {
            return (byte[])this;
        }

        public byte[] ToBytes(int position)
        {
            return ToBytes(position, data.Length - position);
        }

        public byte[] ToBytes(int position, int length)
        {
            var data = this.data;
            return Enumerable.Range(position, length)
                .Select(index => data[index])
                .ToArray();
        }

        public override string ToString()
        {
            return (string)this;
        }
    }
}