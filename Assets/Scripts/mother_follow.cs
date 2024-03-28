using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class mother_follow : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Animator aiAnim;
    Vector3 dest;
    void Update()
    {
        // If the script is enabled (after the 20-second wait), start following the player
        if (enabled)
        {
            dest = player.position;
            ai.destination = dest;

            if (ai.remainingDistance <= ai.stoppingDistance)
            {
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
}
