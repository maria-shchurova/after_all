using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueDisplay : MonoBehaviour
{
    [SerializeField] GameObject MonologuePanel;
    [SerializeField] GameObject BlackFadePanel;

    [SerializeField] Text descriptionText;
    [SerializeField] Text responce0_Text;//neutral - optional TODO
    [SerializeField] Text responce1_Text;
    [SerializeField] Text responce2_Text;

    [SerializeField] Button positiveChoice;
    [SerializeField] Button negativeChoice;

    string _positiveMessage;
    string _negativeMessage;

    private ClickToMove playerMovement;

    public string PositiveMessage
    {
        get => _positiveMessage;
        set => _positiveMessage = value;
    }

    public string NegativeMessage
    {
        get => _negativeMessage;
        set => _negativeMessage = value;
    }
    void Start()
    {
        playerMovement = FindObjectOfType<ClickToMove>();

        positiveChoice.onClick.AddListener(PositiveResponce);
        negativeChoice.onClick.AddListener(NegativeResponce);
    }

    // Update is called once per frame
    public void OnSelectOption() // button
    {
        MonologuePanel.SetActive(false);
        BlackFadePanel.SetActive(false);

        playerMovement.ReleaseAgent();
    }
    public void Display(string description, string positive, string negative)
    {
        descriptionText.text = description;
        responce1_Text.text = positive; //TODO randomize order
        responce2_Text.text = negative;
        MonologuePanel.SetActive(true);
        BlackFadePanel.SetActive(true);
    }

    void PositiveResponce()
    {
        Messenger.Broadcast(PositiveMessage);
        MoodKeeper.MoodScale += 1;
        print("MoodScale is " + MoodKeeper.MoodScale);
    }

    void NegativeResponce()
    {
        Messenger.Broadcast(NegativeMessage);
        MoodKeeper.MoodScale -= 1;

        print("MoodScale is " + MoodKeeper.MoodScale);
    }
}
