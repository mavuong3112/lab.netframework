package com.duy.lab02.view_models;

public class TimerWatchUiState {
    private String selectedColor;

    private String secondPart;

    private String minutePart;

    private String hourPart;


    // GETTERS


    public String getSelectedColor() {
        return selectedColor;
    }

    public String getSecondPart() {
        return secondPart;
    }

    public String getMinutePart() {
        return minutePart;
    }

    public String getHourPart() {
        return hourPart;
    }

    // CONSTRUCTOR
    public TimerWatchUiState(
            String selectedColor,
            String secondPart,
            String minutePart,
            String hourPart
    ) {
        this.selectedColor = selectedColor;
        this.secondPart = secondPart;
        this.minutePart = minutePart;
        this.hourPart = hourPart;
    }

}
