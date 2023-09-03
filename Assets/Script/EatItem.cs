using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : MonoBehaviour
{
    public AudioClip SoundClip;
    private AudioSource audioSource;

    private bool isPressed = false; // �з����� ���ȴ��� ����

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = SoundClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.gameObject.CompareTag("Player"))
        {
            // �з��ǿ� �÷��̾ ������ ���
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
