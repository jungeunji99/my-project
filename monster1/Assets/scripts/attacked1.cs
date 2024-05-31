using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacked1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("TakeAttack");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("TakeDamage");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("Dead");
        }

    }
}
