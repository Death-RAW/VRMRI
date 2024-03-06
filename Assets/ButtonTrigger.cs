using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class ButtonTrigger : Button
{
    

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Finger"))
        {
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current),ExecuteEvents.submitHandler);
            string buttonName = gameObject.name;
            if (buttonName == "Button1")
            {
                Debug.Log("Pressed button 1");
                SomeMethod(0);
            }
            else if (buttonName == "Button2")
            {
                Debug.Log("Pressed button 2");
                SomeMethod(1);
            }
            else if (buttonName == "Button3")
            {
                Debug.Log("Pressed button 3");
                SomeMethod(2);
            }
            else if (buttonName == "Button4")
            {
                Debug.Log("Pressed button 4");
                SomeMethod(3);
            }
            else if (buttonName == "Button5")
            {
                Debug.Log("Pressed button 5");
                SomeMethod(4);
            }
            else if (buttonName == "Button6")
            {
                Debug.Log("Pressed button 6");
                SomeMethod(5);
            }
            else if (buttonName == "Button7")
            {
                Debug.Log("Pressed button 7");
                SomeMethod(6);
            }
            else if (buttonName == "Button8")
            {
                Debug.Log("Pressed button 8");
                SomeMethod(7);
            }
            else if (buttonName == "Button9")
            {
                Debug.Log("Pressed button 9");
                SomeMethod(8);
            }
            else if (buttonName == "Button10")
            {
                Debug.Log("Pressed button 10");
                SomeMethod(9);
            }
            else if (buttonName == "Button11")
            {
                Debug.Log("Pressed button 11");
                SomeMethod(10);
            }
            else if (buttonName == "Button12")
            {
                Debug.Log("Pressed button 12");
                SomeMethod(11);
            }
        }
    }
        private void SomeMethod(int index)
    {
        // Find the GameObject with the QuestionManager script attached
        GameObject questionManagerObject = GameObject.Find("Canvas");

        // Check if the object with QuestionManager script is found
        if (questionManagerObject != null)
        {
            // Get the QuestionManager component
            QuestionManager questionManager = questionManagerObject.GetComponent<QuestionManager>();

            // Check if the QuestionManager component is found
            if (questionManager != null)
            {
                // Call the DisplayAnswer function
                questionManager.DisplayAnswer(index);
            }
            else
            {
                Debug.LogError("QuestionManager component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("Object with QuestionManager script not found.");
        }
}
}