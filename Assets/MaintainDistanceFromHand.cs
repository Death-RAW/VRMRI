using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaintainDistanceFromHand : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private XRBaseInteractor currentInteractor;
    private float distanceFromHand = 0.5f; // Adjust this value to set the desired distance from the hand

    [System.Obsolete]
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component not found on GameObject.");
        }
        else
        {
            grabInteractable.onSelectEnter.AddListener(OnSelectEnter);
            grabInteractable.onSelectExit.AddListener(OnSelectExit);
        }
    }

    private void Update()
    {
        if (currentInteractor != null)
        {
            // Calculate the new position 2 meters away from the interactor's position
            Vector3 newPosition = currentInteractor.transform.position + currentInteractor.transform.forward * distanceFromHand;

            // Update the position of the interactable object
            transform.position = newPosition;
        }
    }

    private void OnSelectEnter(XRBaseInteractor interactor)
    {
        currentInteractor = interactor;
    }

    private void OnSelectExit(XRBaseInteractor interactor)
    {
        currentInteractor = null;
    }
}
