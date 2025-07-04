using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MAX_JUMP_COUNT = 2;
    private float m_jumpForce = 500f;
    private int m_jumpCount = 0;
    private bool m_isGrounded = true;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    private AudioSource m_audioSource;
    [SerializeField] AudioClip m_jumpSound;
    [SerializeField] AudioClip m_deathSound;

    float m_adJustPositionX = -6.0f;
    bool isAdJust = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void Init()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();

        m_jumpCount = 0;
        m_isGrounded = true;
        m_rigidbody.linearVelocity = Vector2.zero;
        transform.position = new Vector2(-6f, -1.2f);
        m_animator.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameBegin()) return;
        
        Jump();
        AdJust();
        m_animator.SetBool("IsGround", m_isGrounded);
    }

    void AdJust()
    {
        if (!isAdJust) return;
        if (transform.position.x < -6.1f || transform.position.x > -5.9f)
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_adJustPositionX, Time.deltaTime * 2f), transform.position.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (m_jumpCount < MAX_JUMP_COUNT)
            {
                m_rigidbody.linearVelocity = Vector2.zero;
                m_rigidbody.AddForce(new Vector2(0, m_jumpForce));
                m_jumpCount++;
                m_audioSource.PlayOneShot(m_jumpSound);
            }
        }
        else if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) && m_rigidbody.linearVelocity.y > 0)
        {
            m_rigidbody.linearVelocity = new Vector2(m_rigidbody.linearVelocity.x, m_rigidbody.linearVelocity.y * 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.Instance.IsGameBegin()) return;
        if (collision.contacts[0].normal.y > 0.7f)
        {
            m_isGrounded = true;
            m_jumpCount = 0;
        }
        else
        {
            m_isGrounded = false;
            m_jumpCount = 2;
        }
    }
    void OisionStay2D(Collision2D collision)
    {
        if (collision != null) isAdJust = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        m_isGrounded = false;
        isAdJust = true;
    }

    void Die()
    {
        m_audioSource.PlayOneShot(m_deathSound);
        m_animator.SetTrigger("Dead");
        GameManager.Instance.SetIsGameBegin(false);
        GameManager.Instance.EndGame();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone") && GameManager.Instance.IsGameBegin())
        {
            Die();
        }
    }
}
