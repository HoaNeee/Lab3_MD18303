using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{

    public float speedMove = 5;
    public float move;
    public int do_cao = 6;
    private Rigidbody2D rb;
    private Animator ani;

    public bool allowJump;
    public Transform _allowJump;
    bool isFaceRight = true;
    public bool allowDoubleJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {

        // di chuyển
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move*speedMove, rb.velocity.y);

        // Nhảy
        //if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
            //rb.velocity = new Vector2(rb.velocity.x, do_cao);
        //}

        //điều kiện nhảy 

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && allowJump)
         {
               rb.AddForce(Vector2.up * do_cao, ForceMode2D.Impulse);
            
            
         }


        //Xoay người khi di chuyển
        flip();

        //
        ani.SetFloat("Move", Mathf.Abs(move));

        //isJump = Physics2D.OverlapCircle(_isJump.position, 0.2f, san);

        // nhảy đôi
       if(allowJump && !(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))){
            allowDoubleJump = false;
        }
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(allowDoubleJump || allowJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, do_cao);
                allowDoubleJump = !allowDoubleJump;
            }
        }
    }

    void flip()
    {
        //if(isFaceRight == true && move == -1)
        //{
        //transform.localScale = new Vector3(-1, 1, 1);
        //isFaceRight = false;
        //}
        //else if (isFaceRight = false && move == 1)
        //{
        //   transform.localScale = new Vector3(1, 1, 1);
        //isFaceRight = true;
        //}

        if (isFaceRight && move < 0 || !isFaceRight && move > 0)
        {
            isFaceRight = !isFaceRight;
            Vector3 vector3 = transform.localScale;
            vector3.x = vector3.x * (-1);
            transform.localScale = vector3;
        }
    }

    // 2 hàm điều kiện nhảy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "San")
        {
            allowJump = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "San")
        {
            allowJump = false;
        }
    }

    
}
