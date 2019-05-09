using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    private Button Button;

    void Awake()
    {
        if (Button == null)
            Button = GetComponent<Button>();

        Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if(GameManager.Instance)
        {
            GameManager.Instance.Score = 0;
            GameManager.Instance.DestroyedBoxes = 0;
        }
        SceneManager.LoadScene("Level1");
    }
}
