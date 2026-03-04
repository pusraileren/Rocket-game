using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject spawner;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseScoreText;

    public AudioSource arcadeMusic;
    public AudioSource winSound;
    public AudioSource loseSound;

    float timer = 0f;
    int score = 0;

    public int winScore = 80;

    bool isPlaying = false;

    void Start()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        spawner.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;

        score = Mathf.FloorToInt(timer);

        timerText.text = "TIME: " + score;
        scoreText.text = "SCORE: " + score;

        if (score >= winScore)
        {
            WinGame();
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);

        spawner.SetActive(true);

        timer = 0;
        score = 0;

        isPlaying = true;

        arcadeMusic.Play();
    }

    public void LoseGame()
    {
        isPlaying = false;

        gamePanel.SetActive(false);
        losePanel.SetActive(true);

        spawner.SetActive(false);

        loseScoreText.text = "YOUR SCORE: " + score;

        arcadeMusic.Stop();
        loseSound.Play();
    }

    void WinGame()
    {
        isPlaying = false;

        gamePanel.SetActive(false);
        winPanel.SetActive(true);

        spawner.SetActive(false);

        arcadeMusic.Stop();
        winSound.Play();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}