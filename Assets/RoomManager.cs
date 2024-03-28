using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.Video;
using System.Threading;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour{
    public AudioClip carSound;
    public float initialDelay = 2f;
    public float audioStartDelay = 17f;
    public float audioStopTime = 34f;
    public GameObject xrCamera;
    private AudioSource audioSource;
    public GameObject mother;
    void Start()
    {
        GameObject videoPlane = GameObject.Find("videoPlane");
        if (videoPlane != null)
        {
            VideoPlayer videoPlayer = videoPlane.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.enabled = false; // Disable the VideoPlayer component
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on the GameObject named 'videoPlane'.");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'videoPlane' not found.");
        }
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

        // // Move XR Camera (XR Rig) to the first position
        // MoveXRCameraToPosition(new Vector3(-12.62f, 0.6f, 31.819f));
        // Debug.Log("XR Camera (XR Rig) moved to the first position. Current position: " + GetXRCameraPosition());

        // // Wait for the specified duration
        // yield return new WaitForSeconds(audioStartDelay);
        // Debug.Log("Waited for audio start delay.");

        // Move XR Camera (XR Rig) to the 2 position
        MoveXRCameraToPosition(new Vector3(-38.88f, 0.327f, 16.296f));
        Debug.Log("XR Camera (XR Rig) moved to the 2 position. Current position: " + GetXRCameraPosition());

        GameObject videoPlane = GameObject.Find("videoPlane");
        if (videoPlane != null)
        {
            VideoPlayer videoPlayer = videoPlane.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.enabled = true; // enable the VideoPlayer component
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on the GameObject named 'videoPlane'.");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'videoPlane' not found.");
        }
        
        // Start playing car sound
        StartCarSound();
        Debug.Log("Car sound started.");

        // Wait for the specified duration
        yield return new WaitForSeconds(audioStopTime - audioStartDelay);
        Debug.Log("Waited for audio stop time.");

        // Stop the car sound
        StopCarSound();
        Debug.Log("Car sound stopped.");
        MoveMotherToPosition(new Vector3(-6.712f, 0.01f, 10.099f));

        // Move XR Camera (XR Rig) to the final position
        MoveXRCameraToPosition(new Vector3(-6.59f, 0.584f, 9.073f));
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
    }/* 
    private void DisableHeadRotationAfterDuration()
    {
        if (headrotation != null)
        {
            headrotation.enabled = false; // Disable head rotation
        }
    } */

    void MoveXRCameraToPosition(Vector3 position)
    {
        if (xrCamera != null)
        {
            xrCamera.transform.position = position;
        }
    }
    void MoveMotherToPosition(Vector3 position)
    {
        if (mother != null)
        {
            mother.transform.position = position;
        }
    }

    void StartCarSound()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    void StopCarSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
                    GameObject videoPlane = GameObject.Find("videoPlane");
        if (videoPlane != null)
        {
            VideoPlayer videoPlayer = videoPlane.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.enabled = false; // Disable the VideoPlayer component
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on the GameObject named 'videoPlane'.");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'videoPlane' not found.");
        }
        
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
    void VideoPlayerErrorReceived(VideoPlayer source, string message)
    {
        Debug.LogError("VideoPlayer Error: " + message);
    }

    void VideoPlayerPrepareCompleted(VideoPlayer source)
    {
        Debug.Log("VideoPlayer Prepare Completed");
    }

    void VideoPlayerStarted(VideoPlayer source)
    {
        Debug.Log("VideoPlayer Started");
    }

    void VideoPlayerLoopPointReached(VideoPlayer source)
    {
        Debug.Log("VideoPlayer Loop Point Reached");
    }
}
