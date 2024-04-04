using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UniqueAudioPlayerAndSceneLoader : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public Transform teleportLocation;
    public float teleportDelay = 3f; // Delay before teleporting after audio playback
    public string sceneToLoad;
    public float sceneChangeDelay = 30f; // Delay before scene change

    private AudioSource audioSource;
    private bool isTeleporting = false;

    void Start()
    {
        // Get AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Start the coroutine for playing audio clips and teleporting after a delay
        StartCoroutine(PlayAudioClipsAndTeleport());
    }

    IEnumerator PlayAudioClipsAndTeleport()
    {
        yield return new WaitForSeconds(sceneChangeDelay);

        // Play audio clips
        foreach (AudioClip clip in audioClips)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length); // Wait for clip to finish playing
        }

        // Wait for teleport delay
        yield return new WaitForSeconds(teleportDelay);

        // Teleport player
        TeleportPlayer();

        // Load scene
        SceneManager.LoadScene(sceneToLoad);
    }

    void TeleportPlayer()
    {
        // Teleport player to specified location
        if (teleportLocation != null)
        {
            transform.position = teleportLocation.position;
        }
        else
        {
            Debug.LogWarning("Teleport location not set!");
        }
    }
}