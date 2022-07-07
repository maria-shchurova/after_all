using System.Collections;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class MoodManager : MonoBehaviour
{
    [SerializeField] Light[] AllLights;
    [SerializeField] HDAdditionalLightData[] AllLightsData;
    [SerializeField] Volume m_Volume;

    [SerializeField] int lightTweakingPercent = 10;
    void Start()
    {
        Messenger.AddListener("MoodChange", OnMoodChange);
    }

    void OnMoodChange() //18 max 
    {
        foreach(HDAdditionalLightData data in AllLightsData)
        {
            data.intensity  =  IntensityChange(data, MoodKeeper.MoodScale);
        }
    }


    float IntensityChange(HDAdditionalLightData light, int  scale)
    {
        var hundered_percent = light.intensity;//current intencity

        if (scale > 0)
        {
            var percentToAdd = hundered_percent / 100 * lightTweakingPercent;
            return light.intensity + percentToAdd;
        }

        else if (scale < 0)
        {
            var percentToSubtract = hundered_percent / 100 * lightTweakingPercent;
            return light.intensity - percentToSubtract;
        }
        else
            return hundered_percent;        
        
    }
}
