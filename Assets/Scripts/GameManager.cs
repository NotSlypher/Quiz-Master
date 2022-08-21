using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private quiz Quiz;
    private EndScreen endScreen;

    void Awake()
    {
        Quiz = FindObjectOfType<quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    void Start()
    {
        Quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Quiz.isComplete)
        {
            Quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.showFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
