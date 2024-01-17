using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove1 : MonoBehaviour
{
    public float wSpeed = 7f;
    public float rSpeed = 12f;
    public float move;
    public int do_cao = 13;
    public bool allowJump;
    public bool allowDoubleJump;


    public bool isGround = true;

    public static CharMove1 charMove1;

    private Rigidbody2D rb;
    private Animator anim;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        charMove1 = this;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speedControll(wSpeed, rSpeed);
        CharMovement(move);

        CharFlip();

        CharJump();

        checkAni();
    }
    void CharMovement(float speed)
    {
        move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
    void speedControll(float walkSpeed, float runSpeed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move = runSpeed;
        }
        else
        {
            move = walkSpeed;
        }
    }
    void CharJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGround)
        {
            rb.AddForce(Vector2.up * do_cao, ForceMode2D.Impulse);
            allowDoubleJump = false;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (allowDoubleJump || isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, do_cao);
                allowDoubleJump = !allowDoubleJump;
            }
        }
    }
    void checkAni()
    {

        anim.SetFloat("Move", Mathf.Abs(move));
        if (!isGround)
        {
            anim.SetBool("isGround", false);
        }
        else
        {
            anim.SetBool("isGround", true);
        }
        //if(rb.velocity.x == wSpeed && allowJump || rb.velocity.x == -wSpeed && allowJump)
        //{
        //    anim.SetInteger("Status", 1);
        //} else if(rb.velocity.x == rSpeed && allowJump || rb.velocity.x == -rSpeed && allowJump)
        //{
        //    anim.SetInteger("Status", 2);
        //} else if(!allowJump || !allowJump && rb.velocity.x != 0)
        //{
        //    anim.SetInteger("Status", 3);
        //} else if(rb.velocity.x == 0 && rb.velocity.y == 0)
        //{
        //    anim.SetInteger("Status", 0);
        //}
    }
    void CharFlip()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
