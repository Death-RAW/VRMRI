using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Suite : MonoBehaviour
{
    private Animator animator;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(true) // add the trigger values here s
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            animator.SetTrigger("start_Walking");
        }
    }
}
