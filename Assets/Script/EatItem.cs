using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    public AudioClip SoundClip;
    private AudioSource audioSource;

    private bool isPressed = false; // 압력판이 눌렸는지 여부

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = SoundClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.gameObject.CompareTag("Player"))
        {
            // 압력판에 플레이어가 진입한 경우
            isPressed = true;
            audioSource.Play();
            PressButton();
        }
    }

    private void PressButton()
    {
        
        Destroy(gameObject);
    }
}
