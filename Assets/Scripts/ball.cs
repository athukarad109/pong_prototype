using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 1.0f;
    private float currSpeed;
    
    [SerializeField]float x = -0.1f;
    [SerializeField]float y = -0.1f;

    [SerializeField] float respawnAfter;

    private enemy enemyScript;
    public GameObject Enemy;
    
    private bgScroll  bgscroll;
    public GameObject Bg;

    [SerializeField] GameObject gamemanager;
    private gameManager manager;

    [SerializeField] GameObject Camera;
    private cameraShake camerashake;

    private Animator anim;

    [SerializeField] ParticleSystem particle_system;
    [SerializeField] AudioSource sound;


    private void Start()
    {
        enemyScript = Enemy.GetComponent<enemy>();
        bgscroll = Bg.GetComponent<bgScroll>();
        manager = gamemanager.GetComponent<gameManager>();
        camerashake = Camera.GetComponent<cameraShake>();
        currSpeed = speed;
        anim = GetComponent<Animator>();
        anim.applyRootMotion = true;
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 move = new Vector3(x * currSpeed, y * currSpeed, 0f) * Time.deltaTime;
        transform.Translate(move);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        camerashake.startShake();
        playEffects(collision.transform);

        if (collision.gameObject.CompareTag("colliderX"))
        {
            x *= -1;
        }
        if(collision.gameObject.CompareTag("colliderY"))
        {
            y *= -1;
        }
        if (collision.gameObject.CompareTag("playerwin"))
        {
            manager.playerWin();
        }
        if (collision.gameObject.CompareTag("playerlose"))
        {
            manager.playerLose();
        }
    }

    public void respawn()
    {
        anim.applyRootMotion = false;
        anim.SetBool("isBallSpawn", true);
        //anim.Play("respawn", -1, 0f);
        StartCoroutine("enableAfter");

    }

    IEnumerator enableAfter()
    {
        yield return new WaitForSeconds(respawnAfter);
        //GetComponent<Renderer>().enabled = true;
        anim.SetBool("isBallSpawn", false);
        anim.applyRootMotion = true;
    }

    public void resetBall()
    {
        transform.position = new Vector2(0f, 0f);
        //stopBall();
    }

    public void stopBall()
    {
        currSpeed = 0f;
    }

    public void startBall()
    {
        currSpeed = speed;
    }

    void playEffects(Transform pos)
    {
        particle_system.Play();
        sound.Play();
    }


}
