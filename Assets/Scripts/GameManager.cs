using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    public GameObject gameOverPanel; // Game Over UI paneli
    public GameObject victoryPanel; // Victory UI paneli

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Singleton olarak ayarla
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowGameOverScreen(float score)
    {
        gameOverPanel.SetActive(true); // Game Over panelini aç
        CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true; // Butonları aktif et
            canvasGroup.blocksRaycasts = true; // UI etkileşimini aktif et
        }
        Time.timeScale = 0f; // Oyunu durdur
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
    }

    public void ShowVictoryScreen(float score)
    {
        victoryPanel.SetActive(true); // Victory panelini aç
        CanvasGroup canvasGroup = victoryPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true; // Butonları aktif et
            canvasGroup.blocksRaycasts = true; // UI etkileşimini aktif et
        }
        Time.timeScale = 0f; // Oyunu durdur
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
    }

    public void RestartGame()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.ResetTimer(); // Zamanlayıcıyı sıfırla
        }
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.XP = 0; // Skoru sıfırla
        }
        Time.timeScale = 1f; // Zamanı başlat
        gameOverPanel.SetActive(false); // Game Over panelini kapat
        victoryPanel.SetActive(false); // Victory panelini kapat
        SceneManager.LoadScene("GameScene"); // Sahneyi yeniden yükles
    }
    // Main Menu'ye git
    public void GoToMainMenu()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.ResetTimer(); // Zamanlayıcıyı sıfırla
        }
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.XP = 0; // Skoru sıfırla
        }
        Time.timeScale = 1f; // Zamanı başlat
        SceneManager.LoadScene("StartingScene"); // MainMenu sahnesine geçiş yap
    }

    // Sonraki seviyeye geçiş
    public void GoToNextLevel()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.ResetTimer(); // Zamanlayıcıyı sıfırla
        }
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.XP = 0; // Skoru sıfırla
        }
        Time.timeScale = 1f; // Zamanı başlat
        SceneManager.LoadScene("SelectionScene"); // Sonraki seviyeye geçiş yap
    }
}
