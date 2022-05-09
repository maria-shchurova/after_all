using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueDisplay : MonoBehaviour
{
    [SerializeField] GameObject MonologuePanel;
    [SerializeField] Text descriptionText;
    [SerializeField] Text responce0_Text;//neutral - optional TODO
    [SerializeField] Text responce1_Text;
    [SerializeField] Text responce2_Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnSelectOption() // button
    {
        MonologuePanel.SetActive(false);
    }
    public void Display(string description, string positive, string negative)
    {
        descriptionText.text = description;
        responce1_Text.text = positive; //TODO randomize order
        responce2_Text.text = negative;
        MonologuePanel.SetActive(true);
    }
}
