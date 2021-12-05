using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int level;
    private int DEFAULT_POINTS = 1;
    private int maxScore;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    private int maxLevel = 3;


    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        maxScore = level;

        DisplayScore();
        DisplayLevel();
    }


    // Update is called once per frame
    void Update()
    {
    
    }

    public void AddPoints(int points)
    {
        score += points;
        DisplayScore();

        if (score >= maxScore) {
            AdvanceLevel();
        }

    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        sceneTxt.text = "Level: " + level;
    }

    public void AdvanceLevel() 
    {   
        if(level < maxLevel)
            SceneManager.LoadScene(level + 1);   
        }

}
