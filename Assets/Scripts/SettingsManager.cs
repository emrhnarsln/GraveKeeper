using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel; // Ayarlar Paneli
    public Slider musicSlider;       // Müzik sliderı
    public Slider sfxSlider;         // SFX sliderı

    public void Pause()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("StartingScene");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
