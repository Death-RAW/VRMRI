/*using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public AudioClip carHumSound;
    public float homeroomDuration = 50f;
    public float hallwayDelay = 15f;

    private AudioSource audioSource;

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

        // Initialize the audioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Start the homeroom scene
        StartCoroutine(LoadIntermediateAndHallway());
    }

    IEnumerator LoadIntermediateAndHallway()
    {
        // Wait for the homeroom duration
        yield return new WaitForSeconds(homeroomDuration);

        // Play car sound after the homeroom duration
        if (audioSource != null && carHumSound != null)
        {
            audioSource.clip = carHumSound;
            audioSource.Play();
        }

        // Load the intermediate "black" scene
        SceneManager.LoadScene("IntermediateScene");
        // Wait for the specified hallway delay before transitioning to the hallway scene
        yield return new WaitForSeconds(hallwayDelay);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if (scene.name == "IntermediateScene")
        {
            Debug.Log("Additional setup for IntermediateScene");

            // Wait for the specified hallway delay before transitioning to the hallway scene
            StartCoroutine(WaitAndLoadHallway());
        }
    }

    IEnumerator WaitAndLoadHallway()
    {
        Debug.Log("Waiting for hallwayDelay before loading Hallway");

        // Wait for the specified hallway delay before transitioning to the hallway scene
        yield return new WaitForSeconds(hallwayDelay);

        Debug.Log("Loading Hallway");

        // Load the hallway scene
        SceneManager.LoadScene("Hallway");
    }

    void OnDestroy()
    {
        Debug.Log("SceneController destroyed");
        // Unsubscribe from the sceneLoaded event when the script is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        // You can add any specific logic here if needed
    }
}
*/