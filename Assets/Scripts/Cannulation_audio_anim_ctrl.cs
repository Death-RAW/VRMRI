using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannulation_audio_anim_ctrl : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    private int currentIndex = 0;
    public Animator aiAnim;
    public GameObject character;
    private bool hasPlayedKneelAnimation = false;


    void Start()
    {
        
        if (clips.Length > 0)
        {
            character.GetComponent<Animator>().Play("prayNurse_cannulation_idle");
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
           
            if (currentIndex == 2)
            {
                aiAnim.SetTrigger("pray");
                aiAnim.SetTrigger("kneel");
                
            }
            // if (currentIndex == 3 )
            // {
            //     Debug.Log("fk in");
            //     aiAnim.SetTrigger("kneel");
               
                
            // }

            StartCoroutine(WaitForAudioClip(source.clip.length, () =>
            { 
                currentIndex++;
                PlayNextClip();
            }));
        }
    }

   
    private IEnumerator WaitForAudioClip(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }
}
