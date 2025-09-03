using System;
using NAudio.Wave;
using AudioDSP;

class Program
{
    static void Main()
    {
        int sampleRate = 48000;
        int durationSeconds = 5;
        int sampleCount = sampleRate * durationSeconds;

        // Create filters
        var filter1 = new BiquadFilter(BiquadFilterType.LowPass, sampleRate, 1200, 0.707);
        var filter2 = new BiquadFilter(BiquadFilterType.LowPass, sampleRate, 1500, 0.707);

        float[] left = new float[sampleCount];
        float[] right = new float[sampleCount];

        int fadeSamples = (int)(0.2 * sampleRate); // 0.2 second fade in/out

        for (int n = 0; n < sampleCount; n++)
        {
            double t = (double)n / sampleRate;

            // Tone 1 (400 Hz + 800 Hz harmonic)
            double tone1 = Math.Sin(2 * Math.PI * 400 * t) + 0.2 * Math.Sin(2 * Math.PI * 800 * t);
            tone1 *= 0.9 + 0.1 * Math.Sin(2 * Math.PI * 1.5 * t); // tremolo
            tone1 = filter1.Process(tone1);

            // Tone 2 (600 Hz + 1200 Hz harmonic)
            double tone2 = Math.Sin(2 * Math.PI * 600 * t) + 0.2 * Math.Sin(2 * Math.PI * 1200 * t);
            tone2 *= 0.9 + 0.1 * Math.Sin(2 * Math.PI * 1.2 * t);
            tone2 = filter2.Process(tone2);

            // Stereo panning
            double pan1 = 0.5 + 0.5 * Math.Sin(2 * Math.PI * 0.1 * t);
            double pan2 = 0.5 + 0.5 * Math.Cos(2 * Math.PI * 0.15 * t);

            left[n] = (float)((tone1 * (1 - pan1) + tone2 * (1 - pan2)) / 2);
            right[n] = (float)((tone1 * pan1 + tone2 * pan2) / 2);

            // Fade-in/fade-out
            if (n < fadeSamples)
            {
                double fadeFactor = (double)n / fadeSamples;
                left[n] *= (float)fadeFactor;
                right[n] *= (float)fadeFactor;
            }
            else if (n >= sampleCount - fadeSamples)
            {
                double fadeFactor = (double)(sampleCount - n) / fadeSamples;
                left[n] *= (float)fadeFactor;
                right[n] *= (float)fadeFactor;
            }
        }

        // Write WAV
        using (var writer = new WaveFileWriter("stereo_demo2.wav", new WaveFormat(sampleRate, 2)))
        {
            for (int i = 0; i < sampleCount; i++)
            {
                writer.WriteSample(left[i]);
                writer.WriteSample(right[i]);
            }
        }

        Console.WriteLine("stereo_demo2.wav created successfully!");
    }
}
