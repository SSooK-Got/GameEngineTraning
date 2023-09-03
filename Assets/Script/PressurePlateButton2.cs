using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateButton2 : MonoBehaviour
{

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

    //private void OnTriggerExit(Collider other)
    //{
    //    if (isPressed && other.gameObject.CompareTag("Player"))
    //    {
    //        // 플레이어가 압력판에서 벗어난 경우
    //        isPressed = false;
    //        ReleaseButton();
    //    }
    //}

    private void PressButton()
    {
        // 압력판이 눌렸을 때의 동작 처리
        // 예: 문이 열리거나 함정이 작동하는 등의 동작
        SceneManager.LoadScene("NextScene");
        gameObject.SetActive(false);
    }

    
}
