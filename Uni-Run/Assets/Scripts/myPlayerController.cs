using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayerController : MonoBehaviour
{
    public AudioClip deathClip; // ����� ����� ����� Ŭ��
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����

    private Rigidbody2D playerRigidbody = default; // ����� ������ٵ� ������Ʈ
    private Animator animator = default; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio = default; // ����� ����� �ҽ� ������Ʈ

    private void Start()
    {
        // �ʱ�ȭ
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
