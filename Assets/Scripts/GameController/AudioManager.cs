using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Range(0f, 2f)] [SerializeField] private float efectsVolume = 1;
    [Range(0f, 1f)] [SerializeField] private float musicVolume = 1;

    public static AudioManager Instance;

    public SoundAudioClip[] audioClips;
    private static Dictionary<Sound, float> _soundTimerDictionary;
    private AudioSource _musicPlayerSource;
    private AudioManager _audioM;


    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _soundTimerDictionary = new Dictionary<Sound, float>();
        _soundTimerDictionary[Sound.PlayerMove] = 0f;

        GameObject musicPlayer = new GameObject("LevelSound");
        musicPlayer.transform.SetParent(transform);
        _musicPlayerSource = musicPlayer.AddComponent<AudioSource>();
        _musicPlayerSource.volume = musicVolume;

        try
        {
            _musicPlayerSource.clip = GetAudioClip(Sound.Music).audioClip;
            _musicPlayerSource.loop = true;


            _musicPlayerSource.Play();
        }
        catch
        {
        }
    }


    public void PlaySound(Sound sound)
    {
        SoundAudioClip sc = GetAudioClip(sound);
        if (!CanPlaySound(sc)) return;
        GameObject soundGameObject = new GameObject("Sound");
        soundGameObject.transform.SetParent(transform);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(sc.audioClip, efectsVolume);
        //audioSource.PlayOneShot(sc.audioClip, efectsVolume);
        Destroy(soundGameObject, sc.audioClip.length);
    }

    private static bool CanPlaySound(SoundAudioClip newSound)
    {
        switch (newSound.sound)
        {
            default:
                return true;
            case Sound.PlayerMove:
                if (_soundTimerDictionary.ContainsKey(newSound.sound))
                {
                    float lastTimePlayed = _soundTimerDictionary[newSound.sound];
                    float playerMoverTimerMax = newSound.audioTime;

                    if (lastTimePlayed + playerMoverTimerMax < Time.time)
                    {
                        _soundTimerDictionary[newSound.sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }

    private SoundAudioClip GetAudioClip(Sound soundToPlay)
    {
        foreach (SoundAudioClip sc in audioClips)
        {
            if (sc.sound == soundToPlay)
            {
                return sc;
            }
        }

        Debug.LogError("Sound " + soundToPlay + " not found!");
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // _musicPlayerSource.volume = musicVolume;
    }
}