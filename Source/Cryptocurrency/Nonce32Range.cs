using System;
using System.Linq;

namespace Cryptocurrency
{
    public struct Nonce32Range
    {
        private Nonce32 start;
        private Nonce32 stop;

        public static implicit operator Nonce32Range(string value)
        {
            var middle = value.Length / 2;
            var first = value.Substring(0, middle);
            var last = value.Substring(middle);

            return new Nonce32Range
            {
                start = Enumerable.Range(0, first.ToString().Length)
                    .Where(index => index % 2 == 0)
                    .Select(index => Convert.ToByte(first.ToString().Substring(index, 2), 16))
                    .ToArray(),
                stop = Enumerable.Range(0, last.ToString().Length)
                    .Where(index => index % 2 == 0)
                    .Select(index => Convert.ToByte(last.ToString().Substring(index, 2), 16))
                    .ToArray()
            };
        }

        public static explicit operator string(Nonce32Range value)
        {
            return (string)value.start + (string)value.stop;
        }

        public Nonce32 GetStart()
        {
            return start;
        }

        public Nonce32 GetStop()
        {
            return stop;
        }

        public override string ToString()
        {
            return (string)this;
        }
    }
}