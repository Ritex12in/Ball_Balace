using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;

public class GameControlScript : MonoBehaviour
{
    public AudioSource audio;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject scoreObject;
    public GameObject Cam1;
    public GameObject Cam2;
    public Text scoreText;
    public Text finalScore;
    public Text highScoreMain;
    public Text highScorepanel;
    public GameObject highScoreObject;
    public GameObject gamePausePanel;
    public GameObject gameOverPanel;
    public GameObject gameExitPanel;
    private int score;
    public Transform plankTransform;
    public BallMovement bm;
    private bool isgameOver;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        bm.enabled = false;
        score = 0;
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        playButton.SetActive(true);
        scoreObject.SetActive(false);
        pauseButton.SetActive(false);
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameExitPanel.SetActive(false);
        highScoreObject.SetActive(true);

        highScoreMain.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                gameExitPanel.SetActive(true);
                return;
            }
        }
        scoreText.text = "Score: " + score.ToString();

        Vector3 plankPos = plankTransform.position;
        if(plankPos.y<-2 && !isgameOver){
            gameOver();
        }
        
    }

    public void setScore()
    {
            score+=1;
    }

    public void hideGameExitPanel()
    {
        Time.timeScale = 1f;
        gameExitPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void pauseGame()
    {
        gamePausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void gameOver()
    {
        isgameOver = true;
        audio.Play();
        if(score> PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
        highScorepanel.text = "Highest Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOverPanel.SetActive(true);
        scoreObject.SetActive(false);
        pauseButton.SetActive(false);
        finalScore.text = "Total score: "+ score.ToString();
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void startGame()
    {
        isgameOver = false;
        Time.timeScale = 1f;
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        bm.enabled = true;
        playButton.SetActive(false);
        scoreObject.SetActive(true);
        pauseButton.SetActive(true);
        gamePausePanel.SetActive(false);
        highScoreObject.SetActive(false);
    }
}
