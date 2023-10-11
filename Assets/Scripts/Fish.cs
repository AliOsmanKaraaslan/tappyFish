using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
    int angle;
    int maxangle = 20;
    int minangle = -40;
    public Score score1;
    bool touchedground;
    public GameManager manager;
    public Sprite fishDied;
    public SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstaclespawner;
    [SerializeField] private AudioSource swim, hit, point;  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
 
    }
     
    // Update is called once per frame
    void Update()
    {
        fishSwim();
      
    }

    private void FixedUpdate()
    {
        fishRotation();
    }
    void fishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameover == false)
        {
            swim.Play();
            if(GameManager.gameStarted == false)
            {    
                rb.gravityScale = 4f;
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
                obstaclespawner.InstantiateObstacle();
                manager.gameHasStarted();
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    void fishRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxangle)
            {
                angle += 4;
            }
        }
        else if (rb.velocity.y < -2)
        {
            if (angle > minangle)
            {
                angle -= 2;
                   
            }

        }
        if (touchedground == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("obstacle"))
        {
            score1.Scored();
            point.Play();
        }
        else if(collision.CompareTag("column") && GameManager.gameover == false)
        {
            //game over
            fishDieEffect();
            manager.gameOver();
        }
    }

    void fishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(GameManager.gameover == false)
            {
                // game over
                fishDieEffect();    
                manager.gameOver();
                gameOver();
            }
            else
            {
                gameOver();
            }
        }
    }
      void gameOver()
    {
        touchedground = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
