package com.dawisto.controllers;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;

public class MainApp extends Application {

    public static Stage primaryStage;
    public static BorderPane rootLayout;

    @Override
    public void start(Stage primaryStage) {
        this.primaryStage = primaryStage;
        primaryStage.setMinWidth(600);
        primaryStage.setMinHeight(600);
        primaryStage.setHeight(850);
        primaryStage.setWidth(1400);
        primaryStage.setMaximized(true);
        primaryStage.setTitle("Kovalenko Vladislav");
        initRootLayout();
        showUI();
    }

    private void initRootLayout() {
        try {
            FXMLLoader loader = new FXMLLoader();
            URL resource = MainApp.class.getResource("../../../gui/rootLayout.fxml");
            loader.setLocation(resource);
            rootLayout = loader.load();
            Scene scene = new Scene(rootLayout);
            primaryStage.setScene(scene);
            primaryStage.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void showUI() {
        try {
            FXMLLoader loader = new FXMLLoader();
            loader.setLocation(MainApp.class.getResource("../../../gui/ui.fxml"));
            AnchorPane setup = loader.load();


            UIController uiController = (UIController) loader.getController();
            UIController.setMainApp(setup);

            rootLayout.setCenter(setup);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args) {
        launch(args);
    }
}
