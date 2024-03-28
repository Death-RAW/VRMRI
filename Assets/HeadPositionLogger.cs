using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HeadsetPositionLogger : MonoBehaviour
{
    // Reference to the XR Rig
    public Transform xrRigTransform;

    void Update()
    {
        // Check if the XR Rig reference has been set
        if (xrRigTransform != null)
        {
            // Get the position of the XR Rig (which should be the same as the headset position)
            Vector3 position = xrRigTransform.position;

            // Print the position to the console
            Debug.Log("Headset Position: " + position);
        }
        else
        {
            Debug.Log("XR Rig reference not set. Please drag the XR Rig into the script in the inspector.");
        }
    }
}
