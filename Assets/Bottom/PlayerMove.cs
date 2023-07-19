using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer sR;
    Animator ani;

    private float speed = 1.5f;
    private bool doubleJump = true;
    private float jumping = 2.5f;
    public float inicioX = 0f;
    public float inicioY = 0f;
    private bool appearingActive = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
        if (appearingActive)
        {
            Appering();
        }
        if (DamagePlayer.damageSignal == false && pauseManager.pause == false)
        {
            HorizontalController();
            JumpController();
        } 
        else if (DamagePlayer.damageSignal == true)
        {
            Appering();
        }
    }
    private void HorizontalController()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            ani.SetBool("Run", true);
            if (Input.GetAxis("Horizontal") < 0)
            {
                sR.flipX = true;
            }
            else
            {
                sR.flipX = false;
            }
        } 
        else
        {
            ani.SetBool("Run", false);
        }
    }
    private void JumpController()
    {
        if (DetectGround.checkGround == true)
        {
            ani.SetBool("Jump", false);
            ani.SetBool("DJump", false);
            doubleJump = true;
            if (Input.GetKeyDown("space"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumping);
            }
        }
        else if (DetectGround.checkGround == false)
        {
            ani.SetBool("Jump", true);
            if (doubleJump && Input.GetKeyDown("space"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                ani.SetBool("DJump", true);
                doubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumping);
            }
        }
    }
    private void Appering()
    {
        sR.enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(inicioX, inicioY, 0);
        DamagePlayer.damageTime += Time.deltaTime;
        if (DamagePlayer.damageTime > 0.5f)
        {
            sR.enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            appearingActive = false;
            DamagePlayer.damageSignal = false;
            //DamagePlayer.Lesslife();
        }
    }
}