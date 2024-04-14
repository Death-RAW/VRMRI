using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController7 : MonoBehaviour
{
    public AudioClip[] audioClips;
    public string nextSceneName; // Name of the scene to transition to next
    public AudioSource audioSource; // AudioSource component to play the audio clips
    private bool isPlaying = false;

    // Ensure that only one instance of SceneController exists
    private static SceneController7 instance;

    void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // Destroy the duplicate instance
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Mark the GameObject as "Don't Destroy On Load"

        // Start playing the audio clips
        StartCoroutine(PlayAudioThenLoadScene());
    }

    IEnumerator PlayAudioThenLoadScene()
    {
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource assigned to SceneController.");
            yield break;
        }

        isPlaying = true;

        // Play each audio clip sequentially
        foreach (AudioClip clip in audioClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }

        isPlaying = false;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    // Check if the audio is still playing
    public bool IsPlaying()
    {
        return isPlaying;
    }

    void OnDestroy()
    {
        Debug.Log("SceneController destroyed");
    }
}
