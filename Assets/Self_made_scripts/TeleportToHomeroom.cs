using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButton : MonoBehaviour
{
    // Specify the name of the scene you want to load
    public string sceneToLoad = "Homeroom";

    // This function will be called when the button is clicked
    public void TeleportToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}