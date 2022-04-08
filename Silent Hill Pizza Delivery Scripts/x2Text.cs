using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class x2Text : MonoBehaviour
{
    private Text child;
    private static x2Text instance;

    public static x2Text GetInstance()
    {
        return instance;
    }

    public void TextOn()//turns on the x2 text using script attached to the parent
    {
        child.enabled = true;
    }

    public void TextOff()//turns off the x2 text
    {
        child.enabled=false;
    }

    private void Awake()
    {
        instance = this;
        child = transform.GetChild(0).GetComponent<Text>();
        child.enabled = true;//makes sure that child's reference is available on scene load
        child.enabled = false;
    }
}
