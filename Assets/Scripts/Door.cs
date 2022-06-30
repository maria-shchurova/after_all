using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float InteractionDistance;
    public bool mouseOver;
    private ClickToMove playerMovement;
    bool playerWalksTowards = false;
    public MeshRenderer outlineObj;
    Animator Animator;

    void Start()
    {
        playerMovement = FindObjectOfType<ClickToMove>();
        Animator = GetComponent<Animator>();
    }

    bool isClose()
    {
        return Vector3.Distance(playerMovement.transform.position, transform.position) < InteractionDistance;
    }
    void Update()
    {
        if (outlineObj != null)
            outlineObj.enabled = mouseOver;

        if (mouseOver)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (isClose())
                {
                    playerMovement.ResetDestination();
                    Animator.SetTrigger("Open");
                    mouseOver = playerWalksTowards = false;
                }
                else
                {
                    playerMovement.SetDestination(transform.position);
                    playerWalksTowards = true;
                }

            }
        }


        if (playerWalksTowards == true)
        {
            if (isClose())
            {
                playerMovement.ResetDestination();
                Animator.SetTrigger("Open");
                mouseOver = playerWalksTowards = false;
            }
        }
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void OnDisable()
    {
        OnMouseExit();
    }
}
