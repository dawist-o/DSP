package com.dawisto.signal;

import java.util.*;

import static com.dawisto.signal.MathUtils.*;
import static java.lang.Math.PI;

public class NoiseSignal {

    private double[] signal;
    private double[] smoothedSignal;

    private double[] restoredSignalWithPhase;
    private double[] restoredSignalWithoutPhase;

    private double[] amplitudeSpectre;
    private double[] smoothedAmplitudeSpectre;

    private double[] phaseSpectre;
    private double[] smoothedPhaseSpectre;

    private int smoothingWindowSize = 9;
    private int medianWindowSize = 5;

    public NoiseSignal(SmoothingType type) {
        signal = createDefaultSignal();

        double[] sineSpectre = MathUtils.getSineSpectre(signal);
        double[] cosineSpectre = MathUtils.getCosineSpectre(signal);

        amplitudeSpectre = MathUtils.getAmplSpectre(sineSpectre, cosineSpectre);
        phaseSpectre = MathUtils.getPhaseSpectre(sineSpectre, cosineSpectre);

        restoredSignalWithPhase = MathUtils.restoredSignalWithPhase(amplitudeSpectre, phaseSpectre);
        restoredSignalWithoutPhase = MathUtils.restoreSignalWithoutPhase(amplitudeSpectre);

        smoothedSignal = generateSignalByType(type);
        double[] sineSpectreSmoothed = MathUtils.getSineSpectre(smoothedSignal);
        double[] cosineSpectreSmoothed = MathUtils.getCosineSpectre(smoothedSignal);

        smoothedAmplitudeSpectre = MathUtils.getAmplSpectre(sineSpectreSmoothed, cosineSpectreSmoothed);
        smoothedPhaseSpectre = MathUtils.getPhaseSpectre(sineSpectreSmoothed, cosineSpectreSmoothed);
    }

    private double[] generateSignalByType(SmoothingType type) {
        switch (type) {
            case Sliding -> {
                return getSlidingSmoothSignal(smoothingWindowSize);
            }
            case Parabolic -> {
                return getParabolicSmoothingSignal();
            }
            case Median -> {
                return getMedianSmoothingSignal(medianWindowSize);
            }
        }
        return signal;
    }

    private double[] createDefaultSignal() {
        double[] sign = new double[N];
        Random rnd = new Random();
        for (int i = 0; i < N; i++) {
            sign[i] = Amplitude * Math.sin(2 * PI * Frequency * i / N + Phase);
            double noise = 0;
            for (int j = 50; j <= 70; j++) {
                double noiseTemp = B * Math.sin(2 * PI * Frequency * i * j / N + Phase);
                noise += rnd.nextBoolean() ? (noiseTemp) : (-noiseTemp);
            }
            sign[i] += noise;
        }
        return sign;
    }

    private double[] getSlidingSmoothSignal(int windowSize) {
        double[] smoothedSignal = signal.clone();
        List<Double> window = new ArrayList<>();
        int halfSize = windowSize/2;
        for (int i = halfSize; i < smoothedSignal.length - halfSize; i++) {
            window.clear();
            for (int j = i-halfSize; j < i + halfSize; j++) {
                window.add(signal[j]);
            }
            double avg = window.stream().mapToDouble(Double::doubleValue).sum() / (windowSize);
            smoothedSignal[i] = avg;
        }
        return smoothedSignal;
    }

    public double[] getParabolicSmoothingSignal() {
        double[] parabolicSignal = new double[N];
        for (int i = 7; i <= parabolicSignal.length - 8; i++) {
            parabolicSignal[i] = (-3 * signal[i - 7] - 6 * signal[i - 6] - 5 * signal[i - 5]
                    + 3 * signal[i - 4] + 21 * signal[i - 3] + 46 * signal[i - 2]
                    + 67 * signal[i - 1] + 74 * signal[i] - 3 * signal[i + 7]
                    - 6 * signal[i + 6] - 5 * signal[i + 5] + 3 * signal[i + 4]
                    + 21 * signal[i + 3] + 46 * signal[i + 2] + 67 * signal[i + 1]) / 320;
        }
        return parabolicSignal;
    }

    public double[] getMedianSmoothingSignal(int windowSize) {
        double[] medianSignal = signal.clone();
        List<Double> window = new LinkedList<>();
        int halfSize = windowSize/2;
        for (int i = halfSize; i < medianSignal.length - halfSize; i++) {
            window.clear();
            for (int j = i-halfSize; j < i + halfSize; j++) {
                window.add(signal[j]);
            }
            Collections.sort(window);
            medianSignal[i] = window.get(windowSize/2);
        }
        return medianSignal;
    }

    public double[] getSignal() {
        return signal;
    }

    public double[] getRestoredSignalWithPhase() {
        return restoredSignalWithPhase;
    }

    public double[] getSmoothedSignal() {
        return smoothedSignal;
    }

    public double[] getRestoredSignalWithoutPhase() {
        return restoredSignalWithoutPhase;
    }

    public double[] getAmplitudeSpectre() {
        return amplitudeSpectre;
    }

    public double[] getPhaseSpectre() {
        return phaseSpectre;
    }

    public double[] getSmoothedAmplitudeSpectre() {
        return smoothedAmplitudeSpectre;
    }

    public double[] getSmoothedPhaseSpectre() {
        return smoothedPhaseSpectre;
    }

}
