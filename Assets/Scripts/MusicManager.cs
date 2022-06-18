using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public float[] SpectrumWidth;
    public AudioSource audioSource;

    void Awake()
    {
        SpectrumWidth = new float[64];
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    void FixedUpdate()
    {
        audioSource.GetSpectrumData(SpectrumWidth, 0, FFTWindow.Blackman);
    }

    public  float GetFrequencesDiapason(int start,  int  end, int mult)
    {
        return SpectrumWidth.ToList().GetRange(start, end).Average() * mult;
    }
}
