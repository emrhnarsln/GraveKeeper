using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Bu fonksiyon sahne değiştirir
    public void LoadCharacterSelectionScene()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.ResetTimer(); // Zamanlayıcıyı sıfırla
            Debug.Log("Burası calisti");
        }
        Time.timeScale = 1f; // Zamanı başlat
        SceneManager.LoadScene("SelectionScene");
    }

        public void StartBossFight()
    {
        
        SceneManager.LoadScene("FinalBossScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
