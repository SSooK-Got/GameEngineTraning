using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateButton2 : MonoBehaviour
{

    private bool isPressed = false; // �з����� ���ȴ��� ����

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.gameObject.CompareTag("Player"))
        {
            // �з��ǿ� �÷��̾ ������ ���
            isPressed = true;
            PressButton();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (isPressed && other.gameObject.CompareTag("Player"))
    //    {
    //        // �÷��̾ �з��ǿ��� ��� ���
    //        isPressed = false;
    //        ReleaseButton();
    //    }
    //}

    private void PressButton()
    {
        // �з����� ������ ���� ���� ó��
        // ��: ���� �����ų� ������ �۵��ϴ� ���� ����
        SceneManager.LoadScene("NextScene");
        gameObject.SetActive(false);
    }

    
}
