using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopInteractions : MonoBehaviour
{
    public bool mouseOver;
    public MeshRenderer outlineObj;

    [SerializeField] string Description;
    [SerializeField] string NegativeResponce;
    [SerializeField] string PositiveResponce;

    [SerializeField] GameObject LaptopUI;
    [SerializeField] GameObject PhotoWindow;
    [SerializeField] GameObject MessengerWindow;
    [SerializeField] GameObject Notification;
    [SerializeField] GameObject Electricity;
    [SerializeField] Animator BSOD;
    [SerializeField] Button OpenMessageButton;
    [SerializeField] Button LogOutButton;
    [SerializeField] GameObject ParticleHighlight;

    private MonologueDisplay display;
    private ClickToMove playerMovement;
    bool playerWalksTowardItem = false;


    public string positiveEventMessage;
    public string negativeEventMessage;
    void Start()
    {
        display = FindObjectOfType<MonologueDisplay>();
        playerMovement = FindObjectOfType<ClickToMove>();

        Messenger.AddListener("I do look good", MomsMessage);
        Messenger.AddListener("Fan's best moment", Explode);
    }

    bool isClose()
    {
        return Vector3.Distance(playerMovement.transform.position, transform.position) < 4;
    }

    void Update()
    {
        if (outlineObj != null)
            outlineObj.enabled = mouseOver;

        if (mouseOver)
        {
            if (Input.GetMouseButton(0) || playerWalksTowardItem)
            {
                if (isClose())
                {
                    playerMovement.ResetDestination();
                    ParticleHighlight.SetActive(false);

                    LaptopUI.SetActive(true);
                    Destroy(outlineObj);
                }
                else
                {
                    playerMovement.SetDestination(transform.position);
                    playerWalksTowardItem = true;
                }

            }
        }
    }

    public void OpenPhoto()
    {
        PhotoWindow.SetActive(true);

        display.Display(Description, PositiveResponce, NegativeResponce);
        display.PositiveMessage = positiveEventMessage;
        display.NegativeMessage = negativeEventMessage;
    }

    void MomsMessage()
    {
        PhotoWindow.SetActive(false);
        Notification.SetActive(true);
        OpenMessageButton.enabled = true;
    }

    public void OpenMessage()
    {
        MessengerWindow.SetActive(true);
        LogOutButton.enabled = true;
    }

    public void LogOut()
    {
        LaptopUI.SetActive(false);
        Destroy(outlineObj);
        Destroy(this);
    }

    void Explode()
    {
        Electricity.SetActive(true);
        BSOD.enabled = true;

        Destroy(outlineObj);
        Destroy(this);
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
