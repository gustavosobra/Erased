using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Código maioritariamente da autoria de outra pessoa
    public Transform target;
    public float distance = -10f;
    public float height = 0f;
    public float damping = 5.0f;
    public float mapX = 100.0f;
    public float mapY = 100.0f;
    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;

    void Start()
    {
        minX = transform.position.x;
        minY = transform.position.y;
        maxX = mapX;
        maxY = mapY;
    }

    void FixedUpdate()
    {

        Vector3 wantedPosition = target.TransformPoint(0, height, distance);

        wantedPosition.x = (wantedPosition.x < minX) ? minX : wantedPosition.x;
        wantedPosition.x = (wantedPosition.x > maxX) ? maxX : wantedPosition.x;

        wantedPosition.y = (wantedPosition.y < minY) ? minY : wantedPosition.y;
        wantedPosition.y = (wantedPosition.y > maxY) ? maxY : wantedPosition.y;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, (Time.deltaTime * damping));
    }
}
