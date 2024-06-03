using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked1 : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public float detectionDistance = 10.0f;
    private int health = 100;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionDistance && !isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        while (health > 0)
        {

            animator.SetTrigger("Idle");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            for (int i = 0; i < 2; i++)
            {
                animator.SetTrigger("TakeAttack");
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            }

            animator.SetTrigger("Idle");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            animator.SetTrigger("Idle");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            for (int i = 0; i < 2; i++)
            {
                animator.SetTrigger("TakeAttack");
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }

        if (health <= 0)
        {
            animator.SetTrigger("Dead");
        }
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StopAllCoroutines();
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }
}

