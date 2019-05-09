using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    int FinalScore;
    int FinalDestroyedBoxes;
    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Text DestroyedBoxesText;
    GameManager gameManager;

    void Awake()
    {
        if (!GameManager.Instance)
        {
            gameManager = new GameManager();
        }
        else
        {
            gameManager = GameManager.Instance;
        }
        FinalScore = gameManager.Score;
        FinalDestroyedBoxes = gameManager.DestroyedBoxes;
    }

    private void OnEnable()
    {
        if(ScoreText)
            ScoreText.text = "Score: " + FinalScore.ToString();
        if(DestroyedBoxesText)
            DestroyedBoxesText.text = "Destroyed Boxes: " + FinalDestroyedBoxes;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
