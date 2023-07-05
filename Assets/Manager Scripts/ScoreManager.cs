using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverScore;
    private int score;
    private int streak;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString());
        gameOverScore.SetText(score.ToString());
    }

    public void addScore(int type)
    {

        if (type == 1)
        {
            streak = 0;
            score++;
        }
        if (type == 2)
        {
            streak++;
            score += streak + 1;
        }
    }

}
