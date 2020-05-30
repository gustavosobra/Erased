using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float circleRadius;

    public Text partsText;

    [SerializeField]
    public int partCount;

    public bool died;
    public bool facingRight;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    RaycastHit hit;

    private static PlayerMovement _instance;

    public static PlayerMovement instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        facingRight = true;
        died = false;
        partCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        partsText.text = "Parts: " + partCount;

        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLayer);

        if (collider != null)
            isGrounded = true;
        else
            isGrounded = false;

        float xMove = Input.GetAxisRaw("Horizontal");
        float move = xMove * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.D) && !facingRight)
        {
            Flip();
            facingRight = true;
        }
        if(Input.GetKeyDown(KeyCode.A) && facingRight)
        {
            Flip();
            facingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            died = true;

    }

}
