using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 2f; // �̵� �ӵ�
    public float distance = 5f; // �պ� �Ÿ�

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true; // ���� �̵� ����

    private void Start()
    {
        // �ʱ� ��ġ ����
        startPosition = transform.position;

        // ��ǥ ��ġ ����
        targetPosition = startPosition + Vector3.up* distance;
    }

private void Update()
{
    // ���� �̵� ���⿡ ���� ��ǥ ��ġ ����
    if (movingForward)
    {
        targetPosition = startPosition + Vector3.up * distance;
    }
    else
    {
        targetPosition = startPosition;
    }

    // ��ü �̵�

    // ��ǥ ��ġ�� �����ϸ� �̵� ���� ����
    if (transform.position == targetPosition)
    {
        movingForward = !movingForward;
    }
}

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        Move();
    }
}
