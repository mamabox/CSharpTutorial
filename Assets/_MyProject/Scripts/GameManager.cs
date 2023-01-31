using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Action BalloonPopped;

    [SerializeField] public int balloonsInScene;
    [SerializeField] public int balloonsPopped = 0;
    [SerializeField] private TextMeshProUGUI score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        BalloonPopped += OnBalloonPopped;   //When event is triggered
        balloonsInScene = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }
    private void Start()
    {


    }

    // Gets called when game stops or event manager is destroyed or deleeted
    private void OnDestroy()
    {
        BalloonPopped -= OnBalloonPopped; //
    }

    public void OnBalloonPopped()
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
        StartCoroutine(UIManager.Instance.ShowWinPanel());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
