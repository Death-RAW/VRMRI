using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_tri : MonoBehaviour
{
    public Animator aiAnim;
    private void OnTriggerEnter(Collider other){
        
       Debug.Log("Entered Trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered");
            if (aiAnim == null)
            {
                Debug.LogError("Animator reference is null. Assign a reference to the Animator component in the inspector.");
                return;
            }

            // aiAnim.ResetTrigger("close");
            aiAnim.SetTrigger("open");
        }
    }
}
