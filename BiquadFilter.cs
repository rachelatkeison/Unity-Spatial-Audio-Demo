using System;

namespace AudioDSP
{
    public enum BiquadFilterType { LowPass, HighPass }

    public class BiquadFilter
    {
        private double a0, a1, a2, b0, b1, b2;
        private double z1, z2;

        public BiquadFilter(BiquadFilterType type, double sampleRate, double freq, double q)
        {
            double omega = 2.0 * Math.PI * freq / sampleRate;
            double alpha = Math.Sin(omega) / (2.0 * q);
            double cosw = Math.Cos(omega);

            switch (type)
            {
                case BiquadFilterType.LowPass:
                    b0 = (1 - cosw) / 2; b1 = 1 - cosw; b2 = (1 - cosw) / 2;
                    a0 = 1 + alpha; a1 = -2 * cosw; a2 = 1 - alpha;
                    break;
                case BiquadFilterType.HighPass:
                    b0 = (1 + cosw) / 2; b1 = -(1 + cosw); b2 = (1 + cosw) / 2;
                    a0 = 1 + alpha; a1 = -2 * cosw; a2 = 1 - alpha;
                    break;
            }

            //normalize
            b0 /= a0; b1 /= a0; b2 /= a0;
            a1 /= a0; a2 /= a0;
        }

        public double Process(double input)
        {
            double output = b0 * input + b1 * z1 + b2 * z2 - a1 * z1 - a2 * z2;
            z2 = z1;
            z1 = output;
            return output;
        }
    }
}
