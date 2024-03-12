using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public float homeroomDuration = 68f;

    // Ensure that only one instance of SceneController exists
    private static SceneController instance;

    void Awake()
    {
        
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // Destroy the duplicate instance
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Mark the GameObject as "Don't Destroy On Load"
        DontDestroyOnLoad(gameObject);

        // Start the homeroom scene
        StartCoroutine(LoadHallwayAfterDuration());
    }

    IEnumerator LoadHallwayAfterDuration()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(homeroomDuration);

        // Load the hallway scene
        SceneManager.LoadScene("Hallway");
    }

    void OnDestroy1()
    {
        Debug.Log("SceneController destroyed");
    }
}
