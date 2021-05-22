using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    void Awake()
    {
       int numberOfMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if(numberOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
