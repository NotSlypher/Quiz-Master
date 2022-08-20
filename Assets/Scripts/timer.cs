using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] private float TimeToCompleteQuestion = 30f;
    [SerializeField] private float TimeToShowCorrectAnswer = 10f;
    private float timerValue;
    public bool isAnsweringQuestion = false;
    public bool loadNextQues;
    public float fillFraction;

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
         
        if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = TimeToShowCorrectAnswer;
            }
            else
                fillFraction = timerValue / TimeToCompleteQuestion;
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = TimeToCompleteQuestion;
                loadNextQues = true;
            }
            else
                fillFraction = timerValue / TimeToShowCorrectAnswer;
        }

        Debug.Log(isAnsweringQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
