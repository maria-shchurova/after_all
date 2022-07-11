using UnityEngine;
using UnityEngine.EventSystems;

public class EndingDoorInteraction : MonoBehaviour
{
    public float InteractionDistance;
    public bool mouseOver;
    public MeshRenderer outlineObj;

    [SerializeField]GameObject endingTextPanel; //ending text script there

    private ClickToMove playerMovement;
    bool playerWalksTowardItem = false;

    void Start()
    {
        playerMovement = FindObjectOfType<ClickToMove>();
    }
    bool isClose()
    {
        return Vector3.Distance(playerMovement.transform.position, transform.position) < InteractionDistance;
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

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        else
        {
            if (outlineObj != null)
                outlineObj.enabled = mouseOver;

            if (mouseOver)
            {
                if (Input.GetMouseButton(0))
                {
                    if (isClose())
                    {
                        playerMovement.ResetDestination();

                        endingTextPanel.SetActive(true);
                        Messenger.Broadcast("LastInteraction");

                        Destroy(outlineObj);
                        Destroy(this);
                    }
                    else
                    {
                        playerMovement.SetDestination(transform.position);
                        playerWalksTowardItem = true;
                    }

                }
            }


            if (playerWalksTowardItem == true)
            {
                if (isClose())
                {
                    playerMovement.ResetDestination();

                    endingTextPanel.SetActive(true);
                    Messenger.Broadcast("LastInteraction");

                    Destroy(outlineObj);
                    Destroy(this);

                }
            }
        }

        }
    }

