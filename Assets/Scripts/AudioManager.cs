using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("--------------- Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------------- Audio Clip --------------")]
    public AudioClip background;
    public AudioClip gameBackground;
    public AudioClip bossBackground;
    public AudioClip death;
    public AudioClip victory;
    public AudioClip damage;

    private void Awake()
    {
        // AudioManager'in sahne geçişinde yok olmaması için
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Sahne yüklendiğinde tetiklenen olay
        PlayMusic(background); // Başlangıç sahnesinde arka plan müziği başlatılır
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "StartingScene":
            case "SelectionScene":
                if (musicSource.clip != background)
                    PlayMusic(background);
                break;

            case "GameScene":
                if (musicSource.clip != gameBackground)
                    PlayMusic(gameBackground);
                break;

            case "FinalBossScene":
                if (musicSource.clip != bossBackground)
                    PlayMusic(bossBackground);
                break;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void GameOver()
    {
        PlayMusic(death); // Ölüm ses efekti çalınır
    }

    public void Victory()
    {
        PlayMusic(victory); // Zafer ses efekti çalınır
    }

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.isPlaying && musicSource.clip == clip)
            return; // Aynı müzik zaten çalıyorsa bir şey yapma

        musicSource.clip = clip;
        musicSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Olay aboneliği temizlenir
    }
}
