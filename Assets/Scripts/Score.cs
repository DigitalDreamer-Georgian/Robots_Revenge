using UnityEngine;
using TMPro;
//using Unity.Android.Types;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI ScoreText;
    private int score = 0;

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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    // Update is called once per frame
    void UpdateScoreText()
    {
        ScoreText.text = "Scrap: " + score;
    }
}
