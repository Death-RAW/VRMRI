using UnityEngine;
using UnityEngine.SceneManagement;
 
 public class SceneLoader : MonoBehaviour {
     void Update() {
         if (OVRInput.Get(OVRInput.Button.Two))
             Debug.Log("two pressed");
         if (OVRInput.Get(OVRInput.Button.One))
             Debug.Log("one pressed");
     }
 }