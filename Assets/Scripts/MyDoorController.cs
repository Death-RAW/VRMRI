// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class door_anim_trigger : MonoBehaviour
// {
    
//     [SerializeField] private Animator myDoor = null;
//     [SerializeField] private bool openTrigger = false;
//     [SerializeField] private bool closeTrigger = false;
    
//     private void Update(){
//         myDoor.Play("Door_open", 0, 0.0f);
//     }

//     private void OnTriggerEnter(Collider other){
//         Debug.Log("in");
//         if(other.CompareTag("Player")){
//             if(openTrigger){
//                 Debug.Log("in");
//                 myDoor.Play("Door_open", 0, 0.0f);
//                 gameObject.SetActive(false);
//             }
//             else if(closeTrigger){
//                 myDoor.Play("Door_close", 0, 0.0f);
//                 gameObject.SetActive(false);
//             }
//         }
//     }

	
// }
