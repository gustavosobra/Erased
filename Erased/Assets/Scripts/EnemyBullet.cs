using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float bulletTimer;
    [SerializeField]
    private Rigidbody2D bulletRb;
    void Start()
    {
        bulletRb.velocity = -transform.right * bulletSpeed * Time.deltaTime;
    }

    void Update()
    {
        bulletTimer -= Time.deltaTime;

        if (bulletTimer < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
