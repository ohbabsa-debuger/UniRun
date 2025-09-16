using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //����� ����� �����Ŭ��
    public float jumpForce = 700f; //���� ��

    private int jumpCount = 0; //���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; //�������

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; //����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; //����� ����� �ҽ�  ������Ʈ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //������Ʈ �ȿ� ������Ʈ�� ã��
        playerRigidbody = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //�ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        //����� �Է��� �����ϰ� �����ϴ� ó��
        if (isDead)
        {
            //����� �� �������� �ʰ� ����
            return;
        }

        if ((Input.GetMouseButtonDown(0)) && jumpCount < 2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigidbody.linearVelocity = Vector2.zero;
            //������ٵ� �������� ���� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y >0)
        {
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }
        //�ִϸ������� Grounded �Ķ���͸� isGrounded������ ���� "isGrounded"��ҹ��� ����
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
        if (collision.tag == "DEAD" && !isDead)
        {
            //�浹�� ������ �±װ� DEAD�̸� ���� ������� �ʾҴٸ� Die()����
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴڿ� ������� �����ϴ� ó��
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
    }
    private void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        playerRigidbody.linearVelocity = Vector2.zero;
        //������� true�� ����
        isDead = true;
    }
}
