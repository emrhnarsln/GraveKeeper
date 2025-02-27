using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText; // Timer UI text referansı
    public float timeRemaining = 0f; // Zamanlayıcı süresi
    private string targetSceneName = "FinalBossScene";
    private string giris = "StartingScene";
    private string selection = "SelectionScene";

    void Start()
    {
        // PlayerPrefs'ten zamanı al, yoksa varsayılan değeri ata
        timeRemaining = PlayerPrefs.GetFloat("TimeLeft", 0f);
    }
    void Update()
    {
        // Zamanlayıcıyı her saniye artır
        timeRemaining += Time.deltaTime;

        // Zamanlayıcıyı ekranda göster
        int totalSeconds = Mathf.FloorToInt(timeRemaining); // Sadece tam saniyeleri al
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        timerText.text = $"Time: {minutes:00}:{seconds:00}"; // UI'da göster

        // Süreyi PlayerPrefs'e kaydet
        PlayerPrefs.SetFloat("TimeLeft", timeRemaining);

        // Hedef sahneye geçiş şartını kontrol et
        if (timeRemaining >= 60f && SceneManager.GetActiveScene().name != targetSceneName && SceneManager.GetActiveScene().name != giris  && SceneManager.GetActiveScene().name != selection)
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 0f;
        PlayerPrefs.SetFloat("TimeLeft", 0f);
    }
}
