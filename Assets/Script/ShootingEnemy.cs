using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : MonoBehaviour
{
    public AudioClip guardSoundClip;
    private AudioSource audioSource;
    public GameObject target;
    NavMeshAgent agent;
    public float moveSpeed = 3f; // 이동 속도
    public float shootDistance = 5f; // 총알 발사 거리
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 총알 발사 위치
    public float fireDelay = 1f;
    private float bulletSpeed = 200f;
    private float shootTimer = 0f;
    private Transform player; // 플레이어 위치
    private bool canShoot = false; // 총알 발사 가능 여부

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = guardSoundClip;
    }

    private void Update()
    {
        // 플레이어를 바라보는 방향으로 회전
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > shootDistance)
        {
            canShoot = false;
        }
        else
        {
            // 플레이어와 일정 거리 이하일 때 총알 발사
            canShoot = true;
        }

        if (canShoot)
        {
            
            if (shootTimer >= fireDelay)
            {
                // 총알 발사
                Shoot();
                shootTimer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!canShoot)
            Move();
        shootTimer += Time.deltaTime;
    }
    private void Shoot()
    {
        // 정면을 체크하여 총알이 정면으로 나가도록 발사 방향 설정
        Vector3 fireDirection = firePoint.forward*bulletSpeed;

        audioSource.Play();
        // 예시로 총알을 발사하는 코드를 추가합니다.
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Bullet bulletScr = bulletObj.GetComponent<Bullet>();
        bulletScr.shootBullet(fireDirection);
    }

    private void Move()
    {
        // 플레이어와 일정 거리 이상일 때 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
    }
}
