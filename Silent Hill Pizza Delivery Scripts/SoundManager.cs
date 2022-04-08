using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    //same sound system as in Flappy Dragon
    public enum Sound
    {
        Lose,
        CarEngine,
        CarEngineStart,
        CarHonk,//unused, oops!
        StartScreen,
        Fall,
    }

    public static void PlaySound(Sound sound)
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound), 0.3f);
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.GetInstance().soundAudioClipArray)
        {

                if (soundAudioClip.sound == sound)
                {
                    return soundAudioClip.audioClip;
                }
           
        }

        return null;

    }
}
