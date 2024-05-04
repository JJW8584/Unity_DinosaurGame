using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxScoreDelay = 0.1f;
    public float curScoreDelay = 0f;
    public bool isDead = false;
    public float h;

    private bool isGround = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Move();
            Jump();
            if (curScoreDelay >= maxScoreDelay)
            {
                GameManager.instance.score += 1;
                curScoreDelay = 0f;
            }
            curScoreDelay += Time.deltaTime;
        }
    }
     void Move()
    {
        h = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(Vector3.right * h * Time.deltaTime * 3);
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.2f) worldPos.x = 0.2f;
        if (worldPos.x > 0.8f) worldPos.x = 0.8f;
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }
    void Jump()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigidbody2D.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
            isGround = false;
            animator.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("isJump", false);
        }
        else if(collision.gameObject.tag == "obstacle")
        {
            animator.SetBool("isDead", true);
            GameManager.instance.isPlaying = false;
            isDead = true;
            GameManager.instance.GameOver();
        }
    }
}
