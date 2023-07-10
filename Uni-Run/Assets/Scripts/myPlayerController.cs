using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    private int jumpCount = 0; // 누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false; // 사망 상태

    private Rigidbody2D playerRigidbody = default; // 사용할 리지드바디 컴포넌트
    private Animator animator = default; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio = default; // 사용할 오디오 소스 컴포넌트

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
