using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChairTeleportationAnchor : MonoBehaviour
{
    // Reference to the HallwayAudio script
    public HallwayAudio hallwayAudio;

    // Detect when a player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("hmd"))
        {
            Debug.Log("HMD Triggered");
            StartCoroutine(MyCoroutine());

        }
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("Before WaitForSeconds");
        yield return new WaitForSeconds(1); // Wait for 1 second
        // Trigger the HallwayAudio script to play the last clip
        if (hallwayAudio != null)
        {
            hallwayAudio.PlayAndRemoveClip();
        }
        Debug.Log("After WaitForSeconds");
        yield return new WaitForSeconds(3);

        // Load the hallway scene
        SceneManager.LoadScene("cannulation_room");
    }
}