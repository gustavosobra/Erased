using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPart : MonoBehaviour
{
    [SerializeField]
    private GameObject parts;

    private void OnDestroy()
    {
            Instantiate(parts, transform.position, transform.rotation);
    }
}
