using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    public GameObject xrRigObject;
    public Transform teleportLocation; // The location to teleport to
    public float desiredRotationY = 180f;
    void Start()
    {
        // Invoke the Teleport function after 10 seconds
        Invoke("Teleport", 15f);
    }

    void Teleport()
    {
        // Check if the xrRigObject and teleportLocation are assigned
        if (xrRigObject != null && teleportLocation != null)
        {
            // Teleport the xrRigObject to the specified location
            xrRigObject.transform.rotation = Quaternion.Euler(0f, desiredRotationY, 0f);
            xrRigObject.transform.position = teleportLocation.position;
        }
        else
        {
            Debug.LogWarning("xrRigObject or teleportLocation is not assigned.");
        }
    }
}