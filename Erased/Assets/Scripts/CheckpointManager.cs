using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager _instance;

    public int currentCheckpoint = 0;

    [SerializeField]
    public Transform[] checkPosition;

    public static CheckpointManager instance
    {
        get { return _instance; }
    }

    void Start()
    {
        _instance = this;
    }

}
