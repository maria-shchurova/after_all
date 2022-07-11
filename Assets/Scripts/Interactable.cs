using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour
{
    public float InteractionDistance;
    public bool mouseOver;
    public MeshRenderer outlineObj;

    [SerializeField] string Description;
    [SerializeField] string NegativeResponce;
    [SerializeField] string PositiveResponce;

    private MonologueDisplay display;
    private ClickToMove playerMovement;
    bool playerWalksTowardItem = false;
    
    public string positiveEventMessage;
    public string negativeEventMessage;

    [SerializeField] GameObject  hightlightParticleSystem;
    void Start()
    {
        display = FindObjectOfType<MonologueDisplay>();
        playerMovement = FindObjectOfType<ClickToMove>();
    }

    bool isClose()
    {
        return Vector3.Distance(playerMovement.transform.position, transform.position) < InteractionDistance;
    }

    private void OnEnable()
    {
        hightlightParticleSystem.SetActive(true);
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
                        hightlightParticleSystem.SetActive(false);

                        display.Display(Description, PositiveResponce, NegativeResponce);
                        display.PositiveMessage = positiveEventMessage;
                        display.NegativeMessage = negativeEventMessage;

                        if (gameObject.name == "BandPoster")
                        {
                            Messenger.Broadcast("PosterDisplay");
                        }

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
                    hightlightParticleSystem.SetActive(false);

                    display.Display(Description, PositiveResponce, NegativeResponce);
                    display.PositiveMessage = positiveEventMessage;
                    display.NegativeMessage = negativeEventMessage;

                    if (gameObject.name == "BandPoster")
                    {
                        Messenger.Broadcast("PosterDisplay");
                    }

                    Destroy(outlineObj);
                    Destroy(hightlightParticleSystem);
                    Destroy(this);

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

    private void OnDisable()
    {
        OnMouseExit();
    }
}
