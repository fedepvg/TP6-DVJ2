using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    int score;
    int destroyedBoxes;
    const int ScorePerBox = 100;
    const int ScorePerBoxOnFloor = -50;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static GameManager Instance
    {
        get { return instance; }
    }

    public int Score
    {
        get { return score; }
        set { score=value; }
    }

    public int DestroyedBoxes
    {
        get { return destroyedBoxes; }
        set { destroyedBoxes = value; }
    }

    public void AddBoxDestroyed(bool OnFloor)
    {
        destroyedBoxes++;
        if(!OnFloor)
        {
            score += ScorePerBox;
        }
        else
        {
            score += ScorePerBoxOnFloor;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndGameScene");
    }
}
