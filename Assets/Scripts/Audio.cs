using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip gettingSmaller, gettingBigger, gettingReset;
    public AudioSource AudioSource;

    public PlayerScale _playerScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerScale.playSmallAudio)
        {
            PlayGettingSmaller();
        }

        
    }

    public void PlayGettingSmaller()
    {
        AudioSource.PlayOneShot(gettingSmaller);
    }

    public void PlayGettingBigger()
    {
        AudioSource.PlayOneShot(gettingBigger, 1);
    }

    public void PlayGettingReset()
    {
        AudioSource.PlayOneShot(gettingReset);
    }
}
