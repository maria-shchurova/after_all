using System.Collections;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class MoodManager : MonoBehaviour
{
    [SerializeField] HDAdditionalLightData[] AllLightsData;
    [SerializeField] Volume m_Volume;

    [SerializeField] int lightTweakingPercent = 10;
    [SerializeField] int colorStep = 5;
    void Start()
    {
        Messenger.AddListener("MoodChange", OnMoodChange);
    }

    void OnMoodChange() //18 max 
    {
        if(MoodKeeper.MoodScale  > 0)
        {
            SaturationShift(colorStep);
        }
        else
        {
            SaturationShift(-colorStep);
        }

        foreach (HDAdditionalLightData data in AllLightsData)
        {
            data.intensity  =  IntensityChange(data, MoodKeeper.MoodScale);
        }
    }

    void SaturationShift(int value)
    {
         ColorAdjustments color;
        m_Volume.profile.TryGet(out color);

        color.saturation.value += value;
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
