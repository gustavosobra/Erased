using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if(PlayerMovement.instance.died)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
