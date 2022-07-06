using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventBroadcaster : MonoBehaviour
{
    public void ClothDrop()
    {
        Messenger.Broadcast("ClothDrop");
    }
    public void Key1()
    {
        Messenger.Broadcast("Key1");
    }

    public void Key2()
    {
        Messenger.Broadcast("Key2");
    }
    public void Intro1()
    {
        Messenger.Broadcast("Intro1");
    }

    public void Intro2()
    {
        Messenger.Broadcast("Intro2");
    }

    public  void Finish()
    {
        Messenger.Broadcast("Finish");
    }
}
