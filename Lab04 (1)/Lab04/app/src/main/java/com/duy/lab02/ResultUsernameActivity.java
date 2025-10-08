package com.duy.lab02;

import android.content.Intent;
import android.content.res.Configuration;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.lifecycle.ViewModelProvider;

import com.duy.lab02.view_models.TimerWatchUiState;
import com.duy.lab02.view_models.TimerWatchViewModel;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class ResultUsernameActivity extends AppCompatActivity implements AdapterView.OnItemSelectedListener {


    private TimerWatchViewModel viewModel;

    private Handler handler = new Handler(Looper.getMainLooper());
    private Runnable runnable;

    private boolean isStartWatchStarted = false;

    private List<String> colors = new ArrayList<>();
    private String selectedColor = "";

    private String secondPart = "00";
    private String minutePart = "00";
    private String hourPart = "00";


    private Map<String, String> mappedHourToReadableString = new HashMap<>();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_result_username);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });


        viewModel = new ViewModelProvider(this).get(TimerWatchViewModel.class);
        viewModel.getTimerWatchUiState().observe(this, timerWatchUiState -> {

            Spinner colorSpinner = (Spinner) findViewById(R.id.color_spinner);
            TextView hourpartTextView = findViewById(R.id.hourpart_text_view);
            TextView minutepartTextView = findViewById(R.id.minutepart_text_view);
            TextView secondpartTextView = findViewById(R.id.secondpart_text_view);


            this.selectedColor = timerWatchUiState.getSelectedColor();
            this.hourPart = timerWatchUiState.getHourPart();
            this.minutePart = timerWatchUiState.getMinutePart();
            this.secondPart = timerWatchUiState.getSecondPart();

            colorSpinner.setSelection(colors.indexOf(this.selectedColor));
            hourpartTextView.setText(this.hourPart);
            minutepartTextView.setText(this.minutePart);
            secondpartTextView.setText(this.secondPart);

            Log.d("UI UPDATED", "Selected Color: " + timerWatchUiState.getSelectedColor() + " " + timerWatchUiState.getHourPart() + ":" +  timerWatchUiState.getMinutePart() + ":" + timerWatchUiState.getSecondPart());
        });



        colors.add("red");
        colors.add("blue");

        Intent intent = getIntent();

        String username = intent.getStringExtra("username");

        Bundle resultFragmentBundle = new Bundle();

        resultFragmentBundle.putString("username", username);

        ResultFragment fragment = new ResultFragment();
        fragment.setArguments(resultFragmentBundle);

        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.result_fragment, fragment)
                .commit();


        mappedHourToReadableString.put(
                "00", "không"
        );
        mappedHourToReadableString.put(
                "01", "một"
        );
        mappedHourToReadableString.put(
                "02", "hai"
        );
        mappedHourToReadableString.put(
                "03", "ba"
        );
        mappedHourToReadableString.put(
                "04", "bốn"
        );
        mappedHourToReadableString.put(
                "05", "năm"
        );
        mappedHourToReadableString.put(
                "06", "sáu"
        );
        mappedHourToReadableString.put(
                "07", "bảy"
        );
        mappedHourToReadableString.put(
                "08", "tám"
        );
        mappedHourToReadableString.put(
                "09", "chín"
        );
        mappedHourToReadableString.put(
                "10", "mười"
        );
        mappedHourToReadableString.put(
                "11", "mười một"
        );
        mappedHourToReadableString.put(
                "12", "mười hai"
        );
        mappedHourToReadableString.put(
                "13", "mười ba"
        );
        mappedHourToReadableString.put(
                "14", "mười bốn"
        );
        mappedHourToReadableString.put(
                "15", "mười lăm"
        );
        mappedHourToReadableString.put(
                "16", "mười sáu"
        );
        mappedHourToReadableString.put(
                "17", "mười bảy"
        );
        mappedHourToReadableString.put(
                "18", "mười tám"
        );
        mappedHourToReadableString.put(
                "19", "mười chín"
        );
        mappedHourToReadableString.put(
                "20", "hai mươi"
        );
        mappedHourToReadableString.put(
                "21", "hai mưới mốt"
        );
        mappedHourToReadableString.put(
                "22", "hai mươi hai"
        );
        mappedHourToReadableString.put(
                "23", "hai mươi ba"
        );
        mappedHourToReadableString.put(
                "24", "hai mươi bốn"
        );
        mappedHourToReadableString.put(
                "25", "hai mươi lăm"
        );
        mappedHourToReadableString.put(
                "26", "hai mươi sáu"
        );
        mappedHourToReadableString.put(
                "27", "hai mươi bảy"
        );
        mappedHourToReadableString.put(
                "28", "hai mươi tám"
        );
        mappedHourToReadableString.put(
                "29", "hai mươi chín"
        );
        mappedHourToReadableString.put(
                "30", "ba mươi"
        );
        mappedHourToReadableString.put(
                "31", "ba mươi mốt"
        );
        mappedHourToReadableString.put(
                "32", "ba mươi hai"
        );
        mappedHourToReadableString.put(
                "33", "ba mươi ba"
        );
        mappedHourToReadableString.put(
                "34", "ba mươi bốn"
        );
        mappedHourToReadableString.put(
                "35", "ba mươi lăm"
        );
        mappedHourToReadableString.put(
                "36", "ba mươi sáu"
        );
        mappedHourToReadableString.put(
                "37", "ba mươi bảy"
        );
        mappedHourToReadableString.put(
                "38", "ba mươi tám"
        );
        mappedHourToReadableString.put(
                "39", "ba mươi chín"
        );
        mappedHourToReadableString.put(
                "40", "bốn mươi"
        );
        mappedHourToReadableString.put(
                "41", "bốn mươi mốt"
        );
        mappedHourToReadableString.put(
                "42", "bốn mươi hai"
        );
        mappedHourToReadableString.put(
                "43", "bốn mươi ba"
        );
        mappedHourToReadableString.put(
                "44", "bốn mươi bốn"
        );
        mappedHourToReadableString.put(
                "45", "bốn mươi lăm"
        );
        mappedHourToReadableString.put(
                "46", "bốn mươi sáu"
        );
        mappedHourToReadableString.put(
                "47", "bốn mươi bảy"
        );
        mappedHourToReadableString.put(
                "48", "bốn mươi tám"
        );
        mappedHourToReadableString.put(
                "49", "bốn mươi chín"
        );
        mappedHourToReadableString.put(
                "50", "năm mươi"
        );
        mappedHourToReadableString.put(
                "51", "năm mươi mốt"
        );
        mappedHourToReadableString.put(
                "52", "năm mươi hai"
        );
        mappedHourToReadableString.put(
                "53", "năm mươi ba"
        );
        mappedHourToReadableString.put(
                "54", "năm mươi bốn"
        );
        mappedHourToReadableString.put(
                "55", "năm mươi lăm"
        );
        mappedHourToReadableString.put(
                "56", "năm mươi sáu"
        );
        mappedHourToReadableString.put(
                "57", "năm mươi bảy"
        );
        mappedHourToReadableString.put(
                "58", "năm mươi tám"
        );
        mappedHourToReadableString.put(
                "59", "năm mươi chín"
        );

    }

    @Override
    protected void onPause() {
        super.onPause();
        handler.removeCallbacks(runnable);
    }

    @Override
    protected void onResume() {
        super.onResume();
        handler.post(runnable);
    }


    public void onItemSelected(AdapterView<?> parent, View view,
                               int pos, long id) {

        Object item = parent.getItemAtPosition(pos);

        this.selectedColor = item.toString();

        Log.d("success", "selectedColor: " + this.selectedColor);
    }

    public void onNothingSelected(AdapterView<?> parent) {
        this.selectedColor = "black";
    }


    public void startTimer(View view) {
        Drawable personStandDrawable = ContextCompat.getDrawable(this, R.drawable.person_stand);
        Drawable personRunningDrawable = ContextCompat.getDrawable(this, R.drawable.person_running);

        ImageView runningImageView = findViewById(R.id.running_image_view);
        Button startButton = findViewById(R.id.start_button);

        if (!isStartWatchStarted) {

            TextView hourpartTextView = findViewById(R.id.hourpart_text_view);
            TextView minutepartTextView = findViewById(R.id.minutepart_text_view);
            TextView secondpartTextView = findViewById(R.id.secondpart_text_view);

            runnable = new Runnable() {
                @Override
                public void run() {
                    int secondPartParsed = Integer.parseInt(secondPart);

                    // SECOND PART
                    if (secondPartParsed >= 1 && secondPartParsed <= 9) {
                        hourpartTextView.setText(hourPart);
                        minutepartTextView.setText(minutePart);
                        secondpartTextView.setText("0" + String.valueOf(secondPartParsed));

                        secondPartParsed += 1;
                        secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                        // Schedule again after 1 second
                        handler.postDelayed(this, 100);

                        viewModel.setTimerWatchUiState(
                                new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                        );

                        return;
                    }
                    if (secondPartParsed == 10) {
                        hourpartTextView.setText(hourPart);
                        minutepartTextView.setText(minutePart);
                        secondpartTextView.setText(String.valueOf(secondPartParsed));

                        secondPartParsed += 1;
                        secondPart = String.valueOf(String.valueOf(secondPartParsed));
                        // Schedule again after 1 second
                        handler.postDelayed(this, 100);

                        viewModel.setTimerWatchUiState(
                                new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                        );

                        return;
                    }
                    if (secondPartParsed < 60) {
                        hourpartTextView.setText(hourPart);
                        minutepartTextView.setText(minutePart);
                        secondpartTextView.setText(String.valueOf(secondPartParsed));


                        secondPartParsed += 1;
                        secondPart = String.valueOf(String.valueOf(secondPartParsed));
                        // Schedule again after 1 second
                        handler.postDelayed(this, 100);

                        viewModel.setTimerWatchUiState(
                                new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                        );

                        return;
                    }

                    // MINUTE PART
                    if (secondPartParsed == 60) {
                        int minutePartParsed = Integer.parseInt(minutePart);

                        if (minutePartParsed >= 0 && minutePartParsed < 9) {
                            secondPartParsed = 0;
                            minutePartParsed += 1;

                            hourpartTextView.setText(hourPart);
                            minutepartTextView.setText("0" + String.valueOf(minutePartParsed));
                            secondpartTextView.setText("00");

                            secondPartParsed = 1;

                            secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                            minutePart = String.valueOf("0" + String.valueOf(minutePartParsed));
                            // Schedule again after 1 second
                            handler.postDelayed(this, 100);

                            viewModel.setTimerWatchUiState(
                                    new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                            );

                            return;

                        }
                        if (minutePartParsed == 10) {
                            secondPartParsed = 0;
                            minutePartParsed += 1;

                            hourpartTextView.setText(hourPart);
                            minutepartTextView.setText(String.valueOf(minutePartParsed));
                            secondpartTextView.setText("00");


                            secondPartParsed = 1;

                            secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                            minutePart = String.valueOf(String.valueOf(minutePartParsed));
                            // Schedule again after 1 second
                            handler.postDelayed(this, 100);

                            viewModel.setTimerWatchUiState(
                                    new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                            );

                            return;
                        }
                        if (minutePartParsed < 59) {
                            secondPartParsed = 0;
                            minutePartParsed += 1;

                            hourpartTextView.setText(hourPart);
                            minutepartTextView.setText(String.valueOf(minutePartParsed));
                            secondpartTextView.setText("00");


                            secondPartParsed = 1;

                            secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                            minutePart = String.valueOf(String.valueOf(minutePartParsed));
                            // Schedule again after 1 second
                            handler.postDelayed(this, 100);

                            viewModel.setTimerWatchUiState(
                                    new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                            );

                            return;
                        }

                        // HOUR PART
                        if (minutePartParsed == 59) {

                            int hourPartParsed = Integer.parseInt(hourPart);

                            if (hourPartParsed >= 0 && hourPartParsed < 9) {
                                secondPartParsed = 0;
                                minutePartParsed = 0;
                                hourPartParsed += 1;

                                hourpartTextView.setText("0" + String.valueOf(hourPartParsed));
                                minutepartTextView.setText("00");
                                secondpartTextView.setText("00");


                                secondPartParsed = 1;

                                secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                                minutePart = String.valueOf("0" + String.valueOf(minutePartParsed));
                                hourPart = String.valueOf("0" + String.valueOf(hourPartParsed));
                                // Schedule again after 1 second
                                handler.postDelayed(this, 100);

                                viewModel.setTimerWatchUiState(
                                        new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                                );

                                return;

                            }
                            if (hourPartParsed == 10) {
                                secondPartParsed = 0;
                                minutePartParsed = 0;
                                hourPartParsed += 1;

                                hourpartTextView.setText(String.valueOf(hourPartParsed));
                                minutepartTextView.setText("00");
                                secondpartTextView.setText("00");


                                secondPartParsed = 1;

                                secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                                minutePart = String.valueOf(String.valueOf(minutePartParsed));
                                hourPart = String.valueOf(String.valueOf(hourPartParsed));
                                // Schedule again after 1 second
                                handler.postDelayed(this, 100);

                                viewModel.setTimerWatchUiState(
                                        new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                                );

                                return;
                            }
                            if (hourPartParsed < 60) {
                                secondPartParsed = 0;
                                minutePartParsed = 0;
                                hourPartParsed += 1;

                                hourpartTextView.setText(String.valueOf(hourPartParsed));
                                minutepartTextView.setText("00");
                                secondpartTextView.setText("00");


                                secondPartParsed = 1;

                                secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
                                minutePart = String.valueOf(String.valueOf(minutePartParsed));
                                hourPart = String.valueOf(String.valueOf(hourPartParsed));
                                // Schedule again after 1 second
                                handler.postDelayed(this, 100);

                                viewModel.setTimerWatchUiState(
                                        new TimerWatchUiState(selectedColor, secondPart, minutePart, hourPart)
                                );

                                return;
                            }
                        }
                    }


                }
            };

            handler.post(runnable);
            runningImageView.setImageDrawable(personRunningDrawable);
            startButton.setText("Dừng");
            isStartWatchStarted = true;
        }
        else {


            int secondPartParsed = Integer.parseInt(secondPart);
            secondPartParsed -= 1;

            if (secondPartParsed < 10) {
                secondPart = String.valueOf("0" + String.valueOf(secondPartParsed));
            }
            else {
                secondPart = String.valueOf(String.valueOf(secondPartParsed));
            }


            String readableSecondPart = this.mappedHourToReadableString
                    .get(secondPart) + " giây";
            String readableMinutePart = this.mappedHourToReadableString
                    .get(minutePart) + " phút";
            String readableHourPart = this.mappedHourToReadableString
                    .get(hourPart) + " giờ";


            handler.removeCallbacks(runnable);
            runningImageView.setImageDrawable(personStandDrawable);
            startButton.setText("Bắt đầu");
            isStartWatchStarted = false;

            TextView hourpartTextView = findViewById(R.id.hourpart_text_view);
            TextView minutepartTextView = findViewById(R.id.minutepart_text_view);
            TextView secondpartTextView = findViewById(R.id.secondpart_text_view);

            handler.removeCallbacks(runnable);

            secondPart = "00";
            minutePart = "00";
            hourPart = "00";

            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm:ss");
            LocalDateTime stopTimerAt = LocalDateTime.now();

            hourpartTextView.setText("00");
            minutepartTextView.setText("00");
            secondpartTextView.setText("00");

            Bundle timerResultFragmentBundle = new Bundle();

            timerResultFragmentBundle.putString("timer", readableHourPart + " " + readableMinutePart + " " + readableSecondPart);
            timerResultFragmentBundle.putString("stopTimerAt", stopTimerAt.format(formatter));
            timerResultFragmentBundle.putString("selectedColor", this.selectedColor);

            TimerResultFragment timerResultFragment = new TimerResultFragment();
            timerResultFragment.setArguments(timerResultFragmentBundle);

            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.result_fragment, timerResultFragment)
                    .addToBackStack(null)
                    .commit();

        }
    }

    public void resetTimer(View view) {
        Drawable personStandDrawable = ContextCompat.getDrawable(this, R.drawable.person_stand);
        ImageView runningImageView = findViewById(R.id.running_image_view);

        Button startButton = findViewById(R.id.start_button);

        TextView hourpartTextView = findViewById(R.id.hourpart_text_view);
        TextView minutepartTextView = findViewById(R.id.minutepart_text_view);
        TextView secondpartTextView = findViewById(R.id.secondpart_text_view);


        handler.removeCallbacks(runnable);

        secondPart = "00";
        minutePart = "00";
        hourPart = "00";

        hourpartTextView.setText("00");
        minutepartTextView.setText("00");
        secondpartTextView.setText("00");

        startButton.setText("Bắt đầu");
        runningImageView.setImageDrawable(personStandDrawable);
        isStartWatchStarted = false;
    }



    public void goBack(View view) {
        finish();
    }

    public void goBackResultFragment(View view) {
        getSupportFragmentManager().popBackStack();
    }


}