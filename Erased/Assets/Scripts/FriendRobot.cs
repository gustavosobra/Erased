using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendRobot : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;
    [SerializeField]
    private float playerDistance;
    [SerializeField]
    private float distance;

    private bool isPlaced;
    private bool isRepaired;

    private Vector2 posMove;

    private GameObject goalObject;
    [SerializeField]
    private Transform goal;

    private void Start()
    {
        posMove = Vector2.zero;
        isPlaced = false;
        isRepaired = false;
        goal = null;
    }
    void Update()
    {
        distance = Vector2.Distance(playerLocation.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && 1f >= distance && !isRepaired && PlayerMovement.instance.partCount >= 3)
        {
            isRepaired = true;
            PlayerMovement.instance.partCount -= 3;
        }

        if (Input.GetMouseButtonDown(1) && playerDistance >= distance && isRepaired)
        {
            posMove = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isPlaced = true;
        }

        if(Input.GetKeyDown(KeyCode.E) && playerDistance >= distance && isRepaired)
        {
            isPlaced = false;
            goalObject = GameObject.Find("Robot goal");
            goal = goalObject.transform;
        }

        if(isPlaced && isRepaired)
            transform.position = Vector3.MoveTowards(transform.position, posMove, 20f * Time.deltaTime);
        else if(!isPlaced && isRepaired)
            transform.position = Vector3.MoveTowards(transform.position, goal.position, 20f * Time.deltaTime);
    }
}
