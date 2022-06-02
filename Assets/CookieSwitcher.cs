using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSwitcher : MonoBehaviour
{
public Light spotLight;
public Texture[] textures;
public Texture mainTex;
int i = 0;
 

    void Update()
    {

        mainTex = textures[i];
        spotLight.cookie = mainTex;
        i++;
        if(i>textures.Length-1) i=0;
    }
}
