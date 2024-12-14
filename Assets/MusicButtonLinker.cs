using UnityEngine;
using UnityEngine.UI;

public class MusicButtonLinker : MonoBehaviour
{
    private Button muteButton;

    private void Awake()
    {
        // Find the MusicManager at runtime
        GameObject musicManager = GameObject.Find("MusicManager");

        if (musicManager != null)
        {
            // Get the Button component
            muteButton = GetComponent<Button>();

            // Add the MusicManager's ToggleMusic method to the button's OnClick
            muteButton.onClick.AddListener(musicManager.GetComponent<MusicManager>().ToggleMusic);
        }
        else
        {
            Debug.LogWarning("MusicManager not found in the scene.");
        }
    }
}
