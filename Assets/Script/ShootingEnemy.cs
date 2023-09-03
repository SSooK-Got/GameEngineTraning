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
    public float moveSpeed = 3f; // �̵� �ӵ�
    public float shootDistance = 5f; // �Ѿ� �߻� �Ÿ�
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform firePoint; // �Ѿ� �߻� ��ġ
    public float fireDelay = 1f;
    private float bulletSpeed = 200f;
    private float shootTimer = 0f;
    private Transform player; // �÷��̾� ��ġ
    private bool canShoot = false; // �Ѿ� �߻� ���� ����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = guardSoundClip;
    }

    private void Update()
    {
        // �÷��̾ �ٶ󺸴� �������� ȸ��
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > shootDistance)
        {
            canShoot = false;
        }
        else
        {
            // �÷��̾�� ���� �Ÿ� ������ �� �Ѿ� �߻�
            canShoot = true;
        }

        if (canShoot)
        {
            
            if (shootTimer >= fireDelay)
            {
                // �Ѿ� �߻�
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
        // ������ üũ�Ͽ� �Ѿ��� �������� �������� �߻� ���� ����
        Vector3 fireDirection = firePoint.forward*bulletSpeed;

        audioSource.Play();
        // ���÷� �Ѿ��� �߻��ϴ� �ڵ带 �߰��մϴ�.
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Bullet bulletScr = bulletObj.GetComponent<Bullet>();
        bulletScr.shootBullet(fireDirection);
    }

    private void Move()
    {
        // �÷��̾�� ���� �Ÿ� �̻��� �� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
    }
}
