using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpSoundClip;
    private AudioSource audioSource;

    public Timer timer;
    private bool isCursorLocked = true; // 커서의 잠금 상태를 나타내는 변수

    public Transform targetPosition;

    public int wallet = 0;
    public bool isHiddenMissionClear = false;

    private float hMove;
    private float vMove;

    public float moveSpeed = 5f; // 이동 속도 지정
    public float rotationSpeed = 360f; // 회전 속도 지정

    static public bool isSprint = false;

    public float jumpPower = 5f;
    public bool isJump = false;

    static public bool isBlocking = false; 

    public float gravity;
    public bool isFalling = false;

    private Vector3 moveDirection;
    private Vector3 jumpDirection;

    public Slider hpSlider;
    public Slider spSlider;

    CharacterController characterController;
    Animator animator;

    private Transform camTransform;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = jumpSoundClip;

        LockCursor(); // 시작할 때 커서를 고정
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        camTransform = Camera.main.transform;
    }
    private void Update()
    {
        cursorControll();
        Jump();
        Blocking();
        Move();

        Sprint();

        HpControll();
        missionClear();
        AnimatorController();
        playerDie();
    }

    private void FixedUpdate()
    {
        Gravity_move();
        staminaControll();
        
        if (isBlocking == false)
        {
            // Move()를 이용해 이동, 충돌 처리, 속도 값 얻기 가능
            characterController.Move(moveDirection * moveSpeed*Time.deltaTime);
            characterController.Move(jumpDirection*Time.deltaTime);
        }
          
    }

    void Move()
    {
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;
        
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        

        // 좌우 방향키와 상하 방향키를 눌렀는지 판별
        moveDirection = (camRight * hMove + camForward * vMove);

        camForward.y = 0f;
        camForward.Normalize();
        camRight.Normalize();
        transform.forward = camForward;
    }

    void Gravity_move()
    {
        jumpDirection.y -= gravity*Time.deltaTime;
    }

    void Sprint()
    {
        if (spSlider.value > 1f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprint = true;
                moveSpeed = 10f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprint = false;
                moveSpeed = 5f;
            }
        }
        else
        {
            isSprint = false;
            moveSpeed = 5f;
        }

        if (spSlider.value < 0f)
            spSlider.value = 0f;
        else if (spSlider.value > 100f)
            spSlider.value = 100f;
    }
    void staminaControll()
    {
        if (isSprint == true) spSlider.value -= 20f*Time.deltaTime;
        if (isBlocking == true) spSlider.value -= 15f*Time.deltaTime;
        else spSlider.value += 10f*Time.deltaTime;
    }

    void Jump()
    {
        if (characterController.isGrounded)
        {
            jumpPower = 6f;
            if (Input.GetButtonDown("Jump"))
            {
                jumpDirection.y = jumpPower;
                spSlider.value -= 20f;
                audioSource.Play();
            }
        }
    }

    void Blocking()
    {
        if (spSlider.value > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
                isBlocking = true;
            if (Input.GetKeyUp(KeyCode.LeftControl))
                isBlocking = false;
        }
        else
        {
            isBlocking = false;
        }
    }

    void cursorControll()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Escape 키를 누르면 커서의 잠금 상태를 토글
            isCursorLocked = !isCursorLocked;

            if (isCursorLocked)
                LockCursor();
            else
                UnlockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // 커서를 잠금 상태로 설정
        Cursor.visible = false; // 커서를 보이지 않게 설정
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // 커서의 잠금 해제
        Cursor.visible = true; // 커서를 보이게 설정
    }

    void HpControll()
    {
        if (hpSlider.value <= 0f)
            hpSlider.value = 0f;
        else if (hpSlider.value >= 100f)
            hpSlider.value = 100f;
    }

    void AnimatorController()
    {
        //animator 파라미터 전달
        animator.SetFloat("Speed", characterController.velocity.magnitude);
        animator.SetFloat("Horizontal", hMove);
        animator.SetFloat("Vertical", vMove);
        animator.SetBool("IsSprint", isSprint);
        animator.SetBool("IsGrounded", characterController.isGrounded);
        animator.SetFloat("JumpSpeed", characterController.velocity.y);
        animator.SetBool("IsBlocking", isBlocking);
        animator.SetBool("IsAttacking", Input.GetMouseButtonDown(0));
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isBlocking == false)
        {
            if (collision.collider.CompareTag("Bullet"))
                hpSlider.value -= 7f;

        }

        

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Enemy"))
            hpSlider.value -= 10f;
            
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealPack"))
            hpSlider.value += 30f;
        else if (other.gameObject.CompareTag("StaminaPack"))
            spSlider.value += 30f;

        else if (other.gameObject.CompareTag("Coin"))
            wallet += 1;
        else if (other.gameObject.CompareTag("Floor"))
        { 
            hpSlider.value -= 25f;
            characterController.enabled = false;
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            characterController.enabled = true;
        }
    }

    public void missionClear()
    {
        if (wallet >= 11 && timer.currentTime < 100)
            isHiddenMissionClear = true;
    }

    public void playerDie()
    {
        if (hpSlider.value <= 0f)
            SceneManager.LoadScene("GameOver");
    }
}