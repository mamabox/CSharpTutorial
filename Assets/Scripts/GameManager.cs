using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int balloonsInScene;
    [SerializeField] private int balloonsPopped = 0;

 

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        balloonsInScene = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }

    public void BalloonPopped()
    {
        balloonsPopped++;
        if (balloonsPopped >= balloonsInScene)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("You WON!");
    }
}
