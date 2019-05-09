using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public int DestroyedBoxes
    {
        get { return destroyedBoxes; }
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
        Debug.Log(score);
    }
}
