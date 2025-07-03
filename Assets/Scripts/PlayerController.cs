using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MAX_JUMP_COUNT = 2;
    private float m_jumpForce = 500f;
    private int m_jumpCount = 0;
    private bool m_isGrounded = false;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    private AudioSource m_audioSource;
    [SerializeField] AudioClip m_jumpSound;
    [SerializeField] AudioClip m_deathSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (m_jumpCount < MAX_JUMP_COUNT)
            {
                m_rigidbody.AddForce(new Vector2(0, m_jumpForce));
                m_jumpCount++;
                m_audioSource.PlayOneShot(m_jumpSound);

                if (m_jumpCount <= MAX_JUMP_COUNT) m_isGrounded = false;
                m_animator.SetBool("IsGround", m_isGrounded);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
            m_animator.SetBool("IsGround", m_isGrounded);
            m_jumpCount = 0;
        }
    }
}
