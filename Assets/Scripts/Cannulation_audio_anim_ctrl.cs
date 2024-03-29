using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cannulation_audio_anim_ctrl : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    private int currentIndex = 0;
    public Animator aiAnim;
    public Transform xrRigTransform;
    private bool hasPlayedKneelAnimation = false;

    void Start()
    {
        if (clips.Length > 0)
        {
            Debug.Log("normal audio start");
            PlayNextClip();
        }
        else
        {
            Debug.LogError("No AudioClips assigned to the 'clips' array.");
        }
    }

    void Update()
    {
        // Check conditions to trigger animations or actions
        if (currentIndex == 2 && !hasPlayedKneelAnimation)
        {
            // Trigger animations when currentIndex reaches 2
            aiAnim.SetTrigger("pray");
            aiAnim.SetTrigger("kneel");
            hasPlayedKneelAnimation = true;
        }
    }

    private void PlayNextClip()
    {
        if (currentIndex < clips.Length)
        {
            Debug.Log("Playing audio clip: " + clips[currentIndex].name); // Print the name of the current audio clip
            source.clip = clips[currentIndex];
            source.Play();

            if (currentIndex == clips.Length - 1)
            {
                StartCoroutine(WaitAndTeleport(3f));
            }
            else
            {
                StartCoroutine(WaitForAudioClip(source.clip.length, () =>
                { 
                    currentIndex++;
                    PlayNextClip();
                }));
            }
        }
    }

    private IEnumerator WaitForAudioClip(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

    private IEnumerator WaitAndTeleport(float duration)
    {
        yield return new WaitForSeconds(duration);
        // Load Hallway 2 scene
        SceneManager.LoadScene("Hallway 2");
    }

    // Get the position of the XR Rig (which should be the same as the headset position)
    private Vector3 GetPosition()
    {
        return xrRigTransform.position;
    }
}
