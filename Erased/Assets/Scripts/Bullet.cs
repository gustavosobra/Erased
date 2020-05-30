using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float bulletTimer;
    [SerializeField]
    private Rigidbody2D bulletRb;

    private void Start()
    {
        if (PlayerMovement.instance.facingRight)
            bulletRb.velocity = transform.right * bulletSpeed * Time.deltaTime;
        else if (!PlayerMovement.instance.facingRight)
            bulletRb.velocity = -transform.right * bulletSpeed * Time.deltaTime;
    }

    private void Update()
    {
        bulletTimer -= Time.deltaTime;

        if (bulletTimer < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
