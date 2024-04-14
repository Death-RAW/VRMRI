using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController6 : MonoBehaviour
{
    public AudioClip[] audioClips;
    public string nextSceneName; // Name of the scene to transition to next
    public AudioSource audioSource; // AudioSource component to play the audio clips
    public Transform xrRigOrigin; // Reference to the XR rig origin
    public Vector3 teleportPosition; // Target position to teleport the XR rig origin
    private bool isPlaying = false;

    // Ensure that only one instance of SceneController exists
    private static SceneController6 instance;

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
        DontDestroyOnLoad(gameObject);

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
        for (int i = 0; i < audioClips.Length; i++)
        {
            AudioClip clip = audioClips[i];
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);

            // Teleport XR rig origin after the second voice clip
            if (i == 1)
            {
                TeleportXR();
            }
        }

        Debug.Log("Everything has been said");
        isPlaying = false;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    // Teleport the XR rig origin
    void TeleportXR()
    {
        if (xrRigOrigin != null)
        {
            xrRigOrigin.position = teleportPosition;
        }
        else
        {
            Debug.LogError("XR rig origin not assigned!");
        }
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
