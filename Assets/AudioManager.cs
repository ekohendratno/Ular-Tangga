using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "walk":
                AudioClip clip1 = (AudioClip)Resources.Load ("walk");
                audio.clip = clip1;
                audio.Play();
            break;
            case "trap":
                AudioClip clip2 = (AudioClip)Resources.Load ("trap");
                audio.clip = clip2;
                audio.Play();
            break;
            case "advantage":
                AudioClip clip3 = (AudioClip)Resources.Load ("advantage");
                audio.clip = clip3;
                audio.Play();
            break;
        }
    }
}
