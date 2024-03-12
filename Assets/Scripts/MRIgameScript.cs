using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class MRIgameScript : MonoBehaviour
{
    public TMP_Text positionText;
    public TMP_Text rotationText;

    void Update()
    {
    // Check if the XR device is present
    if (XRSettings.isDeviceActive)
    {
        // Get the XR node representing the headset (HMD)
        InputDevice headset = InputDevices.GetDeviceAtXRNode(XRNode.Head);

        // Get the position and rotation of the headset
        Vector3 headPosition;
        Quaternion headRotation;

        if (headset.TryGetFeatureValue(CommonUsages.devicePosition, out headPosition) &&
            headset.TryGetFeatureValue(CommonUsages.deviceRotation, out headRotation))
        {
            // Check for null references before setting text
            if (positionText != null)
                positionText.text = "Head Position: " + headPosition.ToString("F2");

            if (rotationText != null)
                rotationText.text = "Head Rotation: " + headRotation.eulerAngles.ToString("F2");
        }
    }
    }
}
