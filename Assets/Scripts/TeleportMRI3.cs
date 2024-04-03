using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportMRI3 : MonoBehaviour
{
    // Specify the name of the scene you want to load
    public string sceneToLoad = "MRIroom3";

    // This function will be called when the button is clicked
    public void TeleportToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}