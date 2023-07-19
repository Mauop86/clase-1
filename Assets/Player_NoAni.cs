using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NoAni : MonoBehaviour
{
    [SerializeField] LayerMask capaSuelo;
    Rigidbody2D rb2d;
    SpriteRenderer sR;
    RaycastHit2D raycastSuelo;
    private float timeAcum = 0;
    public float velocidad = 1f;
    public float salto = 3f;
    private bool doubleJump = true;
    private float scaleOnY = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        scaleOnY = gameObject.transform.localScale.y*0.16f+0.04f;
        Debug.Log(scaleOnY);
    }

    // Update is called once per frame
    void Update()
    {
        raycastSuelo = Physics2D.Raycast(transform.position, Vector2.down, scaleOnY, capaSuelo);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        SpriteApper();
        HorizontalController();
        JumpController();
    }
    private void JumpController()
    {
        
        if (Input.GetKeyDown("space"))
        {
            if (raycastSuelo == true)
            {
                gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
            }
            else if (doubleJump)
            {
                doubleJump = false;
                gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
                rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
            }
        }
        else if (raycastSuelo == true)
        {
            doubleJump = true;
        }
    }
    private void SpriteApper()
    {
        timeAcum += Time.deltaTime;
        if (timeAcum > 0.5f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void HorizontalController()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb2d.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {

            if (Input.GetAxis("Horizontal") < 0)
            {
                sR.flipX = true;
            }
            else
            {
                sR.flipX = false;
            }
        }
    }
}
