using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    [SerializeField] TMP_Text endingText;

    [SerializeField] string depressedEndingText;
    [SerializeField] string trueEndingText;
    [SerializeField] string delusionalEndingText;
    void Start()
    {
        if(MoodKeeper.MoodScale <= -3)
        {
            endingText.text = depressedEndingText;
        }
        
        if(MoodKeeper.MoodScale >= 3)
        {
            endingText.text = delusionalEndingText;
        }

        if (MoodKeeper.MoodScale > -3  && MoodKeeper.MoodScale < 3)
        {
            endingText.text = trueEndingText;
        }
        //TODO  animate typing?
    }

    public void RestartButton()
    {
        MoodKeeper.MoodScale = 0;//reset  this
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
}
