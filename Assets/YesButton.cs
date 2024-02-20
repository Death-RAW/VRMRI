using UnityEngine;

public class YesButton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the hand (or another interactable object)
        if (other.CompareTag("hand"))
        {
            Debug.Log("Yes button pressed!");
            // Send a message to the TabletUI script to call its OnYesButtonClick method
            transform.parent.SendMessage("OnYesButtonClick", SendMessageOptions.DontRequireReceiver);
        }
    }
}
