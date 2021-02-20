using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Sound
{
    PlayerMove,
    Music
}

[System.Serializable]
public class SoundAudioClip{
    public Sound sound;
    public AudioClip audioClip;
    public float audioTime;
}

public static class SoundUtils
{
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    }

}
