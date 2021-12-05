using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    const int DEFAULT_POINTS = 1;
    private int SCORE_THRESHOLD = 1;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();

        if (score >= SCORE_THRESHOLD)
            AdvanceLevel();
            SCORE_THRESHOLD += 1;

    }


    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }
}
