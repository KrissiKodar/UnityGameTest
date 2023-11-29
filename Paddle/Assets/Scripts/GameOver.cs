using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject duringGame;

    public TMPro.TextMeshProUGUI scoreLabel;
    public TMPro.TextMeshProUGUI highScoreLabel;
    public static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void OnGameOver()
    {
        duringGame.SetActive(false);
        gameOverScreen.SetActive(true);
        string currentScore = GameManager.instance.score.ToString();
        scoreLabel.text = currentScore;
        highScoreLabel.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        GameManager.instance.score = 0;
        gameOver = true;
    }
}
