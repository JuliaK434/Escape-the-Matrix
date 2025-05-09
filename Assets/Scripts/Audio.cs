using UnityEngine;
using UnityEngine.UI; // ��������� ��� ������ � UI

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = -1;

    // ������ �� ������� ��������� (����� ���������� � ����������)
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

        // ���� Slider �� �������� �������, ��������� ����� ��� �������������
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.Find("VolumeSlider")?.GetComponent<Slider>();
        }

        // ��������� ����� ChangeVolume ��� ���������� ��������� ��������
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            volumeSlider.value = audioSource.volume; // ������������� ������� ���������
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
        // �������������: ��������� ��������� � PlayerPrefs, ����� ��� ����������� ����� ���������
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}