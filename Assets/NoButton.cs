using UnityEngine;

public class NoButton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the hand (or another interactable object)
        if (other.CompareTag("hand"))
        {
            Debug.Log("No button pressed!");
            // Send a message to the TabletUI script to call its OnNoButtonClick method
            transform.parent.SendMessage("OnNoButtonClick", SendMessageOptions.DontRequireReceiver);
        }
    }
}
