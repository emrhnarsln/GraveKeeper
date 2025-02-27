using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text xpText; // UI Text elementine referans
    public Text highScoreText;
    public Text scoreText;
    private PlayerStats playerStats;
    void Start()
    {
        StartCoroutine(WaitForPlayerStats());
        UpdateHighScoreText();
    }

    IEnumerator WaitForPlayerStats()
    {
        while (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
            yield return null; // Bir sonraki frame'e kadar bekle
        }
        UpdateScoreText(); // İlk skor güncellemesi
    }

    void Update()
    {
        if (playerStats != null)
        {
            UpdateScoreText(); // Her karede güncelle
            UpdateHighScore();
        }
    }
    // Skoru UI Text'e yansıtan metot
    public void UpdateScoreText()
    {
        xpText.text = "XP   : " + playerStats.XP.ToString();
        scoreText.text = "Score  : " + playerStats.XP.ToString();
    }
    public void UpdateHighScore()
    {
        float currentXP = playerStats.XP;
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);

        if (currentXP > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentXP);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }
    public void UpdateHighScoreText()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "High Score : " + highScore.ToString();
    }
}
