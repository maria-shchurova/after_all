using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonologueDisplay : MonoBehaviour
{
    [SerializeField] GameObject MonologuePanel;
    [SerializeField] GameObject BlackFadePanel;

    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text responce1_Text;
    [SerializeField] TMP_Text responce2_Text;

    [SerializeField] Button positiveChoice;
    [SerializeField] Button negativeChoice;

    [SerializeField] Scrollbar scrollbar;

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
        scrollbar.value = 1;
        MonologuePanel.SetActive(false);
        BlackFadePanel.SetActive(false);
        playerMovement.ReleaseAgent();

        Messenger.Broadcast("MoodChange");
    }

    private void Reorder()
    {
        if (Random.Range(0, 2) == 1)
            positiveChoice.transform.SetAsLastSibling();
        else
            negativeChoice.transform.SetAsLastSibling();
    }

    public void Display(string description, string positive, string negative)
    {
        Reorder();
        descriptionText.text = description;
        responce1_Text.text = positive; //TODO randomize order
        responce2_Text.text = negative;
        MonologuePanel.SetActive(true);
        BlackFadePanel.SetActive(true);
    }

    void PositiveResponce()
    {
        if(PositiveMessage != "")
        {
            Messenger.Broadcast(PositiveMessage);
            MoodKeeper.MoodScale += 1;
            print("MoodScale is " + MoodKeeper.MoodScale);
        }
    }

    void NegativeResponce()
    {
        Messenger.Broadcast(NegativeMessage);
        MoodKeeper.MoodScale -= 1;

        print("MoodScale is " + MoodKeeper.MoodScale);
    }

}
