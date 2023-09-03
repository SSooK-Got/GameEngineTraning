using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReburseButton : MonoBehaviour
{
    public GameObject targetObject; // 압력판 버튼이 작동할 대상 오브젝트

    private bool isPressed = false; // 압력판이 눌렸는지 여부

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.gameObject.CompareTag("Player"))
        {
            // 압력판에 플레이어가 진입한 경우
            isPressed = true;
            PressButton();
        }
    }

    

    private void PressButton()
    {
        // 압력판이 눌렸을 때의 동작 처리
        // 예: 문이 열리거나 함정이 작동하는 등의 동작
        targetObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void ReleaseButton()
    {
        // 압력판에서 플레이어가 벗어났을 때의 동작 처리
        // 예: 문이 닫히거나 작동이 멈추는 등의 동작
        targetObject.SetActive(false);
    }
}
