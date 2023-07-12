using System;
using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour 
{
    public AudioClip deathClip; // 사망시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    private int jumpCount = 0; // 누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false; // 사망 상태
    private bool isBig = false; //커진 상태

    private Rigidbody2D playerRigidbody = default; // 사용할 리지드바디 컴포넌트
    private Animator animator = default; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio = default; // 사용할 오디오 소스 컴포넌트
   // private Transform playerScale = default; // 커질때 사용할거임
   
    private void Start()
    {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Debug.Assert(playerRigidbody != null);
        Debug.Assert(animator != null);
        Debug.Assert(playerAudio != null);
        
        

    }

    private void Update()
    {
        // 사용자 입력을
        // 감지하고 점프하는 처리
        if (isDead) { return; }
        //LEGACY :
        //if (Input.GetMouseButtonDown(0) && jumpCount <  2)
        //{
        //    // 점프 횟수 증가
        //    jumpCount += 1;
        //    // 점프 직전 속도를 순간적으로 제로 (0,0)로 변경
        //    playerRigidbody.velocity = Vector2.zero;
        //    // 리지드 바디에 위쪽으로 힘 주기
        //    playerRigidbody.AddForce(new Vector2(0, jumpForce));
        //    // 오디오 소스 재생
        //    playerAudio.Play();

        //}
        //else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        //{
        //    //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y 값이 양수라면(위로 상승 중)
        //    // 현재 속도를 절반으로 변경
        //}
        //Jump();
        animator.SetBool("Grounded", isGrounded);
    }

    public void Jump()
    {
        if (isDead) { return; }

        if (jumpCount <  2)
        {
            // 점프 횟수 증가
            jumpCount += 1;
            // 점프 직전 속도를 순간적으로 제로 (0,0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            // 리지드 바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 오디오 소스 재생
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y 값이 양수라면(위로 상승 중)
            // 현재 속도를 절반으로 변경
        }
        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
        // 사망 처리
        animator.SetTrigger("Die");

        //오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        //사망 효과음 재생.
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        // 사망 상태를 true로 변경
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if (other.tag == "Dead" && !isDead)
        {
            //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die()실행
            Die();
        }
        if (other.tag == "Coin" && !isDead)
        {
            other.gameObject.SetActive(false);
            GameManager.instance.AddScore(10);
        }
        if (other.tag == "Mushroom"&& !isDead)
        {
            if (isBig == false)
            {
                isBig = true;
                other.gameObject.SetActive(false);
                transform.localScale += new Vector3(1, 1, 0);
            }
            else
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리
        if (collision.contacts[0].normal.y > 0.7f)
        {
            Debug.Log("땅 착지 완료");
            // isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }
}