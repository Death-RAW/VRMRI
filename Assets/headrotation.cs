using UnityEngine;

public class headrotation : MonoBehaviour
{
    private void Update()
    {
        // Reset the rotation of the camera to prevent head movement
        transform.rotation = Quaternion.identity;
    }
}
