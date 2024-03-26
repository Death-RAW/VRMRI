using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_trigger : MonoBehaviour
{
    public GameObject mother_character;
    private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Entered Trigger");
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Entered");
                mother_character.GetComponent<MRI_Mother>().isMovementActivated = true;
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Exsited the Trigger");
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player exsited");
                mother_character.GetComponent<MRI_Mother>().isMovementActivated = false;
            }
        }

}
