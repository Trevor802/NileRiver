using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip playerSound1;
    public AudioClip playerSound2;
    public AudioClip playerSound3;

    private float delay;
    private int soundToPlay;
    // Start is called before the first frame update
    void Start()
    {
        delay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0f)
        {
            soundToPlay = Random.Range(0, 3);
            //print(soundToPlay);
            if(soundToPlay == 0)
            {
                playerAudio.PlayOneShot(playerSound1);
            }
            else if(soundToPlay == 1)
            {
                playerAudio.PlayOneShot(playerSound2);
            }
            else if(soundToPlay == 2)
            {
                playerAudio.PlayOneShot(playerSound3);
            }
            delay = Random.Range(7, 13);
        }

    }
}
