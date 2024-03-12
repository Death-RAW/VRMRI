using System.Collections;
using UnityEngine;

public class HomeRoomAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (clips.Length > 0)
        {
            PlayNextClip();
        }
        else
        {
            Debug.LogError("No AudioClips assigned to the 'clips' array.");
        }
    }

    // Play the next AudioClip when the current one finishes
    private void PlayNextClip()
    {
        if (currentIndex < clips.Length)
        {
            source.clip = clips[currentIndex];
            source.Play();

            // Set up a callback for the OnComplete event
            StartCoroutine(WaitForAudioClip(source.clip.length, () =>
            {
                // Increment the index and play the next AudioClip
                currentIndex++;
                PlayNextClip();
            }));
        }
    }

    // Coroutine to wait for a given duration and execute a callback
    private IEnumerator WaitForAudioClip(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }
}
