using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    class Envelope
    {
        #region Properties

        public double Width { get; }

        public double Length { get; }

        #endregion

        public Envelope(double length, double width)
        {
            if (width <= length)
            {
                Width = width;
                Length = length;
            }
            else
            {
                Width = length;
                Length = width;
            }
        }

        public bool CanContainEnvelope(Envelope enclosed)
        {
            return enclosed.Length < Length && enclosed.Width < Width;
        }

        public static CompareResult CompareEnvelopes(Envelope x, Envelope y)
        {
            if (x.CanContainEnvelope(y))
            {
                return CompareResult.FirstCanContainSecond;
            }
            else
            {
                if (y.CanContainEnvelope(x))
                {
                    return CompareResult.SecondCanContainFirst;
                }
                else
                {
                    return CompareResult.NotFitted;
                }
            }
        }
    }
}
