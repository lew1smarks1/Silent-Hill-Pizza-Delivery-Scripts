using System;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    //this is a much better way of keeping game assets to be referenced
    private static GameAssets instance;
    public static GameAssets GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }

    [Serializable]
    public class SoundAudioClip//holds sounds
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
    //holds the road prefabs
    public SoundAudioClip[] soundAudioClipArray;
    public Transform Road1;
    public Transform Road2;
    public Transform Road3;
    public Transform Road4;
    public Transform Road5;

}
