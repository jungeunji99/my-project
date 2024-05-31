using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstercontroller : MonoBehaviour
{
    public Transform player; 
    public float detectionRange = 10.0f; 
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionRange)
        {
            animator.SetTrigger("StartAction");
        }
    }
}
