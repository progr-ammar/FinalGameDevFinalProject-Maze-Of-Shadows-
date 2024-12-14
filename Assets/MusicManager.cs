using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Music for menu and non-gameplay scenes
    public AudioClip easyLevelMusic; // Music for Easy level
    public AudioClip hardLevelMusic; // Music for Hard level
    public AudioClip bonusLevelMusic; // Music for Bonus level

    private AudioSource audioSource; // Audio source for music playback
    private static MusicManager instance; // Singleton instance
    private bool isMusicOn = true; // Tracks whether music is on or off

    private void Awake()
    {
        // Ensure a single instance of MusicManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicates
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        // Start with menu music
        PlayMusic(menuMusic);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene load event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the scene name and play corresponding music
        switch (scene.name)
        {
            case "Easy":
                PlayMusic(easyLevelMusic);
                break;
            case "Hard":
                PlayMusic(hardLevelMusic);
                break;
            case "Bonus":
                PlayMusic(bonusLevelMusic);
                break;
            default:
                PlayMusic(menuMusic); // Default to menu music
                break;
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Attempted to play a null AudioClip.");
            return;
        }

        if (audioSource.clip == clip) return; // Avoid restarting the same music
        audioSource.clip = clip;
        audioSource.loop = true; // Loop the music
        audioSource.Play();
    }

    // Method to toggle music on/off
    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        audioSource.mute = !isMusicOn; // Mute or unmute the music
    }
}
