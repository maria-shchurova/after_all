using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    bool walking;
    [SerializeField] float stoppingDistance;
    [SerializeField] float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.CompareTag("Floor"))
                    agent.destination = hit.point;
            }
            //else
            //    return;
        }
        if(agent.remainingDistance <= stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }

        animator.SetBool("Walk", walking);
    }

}
