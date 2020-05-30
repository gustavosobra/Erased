using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemybullet;
    private float reloadTime = 2f;

    // Update is called once per frame
    void Update()
    {
        reloadTime -= Time.deltaTime;

        if (reloadTime < 0)
        {
            Instantiate(Enemybullet, transform.position, transform.rotation);
            reloadTime = 2f;
        }
    }
}
