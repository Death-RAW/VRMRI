using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public AudioClip carSound;
    public float initialDelay = 2f;
    public float audioStartDelay = 17f;
    public float audioStopTime = 34f;

    [Tooltip("Drag the XR Interaction Manager's Camera GameObject here.")]
    public GameObject xrCamera;

    private AudioSource audioSource;

    void Start()
    {
        // Start the room sequence
        StartCoroutine(RoomSequence());
    }

    IEnumerator RoomSequence()
    {
        Debug.Log("Starting room sequence...");

        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("Initial delay completed.");

        // Attempt to find XR Camera if not assigned in the Inspector
        if (xrCamera == null)
        {
            FindXRCamera();
        }

        // Move XR Camera (XR Rig) to the first position
        MoveXRCameraToPosition(new Vector3(-12.62f, 0.6f, 31.819f));
        Debug.Log("XR Camera (XR Rig) moved to the first position. Current position: " + GetXRCameraPosition());

        // Wait for the specified duration
        yield return new WaitForSeconds(audioStartDelay);
        Debug.Log("Waited for audio start delay.");

        // Move XR Camera (XR Rig) to the 2 position
        MoveXRCameraToPosition(new Vector3(-36.26f, 0.6f, 15.99f));
        Debug.Log("XR Camera (XR Rig) moved to the 2 position. Current position: " + GetXRCameraPosition());
        
        // Start playing car sound
        StartCarSound();
        Debug.Log("Car sound started.");

        // Wait for the specified duration
        yield return new WaitForSeconds(audioStopTime - audioStartDelay);
        Debug.Log("Waited for audio stop time.");

        // Stop the car sound
        StopCarSound();
        Debug.Log("Car sound stopped.");

        // Move XR Camera (XR Rig) to the final position
        MoveXRCameraToPosition(new Vector3(-5.715f, 0.6f, 9.917f));
        Debug.Log("XR Camera (XR Rig) moved to the final position. Current position: " + GetXRCameraPosition());

        Debug.Log("Room sequence completed.");

    }

    void FindXRCamera()
    {
        xrCamera = Camera.main.gameObject;
        if (xrCamera == null)
        {
            Debug.LogWarning("XR Camera (XR Rig) not found immediately. Will keep looking during the sequence.");
        }
    }

    void MoveXRCameraToPosition(Vector3 position)
    {
        if (xrCamera != null)
        {
            xrCamera.transform.position = position;
        }
    }

    void StartCarSound()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (audioSource != null && carSound != null)
        {
            audioSource.clip = carSound;
            audioSource.Play();
        }
    }

    void StopCarSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    string GetXRCameraPosition()
    {
        if (xrCamera != null)
        {
            return xrCamera.transform.position.ToString();
        }
        return "XR Camera (XR Rig) not found.";
    }

}
