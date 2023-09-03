using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReburseButton : MonoBehaviour
{
    public GameObject targetObject; // �з��� ��ư�� �۵��� ��� ������Ʈ

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

    

    private void PressButton()
    {
        // �з����� ������ ���� ���� ó��
        // ��: ���� �����ų� ������ �۵��ϴ� ���� ����
        targetObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void ReleaseButton()
    {
        // �з��ǿ��� �÷��̾ ����� ���� ���� ó��
        // ��: ���� �����ų� �۵��� ���ߴ� ���� ����
        targetObject.SetActive(false);
    }
}
