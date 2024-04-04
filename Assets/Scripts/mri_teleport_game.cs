using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class mri_teleport_game : MonoBehaviour
{
    public List<AudioClip> initialAudioClips;
    public List<AudioClip> readinessAudioClips;
    public Transform teleportLocation;
    public GameObject xrRigObject; // Field to assign XR Rig object
    public float teleportDelay = 3f; // Delay before teleporting after initial audio playback
    public string sceneToLoad;
    private AudioSource audioSource;
    private bool isTeleporting = false;
    public float desiredRotationY = 180f;

    void Start()
    {
        // Get AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Play initial audio clips
        StartCoroutine(PlayInitialAudioClips());
    }

    IEnumerator PlayInitialAudioClips()
    {
        // Play initial audio clips
        foreach (AudioClip clip in initialAudioClips)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length); // Wait for clip to finish playing
        }

        TeleportPlayer();
        // Wait for 30 seconds before proceeding

        yield return new WaitForSeconds(30f);

        // Execute PlayReadinessAudioClips
        StartCoroutine(PlayReadinessAudioClips());
    }

    IEnumerator PlayReadinessAudioClips()
    {
        isTeleporting = true;

        // Play readiness audio clips
        foreach (AudioClip clip in readinessAudioClips)
        {
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length); // Wait for clip to finish playing
        }

        // Wait for teleport delay
        yield return new WaitForSeconds(teleportDelay);

        // Load scene
        SceneManager.LoadScene(sceneToLoad);
    }

    void TeleportPlayer()
    {
        // Teleport player to specified location
        if (teleportLocation != null && xrRigObject != null)
        {
            xrRigObject.transform.rotation = Quaternion.Euler(0f, desiredRotationY, 0f);
            xrRigObject.transform.position = teleportLocation.position; // Fixed teleportDestination to teleportLocation
        }
        else
        {
            Debug.LogWarning("Teleport location or XR Rig object not set!");
        }
    }
}
