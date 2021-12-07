using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource audio;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
