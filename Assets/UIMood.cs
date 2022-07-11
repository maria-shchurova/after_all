using UnityEngine.UI;
using UnityEngine;

public class UIMood : MonoBehaviour
{
    [SerializeField] GameObject BadStage1;
    [SerializeField] GameObject BadStage2;
    [SerializeField] GameObject BadStage3;

    GameObject[] AllObjects;

    [SerializeField] Sprite Eyes2;
    [SerializeField] Sprite Eyes3;

    [SerializeField] Sprite Good1;
    [SerializeField] Sprite Good2;
    [SerializeField] Sprite Good3;

    [SerializeField] Image BadStageBG;
    [SerializeField] Image Good;
    void Start()
    {
        Messenger.AddListener("MoodChange", OnMoodChange);

        AllObjects = new GameObject[3] { BadStage1, BadStage2, BadStage3};
    }
    void Clean()
    {
        foreach (GameObject obj in AllObjects)
        {
            obj.SetActive(false);
        }
        Good.enabled = false;
    }
    void OnMoodChange()
    {
        if(MoodKeeper.MoodScale == -3 || MoodKeeper.MoodScale  == -4)
        {
            Clean();
            BadStage1.SetActive(true);
        }

        if (MoodKeeper.MoodScale == -5 || MoodKeeper.MoodScale == -6)
        {
            Clean();
            BadStage1.SetActive(true);
            BadStageBG.sprite = Eyes2;
            BadStage2.SetActive(true);
        }

        if (MoodKeeper.MoodScale <= -7)
        {
            Clean();
            BadStage1.SetActive(true);
            BadStage2.SetActive(true);
            BadStageBG.sprite = Eyes3;
            BadStage3.SetActive(true);
        }

        if (MoodKeeper.MoodScale == 3 || MoodKeeper.MoodScale == 4)
        {
            Clean();
            Good.enabled = true;
            Good.sprite = Good1;
        }

        if (MoodKeeper.MoodScale == 5 || MoodKeeper.MoodScale == 6)
        {
            Clean();
            Good.enabled = true;
            Good.sprite = Good2;
        }

        if (MoodKeeper.MoodScale >= 7)
        {
            Clean();
            Good.enabled = true;
            Good.sprite = Good3;
        }
    }
}
