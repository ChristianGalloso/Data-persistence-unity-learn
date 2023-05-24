using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public Text GameOverText;
    public Button TryAgainButton;
    public Button BackToMainMenuButton;
    public bool m_started = false;  
    public int m_Points;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.NumberTries>0)
        {
            HighScoreText.text = "HighScore: " + GameManager.Instance.HighScore;
        }
        GameManager.Instance.IsGameOver = false;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (m_started == false)
        {
            GameManager.Instance.NumberTries++;
            m_started = true;
            float randomDirection = Random.Range(-1.0f, 1.0f);
            Vector3 forceDir = new Vector3(randomDirection, 1, 0);
            forceDir.Normalize();

            Ball.transform.SetParent(null);
            Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
        }
    }
    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver( bool Victory)
    {
        GameOverText.gameObject.SetActive(true);
        if (Victory == true)
        {
         GameOverText.text = "YOU WON!";
        }
        else
        {
         GameOverText.text = "GAME OVER";
        }
        TryAgainButton.gameObject.SetActive(true);
        BackToMainMenuButton.gameObject.SetActive(true);
        GameManager.Instance.IsGameOver= true;
        if (m_Points> GameManager.Instance.HighScore)
        {
        GameManager.Instance.HighScore = m_Points;
        }
    }
}
