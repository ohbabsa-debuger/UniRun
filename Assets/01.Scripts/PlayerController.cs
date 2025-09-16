using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //사망시 재생할 오디오클립
    public float jumpForce = 700f; //점프 힘

    private int jumpCount = 0; //누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false; //사망상태

    private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
    private Animator animator; //사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; //사용할 오디오 소스  컴포넌트

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //오브젝트 안에 컴포넌트를 찾는
        playerRigidbody = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //초기화
    }

    // Update is called once per frame
    void Update()
    {
        //사용자 입력을 감지하고 점프하는 처리
        if (isDead)
        {
            //사망시 더 진행하지 않고 종료
            return;
        }

        if ((Input.GetMouseButtonDown(0)) && jumpCount < 2)
        {
            //점프 횟수 증가
            jumpCount++;
            // 점프 직전에 속도를 순간적으로 제로(0,0)로 변경
            playerRigidbody.linearVelocity = Vector2.zero;
            //리지드바디에 위쪽으로 힘을 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y >0)
        {
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }
        //애니메이터의 Grounded 파라미터를 isGrounded값으로 갱신 "isGrounded"대소문자 주의
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if (collision.tag == "DEAD" && !isDead)
        {
            //충돌한 상대방의 태그가 DEAD이며 아직 사망하지 않았다면 Die()실행
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿았음을 감지하는 처리
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥에서 벗어났음을 감지하는 처리
    }
    private void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        //사망 효과음 재생
        playerAudio.Play();

        //속도를 제로(0,0)로 변경
        playerRigidbody.linearVelocity = Vector2.zero;
        //사망상태 true로 변경
        isDead = true;
    }
}
