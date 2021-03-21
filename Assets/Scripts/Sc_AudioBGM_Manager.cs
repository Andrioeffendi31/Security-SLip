using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_AudioBGM_Manager : MonoBehaviour
{
    public AudioClip clip1;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clip1;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
