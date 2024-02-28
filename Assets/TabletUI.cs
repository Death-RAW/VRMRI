using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class TabletUI : MonoBehaviour
{
    public GameObject tabletObject; // Reference to the tablet GameObject
    public GameObject[] pictureObjects; // Array of picture game objects to show
    public string[] pictureNames; // Names of the pictures corresponding to each game object

    private XRGrabInteractable tabletGrabInteractable; // Reference to the XRGrabInteractable component of the tablet
    private bool tabletCaught = false; // Flag to track if tablet is caught or not
    private int currentPictureIndex = 0; // Index of the currently displayed picture
    public int MaxNumberPictures = 6;
    public GameObject xrCamera;
    void Start()
    {
    
        tabletGrabInteractable = tabletObject.GetComponent<XRGrabInteractable>(); // Get the XRGrabInteractable component
        if (tabletGrabInteractable == null)
        {
            Debug.LogError("Tablet grab interactable is not assigned!");
        }
        
        // Disable all picture game objects at the start and show first pic
        DisableAllPictures();
        ShowNextPicture();
    }

    void DisableAllPictures()
    {
        foreach (GameObject pictureObject in pictureObjects)
        {
            pictureObject.SetActive(false);
        }
    }

    // Called when the "Yes" button is clicked
    public void OnYesButtonClick()
    {
        Debug.Log("Yes button clicked!");
        // Show the next picture
        ShowNextPicture();
    }

    // Called when the "No" button is clicked
    public void OnNoButtonClick()
    {
        Debug.Log("No button clicked!");
        // Show the next picture
        ShowNextPicture();
    }

    void ShowNextPicture()
    {
        if (currentPictureIndex == MaxNumberPictures){
            // Call the nurse saying come in
            SceneManager.LoadScene("MRI_Room", LoadSceneMode.Additive);
        }
        // Disable the current picture
        pictureObjects[currentPictureIndex].SetActive(false);

        // Increment index to show the next picture
        currentPictureIndex = (currentPictureIndex + 1) % pictureObjects.Length;

        // Enable the next picture
        pictureObjects[currentPictureIndex].SetActive(true);
    }

    void ShowPicture(int index)
    {
        // Enable the specified picture
        pictureObjects[index].SetActive(true);
    }
    void MoveXRCameraToPosition(Vector3 position)
    {
        if (xrCamera != null)
        {
            xrCamera.transform.position = position;
        }
    }
    bool IsOculusIntegrationPresent()
    {
        return typeof(OVRInput) != null;
    }
}
