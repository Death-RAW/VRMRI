using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void QuitGame()
    {
        // This will only work in a standalone build, not in the Unity editor
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}