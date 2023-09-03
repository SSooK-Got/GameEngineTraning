using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChecker : MonoBehaviour
{
    public GameObject Target;
    public GameObject Target2;
    public string targetTag = "Enemy2"; // 체크할 대상 태그

    private void Update()
    {
        // 특정 태그가 일치하는 객체가 존재하는지 체크
        bool isTargetTagExists = CheckTagExists(targetTag);

        if (!Target2.activeInHierarchy)
        {
            if (isTargetTagExists)
                Target.SetActive(false);
            else
                Target.SetActive(true);
        }
    }

    private bool CheckTagExists(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        // 특정 태그가 일치하는 객체가 존재하는지 체크
        if (gameObjects.Length > 0)
        {
            // 특정 태그가 일치하는 객체가 존재하는 경우
            return true;
        }

        // 특정 태그가 일치하는 객체가 존재하지 않는 경우
        return false;
    }
}
