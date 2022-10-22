using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] Transform ball;
    public float speed = 1.0f;
    [SerializeField] float respawnAfter;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.applyRootMotion = true;
    }

    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 ballMove = new Vector3(ball.position.x * speed, 0f, 0f) * Time.deltaTime;
        transform.Translate(ballMove);
    }

    public void respawn()
    {
        anim.applyRootMotion = false;
        anim.SetBool("isSpawning", true);
        //anim.Play("respawn", -1, 0f);
        StartCoroutine("enableEnemyAfter");
        
    }

    IEnumerator enableEnemyAfter()
    {
        yield return new WaitForSeconds(respawnAfter);
        //GetComponent<Renderer>().enabled = true;
        anim.SetBool("isSpawning", false);
        anim.applyRootMotion = true;
    }

    void moveDown(float speed)
    {
        Vector3 position = new Vector3(0f, 3.5f, 0f);
        transform.Translate(position);
    }

}
