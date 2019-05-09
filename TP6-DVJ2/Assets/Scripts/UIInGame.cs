using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    int DestroyeBoxes;
    int Score;
    [SerializeField]
    private Text DestroyedBoxesText;
    [SerializeField]
    private Text ScoreText;


    private void Update()
    {
        int ActualDestroyedBoxes = GameManager.Instance.DestroyedBoxes;
        int ActualScore = GameManager.Instance.Score;

        if (ActualDestroyedBoxes != DestroyeBoxes)
        {
            DestroyeBoxes = ActualDestroyedBoxes;
            DestroyedBoxesText.text = "Destroyed Boxes: " + DestroyeBoxes;
        }
        if (ActualScore != Score)
        {
            Score = ActualScore;
            ScoreText.text = "Score: " + Score;
        }
    }
}
