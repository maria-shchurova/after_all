using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool mouseOver;
    public MeshRenderer outlineObj;

    [SerializeField] string Description;
    [SerializeField] string NegativeResponce;
    [SerializeField] string PositiveResponce;

    private MonologueDisplay display;
    private ClickToMove playerMovement;

    public bool door;

    public string positiveEventMessage;
    public string negativeEventMessage;
    void Start()
    {
        display = FindObjectOfType<MonologueDisplay>();
        playerMovement = FindObjectOfType<ClickToMove>();
    }

    bool isClose()
    {
        return Vector3.Distance(playerMovement.transform.position, transform.position) < 2f;
    }

    void Update()
    {
        if(outlineObj != null)
            outlineObj.enabled = mouseOver;

        if(mouseOver)
        {
            if (Input.GetMouseButton(0))
            {
                if (isClose())
                {
                    if (door)
                    {
                        if (GetComponent<Animator>())
                            GetComponent<Animator>().SetTrigger("Open");
                        //if (GetComponent<SwitchRoom>())
                        //    GetComponent<SwitchRoom>().Switch();
                    }
                    else
                    {
                        display.Display(Description, PositiveResponce, NegativeResponce);
                        display.PositiveMessage = positiveEventMessage;
                        display.NegativeMessage = negativeEventMessage;

                        Destroy(outlineObj);
                        Destroy(this);
                    }
                }
                else
                {
                    playerMovement.SetDestination(transform.position);
                }

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

}
