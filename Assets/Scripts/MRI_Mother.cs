using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_Mother : MonoBehaviour
{
    public Transform targetPosition; // Assign the destination point in the Unity Editor
    public Animator animator; // Reference to the Animator component
    public float moveSpeed = 3f; // Adjust the speed of movement
    public float rotationSpeed = 5f; // Adjust the speed of rotation
    public GameObject character;
    private Vector3 direction;
    private Quaternion targetRotation;
    public bool isMovementActivated = false;

    void Start()
    {
        
    }

    public void Update()
    {
        if (isMovementActivated)
        {
            animator.ResetTrigger("idle");
            animator.SetTrigger("walk");
            
            direction = targetPosition.position - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
            }
            animator.SetTrigger("walk");
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            if (direction.magnitude < 0.2f)
            {
                animator.SetFloat("Speed", 0f);
                animator.ResetTrigger("walk");
                animator.SetTrigger("idle");
            }
            
            // direction = targetPosition.position - transform.position;
            // direction.y = 0;
            // if (direction != Vector3.zero)
            // {
            //     targetRotation = Quaternion.LookRotation(direction);
            //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //     animator.SetFloat("Speed", direction.magnitude);
            // }
            // transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
            // if (direction.magnitude < 0.2f)
            // {
            //     animator.SetFloat("Speed", 0f);
            //     animator.ResetTrigger("walk");
            //     animator.SetTrigger("idle");
            // }
        }
    }
   
}
