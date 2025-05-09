using UnityEngine;
using UnityEngine.UI; // Добавляем для работы с UI

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = -1;

    // Ссылка на слайдер громкости (можно перетащить в инспекторе)
    public Slider volumeSlider;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Если Slider не назначен вручную, попробуем найти его автоматически
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.Find("VolumeSlider")?.GetComponent<Slider>();
        }

        // Назначаем метод ChangeVolume как обработчик изменения слайдера
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            volumeSlider.value = audioSource.volume; // Устанавливаем текущую громкость
        }

        PlayNextTrack();
    }

    public void PlayNextTrack()
    {
        if (musicTracks.Length == 0) return;
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
        // Дополнительно: сохраняем громкость в PlayerPrefs, чтобы она сохранялась между запусками
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}