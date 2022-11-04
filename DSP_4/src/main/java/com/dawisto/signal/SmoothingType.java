package com.dawisto.signal;

public enum SmoothingType {

    Sliding("Sliding"),
    Parabolic("Parabolic"),
    Median("Median");


    private String name;

    SmoothingType(String name) {
        this.name = name;
    }
}
