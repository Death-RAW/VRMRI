using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class MRIGame : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider continuousMoveProvider;
    public GameObject xrRigObject;
    public Transform teleportDestination;
    public Quaternion teleportRotation = Quaternion.identity;
    public Transform layingDownDestination;
    public Image colorChangingImage;
    public float colorChangeThreshold = 0.03f;
    public float colorChangeSpeed = 1f; // Increase the speed
    public AudioClip[] audioClips;
    public float audioDelay = 1f;
    public float layingDownDuration = 60f;
    public float secondTeleportDelay = 10f;
    public Transform headTransform;
    public Image image;
    private bool isTeleported = false;
    private Color startColor = Color.green;
    private Color endColor = Color.red;
    private float colorChangeTimer = 0f;
    private Vector3 lastHeadPosition;
    public float desiredRotationY = 180f;

    void Awake()
    {
        if (continuousMoveProvider == null || xrRigObject == null || teleportDestination == null || layingDownDestination == null || colorChangingImage == null || audioClips == null || audioClips.Length == 0 || headTransform == null)
        {
            Debug.LogError("Ensure all required components are assigned in the inspector!");
            return;
        }

        lastHeadPosition = headTransform.position;
        if (image != null)
        {
            image.color = Color.white;
        }
        else
        {
            Debug.LogError("Image component is null. Make sure it's assigned in the inspector!");
        }

        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        if (continuousMoveProvider != null)
        {
            continuousMoveProvider.enabled = false;
        }
        else
        {
            Debug.LogError("Continuous Move Provider is null. Make sure it's assigned in the inspector!");
            yield break;
        }

        if (teleportDestination != null)
        {
            // Set the rotation to desiredRotationY degrees around the Y-axis
            xrRigObject.transform.rotation = Quaternion.Euler(0f, desiredRotationY, 0f);
            xrRigObject.transform.position = teleportDestination.position;
        }
        else
        {
            Debug.LogError("Teleport Destination is null. Make sure it's assigned in the inspector!");
            yield break;
        }

        isTeleported = true;

        foreach (var audioClip in audioClips)
        {
            if (audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, xrRigObject.transform.position);
                yield return new WaitForSeconds(audioDelay);
            }
            else
            {
                Debug.LogError("Audio Clip is null. Make sure all audio clips are assigned in the inspector!");
            }
        }
        float timeElapsed = 0f;
        while (timeElapsed < secondTeleportDelay)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        if (layingDownDestination != null)
        {
            xrRigObject.transform.rotation = Quaternion.Euler(0f, desiredRotationY, 0f);
            xrRigObject.transform.position = layingDownDestination.position;
        }
        else
        {
            Debug.LogError("Laying Down Destination is null. Make sure it's assigned in the inspector!");
            yield break;
        }
        StartCoroutine(ColorChange());

        yield return new WaitForSeconds(layingDownDuration);

        // Introduce the second teleport delay

        if (teleportDestination != null)
        {
            xrRigObject.transform.position = teleportDestination.position;
            xrRigObject.transform.rotation = teleportRotation;
        }
        else
        {
            Debug.LogError("Teleport Destination is null. Make sure it's assigned in the inspector!");
            yield break;
        }


        if (continuousMoveProvider != null)
        {
            continuousMoveProvider.enabled = true;
        }
        else
        {
            Debug.LogError("Continuous Move Provider is null. Make sure it's assigned in the inspector!");
        }

        isTeleported = false;
    }

    IEnumerator ColorChange()
    {
        Color startColor = Color.green;
        Color brightYellow = new Color(1f, 1f, 0f, 1f);
        Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
        Color orange = new Color(1f, 0.647f, 0f, 1f);
        Color endColor = Color.red;

        Color currentColor = startColor;

        float elapsedTime = 0f;
        float colorChangeInterval = 2f; // Change color every second

        while (elapsedTime < 60f) // Run for one minute
        {
            Vector3 currentHeadPosition = headTransform.position;
            float distance_x = Mathf.Abs(currentHeadPosition.x - lastHeadPosition.x);
            float distance_y = Mathf.Abs(currentHeadPosition.y - lastHeadPosition.y);
            float distance_z = Mathf.Abs(currentHeadPosition.z - lastHeadPosition.z);

            if (distance_x > colorChangeThreshold || distance_y > colorChangeThreshold || distance_z > colorChangeThreshold)
            {
                // Change the color immediately when the head position changes enough
                if (currentColor == startColor)
                    currentColor = brightYellow;
                else if (currentColor == brightYellow)
                    currentColor = yellow;
                else if (currentColor == yellow)
                    currentColor = orange;
                else if (currentColor == orange)
                    currentColor = endColor;

                // Apply the color to the image
                if (image != null)
                {
                    image.color = currentColor;
                    Debug.Log($"Color changed to: {currentColor}");
                }
                else
                {
                    Debug.LogError("Image component is null. Make sure it's assigned in the inspector!");
                }
            }

            lastHeadPosition = currentHeadPosition;
            elapsedTime += Time.deltaTime;

            yield return new WaitForSeconds(colorChangeInterval);
        }
    }
}
