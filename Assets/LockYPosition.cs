using UnityEngine;

public class LockYPosition : MonoBehaviour
{
    private float originalYPosition;

    void Start()
    {
        // Store the original Y position when the script starts
        originalYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        // Lock the Y position to the original value
        transform.position = new Vector3(transform.position.x, originalYPosition, transform.position.z);
    }
}
