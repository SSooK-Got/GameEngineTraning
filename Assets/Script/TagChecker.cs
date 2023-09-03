using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChecker : MonoBehaviour
{
    public GameObject Target;
    public GameObject Target2;
    public string targetTag = "Enemy2"; // üũ�� ��� �±�

    private void Update()
    {
        // Ư�� �±װ� ��ġ�ϴ� ��ü�� �����ϴ��� üũ
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

        // Ư�� �±װ� ��ġ�ϴ� ��ü�� �����ϴ��� üũ
        if (gameObjects.Length > 0)
        {
            // Ư�� �±װ� ��ġ�ϴ� ��ü�� �����ϴ� ���
            return true;
        }

        // Ư�� �±װ� ��ġ�ϴ� ��ü�� �������� �ʴ� ���
        return false;
    }
}
