using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MRIGame : MonoBehaviour
{
    public GameObject xrRigObject;
    public Transform teleportDestination;
    public Quaternion teleportRotation = Quaternion.identity;
    public Transform layingDownDestination;
    public Image colorChangingImage;
    public float colorChangeThreshold = 0.03f;
    public AudioClip[] audioClips;
    public AudioClip[] audioClips2;
    public float audioDelay = 1f;
    public float layingDownDuration = 60f;
    public float secondTeleportDelay = 10f;
    public Transform headTransform;
    public Image image;
    private bool isTeleported = false;
    private Vector3 lastHeadPosition;
    public float desiredRotationY = 180f;
    public AudioClip MRInoise;
    private AudioSource audioSource;
    private Vector3 initialPosition;

    void Awake()
    {
        if (xrRigObject == null || teleportDestination == null || layingDownDestination == null || colorChangingImage == null || audioClips == null || audioClips.Length == 0 || headTransform == null)
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
        initialPosition = xrRigObject.transform.position;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Sequence());
    }

    void Update()
    {
        // Lock Y position of the XR rig object
        Vector3 currentPosition = xrRigObject.transform.position;
        xrRigObject.transform.position = new Vector3(currentPosition.x, initialPosition.y, currentPosition.z);
    }

    IEnumerator Sequence()
    {
        if (teleportDestination != null)
        {
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
                audioSource.PlayOneShot(audioClip);
                yield return new WaitForSeconds(audioClip.length);
            }
            else
            {
                Debug.LogError("Audio Clip is null. Make sure all audio clips are assigned in the inspector!");
            }
        }

        yield return new WaitForSeconds(secondTeleportDelay);

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

        foreach (var audioClip in audioClips2)
        {
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
                yield return new WaitForSeconds(audioClip.length);
            }
            else
            {
                Debug.LogError("Audio Clip is null. Make sure all audio clips are assigned in the inspector!");
            }
        }

        if (MRInoise != null)
        {
            audioSource.PlayOneShot(MRInoise);
        }

        StartCoroutine(ColorChange());

        yield return new WaitForSeconds(layingDownDuration);

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

        isTeleported = false;
    }

    IEnumerator ColorChange()
{
    lastHeadPosition = headTransform.position;
    Color startColor = Color.green;
    Color brightYellow = new Color(1f, 1f, 0f, 1f);
    Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
    Color lightOrange = new Color(1f, 0.8f, 0.1f, 1f);
    Color orange = new Color(1f, 0.647f, 0f, 1f);
    Color darkOrange = new Color(1f, 0.5f, 0f, 1f);
    Color redOrange = new Color(1f, 0.2f, 0f, 1f);
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
            if (currentColor == startColor)
                currentColor = brightYellow;
            else if (currentColor == brightYellow)
                currentColor = yellow;
            else if (currentColor == yellow)
                currentColor = lightOrange;
            else if (currentColor == lightOrange)
                currentColor = orange;
            else if (currentColor == orange)
                currentColor = darkOrange;
            else if (currentColor == darkOrange)
                currentColor = redOrange;
            else if (currentColor == redOrange)
                currentColor = endColor;

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
