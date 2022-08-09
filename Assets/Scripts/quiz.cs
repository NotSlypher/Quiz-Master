using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    [SerializeField] private GameObject[] buttons;
    private int corransidx;
    [SerializeField] private Sprite defaultAnsSprite;
    [SerializeField] private Sprite corrAnsSprite;

    void Start()        
    {
        DisplayQuestion();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    private void SetDefaultButtonSprites()
    {
        Image buttonImage;
        buttonImage = buttons[question.GetCorrind()].GetComponent<Image>();
        buttonImage.sprite = defaultAnsSprite;
    }

    public void onAnsSelected(int idx)
    {
        Image buttonImage;

        if (idx == question.GetCorrind())
        {
            questiontext.text = "Correct";
            buttonImage = buttons[idx].GetComponent<Image>();
            buttonImage.sprite = corrAnsSprite;
        }
        else
        {
            questiontext.text = "Incorrect!! Correct ans is :\n" + question.GetAnswer(question.GetCorrind());
            buttonImage = buttons[question.GetCorrind()].GetComponent<Image>();
            buttonImage.sprite = corrAnsSprite;
        }
        SetButtonState(false);
    }

    private void DisplayQuestion()
    {
        questiontext.text = question.GetQuestion();

        for (var i = 0; i < buttons.Length; i++)
        {
            var buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
