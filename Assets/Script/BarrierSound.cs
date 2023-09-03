using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSound : MonoBehaviour
{
    public AudioClip guardSoundClip;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = guardSoundClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            audioSource.Play();
    }
}
