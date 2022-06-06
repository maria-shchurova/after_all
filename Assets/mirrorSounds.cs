using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorSounds : MonoBehaviour
{
    public AudioClip clip1, clip2, clip3, clip4, clip5;

    public void sound_1()
    {
        AudioSource.PlayClipAtPoint(clip1, transform.position);
    }
    public void sound_2()
    {
        AudioSource.PlayClipAtPoint(clip2, transform.position);
    }
    public void sound_3()
    {
        AudioSource.PlayClipAtPoint(clip3, transform.position);
    }
    public void sound_4()
    {
        AudioSource.PlayClipAtPoint(clip4, transform.position);
    }
    public void sound_5()
    {
        AudioSource.PlayClipAtPoint(clip5, transform.position);
    }
}
