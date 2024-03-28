using UnityEngine;
using System.Collections;

public class HallwayAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    public Transform xrRigTransform;
    void Start()
    {
        if (clips.Length == 0)
        {
            Debug.LogError("No AudioClips assigned to the 'clips' array.");
            return;
        }
        StartCoroutine(MyCoroutine());
    }

    void Update()
    {
        if (clips.Length == 2)
        {   
            if (GetPosition().z < 2f)
            {
                // Wait for trigger (going past the couches)
                PlayAndRemoveClip();
            }
        }
    }

    // Play the first AudioClip and remove it from the array
    public void PlayAndRemoveClip()
    {
        if (clips.Length > 0)
        {
            source.clip = clips[0];
            Debug.Log(clips[0]);
            source.Play();

            // Remove the first clip from the array
            RemoveClipAtIndex(0);
        }
    }

    // Remove the AudioClip at the specified index from the array
    private void RemoveClipAtIndex(int index)
    {
        if (index >= 0 && index < clips.Length)
        {
            for (int i = index; i < clips.Length - 1; i++)
            {
                clips[i] = clips[i + 1];
            }
            System.Array.Resize(ref clips, clips.Length - 1);
        }
    }
    // Get the position of the XR Rig (which should be the same as the headset position)
    private Vector3 GetPosition()
    {
        return xrRigTransform.position;
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("Before WaitForSeconds");
        yield return new WaitForSeconds(20); // Wait for 20 second
        // Trigger the HallwayAudio script to play the last clip
        PlayAndRemoveClip();
        Debug.Log("After WaitForSeconds");
    }
}
