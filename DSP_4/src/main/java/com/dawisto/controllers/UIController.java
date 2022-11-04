package com.dawisto.controllers;

import com.dawisto.signal.MathUtils;
import com.dawisto.signal.NoiseSignal;
import com.dawisto.signal.SmoothingType;
import javafx.collections.FXCollections;
import javafx.fxml.FXML;
import javafx.scene.chart.*;
import javafx.scene.control.ChoiceBox;
import javafx.scene.layout.AnchorPane;

import java.util.Arrays;
import java.util.stream.Collectors;


public class UIController {

    @FXML
    public ChoiceBox<String> smoothingType;

    @FXML
    public LineChart<Number, Number> signalChart;
    @FXML
    public BarChart<String, Number> amplitudeSpectre;
    @FXML
    public BarChart<String, Number> phaseSpectre;

    @FXML
    private void initialize() {
        smoothingType.setItems(FXCollections.observableArrayList(Arrays.stream(SmoothingType.values()).map(Enum::name).collect(Collectors.toList())));
        smoothingType.setValue(SmoothingType.Sliding.name());

        signalChart.setTitle("Signals");
        signalChart.getXAxis().setLabel("Iterations");
        signalChart.getYAxis().setLabel("Value");
        signalChart.setCreateSymbols(false);


        amplitudeSpectre.setTitle("Amplitude spectre");
        amplitudeSpectre.getXAxis().setLabel("Frequency");
        amplitudeSpectre.getYAxis().setLabel("Amplitude value");


        phaseSpectre.setTitle("Phase spectre");
        phaseSpectre.getXAxis().setLabel("Frequency");
        phaseSpectre.getYAxis().setLabel("Phase value");
    }

    @FXML
    private void onDrawButtonClick() {
        drawCharts();
    }


    private void drawCharts() {
        NoiseSignal noiseSignal = new NoiseSignal(SmoothingType.valueOf(smoothingType.getValue()));

        drawSignalChart(noiseSignal);

        drawAmplitudeSpectre(noiseSignal);

        drawPhaseSpectre(noiseSignal);
    }

    private void drawPhaseSpectre(NoiseSignal noiseSignal) {
        phaseSpectre.getData().clear();

        double[] phSpectre = noiseSignal.getPhaseSpectre();

        XYChart.Series<String, Number> phaseSpectreSeries = new XYChart.Series<>();
        phaseSpectreSeries.setName("Phase spectre");
        for (int i = 0; i < MathUtils.HarmonicsCount; i++) {
            phaseSpectreSeries.getData().add(new XYChart.Data<>(String.valueOf(i), phSpectre[i]));
        }
        phaseSpectre.getData().add(phaseSpectreSeries);

        double[] phSmoothedSpectre = noiseSignal.getSmoothedPhaseSpectre();

        XYChart.Series<String, Number> phaseSpectreSmoothedSeries = new XYChart.Series<>();
        phaseSpectreSmoothedSeries.setName("Smoothed phase spectre");
        for (int i = 0; i < MathUtils.HarmonicsCount; i++) {
            phaseSpectreSmoothedSeries.getData().add(new XYChart.Data<>(String.valueOf(i), phSmoothedSpectre[i]));
        }
        phaseSpectre.getData().add(phaseSpectreSmoothedSeries);
    }

    private void drawAmplitudeSpectre(NoiseSignal noiseSignal) {
        amplitudeSpectre.getData().clear();

        double[] amplSpectre = noiseSignal.getAmplitudeSpectre();

        XYChart.Series<String, Number> amplSpectreSeries = new XYChart.Series<>();
        amplSpectreSeries.setName("Amplitude spectre");
        for (int i = 0; i < MathUtils.HarmonicsCount; i++) {
            amplSpectreSeries.getData().add(new XYChart.Data<>(String.valueOf(i), amplSpectre[i]));
        }
        amplitudeSpectre.getData().add(amplSpectreSeries);

        double[] amplSpectreSmoothed = noiseSignal.getSmoothedAmplitudeSpectre();

        XYChart.Series<String, Number> amplSpectreSmoothedSeries = new XYChart.Series<>();
        amplSpectreSmoothedSeries.setName("Smoothed amplitude spectre");
        for (int i = 0; i < MathUtils.HarmonicsCount; i++) {
            amplSpectreSmoothedSeries.getData().add(new XYChart.Data<>(String.valueOf(i), amplSpectreSmoothed[i]));
        }
        amplitudeSpectre.getData().add(amplSpectreSmoothedSeries);

    }


    private void drawSignalChart(NoiseSignal noiseSignal) {
        signalChart.getData().clear();

        double[] signal = noiseSignal.getSignal();

        XYChart.Series<Number, Number> signalSeries = new XYChart.Series<>();
        signalSeries.setName("Signal");
        for (int i = 0; i < MathUtils.N; i++) {
            signalSeries.getData().add(new XYChart.Data<>(i, signal[i]));
        }
        signalChart.getData().add(signalSeries);

        double[] smoothedSignal = noiseSignal.getSmoothedSignal();

        XYChart.Series<Number, Number> smoothedSignalSeries = new XYChart.Series<>();
        smoothedSignalSeries.setName("Smoothed signal");
        for (int i = 0; i < MathUtils.N; i++) {
            smoothedSignalSeries.getData().add(new XYChart.Data<>(i, smoothedSignal[i]));
        }
        signalChart.getData().add(smoothedSignalSeries);
    }


    private static AnchorPane anchorPane;

    public static void setMainApp(AnchorPane anchorPane) {
        UIController.anchorPane = anchorPane;
    }
}
