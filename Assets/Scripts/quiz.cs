using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    [SerializeField] private GameObject[] buttons;

    void Start()        
    {
        questiontext.text = question.GetQuestion();

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI buttonText = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }
    
}
