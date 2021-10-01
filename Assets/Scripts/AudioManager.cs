using System;
using UnityEngine.Audio;
using UnityEngine;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public int prevVal;
    public Sound[] bgMusic;

    //public Sound[] sounds;
    public int chooseTrack;

    public string a;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in bgMusic)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.spatialBlend = s.spatialBlend;
        }
        
        /*
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.spatialBlend = s.spatialBlend;
        }
        */
    }

    private void Start()
    {
        
        chooseTrack = UnityEngine.Random.Range(0, bgMusic.Length);
        prevVal = chooseTrack;
        //print("track chosen: " + chooseTrack);
        a = bgMusic[chooseTrack].name;
        PlayBgMusic(a);
        //Play("BgMusic");
    }

    private void Update()
    {
        //print(sounds.Length);
        if (!bgMusic[chooseTrack].source.isPlaying)
        {
            //print("nextSong");
            if (prevVal == chooseTrack)
            {
                chooseTrack = UnityEngine.Random.Range(0, bgMusic.Length);
            }
            else
            {
                prevVal = chooseTrack;
                //print("track chosen: " + chooseTrack);
                a = bgMusic[chooseTrack].name;
                PlayBgMusic(a);
            }
        }
    }

    public void PlayBgMusic(string name)
    {
        Sound s =Array.Find(bgMusic, sound => sound.name == name);
        s.source.Play();
    }
    
    /*
    public void Play(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    */
}
