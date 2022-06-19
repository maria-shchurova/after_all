using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    Animator animator;
    [SerializeField]Transform character;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void Update()
    {
        transform.LookAt(new Vector3(character.position.x, transform.position.y, character.position.z));

        if (Vector3.Distance(transform.position,character.position)  <  2)
        {
            Attack();
        }
    }
}
