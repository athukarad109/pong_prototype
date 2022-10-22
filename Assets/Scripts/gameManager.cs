using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private ball Ball;
    
    [SerializeField] GameObject enemy;
    private enemy Enemy;
    
    [SerializeField] GameObject bg;
    private bgScroll Bg;

    [SerializeField] GameObject pauseCanvas;

    [SerializeField] GameObject score_system;
    scoreSystem ScoreSystem;


    void Start()
    {
        Ball = ball.GetComponent<ball>();
        Enemy = enemy.GetComponent<enemy>();
        Bg = bg.GetComponent<bgScroll>();
        ScoreSystem = score_system.GetComponent<scoreSystem>();
    }

    public void playerWin()
    {
        StartCoroutine("enemyLose");
        ScoreSystem.addScore();
    }

    public void playerLose()
    {   
        Ball.resetBall();
    }

    public void pause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    IEnumerator enemyLose()
    {
        Ball.resetBall();
        Ball.stopBall();
        Bg.startScrolling();
        Enemy.respawn();
        Ball.respawn();
        yield return new WaitForSeconds(1f);
        Enemy.speed += 1.0f;
        Ball.startBall();
        
    }

}
