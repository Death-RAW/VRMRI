using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_AI_Ctrl : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    private int currentIndex = 0;
    public Animator motherAnim;
    public GameObject mothercharacter;
    public GameObject door;
 
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

    private void PlayNextClip()
    {
        if (currentIndex < clips.Length)
        {
            source.clip = clips[currentIndex];
            source.Play();
           
            if (currentIndex == 1)
            {
                StartCoroutine(DelayedRotationAndAnimation());
            }
            
            StartCoroutine(WaitForAudioClip(source.clip.length, () => { 
                currentIndex++;
                PlayNextClip();
            }));
        }
    }

    private IEnumerator DelayedRotationAndAnimation()
    {
        
        
        // Rotate mothercharacter by 180 degrees
        mothercharacter.transform.Rotate(0, -180, 0);
                
        // Trigger animation to turn and then walk
        motherAnim.SetTrigger("turn");
       
        motherAnim.SetTrigger("walk");
        yield return new WaitForSeconds(1.0f); // Delay by 1 second
        door.GetComponent<Animator>().Play("Door_open_close");
    }

    private IEnumerator WaitForAudioClip(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }
}
