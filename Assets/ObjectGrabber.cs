using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public Transform leftHandTransform; // Reference to the left hand transform
    public Transform rightHandTransform; // Reference to the right hand transform
    public float grabRange = 0.1f; // The range within which the object is grabbed
    public float distanceFromEyes = 0.5f; // Distance from the eyes when grabbed

    private bool isGrabbed = false; // Flag to track if the object is grabbed

    void Update()
    {
        if (!isGrabbed && (IsHandInRange(leftHandTransform) || IsHandInRange(rightHandTransform)))
        {
            GrabObject();
        }
    }

    bool IsHandInRange(Transform handTransform)
    {
        return handTransform != null && Vector3.Distance(transform.position, handTransform.position) < grabRange;
    }

    void GrabObject()
    {
        isGrabbed = true;
        // Attach the object to the closest hand
        Transform closestHand = GetClosestHand();
        transform.parent = closestHand;
        // Disable physics to prevent unnecessary collisions
        GetComponent<Rigidbody>().isKinematic = true;
        // Move the object closer to the player's eyes
        transform.position = closestHand.position + closestHand.forward * distanceFromEyes;
    }

    Transform GetClosestHand()
    {
        if (IsHandInRange(leftHandTransform) && IsHandInRange(rightHandTransform))
        {
            // Both hands are in range, return the closest one
            if (Vector3.Distance(transform.position, leftHandTransform.position) <
                Vector3.Distance(transform.position, rightHandTransform.position))
            {
                return leftHandTransform;
            }
            else
            {
                return rightHandTransform;
            }
        }
        else if (IsHandInRange(leftHandTransform))
        {
            return leftHandTransform;
        }
        else if (IsHandInRange(rightHandTransform))
        {
            return rightHandTransform;
        }
        else
        {
            // Neither hand is in range, return null
            return null;
        }
    }

    void ReleaseObject()
    {
        isGrabbed = false;
        // Release the object from the hand
        transform.parent = null;
        // Enable physics to allow collisions and interactions
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnTriggerExit(Collider other)
    {
        // Release the object if the hand moves away
        if (other.gameObject.CompareTag("Hand"))
        {
            ReleaseObject();
        }
    }
}
