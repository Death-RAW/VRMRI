using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_Nurse_Dest_abnim : MonoBehaviour
{
    public Transform targetPosition; // Assign the destination point in the Unity Editor
    public Transform targetPosition_player; 
    public Transform targetPosition_cupboard;
    public Transform targetPosition_nurse1;  
    public Animator animator; // Reference to the Animator component
    public float moveSpeed = 3f; // Adjust the speed of movement
    public float rotationSpeed = 5f; // Adjust the speed of rotation
    public AudioSource source;
    public AudioClip[] clips;
    private int currentIndex = 0;
    public GameObject character;
    public GameObject mother_character;
    private Vector3 direction;
    Quaternion targetRotation;


   void Start()
    {
        if (clips.Length > 0)
        {
            character.GetComponent<Animator>().Play("idle");
            PlayNextClip();
        }
        else
        {
            Debug.LogError("No AudioClips assigned to the 'clips' array.");
        }
    }

    private void Update()
    {
        direction = targetPosition.position - transform.position;
        direction.y = 0; 

        if (direction != Vector3.zero)
        {
            if (currentIndex == 1)
            {
               // Debug.Log(currentIndex);
                source.Pause();
                targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
                animator.ResetTrigger("idle");
                animator.SetTrigger("walk");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
               // Debug.Log(direction.magnitude);
            }
            if (currentIndex == 2)
            {
                direction = targetPosition_player.position - transform.position; 

                targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
                
                animator.SetTrigger("idle");
                //transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
               // Debug.Log(direction.magnitude);
            }
            if (currentIndex == 7)
            {
                direction = targetPosition_cupboard.position - transform.position;
                targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
                animator.ResetTrigger("idle");
                animator.SetTrigger("point");
                //transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
               // Debug.Log(direction.magnitude);
            }
            if (currentIndex == 8)
            {
                direction = targetPosition_nurse1.position - transform.position;
                targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
                animator.ResetTrigger("idle");
                animator.SetTrigger("walk");
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
               // Debug.Log(direction.magnitude);
            }
           
        }
        // If the character reaches close enough to the target, stop the animation
        
        if (direction.magnitude < 1.9f)
        {
           // Debug.Log("target in range");
            animator.SetFloat("Speed", 0f);
            animator.ResetTrigger("walk");
            animator.SetTrigger("idle");
            
        }
    }

    private void PlayNextClip()
    {
        //Debug.Log(currentIndex);
        if (currentIndex < clips.Length)
        {
            source.clip = clips[currentIndex];
            source.Play();
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
