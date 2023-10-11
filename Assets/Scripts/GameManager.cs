using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameover;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject getReady;
    public static int gameScore;
    public GameObject score;
    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
     
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        gameover = false;
        gameStarted = false;
    }
    public void gameHasStarted()
    {
        gameStarted = true;
        getReady.SetActive(false);
    }

    public void gameOver()
    {
        gameover = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false); 
        gameScore = score.GetComponent<Score>().getScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
