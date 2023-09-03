using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 2f; // 이동 속도
    public float distance = 5f; // 왕복 거리

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true; // 현재 이동 방향

    private void Start()
    {
        // 초기 위치 저장
        startPosition = transform.position;

        // 목표 위치 설정
        targetPosition = startPosition + Vector3.up* distance;
    }

private void Update()
{
    // 현재 이동 방향에 따라 목표 위치 설정
    if (movingForward)
    {
        targetPosition = startPosition + Vector3.up * distance;
    }
    else
    {
        targetPosition = startPosition;
    }

    // 객체 이동

    // 목표 위치에 도달하면 이동 방향 변경
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
