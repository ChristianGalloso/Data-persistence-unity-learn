using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI NumberTriesText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadData();
        if (GameManager.Instance.NumberTries > 0)
        {
            HighScoreText.text = "HighScore: " + GameManager.Instance.HighScore;
            NumberTriesText.text = "You have played " + GameManager.Instance.NumberTries + " times";
        }
    }


}
