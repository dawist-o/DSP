package com.dawisto.signal;

import static java.lang.Math.*;

public class MathUtils {

    static final int Amplitude = 100;
    static final int B = 5;
    static final double Phase = PI/4;
    static final int Frequency = 5;
//    public static final int N = 1024;
    public static final int N = 512;
    public static final int HarmonicsCount = 100;

    public static double[] getSineSpectre(double[] signal) {
        double[] values = new double[HarmonicsCount];
        for (int j = 0; j < HarmonicsCount; j++) {
            double val = 0;
            for (int i = 0; i < N; i++) {
                val += signal[i] * sin(2 * PI * i * j / N);
            }
            values[j] = 2 * val / N;
        }
        return values;
    }

    public static double[] getCosineSpectre(double[] signal) {
        double[] values = new double[HarmonicsCount];
        for (int j = 0; j < HarmonicsCount; j++) {
            double val = 0;
            for (int i = 0; i < N; i++) {
                val += signal[i] * cos(2 * PI * i * j / N);
            }
            values[j] = 2 * val / N;
        }
        return values;
    }

    public static double[] getAmplSpectre(double[] sineSpectre, double[] cosineSpectre) {
        double[] values = new double[HarmonicsCount];
        for (int j = 0; j < HarmonicsCount ; j++) {
            values[j] = Math.sqrt(pow(sineSpectre[j], 2) + pow(cosineSpectre[j], 2));
        }
        return values;
    }

    public static double[] getPhaseSpectre(double[] sineSpectre, double[] cosineSpectre) {
        double[] values = new double[HarmonicsCount];
        for (int j = 0; j < HarmonicsCount; j++) {
            values[j] = Math.atan(sineSpectre[j] / cosineSpectre[j]);
        }
        return values;
    }

    public static double[] restoredSignalWithPhase(double[] amplitudeSpector, double[] phaseSpector) {
        double[] values = new double[N];
        for (int i = 0; i < N; i++) {
            double val = 0;
            for (int j = 0; j < HarmonicsCount; j++) {
                val += amplitudeSpector[j] * Math.cos(2 * Math.PI * i * j / N - phaseSpector[j]);
            }
            values[i] = val;
        }
        return values;
    }

    public static double[] restoreSignalWithoutPhase(double[] amplitudeSpector) {
        double[] values = new double[N];
        for (int i = 0; i <= N - 1; i++) {
            double val = 0;
            for (int j = 0; j <= HarmonicsCount - 1; j++) {
                val += amplitudeSpector[j] * cos(2 * PI * i * j / N);
            }
            values[i] = val;
        }
        return values;
    }


}
