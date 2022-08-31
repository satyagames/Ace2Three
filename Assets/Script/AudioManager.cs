using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Ad;
    
    public void playAudio(int c)
    {
        gameObject.GetComponent<AudioSource>().clip = Ad[c];
        gameObject.GetComponent<AudioSource>().Play();
    }
}
