using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_follow_destination : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    Vector3 dest;

    IEnumerator StartAIWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enabled = true; // Enable the AI_follow_destination script
    }

    void Start()
    {
        enabled = false; // Disable the script initially
        StartCoroutine(StartAIWithDelay(10f)); // Start the coroutine with a 10-second delay
    }

    void Update()
    {
        if (!enabled)
            return; // If the script is disabled, do not execute the following code
        
        aiAnim.SetTrigger("walk");
        dest = player.position;
        ai.destination = dest;
        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            Debug.Log("iiiinnnn");
            aiAnim.ResetTrigger("walk");
            aiAnim.SetTrigger("idle");
        }
        else
        {
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("walk");
        }
    }
}
