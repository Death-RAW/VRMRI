using UnityEngine;

public class VirtualButtonOnTabletYes : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the hand (or another interactable object)
        if (other.CompareTag("hand"))
        {
            Debug.Log("Yes utton Pressed on Tablet!");
            // Perform any action you want the button to do here
        }
    }
}
