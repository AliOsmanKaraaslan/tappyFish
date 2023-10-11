using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;
    Text scoretext;
    int highscore;
    int lowscore;
    public Text panelscore;
    public Text panelhighscore;
    public GameObject New;
    void Start()
    {
        score = 0;
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
        panelscore.text = score.ToString();
        highscore = PlayerPrefs.GetInt("highscore");
        panelhighscore.text = highscore.ToString();     
    }

    public void Scored()
    {
        score ++;
        scoretext.text = score.ToString(); 
        panelscore.text = score.ToString();
        if(score > highscore)
        {
            highscore = score;  
            panelhighscore.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
            New.SetActive(true);
        }
    }


    public int getScore()
    {
        return score;
    }
}


