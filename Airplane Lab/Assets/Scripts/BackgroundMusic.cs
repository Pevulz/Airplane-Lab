using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(music.clip, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //keeps playing the music
        DontDestroyOnLoad(transform.gameObject);
    }
}
