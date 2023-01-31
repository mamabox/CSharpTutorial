using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button restartBtn;
    [SerializeField] private CanvasGroup winPanel;
    [SerializeField] private float fadeSpeed = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.BalloonPopped += UpdateUI;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
            GameManager.BalloonPopped -= UpdateUI;
    }

    private void UpdateUI()
    {
        score.text = string.Format("{0}/{1}", GameManager.Instance.balloonsPopped.ToString("D2"), GameManager.Instance.balloonsInScene.ToString("D2"));
    }

    public IEnumerator ShowWinPanel()
    {
        while (winPanel.alpha < 1)
        {
            winPanel.alpha += Time.deltaTime * fadeSpeed;
            yield return new WaitForEndOfFrame(); //When to give control back to Unity to run other methods
        }
    }
        
}
