package com.duy.lab02;

import android.graphics.Color;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link TimerResultFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class TimerResultFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public TimerResultFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment TimerResultFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static TimerResultFragment newInstance(String param1, String param2) {
        TimerResultFragment fragment = new TimerResultFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_timer_result, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();

        String timer = getArguments().getString("timer");
        String selectedColor = getArguments().getString("selectedColor");
        String stopTimerAt = getArguments().getString("stopTimerAt");


        TextView stopwatchResultTextView = getView().findViewById(R.id.stopwatch_result_text_view);
        TextView stopTimerAtTextView = getView().findViewById(R.id.stopwatch_at_text_view);

        if (selectedColor.equals("red")) {
            stopwatchResultTextView.setTextColor(Color.parseColor("#FF0000"));
        }
        if (selectedColor.equals("blue")) {
            stopwatchResultTextView.setTextColor(Color.parseColor("#0000FF"));
        }
        if (selectedColor.equals("black")) {
            stopwatchResultTextView.setTextColor(Color.parseColor("#000000"));
        }

        stopwatchResultTextView.setText(timer);
        stopTimerAtTextView.setText(stopTimerAt);
    }

}