using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D EnemyRb;

    [SerializeField]
    private float moveSpeed;
    private float move;

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform edgeCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float circleRadius;

    [SerializeField]
    private bool edge;
    [SerializeField]
    private bool wall;
    private bool facingRight;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        edge = false;
        wall = false;
        facingRight = false;
        move = -moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D colliderEdge = Physics2D.OverlapCircle(edgeCheck.position, circleRadius,  groundLayer);
        Collider2D colliderWall = Physics2D.OverlapCircle(wallCheck.position, circleRadius, groundLayer);

        if (colliderEdge != null)
            edge = false;
        else
            edge = true;

        if (colliderWall != null)
            wall = true;
        else
            wall = false;

        if (edge || wall)
        {
            Flip();
            move *= -1f;
        }


        EnemyRb.velocity = new Vector2(move, EnemyRb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;

        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
        transform.Rotate(0, 180, 0);
    }

}
