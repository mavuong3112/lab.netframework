package com.duy.lab02.view_models;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class TimerWatchViewModel extends ViewModel {

    private final MutableLiveData<TimerWatchUiState> timerWatchUiState = new MutableLiveData<>(
            new TimerWatchUiState("black", "00", "00", "00")
    );

    public LiveData<TimerWatchUiState> getTimerWatchUiState() {
        return timerWatchUiState;
    }

    public void setTimerWatchUiState(TimerWatchUiState timerWatchUiState) {
        this.timerWatchUiState.setValue(timerWatchUiState);
    }

}
